using System;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.WebUtilities;
using xbytechat.api.AuthModule.Services;

namespace xbytechat.api.Features.Tracking.Services
{

    public class UrlBuilderService : IUrlBuilderService
    {
        private readonly string _apiBaseUrl; // e.g., "https://api.yourserver.com"

        public UrlBuilderService(IConfiguration configuration)
        {
            // Get your API's base URL from appsettings.json
            _apiBaseUrl = configuration["ApiBaseUrl"] ?? "http://localhost:7113";
        }

        //public string GenerateCampaignTrackingUrl(Guid campaignSendLogId, string buttonType, string finalDestinationUrl)
        //{
        //    var trackingUrl = $"{_apiBaseUrl}/api/tracking/redirect/{campaignSendLogId}";

        //    var queryParams = new Dictionary<string, string>
        //    {
        //        { "type", buttonType },
        //        { "to", finalDestinationUrl } // Pass the final destination in the query
        //    };

        //    return QueryHelpers.AddQueryString(trackingUrl, queryParams);
        //}

        public string GenerateCampaignTrackingUrl(Guid campaignSendLogId, string buttonType, string finalDestinationUrl, string contactPhone)
        {
            // 👇 FIX: This new logic replaces the {{1}} placeholder
            string resolvedDestinationUrl = finalDestinationUrl;
            if (finalDestinationUrl.Contains("{{1}}"))
            {
                // Replace the placeholder with the contact's phone number and URL-encode it
                resolvedDestinationUrl = finalDestinationUrl.Replace("{{1}}", HttpUtility.UrlEncode(contactPhone));
            }

            var trackingUrl = $"{_apiBaseUrl}/api/tracking/redirect/{campaignSendLogId}";

            var queryParams = new Dictionary<string, string>
            {
                { "type", buttonType },
                { "to", resolvedDestinationUrl } // Use the new resolved URL
            };

            return QueryHelpers.AddQueryString(trackingUrl, queryParams);
        }
    }
}
