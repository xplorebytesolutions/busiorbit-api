// Features/Tracking/Services/UrlBuilderService.cs
using System;
using Microsoft.Extensions.Options;
using xbytechat.api.Features.CampaignTracking.Config;
using xbytechat.api.Features.CampaignTracking.Services;

namespace xbytechat.api.Features.Tracking.Services
{
    public class UrlBuilderService : IUrlBuilderService
    {
        private readonly IClickTokenService _token;
        private readonly TrackingOptions _opt;

        // Allowed schemes for destination links
        private static readonly string[] AllowedSchemes = new[] { "http", "https", "tel", "wa", "whatsapp" };

        public UrlBuilderService(IClickTokenService token, IOptions<TrackingOptions> opt)
        {
            _token = token;
            _opt = opt.Value;
        }

        /// <summary>
        /// Normalizes destination and enforces an allowlist of schemes:
        /// http, https, tel, wa, whatsapp.
        /// Also supports shorthand WhatsApp hosts: wa.me/... and api.whatsapp.com/...
        /// </summary>
        private static string NormalizeAbsoluteUrlOrThrow(string input)
        {
            if (input is null) throw new ArgumentException("Destination URL is null.", nameof(input));

            // Trim and remove any non-printable/control whitespace characters
            var s = input.Trim();
            s = new string(Array.FindAll(s.ToCharArray(), c => !char.IsControl(c)));

            if (s.Length == 0)
                throw new ArgumentException("Destination URL is empty after trimming.", nameof(input));

            // Short-circuit for already tracked links, just in case this ever gets called that way
            if (s.Contains("/r/", StringComparison.Ordinal))
                return s;

            // Support common WhatsApp shorthands without scheme
            // e.g. "wa.me/9170..." or "api.whatsapp.com/send?phone=..."
            if (!s.Contains("://", StringComparison.Ordinal))
            {
                if (s.StartsWith("wa.me/", StringComparison.OrdinalIgnoreCase) ||
                    s.StartsWith("api.whatsapp.com/", StringComparison.OrdinalIgnoreCase))
                {
                    var guessWa = "https://" + s;
                    if (Uri.TryCreate(guessWa, UriKind.Absolute, out var waAbs))
                        return waAbs.AbsoluteUri;
                }
            }

            // Accept absolute URIs with allowed schemes
            if (Uri.TryCreate(s, UriKind.Absolute, out var abs))
            {
                var scheme = abs.Scheme ?? string.Empty;

                // Allow only whitelisted schemes
                var isAllowed = false;
                for (int i = 0; i < AllowedSchemes.Length; i++)
                {
                    if (scheme.Equals(AllowedSchemes[i], StringComparison.OrdinalIgnoreCase))
                    {
                        isAllowed = true;
                        break;
                    }
                }

                if (!isAllowed)
                    throw new ArgumentException(
                        $"Destination must use one of: http, https, tel, wa, whatsapp. Got '{scheme}:'",
                        nameof(input));

                // http/https → return canonical AbsoluteUri
                if (scheme.Equals(Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) ||
                    scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase))
                {
                    return abs.AbsoluteUri;
                }

                // tel:/wa:/whatsapp://send → return as provided (trimmed), do not modify
                return s;
            }

            // Human input like "www.example.com/..." or "example.com/..."
            if (!s.Contains("://", StringComparison.Ordinal) && s.Contains('.', StringComparison.Ordinal))
            {
                var guess = "https://" + s;
                if (Uri.TryCreate(guess, UriKind.Absolute, out var httpAbs))
                    return httpAbs.AbsoluteUri;
            }

            throw new ArgumentException(
                $"Destination must be an absolute URL or allowed deep link (http, https, tel, wa, whatsapp). Got: '{input}'",
                nameof(input));
        }

        public string BuildTrackedButtonUrl(
            Guid campaignSendLogId,
            int buttonIndex,
            string? buttonTitle,
            string destinationUrlAbsolute)
        {
            var dest = NormalizeAbsoluteUrlOrThrow(destinationUrlAbsolute);

            var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var exp = now + (long)_opt.TokenTtl.TotalSeconds;

            var payload = new ClickTokenPayload(
                cid: campaignSendLogId,
                bi: buttonIndex,
                bt: buttonTitle ?? string.Empty,
                to: dest,
                iat: now,
                exp: exp
            );

            var token = _token.Create(payload);
            return $"{_opt.BaseUrl.TrimEnd('/')}/r/{token}";
        }
    }
}

//using System;
//using System.Text;
//using System.Web;
//using Microsoft.AspNetCore.WebUtilities;
//using Microsoft.Extensions.Options;
//using xbytechat.api.Features.CampaignTracking.Config;
//using xbytechat.api.Features.CampaignTracking.Services;

//namespace xbytechat.api.Features.Tracking.Services
//{

//    public class UrlBuilderService : IUrlBuilderService
//    {
//        private readonly string _apiBaseUrl; // e.g., "https://api.yourserver.com"
//        private readonly IClickTokenService _token;
//        private readonly TrackingOptions _opt;
//        public UrlBuilderService(IConfiguration configuration, IClickTokenService token, IOptions<TrackingOptions> opt)
//        {
//            // Get your API's base URL from appsettings.json
//            _apiBaseUrl = configuration["ApiBaseUrl"] ?? "http://localhost:7113";
//            _token = token;
//            _opt = opt.Value;
//        }


//        //public string GenerateCampaignTrackingUrl(Guid campaignSendLogId, string buttonType, string finalDestinationUrl, string contactPhone)
//        //{
//        //    // 👇 FIX: This new logic replaces the {{1}} placeholder
//        //    string resolvedDestinationUrl = finalDestinationUrl;
//        //    if (finalDestinationUrl.Contains("{{1}}"))
//        //    {
//        //        // Replace the placeholder with the contact's phone number and URL-encode it
//        //        resolvedDestinationUrl = finalDestinationUrl.Replace("{{1}}", HttpUtility.UrlEncode(contactPhone));
//        //    }

//        //    var trackingUrl = $"{_apiBaseUrl}/api/tracking/redirect/{campaignSendLogId}";

//        //    var queryParams = new Dictionary<string, string>
//        //    {
//        //        { "type", buttonType },
//        //        { "to", resolvedDestinationUrl } // Use the new resolved URL
//        //    };

//        //    return QueryHelpers.AddQueryString(trackingUrl, queryParams);
//        //}

//        public string BuildTrackedButtonUrl(
//            Guid campaignSendLogId,
//            int buttonIndex,
//            string? buttonTitle,
//            string destinationUrlAbsolute)
//        {
//            if (!Uri.TryCreate(destinationUrlAbsolute, UriKind.Absolute, out _))
//                throw new ArgumentException("Destination must be an absolute URL", nameof(destinationUrlAbsolute));

//            var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
//            var exp = now + (long)_opt.TokenTtl.TotalSeconds;

//            var payload = new ClickTokenPayload(
//                cid: campaignSendLogId,
//                bi: buttonIndex,
//                bt: buttonTitle ?? string.Empty,
//                to: destinationUrlAbsolute,
//                iat: now,
//                exp: exp
//            );

//            var token = _token.Create(payload);
//            return $"{_opt.BaseUrl.TrimEnd('/')}/r/{token}";
//        }
//    }

//}

