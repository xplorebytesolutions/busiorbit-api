using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using xbytechat.api;
using xbytechat.api.WhatsAppSettings.DTOs;

namespace xbytechat_api.WhatsAppSettings.Services
{

    public class WhatsAppTemplateFetcherService : IWhatsAppTemplateFetcherService
    {
        private readonly AppDbContext _dbContext;
        private readonly HttpClient _httpClient;
        private readonly ILogger<WhatsAppTemplateFetcherService> _logger;

        public WhatsAppTemplateFetcherService(AppDbContext dbContext, HttpClient httpClient, ILogger<WhatsAppTemplateFetcherService> logger)
        {
            _dbContext = dbContext;
            _httpClient = httpClient;
            _logger = logger;
        }

        //public async Task<List<TemplateMetadataDto>> FetchTemplatesAsync(Guid businessId)
        //{
        //    var templates = new List<TemplateMetadataDto>();

        //    var setting = await _dbContext.WhatsAppSettings
        //        .FirstOrDefaultAsync(x => x.BusinessId == businessId && x.IsActive);

        //    if (setting == null)
        //    {
        //        _logger.LogWarning("WhatsApp Settings not found for BusinessId: {BusinessId}", businessId);
        //        return templates;
        //    }

        //    if (string.IsNullOrWhiteSpace(setting.ApiToken) || string.IsNullOrWhiteSpace(setting.PhoneNumberId))
        //    {
        //        _logger.LogWarning("Missing API Token or WABA ID for BusinessId: {BusinessId}", businessId);
        //        return templates;
        //    }

        //    try
        //    {
        //        var baseUrl = setting.ApiUrl?.TrimEnd('/') ?? "https://graph.facebook.com/v18.0";
        //        var url = $"{baseUrl}/{setting.WabaId}/message_templates";

        //        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", setting.ApiToken);

        //        var response = await _httpClient.GetAsync(url);
        //        var json = await response.Content.ReadAsStringAsync();
        //        _logger.LogInformation("🧪 Meta Template API Raw JSON for {BusinessId}:\n{Json}", setting.BusinessId, json);



        //        if (!response.IsSuccessStatusCode)
        //        {
        //            _logger.LogError("Failed to fetch templates from Meta: {Response}", json);
        //            return templates;
        //        }

        //        var parsed = JsonConvert.DeserializeObject<dynamic>(json);

        //        foreach (var tpl in parsed.data)
        //        {
        //            string name = tpl.name;
        //            string language = tpl.language ?? "en_US";
        //            string body = "";

        //            foreach (var component in tpl.components)
        //            {
        //                if (component.type == "BODY")
        //                {
        //                    body = component.text;
        //                    break;
        //                }
        //            }

        //            int placeholderCount = System.Text.RegularExpressions.Regex.Matches(body, "{{(.*?)}}").Count;

        //            templates.Add(new TemplateMetadataDto
        //            {
        //                Name = name,
        //                Language = language,
        //                Body = body,
        //                PlaceholderCount = placeholderCount
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Exception while fetching WhatsApp templates.");
        //    }

        //    return templates;
        //}
        //public async Task<List<TemplateMetadataDto>> FetchTemplatesAsync(Guid businessId)
        //{
        //    var templates = new List<TemplateMetadataDto>();

        //    var setting = await _dbContext.WhatsAppSettings
        //        .FirstOrDefaultAsync(x => x.BusinessId == businessId && x.IsActive);

        //    if (setting == null)
        //    {
        //        _logger.LogWarning("WhatsApp Settings not found for BusinessId: {BusinessId}", businessId);
        //        return templates;
        //    }

        //    if (string.IsNullOrWhiteSpace(setting.ApiToken) || string.IsNullOrWhiteSpace(setting.PhoneNumberId))
        //    {
        //        _logger.LogWarning("Missing API Token or WABA ID for BusinessId: {BusinessId}", businessId);
        //        return templates;
        //    }

        //    try
        //    {
        //        var baseUrl = setting.ApiUrl?.TrimEnd('/') ?? "https://graph.facebook.com/v18.0";
        //        var url = $"{baseUrl}/{setting.WabaId}/message_templates";

        //        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", setting.ApiToken);

        //        var response = await _httpClient.GetAsync(url);
        //        var json = await response.Content.ReadAsStringAsync();
        //        _logger.LogInformation("🧪 Meta Template API Raw JSON for {BusinessId}:\n{Json}", setting.BusinessId, json);

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            _logger.LogError("Failed to fetch templates from Meta: {Response}", json);
        //            return templates;
        //        }

        //        var parsed = JsonConvert.DeserializeObject<dynamic>(json);

        //        foreach (var tpl in parsed.data)
        //        {
        //            string name = tpl.name;
        //            string language = tpl.language ?? "en_US";
        //            string body = "";
        //            var buttons = new List<ButtonMetadataDto>();
        //            bool hasImageHeader = false;

        //            foreach (var component in tpl.components)
        //            {
        //                string type = component.type?.ToString()?.ToUpper();

        //                if (type == "BODY")
        //                {
        //                    body = component.text?.ToString() ?? "";
        //                }

        //                if (type == "HEADER")
        //                {
        //                    string format = component.format?.ToString()?.ToUpper();
        //                    if (format == "IMAGE") hasImageHeader = true;
        //                }

        //                if (type == "BUTTONS")
        //                {
        //                    foreach (var button in component.buttons)
        //                    {
        //                        try
        //                        {
        //                            string btnType = button.type?.ToString()?.ToUpper() ?? "";
        //                            string text = button.text?.ToString() ?? "";
        //                            int index = buttons.Count;

        //                            string subType = btnType switch
        //                            {
        //                                "URL" => "url",
        //                                "PHONE_NUMBER" => "voice_call",
        //                                "QUICK_REPLY" => "quick_reply",
        //                                "COPY_CODE" => "copy_code",
        //                                "CATALOG" => "catalog",
        //                                "FLOW" => "flow",
        //                                "REMINDER" => "reminder",
        //                                "ORDER_DETAILS" => "order_details",
        //                                _ => "unknown"
        //                            };

        //                            string? paramValue = null;
        //                            if (button.url != null)
        //                                paramValue = button.url.ToString();
        //                            else if (button.phone_number != null)
        //                                paramValue = button.phone_number.ToString();
        //                            else if (button.coupon_code != null)
        //                                paramValue = button.coupon_code.ToString();
        //                            else if (button.flow_id != null)
        //                                paramValue = button.flow_id.ToString();

        //                            bool hasExample = button.example != null;
        //                            bool isDynamic = hasExample && Regex.IsMatch(button.example.ToString(), @"\{\{[0-9]+\}\}");
        //                            bool requiresParam = new[] { "url", "flow", "copy_code", "catalog", "reminder" }.Contains(subType);
        //                            bool needsRuntimeValue = requiresParam && isDynamic;

        //                            if (subType == "unknown" || (paramValue == null && needsRuntimeValue))
        //                            {
        //                                _logger.LogWarning("⚠️ Skipping button '{Text}' due to unknown type or missing required param.", text);
        //                                continue;
        //                            }

        //                            buttons.Add(new ButtonMetadataDto
        //                            {
        //                                Text = text,
        //                                Type = btnType,
        //                                SubType = subType,
        //                                Index = index,
        //                                ParameterValue = paramValue ?? ""
        //                            });
        //                        }
        //                        catch (Exception exBtn)
        //                        {
        //                            _logger.LogWarning(exBtn, "⚠️ Failed to parse button for template {TemplateName}", name);
        //                        }
        //                    }
        //                }
        //            }

        //            int placeholderCount = Regex.Matches(body ?? "", "{{(.*?)}}").Count;

        //            templates.Add(new TemplateMetadataDto
        //            {
        //                Name = name,
        //                Language = language,
        //                Body = body,
        //                PlaceholderCount = placeholderCount,
        //                HasImageHeader = hasImageHeader,
        //                ButtonParams = buttons
        //            });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Exception while fetching WhatsApp templates.");
        //    }

        //    return templates;
        //}


        //public async Task<List<TemplateForUIResponseDto>> FetchAllTemplatesAsync()
        //{
        //    var allTemplates = new List<TemplateForUIResponseDto>();

        //    var settingsList = await _dbContext.WhatsAppSettings
        //        .Where(x => x.IsActive)
        //        .ToListAsync();

        //    foreach (var setting in settingsList)
        //    {
        //        if (string.IsNullOrWhiteSpace(setting.ApiToken) || string.IsNullOrWhiteSpace(setting.PhoneNumberId))
        //        {
        //            _logger.LogWarning("⏭️ Skipping BusinessId {BusinessId} due to missing token or phone ID", setting.BusinessId);
        //            continue;
        //        }

        //        try
        //        {
        //            var baseUrl = setting.ApiUrl?.TrimEnd('/') ?? "https://graph.facebook.com/v22.0";
        //            var url = $"{baseUrl}/{setting.WabaId}/message_templates";

        //            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", setting.ApiToken);

        //            var response = await _httpClient.GetAsync(url);
        //            var json = await response.Content.ReadAsStringAsync();

        //            _logger.LogInformation("📦 Meta Template API Raw JSON for {BusinessId}:\n{Json}", setting.BusinessId, json);

        //            if (!response.IsSuccessStatusCode)
        //            {
        //                _logger.LogError("❌ Failed to fetch templates for BusinessId {BusinessId}: {Response}", setting.BusinessId, json);
        //                continue;
        //            }

        //            var parsed = JsonConvert.DeserializeObject<dynamic>(json);


        //            foreach (var tpl in parsed.data)
        //            {
        //                string name = tpl.name;
        //                string language = tpl.language ?? "en_US";
        //                string body = "";
        //                bool hasImageHeader = false;
        //                var buttons = new List<ButtonMetadataDto>();

        //                foreach (var component in tpl.components)
        //                {
        //                    string type = component.type?.ToString()?.ToUpper();

        //                    if (type == "BODY")
        //                    {
        //                        try
        //                        {
        //                            body = component.text?.ToString() ?? "";
        //                        }
        //                        catch
        //                        {
        //                            _logger.LogWarning("⚠️ Could not read BODY component text for template: {TemplateName}", name);
        //                            body = "";
        //                        }
        //                    }

        //                    if (type == "HEADER")
        //                    {
        //                        string format = component.format?.ToString()?.ToUpper();
        //                        if (format == "IMAGE")
        //                        {
        //                            hasImageHeader = true;
        //                        }
        //                    }

        //                    if (type == "BUTTONS")
        //                    {
        //                        foreach (var button in component.buttons)
        //                        {
        //                            try
        //                            {
        //                                string btnType = button.type?.ToString()?.ToUpper() ?? "";
        //                                string text = button.text?.ToString() ?? "";
        //                                int index = buttons.Count;

        //                                string subType = btnType switch
        //                                {
        //                                    "URL" => "url",
        //                                    "PHONE_NUMBER" => "voice_call",
        //                                    "QUICK_REPLY" => "quick_reply",
        //                                    "COPY_CODE" => "copy_code",
        //                                    "CATALOG" => "catalog",
        //                                    "FLOW" => "flow",
        //                                    "REMINDER" => "reminder",
        //                                    "ORDER_DETAILS" => "order_details",
        //                                    _ => "unknown"
        //                                };

        //                                string? paramValue = null;
        //                                if (button.url != null)
        //                                    paramValue = button.url.ToString();
        //                                else if (button.phone_number != null)
        //                                    paramValue = button.phone_number.ToString();
        //                                else if (button.coupon_code != null)
        //                                    paramValue = button.coupon_code.ToString();
        //                                else if (button.flow_id != null)
        //                                    paramValue = button.flow_id.ToString();

        //                                // 🧠 Meta injects static values — no need to enforce paramValue if STATIC
        //                                bool hasExample = button.example != null;
        //                                bool isDynamic = hasExample && Regex.IsMatch(button.example.ToString(), @"\{\{[0-9]+\}\}");

        //                                bool requiresParam = new[] { "url", "flow", "copy_code", "catalog", "reminder" }.Contains(subType);
        //                                bool needsRuntimeValue = requiresParam && isDynamic;

        //                                // ❌ Skip if invalid OR dynamic + missing runtime param
        //                                if (subType == "unknown" || (paramValue == null && needsRuntimeValue))
        //                                {
        //                                    _logger.LogWarning("⚠️ Skipping button '{Text}' due to unknown type or missing required param.", text);
        //                                    continue;
        //                                }

        //                                buttons.Add(new ButtonMetadataDto
        //                                {
        //                                    Text = text,
        //                                    Type = btnType,
        //                                    SubType = subType,
        //                                    Index = index,
        //                                    ParameterValue = paramValue ?? "" // ✅ Always safe for static
        //                                });
        //                            }
        //                            catch (Exception exBtn)
        //                            {
        //                                _logger.LogWarning(exBtn, "⚠️ Failed to parse button for template {TemplateName}", name);
        //                            }
        //                        }

        //                    }
        //                }

        //                int placeholderCount = Regex.Matches(body ?? "", "{{(.*?)}}").Count;

        //                allTemplates.Add(new TemplateForUIResponseDto
        //                {
        //                    Name = name,
        //                    Language = language,
        //                    Body = body,
        //                    ParametersCount = placeholderCount,
        //                    HasImageHeader = hasImageHeader,
        //                    ButtonParams = buttons
        //                });
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            _logger.LogError(ex, "❌ Exception while fetching templates for BusinessId {BusinessId}", setting.BusinessId);
        //        }
        //    }

        //    return allTemplates;
        //}

        public async Task<List<TemplateMetadataDto>> FetchTemplatesAsync(Guid businessId)
        {
            var templates = new List<TemplateMetadataDto>();

            var setting = await _dbContext.WhatsAppSettings
                .FirstOrDefaultAsync(x => x.BusinessId == businessId && x.IsActive);

            if (setting == null)
            {
                _logger.LogWarning("WhatsApp Settings not found for BusinessId: {BusinessId}", businessId);
                return templates;
            }

            var provider = (setting.Provider ?? "").Trim().ToLowerInvariant();
            var baseUrl = setting.ApiUrl?.TrimEnd('/') ?? "";

            try
            {
                if (provider == "meta_cloud")
                {
                    if (string.IsNullOrWhiteSpace(setting.ApiToken) || string.IsNullOrWhiteSpace(setting.WabaId))
                    {
                        _logger.LogWarning("Missing API Token or WABA ID for BusinessId: {BusinessId}", businessId);
                        return templates;
                    }

                    var nextUrl = $"{(string.IsNullOrWhiteSpace(baseUrl) ? "https://graph.facebook.com/v22.0" : baseUrl)}/{setting.WabaId}/message_templates?limit=100";
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", setting.ApiToken);

                    while (!string.IsNullOrWhiteSpace(nextUrl))
                    {
                        var response = await _httpClient.GetAsync(nextUrl);
                        var json = await response.Content.ReadAsStringAsync();
                        _logger.LogInformation("📦 Meta Template API Raw JSON for {BusinessId}:\n{Json}", setting.BusinessId, json);

                        if (!response.IsSuccessStatusCode)
                        {
                            _logger.LogError("❌ Failed to fetch templates from Meta: {Response}", json);
                            break;
                        }

                        dynamic parsed = JsonConvert.DeserializeObject(json);
                        templates.AddRange(ParseTemplatesFromMetaLikePayload(parsed));
                        nextUrl = parsed?.paging?.next?.ToString();
                    }

                    return templates;
                }
                else if (provider == "pinnacle")
                {
                    if (string.IsNullOrWhiteSpace(setting.ApiKey))
                    {
                        _logger.LogWarning("Pinnacle API key missing for BusinessId: {BusinessId}", businessId);
                        return templates;
                    }

                    // Pinnacle typically accepts either WABA ID or PhoneNumberId. Prefer WABA.
                    var pathId = !string.IsNullOrWhiteSpace(setting.WabaId)
                        ? setting.WabaId!.Trim()
                        : setting.PhoneNumberId?.Trim();

                    if (string.IsNullOrWhiteSpace(pathId))
                    {
                        _logger.LogWarning("Pinnacle path id missing (WabaId/PhoneNumberId) for BusinessId: {BusinessId}", businessId);
                        return templates;
                    }

                    var nextUrl = $"{(string.IsNullOrWhiteSpace(baseUrl) ? "https://partnersv1.pinbot.ai/v3" : baseUrl)}/{pathId}/message_templates?limit=100";

                    // IMPORTANT: Pinnacle needs apikey header
                    _httpClient.DefaultRequestHeaders.Remove("apikey");
                    _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("apikey", setting.ApiKey);

                    while (!string.IsNullOrWhiteSpace(nextUrl))
                    {
                        var response = await _httpClient.GetAsync(nextUrl);
                        var json = await response.Content.ReadAsStringAsync();
                        _logger.LogInformation("📦 Pinnacle Template API Raw JSON for {BusinessId}:\n{Json}", setting.BusinessId, json);

                        if (!response.IsSuccessStatusCode)
                        {
                            _logger.LogError("❌ Failed to fetch templates from Pinnacle: {Response}", json);
                            break;
                        }

                        // Try to support both "data": [...] and "templates": [...] styles
                        dynamic parsed = JsonConvert.DeserializeObject(json);
                        templates.AddRange(ParseTemplatesFromMetaLikePayload(parsed)); // many BSPs mirror Meta's shape
                        nextUrl = parsed?.paging?.next?.ToString(); // if their API paginates similarly
                                                                    // If no paging in Pinnacle, set nextUrl = null to exit loop
                        if (nextUrl == null) break;
                    }

                    return templates;
                }
                else
                {
                    _logger.LogInformation("Provider {Provider} does not support listing via API in this build.", provider);
                    return templates;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception while fetching WhatsApp templates for provider {Provider}.", provider);
                return templates;
            }
        }

        private static IEnumerable<TemplateMetadataDto> ParseTemplatesFromMetaLikePayload(dynamic parsed)
        {
            var list = new List<TemplateMetadataDto>();
            if (parsed == null) return list;

            // Prefer parsed.data; fall back to parsed.templates
            var collection = parsed.data ?? parsed.templates;
            if (collection == null) return list;

            foreach (var tpl in collection)
            {
                string name = tpl.name?.ToString() ?? "";
                string language = tpl.language?.ToString() ?? "en_US";
                string body = "";
                bool hasImageHeader = false;
                var buttons = new List<ButtonMetadataDto>();

                // components may be null for some BSPs
                var components = tpl.components;
                if (components != null)
                {
                    foreach (var component in components)
                    {
                        string type = component.type?.ToString()?.ToUpperInvariant();

                        if (type == "BODY")
                            body = component.text?.ToString() ?? "";

                        if (type == "HEADER" && (component.format?.ToString()?.ToUpperInvariant() == "IMAGE"))
                            hasImageHeader = true;

                        if (type == "BUTTONS" && component.buttons != null)
                        {
                            foreach (var button in component.buttons)
                            {
                                try
                                {
                                    string btnType = button.type?.ToString()?.ToUpperInvariant() ?? "";
                                    string text = button.text?.ToString() ?? "";
                                    int index = buttons.Count;

                                    string subType = btnType switch
                                    {
                                        "URL" => "url",
                                        "PHONE_NUMBER" => "voice_call",
                                        "QUICK_REPLY" => "quick_reply",
                                        "COPY_CODE" => "copy_code",
                                        "CATALOG" => "catalog",
                                        "FLOW" => "flow",
                                        "REMINDER" => "reminder",
                                        "ORDER_DETAILS" => "order_details",
                                        _ => "unknown"
                                    };

                                    string? paramValue =
                                        button.url != null ? button.url.ToString() :
                                        button.phone_number != null ? button.phone_number.ToString() :
                                        button.coupon_code != null ? button.coupon_code.ToString() :
                                        button.flow_id != null ? button.flow_id.ToString() :
                                        null;

                                    // If BSP marks dynamic examples like Meta, respect them; otherwise be lenient
                                    buttons.Add(new ButtonMetadataDto
                                    {
                                        Text = text,
                                        Type = btnType,
                                        SubType = subType,
                                        Index = index,
                                        ParameterValue = paramValue ?? ""
                                    });
                                }
                                catch { /* ignore per-button parsing issues */ }
                            }
                        }
                    }
                }

                int placeholderCount = Regex.Matches(body ?? "", "{{(.*?)}}").Count;

                list.Add(new TemplateMetadataDto
                {
                    Name = name,
                    Language = language,
                    Body = body,
                    PlaceholderCount = placeholderCount,
                    HasImageHeader = hasImageHeader,
                    ButtonParams = buttons
                });
            }

            return list;
        }

        public async Task<List<TemplateForUIResponseDto>> FetchAllTemplatesAsync()
        {
            var allTemplates = new List<TemplateForUIResponseDto>();

            var settingsList = await _dbContext.WhatsAppSettings
                .Where(x => x.IsActive)
                .ToListAsync();

            foreach (var setting in settingsList)
            {
                if (string.IsNullOrWhiteSpace(setting.ApiToken) || string.IsNullOrWhiteSpace(setting.PhoneNumberId))
                {
                    _logger.LogWarning("⏭️ Skipping BusinessId {BusinessId} due to missing token or phone ID", setting.BusinessId);
                    continue;
                }

                try
                {
                    var baseUrl = setting.ApiUrl?.TrimEnd('/') ?? "https://graph.facebook.com/v22.0";
                    // start with a large page size; we'll follow paging.next if present
                    string nextUrl = $"{baseUrl}/{setting.WabaId}/message_templates?limit=100";

                    _httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", setting.ApiToken);

                    while (!string.IsNullOrWhiteSpace(nextUrl))
                    {
                        var response = await _httpClient.GetAsync(nextUrl);
                        var json = await response.Content.ReadAsStringAsync();

                        _logger.LogInformation("📦 Meta Template API Raw JSON for {BusinessId}:\n{Json}", setting.BusinessId, json);

                        if (!response.IsSuccessStatusCode)
                        {
                            _logger.LogError("❌ Failed to fetch templates for BusinessId {BusinessId}: {Response}", setting.BusinessId, json);
                            break;
                        }

                        dynamic parsed = JsonConvert.DeserializeObject<dynamic>(json);

                        foreach (var tpl in parsed.data)
                        {
                            // ⛔️ Filter: only show APPROVED (or ACTIVE) templates in the dropdown
                            string status = (tpl.status?.ToString() ?? "").ToUpperInvariant();
                            if (status != "APPROVED" && status != "ACTIVE")
                            {
                                _logger.LogInformation("🔎 Skipping template {Name} with status {Status}", (string)tpl.name, status);
                                continue;
                            }

                            string name = tpl.name;
                            string language = tpl.language ?? "en_US";
                            string body = "";
                            bool hasImageHeader = false;
                            var buttons = new List<ButtonMetadataDto>();

                            foreach (var component in tpl.components)
                            {
                                string type = component.type?.ToString()?.ToUpperInvariant();

                                if (type == "BODY")
                                {
                                    try
                                    {
                                        body = component.text?.ToString() ?? "";
                                    }
                                    catch
                                    {
                                        _logger.LogWarning("⚠️ Could not read BODY component text for template: {TemplateName}", name);
                                        body = "";
                                    }
                                }

                                if (type == "HEADER")
                                {
                                    string format = component.format?.ToString()?.ToUpperInvariant();
                                    if (format == "IMAGE") hasImageHeader = true;
                                }

                                if (type == "BUTTONS")
                                {
                                    foreach (var button in component.buttons)
                                    {
                                        try
                                        {
                                            string btnType = button.type?.ToString()?.ToUpperInvariant() ?? "";
                                            string text = button.text?.ToString() ?? "";
                                            int index = buttons.Count;

                                            string subType = btnType switch
                                            {
                                                "URL" => "url",
                                                "PHONE_NUMBER" => "voice_call",
                                                "QUICK_REPLY" => "quick_reply",
                                                "COPY_CODE" => "copy_code",
                                                "CATALOG" => "catalog",
                                                "FLOW" => "flow",
                                                "REMINDER" => "reminder",
                                                "ORDER_DETAILS" => "order_details",
                                                _ => "unknown"
                                            };

                                            string? paramValue = null;
                                            if (button.url != null) paramValue = button.url.ToString();
                                            else if (button.phone_number != null) paramValue = button.phone_number.ToString();
                                            else if (button.coupon_code != null) paramValue = button.coupon_code.ToString();
                                            else if (button.flow_id != null) paramValue = button.flow_id.ToString();

                                            bool hasExample = button.example != null;
                                            bool isDynamic = hasExample && Regex.IsMatch(button.example.ToString(), @"\{\{[0-9]+\}\}");
                                            bool requiresParam = new[] { "url", "flow", "copy_code", "catalog", "reminder" }.Contains(subType);
                                            bool needsRuntimeValue = requiresParam && isDynamic;

                                            if (subType == "unknown" || (paramValue == null && needsRuntimeValue))
                                            {
                                                _logger.LogWarning("⚠️ Skipping button '{Text}' due to unknown type or missing required param.", text);
                                                continue;
                                            }

                                            buttons.Add(new ButtonMetadataDto
                                            {
                                                Text = text,
                                                Type = btnType,
                                                SubType = subType,
                                                Index = index,
                                                ParameterValue = paramValue ?? ""
                                            });
                                        }
                                        catch (Exception exBtn)
                                        {
                                            _logger.LogWarning(exBtn, "⚠️ Failed to parse button for template {TemplateName}", name);
                                        }
                                    }
                                }
                            }

                            int placeholderCount = Regex.Matches(body ?? "", "{{(.*?)}}").Count;

                            allTemplates.Add(new TemplateForUIResponseDto
                            {
                                Name = name,
                                Language = language,
                                Body = body,
                                ParametersCount = placeholderCount,
                                HasImageHeader = hasImageHeader,
                                ButtonParams = buttons
                            });
                        }

                        // follow pagination if present
                        nextUrl = parsed?.paging?.next?.ToString();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "❌ Exception while fetching templates for BusinessId {BusinessId}", setting.BusinessId);
                }
            }

            return allTemplates;
        }


        //public async Task<TemplateMetadataDto?> GetTemplateByNameAsync(Guid businessId, string templateName, bool includeButtons)
        //{
        //    var setting = await _dbContext.WhatsAppSettings
        //        .FirstOrDefaultAsync(x => x.IsActive && x.BusinessId == businessId);

        //    if (setting == null ||
        //        string.IsNullOrWhiteSpace(setting.ApiToken) ||
        //        string.IsNullOrWhiteSpace(setting.PhoneNumberId))
        //    {
        //        _logger.LogWarning("❌ Missing WhatsApp config for business: {BusinessId}", businessId);
        //        return null;
        //    }

        //    try
        //    {
        //        var baseUrl = setting.ApiUrl?.TrimEnd('/') ?? "https://graph.facebook.com/v18.0";
        //        var url = $"{baseUrl}/{setting.WabaId}/message_templates";

        //        _httpClient.DefaultRequestHeaders.Authorization =
        //            new AuthenticationHeaderValue("Bearer", setting.ApiToken);

        //        var response = await _httpClient.GetAsync(url);
        //        var json = await response.Content.ReadAsStringAsync();

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            _logger.LogError("❌ Failed to fetch templates for BusinessId {BusinessId}: {Json}", businessId, json);
        //            return null;
        //        }

        //        var parsed = JsonConvert.DeserializeObject<dynamic>(json);

        //        foreach (var tpl in parsed.data)
        //        {
        //            string name = tpl.name;
        //            if (!name.Equals(templateName, StringComparison.OrdinalIgnoreCase))
        //                continue;

        //            string language = tpl.language ?? "en_US";
        //            string body = "";
        //            var buttons = new List<ButtonMetadataDto>();
        //            bool hasImageHeader = false;

        //            foreach (var component in tpl.components)
        //            {
        //                string type = component.type?.ToString()?.ToUpper();

        //                if (type == "BODY")
        //                {
        //                    try
        //                    {
        //                        body = component.text?.ToString() ?? "";
        //                    }
        //                    catch
        //                    {
        //                        body = "";
        //                    }
        //                }

        //                if (type == "HEADER")
        //                {
        //                    string format = component.format?.ToString()?.ToUpper();
        //                    if (format == "IMAGE") hasImageHeader = true;
        //                }

        //                if (includeButtons && type == "BUTTONS")
        //                {
        //                    foreach (var button in component.buttons)
        //                    {
        //                        try
        //                        {
        //                            string btnType = button.type?.ToString()?.ToUpper() ?? "";
        //                            string text = button.text?.ToString() ?? "";
        //                            int index = buttons.Count;

        //                            string subType = btnType switch
        //                            {
        //                                "URL" => "url",
        //                                "PHONE_NUMBER" => "voice_call",
        //                                "QUICK_REPLY" => "quick_reply",
        //                                "COPY_CODE" => "copy_code",
        //                                "CATALOG" => "catalog",
        //                                "FLOW" => "flow",
        //                                "REMINDER" => "reminder",
        //                                "ORDER_DETAILS" => "order_details",
        //                                _ => "unknown"
        //                            };

        //                            // ✅ Extract known dynamic values
        //                            string? paramValue = null;
        //                            if (button.url != null)
        //                                paramValue = button.url.ToString();
        //                            else if (button.phone_number != null)
        //                                paramValue = button.phone_number.ToString();
        //                            else if (button.coupon_code != null)
        //                                paramValue = button.coupon_code.ToString();
        //                            else if (button.flow_id != null)
        //                                paramValue = button.flow_id.ToString();

        //                            // ✅ Skip truly invalid (unknown + missing value for dynamic)
        //                            if (subType == "unknown" || (paramValue == null && new[] { "url", "flow", "copy_code" }.Contains(subType)))

        //                            {
        //                                _logger.LogWarning("⚠️ Skipping button '{Text}' due to unknown type or missing required param.", text);
        //                                continue;
        //                            }

        //                            buttons.Add(new ButtonMetadataDto
        //                            {
        //                                Text = text,
        //                                Type = btnType,
        //                                SubType = subType,
        //                                Index = index,
        //                                ParameterValue = paramValue ?? "" // ✅ Default to empty for static buttons
        //                            });
        //                        }
        //                        catch (Exception exBtn)
        //                        {
        //                            _logger.LogWarning(exBtn, "⚠️ Failed to parse button in template {TemplateName}", name);
        //                        }
        //                    }
        //                }
        //            }

        //            int paramCount = Regex.Matches(body ?? "", "{{(.*?)}}").Count;

        //            return new TemplateMetadataDto
        //            {
        //                Name = name,
        //                Language = language,
        //                Body = body,
        //                PlaceholderCount = paramCount,
        //                HasImageHeader = hasImageHeader,
        //                ButtonParams = includeButtons ? buttons : new List<ButtonMetadataDto>()
        //            };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "❌ Exception in GetTemplateByNameAsync");
        //    }

        //    return null;
        //}
        //public async Task<TemplateMetadataDto?> GetTemplateByNameAsync(Guid businessId, string templateName, bool includeButtons)
        //{
        //    var setting = await _dbContext.WhatsAppSettings
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(x => x.IsActive && x.BusinessId == businessId);

        //    if (setting == null)
        //    {
        //        _logger.LogWarning($"❌ WhatsApp settings not found for BusinessId {businessId}.");
        //        return null;
        //    }

        //    var provider = (setting.Provider ?? "meta_cloud").Trim().ToLowerInvariant();

        //    try
        //    {
        //        if (provider == "meta_cloud")
        //        {
        //            if (string.IsNullOrWhiteSpace(setting.ApiToken))
        //            {
        //                _logger.LogWarning($"❌ ApiToken missing for Meta provider (BusinessId {businessId}).");
        //                return null;
        //            }
        //            if (string.IsNullOrWhiteSpace(setting.WabaId))
        //            {
        //                _logger.LogWarning($"❌ WabaId missing for Meta provider (BusinessId {businessId}).");
        //                return null;
        //            }

        //            var baseUrl = string.IsNullOrWhiteSpace(setting.ApiUrl)
        //                ? "https://graph.facebook.com/v18.0"
        //                : setting.ApiUrl.TrimEnd('/');

        //            var url = $"{baseUrl}/{setting.WabaId}/message_templates?limit=200";

        //            using var req = new HttpRequestMessage(HttpMethod.Get, url);
        //            req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", setting.ApiToken);

        //            var res = await _httpClient.SendAsync(req);
        //            var body = await res.Content.ReadAsStringAsync();

        //            if (!res.IsSuccessStatusCode)
        //            {
        //                _logger.LogError($"❌ Template fetch failed (Meta) for BusinessId {businessId} ({(int)res.StatusCode}): {body}");
        //                return null;
        //            }

        //            return ExtractTemplateFromListJson(body, templateName, includeButtons);
        //        }
        //        else if (provider == "pinnacle")
        //        {
        //            if (string.IsNullOrWhiteSpace(setting.ApiKey))
        //            {
        //                _logger.LogWarning($"❌ ApiKey missing for Pinnacle provider (BusinessId {businessId}).");
        //                return null;
        //            }

        //            // Pinnacle usually uses WABA ID; some setups accept PhoneNumberId. Prefer WABA ID, then phone ID.
        //            var id = !string.IsNullOrWhiteSpace(setting.WabaId) ? setting.WabaId : setting.PhoneNumberId;
        //            if (string.IsNullOrWhiteSpace(id))
        //            {
        //                _logger.LogWarning($"❌ WabaId/PhoneNumberId missing for Pinnacle provider (BusinessId {businessId}).");
        //                return null;
        //            }

        //            var baseUrl = string.IsNullOrWhiteSpace(setting.ApiUrl)
        //                ? "https://partnersv1.pinnacle.ai/v3"
        //                : setting.ApiUrl.TrimEnd('/');

        //            var url = $"{baseUrl}/{id}/message_templates?limit=200";

        //            using var req = new HttpRequestMessage(HttpMethod.Get, url);
        //            req.Headers.TryAddWithoutValidation("apikey", setting.ApiKey);

        //            var res = await _httpClient.SendAsync(req);
        //            var body = await res.Content.ReadAsStringAsync();

        //            if (!res.IsSuccessStatusCode)
        //            {
        //                _logger.LogError($"❌ Template fetch failed (Pinnacle) for BusinessId {businessId} ({(int)res.StatusCode}): {body}");
        //                return null;
        //            }

        //            return ExtractTemplateFromListJson(body, templateName, includeButtons);
        //        }
        //        else
        //        {
        //            _logger.LogWarning($"⚠️ Unknown provider '{setting.Provider}' for BusinessId {businessId}.");
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"❌ Exception while fetching templates for BusinessId {businessId}.");
        //        return null;
        //    }
        //}
        public async Task<TemplateMetadataDto?> GetTemplateByNameAsync(Guid businessId, string templateName, bool includeButtons)
        {
            var setting = await _dbContext.WhatsAppSettings
                .FirstOrDefaultAsync(x => x.IsActive && x.BusinessId == businessId);

            if (setting == null)
            {
                _logger.LogWarning("❌ WhatsApp settings not found for business: {BusinessId}", businessId);
                return null;
            }

            var provider = (setting.Provider ?? "meta_cloud").Trim().ToLowerInvariant();
            var wabaId = setting.WabaId?.Trim();
            if (string.IsNullOrWhiteSpace(wabaId))
            {
                _logger.LogWarning("❌ Missing WABA ID for business: {BusinessId}", businessId);
                return null;
            }

            // Build URL + request with per-request headers
            string url;
            using var req = new HttpRequestMessage(HttpMethod.Get, "");

            if (provider == "pinnacle")
            {
                // Pinnacle: require ApiKey; use WabaId for template listing
                if (string.IsNullOrWhiteSpace(setting.ApiKey))
                {
                    _logger.LogWarning("❌ ApiKey missing for Pinnacle provider (BusinessId {BusinessId})", businessId);
                    return null;
                }

                var baseUrl = string.IsNullOrWhiteSpace(setting.ApiUrl)
                    ? "https://partnersv1.pinbot.ai/v3"
                    : setting.ApiUrl.TrimEnd('/');

                url = $"{baseUrl}/{wabaId}/message_templates?limit=200";
                // add header variants
                req.Headers.TryAddWithoutValidation("apikey", setting.ApiKey);
                req.Headers.TryAddWithoutValidation("x-api-key", setting.ApiKey);
                // safety: also append as query (some edges require it)
                url = url.Contains("apikey=") ? url : $"{url}&apikey={Uri.EscapeDataString(setting.ApiKey)}";
            }
            else // meta_cloud
            {
                // Meta Cloud: require ApiToken; use WabaId for template listing
                if (string.IsNullOrWhiteSpace(setting.ApiToken))
                {
                    _logger.LogWarning("❌ ApiToken missing for Meta provider (BusinessId {BusinessId})", businessId);
                    return null;
                }

                var baseUrl = string.IsNullOrWhiteSpace(setting.ApiUrl)
                    ? "https://graph.facebook.com/v18.0"
                    : setting.ApiUrl.TrimEnd('/');

                url = $"{baseUrl}/{wabaId}/message_templates?limit=200";
                req.Headers.Authorization = new AuthenticationHeaderValue("Bearer", setting.ApiToken);
            }

            req.RequestUri = new Uri(url);
            var response = await _httpClient.SendAsync(req);
            var json = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("❌ Failed to fetch templates (provider={Provider}) for BusinessId {BusinessId}: HTTP {Status} Body: {Body}",
                    provider, businessId, (int)response.StatusCode, json);
                return null;
            }

            try
            {
                dynamic parsed = JsonConvert.DeserializeObject<dynamic>(json);
                var data = parsed?.data;
                if (data == null)
                {
                    _logger.LogWarning("⚠️ No 'data' array in template response (provider={Provider})", provider);
                    return null;
                }

                foreach (var tpl in data)
                {
                    string name = tpl.name;
                    if (!name.Equals(templateName, StringComparison.OrdinalIgnoreCase))
                        continue;

                    string language = tpl.language != null ? (string)tpl.language : "en_US";
                    string body = "";
                    var buttons = new List<ButtonMetadataDto>();
                    bool hasImageHeader = false;

                    // components loop
                    foreach (var component in tpl.components)
                    {
                        string type = component.type?.ToString()?.ToUpperInvariant();

                        if (type == "BODY")
                        {
                            try { body = component.text?.ToString() ?? ""; }
                            catch { body = ""; }
                        }

                        if (type == "HEADER")
                        {
                            string format = component.format?.ToString()?.ToUpperInvariant();
                            if (format == "IMAGE") hasImageHeader = true;
                        }

                        if (includeButtons && type == "BUTTONS")
                        {
                            foreach (var button in component.buttons)
                            {
                                try
                                {
                                    string btnType = button.type?.ToString()?.ToUpperInvariant() ?? "";
                                    string text = button.text?.ToString() ?? "";
                                    int index = buttons.Count;

                                    // normalize sub-type for our app
                                    string subType = btnType switch
                                    {
                                        "URL" => "url",
                                        "PHONE_NUMBER" => "voice_call",
                                        "QUICK_REPLY" => "quick_reply",
                                        "COPY_CODE" => "copy_code",
                                        "CATALOG" => "catalog",
                                        "FLOW" => "flow",
                                        "REMINDER" => "reminder",
                                        "ORDER_DETAILS" => "order_details",
                                        _ => "unknown"
                                    };

                                    // Known dynamic param extraction
                                    string? paramValue = null;
                                    if (button.url != null)
                                        paramValue = button.url.ToString();
                                    else if (button.phone_number != null)
                                        paramValue = button.phone_number.ToString();
                                    else if (button.coupon_code != null)
                                        paramValue = button.coupon_code.ToString();
                                    else if (button.flow_id != null)
                                        paramValue = button.flow_id.ToString();

                                    // Skip truly invalid
                                    if (subType == "unknown" ||
                                        (paramValue == null && new[] { "url", "flow", "copy_code" }.Contains(subType)))
                                    {
                                        _logger.LogWarning("⚠️ Skipping button '{Text}' due to unknown type or missing required param.", text);
                                        continue;
                                    }

                                    buttons.Add(new ButtonMetadataDto
                                    {
                                        Text = text,
                                        Type = btnType,
                                        SubType = subType,
                                        Index = index,
                                        ParameterValue = paramValue ?? "" // empty for static buttons
                                    });
                                }
                                catch (Exception exBtn)
                                {
                                    _logger.LogWarning(exBtn, "⚠️ Failed to parse button in template {TemplateName}", name);
                                }
                            }
                        }
                    }

                    // Count {{n}} placeholders in body
                    int paramCount = Regex.Matches(body ?? "", "{{\\s*\\d+\\s*}}").Count;

                    return new TemplateMetadataDto
                    {
                        Name = name,
                        Language = language,
                        Body = body,
                        PlaceholderCount = paramCount,
                        HasImageHeader = hasImageHeader,
                        ButtonParams = includeButtons ? buttons : new List<ButtonMetadataDto>()
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Exception while parsing template response");
            }

            return null;
        }
        private static TemplateMetadataDto? ExtractTemplateFromListJson(string json, string templateName, bool includeButtons)
        {
            var root = JObject.Parse(json);
            var data = root["data"] as JArray;
            if (data == null) return null;

            foreach (var tplToken in data.OfType<JObject>())
            {
                var name = tplToken.Value<string>("name") ?? "";
                if (!name.Equals(templateName, StringComparison.OrdinalIgnoreCase))
                    continue;

                var language = tplToken.Value<string>("language") ?? "en_US";
                var components = tplToken["components"] as JArray;

                string body = "";
                bool hasImageHeader = false;
                var buttons = new List<ButtonMetadataDto>();

                if (components != null)
                {
                    foreach (var comp in components.OfType<JObject>())
                    {
                        var type = (comp.Value<string>("type") ?? "").ToUpperInvariant();

                        if (type == "BODY")
                        {
                            body = comp.Value<string>("text") ?? body;
                        }
                        else if (type == "HEADER")
                        {
                            var fmt = (comp.Value<string>("format") ?? "").ToUpperInvariant();
                            if (fmt == "IMAGE") hasImageHeader = true;
                        }
                        else if (includeButtons && type == "BUTTONS")
                        {
                            var btns = comp["buttons"] as JArray;
                            if (btns == null) continue;

                            var idx = 0;
                            foreach (var b in btns.OfType<JObject>())
                            {
                                var btnTypeRaw = (b.Value<string>("type") ?? "").ToUpperInvariant();
                                var text = b.Value<string>("text") ?? "";

                                var subType = btnTypeRaw switch
                                {
                                    "URL" => "url",
                                    "PHONE_NUMBER" => "voice_call",
                                    "QUICK_REPLY" => "quick_reply",
                                    "COPY_CODE" => "copy_code",
                                    "CATALOG" => "catalog",
                                    "FLOW" => "flow",
                                    "REMINDER" => "reminder",
                                    "ORDER_DETAILS" => "order_details",
                                    _ => "unknown"
                                };

                                string? paramValue =
                                    b.Value<string>("url") ??
                                    b.Value<string>("phone_number") ??
                                    b.Value<string>("coupon_code") ??
                                    b.Value<string>("flow_id");

                                // Skip unknown or missing required dynamic values
                                if (subType == "unknown") continue;
                                if ((subType is "url" or "flow" or "copy_code") && string.IsNullOrWhiteSpace(paramValue))
                                    continue;

                                buttons.Add(new ButtonMetadataDto
                                {
                                    Text = text,
                                    Type = btnTypeRaw,
                                    SubType = subType,
                                    Index = idx++,
                                    ParameterValue = paramValue ?? ""
                                });
                            }
                        }
                    }
                }

                var paramCount = Regex.Matches(body ?? "", "{{(.*?)}}").Count;

                return new TemplateMetadataDto
                {
                    Name = name,
                    Language = language,
                    Body = body ?? "",
                    PlaceholderCount = paramCount,
                    HasImageHeader = hasImageHeader,
                    ButtonParams = includeButtons ? buttons : new List<ButtonMetadataDto>()
                };
            }

            return null;
        }

    }
}

