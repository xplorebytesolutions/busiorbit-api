using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using xbytechat.api.Features.CTAFlowBuilder.Models;
using xbytechat.api.Features.MessagesEngine.Services;
using xbytechat_api.WhatsAppSettings.Services; 

namespace xbytechat.api.Features.CTAFlowBuilder.Services
{
    public class FlowRuntimeService : IFlowRuntimeService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMessageEngineService _messageEngineService;
        private readonly IWhatsAppTemplateFetcherService _templateFetcherService;

        
        public FlowRuntimeService(
            AppDbContext dbContext,
            IMessageEngineService messageEngineService,
            IWhatsAppTemplateFetcherService templateFetcherService)
        {
            _dbContext = dbContext;
            _messageEngineService = messageEngineService;
            _templateFetcherService = templateFetcherService;
        }

        public async Task<NextStepResult> ExecuteNextAsync(NextStepContext context)
        {
            try
            {
                // 1) URL-only buttons → no WA send, just record and return redirect
                if (context.ClickedButton != null &&
                    context.ClickedButton.ButtonType?.Equals("URL", StringComparison.OrdinalIgnoreCase) == true)
                {
                    _dbContext.FlowExecutionLogs.Add(new FlowExecutionLog
                    {
                        Id = Guid.NewGuid(),
                        BusinessId = context.BusinessId,
                        FlowId = context.FlowId,
                        StepId = context.SourceStepId,
                        StepName = "URL_REDIRECT",
                        MessageLogId = context.MessageLogId,
                        ButtonIndex = context.ButtonIndex,
                        ContactPhone = context.ContactPhone,
                        Success = true,
                        ExecutedAt = DateTime.UtcNow,
                        RequestId = context.RequestId
                    });
                    await _dbContext.SaveChangesAsync();

                    return new NextStepResult
                    {
                        Success = true,
                        RedirectUrl = context.ClickedButton.ButtonValue
                    };
                }

                // 2) Load next step in the same flow
                var targetStep = await _dbContext.CTAFlowSteps
                    .Include(s => s.ButtonLinks)
                    .FirstOrDefaultAsync(s => s.Id == context.TargetStepId &&
                                              s.CTAFlowConfigId == context.FlowId);

                if (targetStep == null)
                    return new NextStepResult { Success = false, Error = "Target step not found." };

                if (string.IsNullOrWhiteSpace(targetStep.TemplateToSend))
                    return new NextStepResult { Success = false, Error = "Target step has no template assigned." };

                var templateName = targetStep.TemplateToSend.Trim();

                // 3) ✅ Preflight the template to pick the correct language and catch 132001 early
                var meta = await _templateFetcherService.GetTemplateByNameAsync(
                    context.BusinessId, templateName, includeButtons: true);

                if (meta == null)
                {
                    // log a failed flow execution (no WA call attempted)
                    _dbContext.FlowExecutionLogs.Add(new FlowExecutionLog
                    {
                        Id = Guid.NewGuid(),
                        BusinessId = context.BusinessId,
                        FlowId = context.FlowId,
                        StepId = targetStep.Id,
                        StepName = templateName,
                        MessageLogId = null,
                        ButtonIndex = context.ButtonIndex,
                        ContactPhone = context.ContactPhone,
                        Success = false,
                        ErrorMessage = $"Template '{templateName}' not found for this WABA.",
                        RawResponse = null,
                        ExecutedAt = DateTime.UtcNow,
                        RequestId = context.RequestId
                    });
                    await _dbContext.SaveChangesAsync();

                    return new NextStepResult
                    {
                        Success = false,
                        Error = $"Template '{templateName}' not found or not approved."
                    };
                }

                // prefer the template’s actual language over hard-coding "en_US"
                var languageCode = string.IsNullOrWhiteSpace(meta.Language) ? "en_US" : meta.Language;

                // (Optional) build body/button components here if your step needs params.
                // Quick-reply buttons require NO components; dynamic URL buttons would.
                var components = new List<object>();

                var payload = new
                {
                    messaging_product = "whatsapp",
                    to = context.ContactPhone,
                    type = "template",
                    template = new
                    {
                        name = templateName,
                        language = new { code = languageCode },
                        components
                    }
                };

                var sendResult = await _messageEngineService.SendPayloadAsync(context.BusinessId, payload);

                // 4) Snapshot buttons for robust click mapping later
                string? buttonBundleJson = null;
                if (targetStep.ButtonLinks?.Count > 0)
                {
                    var bundle = targetStep.ButtonLinks
                        .OrderBy(b => b.ButtonIndex)
                        .Select(b => new
                        {
                            i = b.ButtonIndex,
                            t = b.ButtonText ?? "",
                            ty = b.ButtonType ?? "QUICK_REPLY",
                            v = b.ButtonValue ?? "",
                            ns = b.NextStepId
                        })
                        .ToList();

                    buttonBundleJson = JsonSerializer.Serialize(bundle);
                }

                // 5) ✅ Write MessageLog with NON-NULL MessageContent and sensible timestamps
                var messageLog = new MessageLog
                {
                    Id = Guid.NewGuid(),
                    BusinessId = context.BusinessId,
                    RecipientNumber = context.ContactPhone,
                    CTAFlowConfigId = context.FlowId,
                    CTAFlowStepId = targetStep.Id,
                    FlowVersion = context.Version,
                    Source = "flow",
                    RefMessageId = context.MessageLogId, // correlate to the parent WA msg (if any)
                    CreatedAt = DateTime.UtcNow,
                    Status = sendResult.Success ? "Sent" : "Failed",
                    MessageId = sendResult.MessageId,
                    ErrorMessage = sendResult.ErrorMessage,
                    RawResponse = sendResult.RawResponse,
                    ButtonBundleJson = buttonBundleJson,

                    // 🔴 This was missing before → caused NOT NULL violation
                    MessageContent = templateName,

                    // good hygiene: stamp SentAt on success
                    SentAt = sendResult.Success ? DateTime.UtcNow : (DateTime?)null,
                };

                _dbContext.MessageLogs.Add(messageLog);

                // 6) Flow execution audit row
                _dbContext.FlowExecutionLogs.Add(new FlowExecutionLog
                {
                    Id = Guid.NewGuid(),
                    BusinessId = context.BusinessId,
                    FlowId = context.FlowId,
                    StepId = targetStep.Id,
                    StepName = templateName,
                    MessageLogId = messageLog.Id,
                    ButtonIndex = context.ButtonIndex,
                    ContactPhone = context.ContactPhone,
                    Success = sendResult.Success,
                    ErrorMessage = sendResult.ErrorMessage,
                    RawResponse = sendResult.RawResponse,
                    ExecutedAt = DateTime.UtcNow,
                    RequestId = context.RequestId,

                    // Optional (only if your entity has these columns):
                    // TemplateName = templateName,
                    // TemplateType = targetStep.TemplateType,
                });

                await _dbContext.SaveChangesAsync();

                return new NextStepResult
                {
                    Success = sendResult.Success,
                    Error = sendResult.ErrorMessage,
                    RedirectUrl = null
                };
            }
            catch (Exception ex)
            {
                return new NextStepResult { Success = false, Error = ex.Message };
            }
        }
    }
}


