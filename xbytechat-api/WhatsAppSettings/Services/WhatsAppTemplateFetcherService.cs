using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

            if (string.IsNullOrWhiteSpace(setting.ApiToken) || string.IsNullOrWhiteSpace(setting.PhoneNumberId))
            {
                _logger.LogWarning("Missing API Token or WABA ID for BusinessId: {BusinessId}", businessId);
                return templates;
            }

            try
            {
                var baseUrl = setting.ApiUrl?.TrimEnd('/') ?? "https://graph.facebook.com/v18.0";
                var url = $"{baseUrl}/{setting.WabaId}/message_templates";

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", setting.ApiToken);

                var response = await _httpClient.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("🧪 Meta Template API Raw JSON for {BusinessId}:\n{Json}", setting.BusinessId, json);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("Failed to fetch templates from Meta: {Response}", json);
                    return templates;
                }

                var parsed = JsonConvert.DeserializeObject<dynamic>(json);

                foreach (var tpl in parsed.data)
                {
                    string name = tpl.name;
                    string language = tpl.language ?? "en_US";
                    string body = "";
                    var buttons = new List<ButtonMetadataDto>();
                    bool hasImageHeader = false;

                    foreach (var component in tpl.components)
                    {
                        string type = component.type?.ToString()?.ToUpper();

                        if (type == "BODY")
                        {
                            body = component.text?.ToString() ?? "";
                        }

                        if (type == "HEADER")
                        {
                            string format = component.format?.ToString()?.ToUpper();
                            if (format == "IMAGE") hasImageHeader = true;
                        }

                        if (type == "BUTTONS")
                        {
                            foreach (var button in component.buttons)
                            {
                                try
                                {
                                    string btnType = button.type?.ToString()?.ToUpper() ?? "";
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
                                    if (button.url != null)
                                        paramValue = button.url.ToString();
                                    else if (button.phone_number != null)
                                        paramValue = button.phone_number.ToString();
                                    else if (button.coupon_code != null)
                                        paramValue = button.coupon_code.ToString();
                                    else if (button.flow_id != null)
                                        paramValue = button.flow_id.ToString();

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

                    templates.Add(new TemplateMetadataDto
                    {
                        Name = name,
                        Language = language,
                        Body = body,
                        PlaceholderCount = placeholderCount,
                        HasImageHeader = hasImageHeader,
                        ButtonParams = buttons
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception while fetching WhatsApp templates.");
            }

            return templates;
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
                    var baseUrl = setting.ApiUrl?.TrimEnd('/') ?? "https://graph.facebook.com/v18.0";
                    var url = $"{baseUrl}/{setting.WabaId}/message_templates";

                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", setting.ApiToken);

                    var response = await _httpClient.GetAsync(url);
                    var json = await response.Content.ReadAsStringAsync();

                    _logger.LogInformation("📦 Meta Template API Raw JSON for {BusinessId}:\n{Json}", setting.BusinessId, json);

                    if (!response.IsSuccessStatusCode)
                    {
                        _logger.LogError("❌ Failed to fetch templates for BusinessId {BusinessId}: {Response}", setting.BusinessId, json);
                        continue;
                    }

                    var parsed = JsonConvert.DeserializeObject<dynamic>(json);

                    foreach (var tpl in parsed.data)
                    {
                        string name = tpl.name;
                        string language = tpl.language ?? "en_US";
                        string body = "";
                        bool hasImageHeader = false;
                        var buttons = new List<ButtonMetadataDto>();

                        foreach (var component in tpl.components)
                        {
                            string type = component.type?.ToString()?.ToUpper();

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
                                string format = component.format?.ToString()?.ToUpper();
                                if (format == "IMAGE")
                                {
                                    hasImageHeader = true;
                                }
                            }

                            if (type == "BUTTONS")
                            {
                                foreach (var button in component.buttons)
                                {
                                    try
                                    {
                                        string btnType = button.type?.ToString()?.ToUpper() ?? "";
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
                                        if (button.url != null)
                                            paramValue = button.url.ToString();
                                        else if (button.phone_number != null)
                                            paramValue = button.phone_number.ToString();
                                        else if (button.coupon_code != null)
                                            paramValue = button.coupon_code.ToString();
                                        else if (button.flow_id != null)
                                            paramValue = button.flow_id.ToString();

                                        // 🧠 Meta injects static values — no need to enforce paramValue if STATIC
                                        bool hasExample = button.example != null;
                                        bool isDynamic = hasExample && Regex.IsMatch(button.example.ToString(), @"\{\{[0-9]+\}\}");

                                        bool requiresParam = new[] { "url", "flow", "copy_code", "catalog", "reminder" }.Contains(subType);
                                        bool needsRuntimeValue = requiresParam && isDynamic;

                                        // ❌ Skip if invalid OR dynamic + missing runtime param
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
                                            ParameterValue = paramValue ?? "" // ✅ Always safe for static
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
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "❌ Exception while fetching templates for BusinessId {BusinessId}", setting.BusinessId);
                }
            }

            return allTemplates;
        }


        public async Task<TemplateMetadataDto?> GetTemplateByNameAsync(Guid businessId, string templateName, bool includeButtons)
        {
            var setting = await _dbContext.WhatsAppSettings
                .FirstOrDefaultAsync(x => x.IsActive && x.BusinessId == businessId);

            if (setting == null ||
                string.IsNullOrWhiteSpace(setting.ApiToken) ||
                string.IsNullOrWhiteSpace(setting.PhoneNumberId))
            {
                _logger.LogWarning("❌ Missing WhatsApp config for business: {BusinessId}", businessId);
                return null;
            }

            try
            {
                var baseUrl = setting.ApiUrl?.TrimEnd('/') ?? "https://graph.facebook.com/v18.0";
                var url = $"{baseUrl}/{setting.WabaId}/message_templates";

                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", setting.ApiToken);

                var response = await _httpClient.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("❌ Failed to fetch templates for BusinessId {BusinessId}: {Json}", businessId, json);
                    return null;
                }

                var parsed = JsonConvert.DeserializeObject<dynamic>(json);

                foreach (var tpl in parsed.data)
                {
                    string name = tpl.name;
                    if (!name.Equals(templateName, StringComparison.OrdinalIgnoreCase))
                        continue;

                    string language = tpl.language ?? "en_US";
                    string body = "";
                    var buttons = new List<ButtonMetadataDto>();
                    bool hasImageHeader = false;

                    foreach (var component in tpl.components)
                    {
                        string type = component.type?.ToString()?.ToUpper();

                        if (type == "BODY")
                        {
                            try
                            {
                                body = component.text?.ToString() ?? "";
                            }
                            catch
                            {
                                body = "";
                            }
                        }

                        if (type == "HEADER")
                        {
                            string format = component.format?.ToString()?.ToUpper();
                            if (format == "IMAGE") hasImageHeader = true;
                        }

                        if (includeButtons && type == "BUTTONS")
                        {
                            foreach (var button in component.buttons)
                            {
                                try
                                {
                                    string btnType = button.type?.ToString()?.ToUpper() ?? "";
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

                                    // ✅ Extract known dynamic values
                                    string? paramValue = null;
                                    if (button.url != null)
                                        paramValue = button.url.ToString();
                                    else if (button.phone_number != null)
                                        paramValue = button.phone_number.ToString();
                                    else if (button.coupon_code != null)
                                        paramValue = button.coupon_code.ToString();
                                    else if (button.flow_id != null)
                                        paramValue = button.flow_id.ToString();

                                    // ✅ Skip truly invalid (unknown + missing value for dynamic)
                                    if (subType == "unknown" || (paramValue == null && new[] { "url", "flow", "copy_code" }.Contains(subType)))

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
                                        ParameterValue = paramValue ?? "" // ✅ Default to empty for static buttons
                                    });
                                }
                                catch (Exception exBtn)
                                {
                                    _logger.LogWarning(exBtn, "⚠️ Failed to parse button in template {TemplateName}", name);
                                }
                            }
                        }
                    }

                    int paramCount = Regex.Matches(body ?? "", "{{(.*?)}}").Count;

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
                _logger.LogError(ex, "❌ Exception in GetTemplateByNameAsync");
            }

            return null;
        }

    }
}

