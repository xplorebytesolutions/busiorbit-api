using xbytechat.api.Features.CampaignModule.Models;
using xbytechat.api.Shared.utility;

namespace xbytechat.api.Features.MessagesEngine.PayloadBuilders
{
    public static class MessagePayloadBuilder
    {
        /// <summary>
        /// Builds a WhatsApp template message payload for image header + buttons.
        /// </summary>
        public static object BuildImageTemplatePayload(
            string templateName,
            string languageCode,
            string recipientNumber,
            List<string> templateParams,
            string? imageUrl,
            List<CampaignButton>? buttons
        )
        {
            var components = new List<object>();

            // ✅ Body with template params
            if (templateParams != null && templateParams.Any())
            {
                components.Add(new
                {
                    type = "body",
                    parameters = templateParams.Select(p => new { type = "text", text = p }).ToArray()
                });
            }

            // ✅ Header image if present
            if (!string.IsNullOrWhiteSpace(imageUrl))
            {
                components.Add(new
                {
                    type = "header",
                    parameters = new[]
                    {
                    new { type = "image", image = new { link = imageUrl } }
                }
                });
            }

            // ✅ CTA buttons
            if (buttons != null && buttons.Any())
            {
                var buttonComponents = buttons
                    .OrderBy(b => b.Position)
                    .Take(3)
                    .Select((btn, index) => new
                    {
                        type = "button",
                        sub_type = btn.Type, // "url" or "phone_number"
                        index = index.ToString(),
                        parameters = new[]
                        {
                        new { type = "text", text = btn.Value }
                        }
                    });

                components.AddRange(buttonComponents);
            }

            // ✅ Final WhatsApp Template Payload
            return new
            {
                messaging_product = "whatsapp",
                to = recipientNumber,
                type = "template",
                template = new
                {
                    name = templateName,
                    language = new { code = languageCode },
                    components = components
                }
            };
        }
    }

}