using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.IO.Pipelines;
using System.Text.Json;
using System.Threading.Tasks;
using xbytechat.api;
using xbytechat.api.DTOs.Messages;
using xbytechat.api.Features.CampaignTracking.Models;
using xbytechat.api.Features.CTAFlowBuilder.Models;
using xbytechat.api.Features.CTAFlowBuilder.Services;
using xbytechat.api.Features.MessagesEngine.DTOs;
using xbytechat.api.Features.MessagesEngine.Services;
using xbytechat.api.Features.Tracking.DTOs;
using xbytechat.api.Features.Tracking.Models;
using xbytechat.api.Features.Tracking.Services;
using xbytechat.api.Features.Webhooks.Services.Resolvers;
using xbytechat.api.Helpers;
using xbytechat.api.Shared.TrackingUtils;

namespace xbytechat.api.Features.Webhooks.Services.Processors
{
    public class ClickWebhookProcessor : IClickWebhookProcessor
    {
        private readonly ILogger<ClickWebhookProcessor> _logger;
        private readonly IMessageIdResolver _messageIdResolver;
        private readonly ITrackingService _trackingService;
        private readonly AppDbContext _context;
        private readonly IMessageEngineService _messageEngine;
        private readonly ICTAFlowService _flowService;
        private readonly IFlowRuntimeService _flowRuntime;
        public ClickWebhookProcessor(
            ILogger<ClickWebhookProcessor> logger,
            IMessageIdResolver messageIdResolver,
            ITrackingService trackingService,
            AppDbContext context,
            IMessageEngineService messageEngine,
            ICTAFlowService flowService,
                        IFlowRuntimeService flowRuntime
            )
        {
            _logger = logger;
            _messageIdResolver = messageIdResolver;
            _trackingService = trackingService;
            _context = context;
            _messageEngine = messageEngine;
            _flowService = flowService;
            _flowRuntime = flowRuntime;

        }

       
        public async Task ProcessClickAsync(JsonElement value)
        {
            _logger.LogWarning("📥 [ENTERED CLICK PROCESSOR]");

            try
            {
                if (!value.TryGetProperty("messages", out var messages) || messages.GetArrayLength() == 0)
                    return;

                static string Norm(string? s)
                {
                    if (string.IsNullOrWhiteSpace(s)) return string.Empty;
                    return string.Join(' ', s.Split(new[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                                 .Trim()
                                 .ToLowerInvariant();
                }

                static string NormalizePhone(string? raw)
                {
                    if (string.IsNullOrWhiteSpace(raw)) return "";
                    var p = raw.Trim();
                    return p.StartsWith("+") ? p.Substring(1) : p; // store digits-only (or pick one convention)
                }

                foreach (var msg in messages.EnumerateArray())
                {
                    if (!msg.TryGetProperty("type", out var typeProp))
                        continue;

                    var type = typeProp.GetString();

                    string? clickMessageId = msg.TryGetProperty("id", out var idProp) ? idProp.GetString() : null;
                    string? originalMessageId = msg.TryGetProperty("context", out var ctx) && ctx.TryGetProperty("id", out var ctxId)
                        ? ctxId.GetString()
                        : null;
                    string from = msg.TryGetProperty("from", out var fromProp) ? (fromProp.GetString() ?? "") : "";

                    // ——— button label extraction
                    string? buttonText = null;
                    if (type == "button")
                    {
                        buttonText = msg.TryGetProperty("button", out var btn) &&
                                     btn.TryGetProperty("text", out var textProp)
                                       ? textProp.GetString()?.Trim()
                                       : null;
                    }
                    else if (type == "interactive" && msg.TryGetProperty("interactive", out var interactive))
                    {
                        if (interactive.TryGetProperty("type", out var intrType) &&
                            string.Equals(intrType.GetString(), "button_reply", StringComparison.OrdinalIgnoreCase) &&
                            interactive.TryGetProperty("button_reply", out var br) &&
                            br.TryGetProperty("title", out var titleProp))
                        {
                            buttonText = titleProp.GetString()?.Trim();
                        }
                        else if (interactive.TryGetProperty("list_reply", out var lr) &&
                                 lr.TryGetProperty("title", out var listTitleProp))
                        {
                            buttonText = listTitleProp.GetString()?.Trim();
                        }
                    }

                    if (string.IsNullOrWhiteSpace(buttonText) || string.IsNullOrWhiteSpace(originalMessageId))
                    {
                        _logger.LogDebug("ℹ️ Not a recognized click or missing context.id. type={Type}", type);
                        continue;
                    }

                    _logger.LogInformation("🖱️ Button Click → From: {From}, ClickId: {ClickId}, OrigMsgId: {OrigId}, Text: {Text}",
                        from, clickMessageId, originalMessageId, buttonText);

                    // —— Try 1: originating MessageLog (for flow-sent messages)
                    var origin = await _context.MessageLogs
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m =>
                            m.MessageId == originalMessageId &&
                            m.CTAFlowConfigId != null &&
                            m.CTAFlowStepId != null);

                    Guid businessId;
                    Guid flowId;
                    Guid stepId;
                    string? bundleJson = null;
                    int? flowVersion = null;

                    Guid? campaignSendLogId = null; // 👈 we will always try to set this
                    Guid? runId = null;             // 👈 NEW: will copy from the parent CSL

                    if (origin != null)
                    {
                        businessId = origin.BusinessId;
                        flowId = origin.CTAFlowConfigId!.Value;
                        stepId = origin.CTAFlowStepId!.Value;
                        bundleJson = origin.ButtonBundleJson;
                        flowVersion = origin.FlowVersion;

                        // map back to CSL via MessageLogId or WAMID and fetch RunId
                        var cslInfo = await _context.CampaignSendLogs
                            .AsNoTracking()
                            .Where(csl => (csl.MessageLogId == origin.Id) || (csl.MessageId == originalMessageId))
                            .OrderByDescending(csl => csl.CreatedAt)
                            .Select(csl => new { csl.Id, csl.RunId })
                            .FirstOrDefaultAsync();

                        campaignSendLogId = cslInfo?.Id;
                        runId = cslInfo?.RunId;
                    }
                    else
                    {
                        // —— Try 2: first campaign message (CampaignSendLogs)
                        var sendLog = await _context.CampaignSendLogs
                            .Include(sl => sl.Campaign)
                            .AsNoTracking()
                            .FirstOrDefaultAsync(sl => sl.MessageId == originalMessageId);

                        if (sendLog == null)
                        {
                            _logger.LogWarning("❌ No MessageLog or CampaignSendLog for original WAMID {Orig}", originalMessageId);
                            continue;
                        }

                        businessId = sendLog.BusinessId != Guid.Empty
                            ? sendLog.BusinessId
                            : (sendLog.Campaign?.BusinessId ?? Guid.Empty);

                        if (businessId == Guid.Empty)
                        {
                            _logger.LogWarning("❌ Could not resolve BusinessId for WAMID {Orig}", originalMessageId);
                            continue;
                        }

                        campaignSendLogId = sendLog.Id; // 👈 link the click to this send
                        runId = sendLog.RunId;          // 👈 NEW: capture the run id

                        if (sendLog.CTAFlowConfigId.HasValue && sendLog.CTAFlowStepId.HasValue)
                        {
                            flowId = sendLog.CTAFlowConfigId.Value;
                            stepId = sendLog.CTAFlowStepId.Value;
                        }
                        else if (sendLog.Campaign?.CTAFlowConfigId != null)
                        {
                            flowId = sendLog.Campaign.CTAFlowConfigId.Value;

                            var entry = await _context.CTAFlowSteps
                                .Where(s => s.CTAFlowConfigId == flowId)
                                .OrderBy(s => s.StepOrder)
                                .Select(s => s.Id)
                                .FirstOrDefaultAsync();

                            if (entry == Guid.Empty)
                            {
                                _logger.LogWarning("❌ No entry step found for flow {Flow}", flowId);
                                continue;
                            }

                            stepId = entry;
                        }
                        else
                        {
                            _logger.LogWarning("❌ No flow context on CampaignSendLog for WAMID {Orig}", originalMessageId);
                            continue;
                        }

                        bundleJson = sendLog.ButtonBundleJson;
                    }

                    // —— Map clicked text -> button index via the shown bundle
                    short? buttonIndex = null;
                    FlowBtnBundleNode? hit = null;

                    if (!string.IsNullOrWhiteSpace(bundleJson))
                    {
                        try
                        {
                            var nodes = System.Text.Json.JsonSerializer
                                .Deserialize<List<FlowBtnBundleNode>>(bundleJson) ?? new();

                            hit = nodes.FirstOrDefault(n =>
                                string.Equals(n.t ?? "", buttonText, StringComparison.OrdinalIgnoreCase))
                                ?? nodes.FirstOrDefault(n => Norm(n.t) == Norm(buttonText));

                            if (hit != null)
                                buttonIndex = (short)hit.i;
                        }
                        catch (Exception ex)
                        {
                            _logger.LogWarning(ex, "⚠️ Failed to parse ButtonBundleJson");
                        }
                    }

                    // —— Fallback: find link by TEXT for this step
                    FlowButtonLink? linkMatchedByText = null;
                    if (buttonIndex == null)
                    {
                        var stepLinks = await _context.FlowButtonLinks
                            .Where(l => l.CTAFlowStepId == stepId)
                            .OrderBy(l => l.ButtonIndex)
                            .ToListAsync();

                        if (stepLinks.Count > 0)
                        {
                            linkMatchedByText = stepLinks.FirstOrDefault(l =>
                                string.Equals(l.ButtonText ?? "", buttonText, StringComparison.OrdinalIgnoreCase))
                                ?? stepLinks.FirstOrDefault(l => Norm(l.ButtonText) == Norm(buttonText));

                            if (linkMatchedByText == null && stepLinks.Count == 1)
                            {
                                linkMatchedByText = stepLinks[0];
                                _logger.LogInformation("🟨 Falling back to single available link for step {Step}", stepId);
                            }

                            if (linkMatchedByText != null)
                            {
                                buttonIndex = (short?)linkMatchedByText.ButtonIndex;
                                _logger.LogInformation("✅ Mapped click by TEXT to index {Idx} (flow={Flow}, step={Step})",
                                    buttonIndex, flowId, stepId);
                            }
                        }
                    }

                    if (buttonIndex == null)
                    {
                        _logger.LogInformation("🟡 Button text not found in bundle or flow links. Ref={Ref}, Text='{Text}'",
                            originalMessageId, buttonText);
                        continue;
                    }

                    // —— Prefer exact link by index; otherwise use the text-matched link
                    var link = await _flowService.GetLinkAsync(flowId, stepId, buttonIndex.Value)
                               ?? linkMatchedByText;

                    if (link == null)
                    {
                        _logger.LogInformation("🟡 No button link for (flow={Flow}, step={Step}, idx={Idx})",
                            flowId, stepId, buttonIndex);
                        continue;
                    }

                    // —— Resolve index + step name (for logging)
                    short resolvedIndex = buttonIndex ?? Convert.ToInt16(link.ButtonIndex);
                    var stepName = await _context.CTAFlowSteps
                        .Where(s => s.Id == stepId)
                        .Select(s => s.TemplateToSend)
                        .FirstOrDefaultAsync() ?? string.Empty;

                    // ————————————————
                    // 📝 WRITE CLICK LOG (always, even if terminal)
                    // ————————————————
                    try
                    {
                        var clickExec = new FlowExecutionLog
                        {
                            Id = Guid.NewGuid(),
                            BusinessId = businessId,
                            FlowId = flowId,
                            StepId = stepId,
                            StepName = stepName,
                            CampaignSendLogId = campaignSendLogId,  // links this click to the shown message
                            MessageLogId = origin?.Id,
                            ContactPhone = NormalizePhone(from),
                            ButtonIndex = resolvedIndex,
                            TriggeredByButton = buttonText,
                            TemplateName = null,                    // will be set by runtime on send (if you also log sends)
                            TemplateType = "quick_reply",
                            Success = true,
                            ExecutedAt = DateTime.UtcNow,
                            RequestId = Guid.NewGuid(),
                            RunId = runId                           // 👈 NEW: copy parent CSL's RunId
                        };

                        _context.FlowExecutionLogs.Add(clickExec);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception exSave)
                    {
                        _logger.LogWarning(exSave, "⚠️ Failed to persist FlowExecutionLog (click). Continuing…");
                    }

                    // —— If terminal/URL button: we already logged the click; optionally log CampaignClickLog here
                    if (link.NextStepId == null)
                    {
                        _logger.LogInformation("🔚 Terminal/URL button: no NextStepId. flow={Flow}, step={Step}, idx={Idx}, text='{Text}'",
                            flowId, stepId, resolvedIndex, link.ButtonText);

                        // OPTIONAL: if you log URL clicks here (instead of your redirect endpoint), include RunId too:
                        // _context.CampaignClickLogs.Add(new CampaignClickLog {
                        //     Id = Guid.NewGuid(),
                        //     CampaignSendLogId = campaignSendLogId!.Value,
                        //     ButtonIndex = resolvedIndex,
                        //     ButtonTitle = buttonText,
                        //     Destination = "<resolved-url-if-known>",
                        //     ClickedAt = DateTime.UtcNow,
                        //     RunId = runId                               // 👈 include
                        // });
                        // await _context.SaveChangesAsync();

                        continue;
                    }

                    if (_flowRuntime == null)
                    {
                        _logger.LogError("❌ _flowRuntime is null. Cannot execute next step. flow={Flow}, step={Step}, idx={Idx}", flowId, stepId, resolvedIndex);
                        continue;
                    }

                    // —— Execute next
                    var ctxObj = new NextStepContext
                    {
                        BusinessId = businessId,
                        FlowId = flowId,
                        Version = flowVersion ?? 1,
                        SourceStepId = stepId,
                        TargetStepId = link.NextStepId,   // not null here
                        ButtonIndex = resolvedIndex,
                        MessageLogId = origin?.Id ?? Guid.Empty,
                        ContactPhone = from,
                        RequestId = Guid.NewGuid(),
                        ClickedButton = link
                        // If your NextStepContext supports it, also pass RunId = runId
                    };

                    try
                    {
                        var result = await _flowRuntime.ExecuteNextAsync(ctxObj);

                        // ⚠️ Make sure your flow send path copies the parent CSL.RunId
                        if (result.Success && !string.IsNullOrWhiteSpace(result.RedirectUrl))
                        {
                            _logger.LogInformation("🔗 URL button redirect (logical): {Url}", result.RedirectUrl);
                        }
                    }
                    catch (Exception exRun)
                    {
                        _logger.LogError(exRun,
                            "❌ ExecuteNextAsync failed. ctx: flow={Flow} step={Step} next={Next} idx={Idx} from={From} orig={Orig} text='{Text}'",
                            ctxObj.FlowId, ctxObj.SourceStepId, ctxObj.TargetStepId, ctxObj.ButtonIndex, from, originalMessageId, buttonText);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Failed to process CTA button click.");
            }
        }

        private sealed class FlowBtnBundleNode
        {
            public int i { get; init; }
            public string? t { get; init; }   // button text/title
            public string? ty { get; init; }  // button type (URL/QUICK_REPLY/FLOW)
            public string? v { get; init; }   // value/payload (e.g., URL)
            public Guid? ns { get; init; }    // next step id
        }


    

    }
}
