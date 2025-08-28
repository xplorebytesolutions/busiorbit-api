// 📄 Features/CampaignTracking/Controllers/CampaignTrackingController.cs
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using xbytechat.api;
using xbytechat.api.Features.CampaignTracking.Services;
using xbytechat.api.Features.CampaignTracking.Worker;

namespace xbytechat.api.Features.CampaignTracking.Controllers
{
    [ApiController]
    [Route("r")] // /r/{token}
    public class CampaignTrackingController : ControllerBase
    {
        private static readonly HtmlEncoder HtmlEnc = HtmlEncoder.Default;

        private readonly ILogger<CampaignTrackingController> _log;
        private readonly IClickTokenService _token;
        private readonly IClickEventQueue _queue;
        private readonly AppDbContext _db;

        public CampaignTrackingController(
            ILogger<CampaignTrackingController> log,
            IClickTokenService token,
            IClickEventQueue queue,
            AppDbContext db)
        {
            _log = log;
            _token = token;
            _queue = queue;
            _db = db;
        }

        [HttpGet("{token}")]
        [AllowAnonymous]
        public async Task<IActionResult> RedirectByToken([FromRoute] string token, CancellationToken ct)
        {
            // 1) Validate token
            if (!_token.TryValidate(token, out var p, out var reason))
            {
                _log.LogWarning("Tracking token rejected. reason={Reason}", reason);
                return BadRequest("Invalid token.");
            }

            // 2) Normalize + classify destination
            if (!TryNormalizeAllowedDestination(p!.to, out var safeDest, out var scheme))
            {
                _log.LogWarning("Rejected destination for cid {Cid}: {Dest}", p.cid, p.to);
                return BadRequest("Invalid destination.");
            }

            // 3) Capture client info
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "0.0.0.0";
            var ua = Request.Headers.UserAgent.ToString();
            var now = DateTime.UtcNow;

            // 4) Determine click type (web | call | whatsapp)
            var clickType = ClassifyClickType(safeDest, scheme);

            // 5) Write-through (guaranteed persistence)
            try
            {
                await _db.CampaignClickLogs.AddAsync(new CampaignClickLog
                {
                    Id = Guid.NewGuid(),
                    CampaignSendLogId = p.cid,
                    ButtonIndex = p.bi,
                    ButtonTitle = p.bt,
                    Destination = safeDest,
                    ClickedAt = now,
                    Ip = ip,
                    UserAgent = ua,
                    ClickType = clickType
                }, ct);

                await _db.SaveChangesAsync(ct);

                _log.LogInformation(
                    "CLICK WRITE-THROUGH cid={Cid} idx={Idx} type={Type} dest={Dest}",
                    p.cid, p.bi, clickType, safeDest);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Write-through insert failed. cid={Cid}", p.cid);
            }

            // 6) Enqueue for async worker (best effort)
            try
            {
                var enq = _queue.TryWrite(new ClickEvent(
                    CampaignSendLogId: p.cid,
                    ButtonIndex: p.bi,
                    ButtonTitle: p.bt,
                    Destination: safeDest,
                    ClickedAtUtc: now,
                    Ip: ip,
                    UserAgent: ua,
                    ClickType: clickType
                ));
                _log.LogInformation("CLICK ENQUEUE cid={Cid} idx={Idx} enqueued={Enqueued}", p.cid, p.bi, enq);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Queue write threw. cid={Cid}", p.cid);
            }

            // 7) First-click fast path
            try
            {
                await _db.Database.ExecuteSqlRawAsync(
                    @"update ""CampaignSendLogs""
                        set ""IsClicked""=TRUE, ""ClickedAt""=NOW() at time zone 'utc'
                      where ""Id""={0} and ""IsClicked""=FALSE;",
                    p.cid);
            }
            catch (Exception ex)
            {
                _log.LogDebug(ex, "First-click update skipped.");
            }

            // 8) Redirect handling
            if (clickType is "call" or "whatsapp")
            {
                // Deep link → return an HTML/JS shim to trigger immediately, with a safe fallback link.
                var destHtml = HtmlEnc.Encode(safeDest);
                var destJs = JsEscape(safeDest);

                var html = $@"<!doctype html>
<html lang=""en"">
<head>
  <meta charset=""utf-8"">
  <meta http-equiv=""x-ua-compatible"" content=""ie=edge"">
  <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
  <meta http-equiv=""refresh"" content=""0;url={destHtml}"">
  <title>Redirecting…</title>
  <style>
    body{{font-family:system-ui,-apple-system,Segoe UI,Roboto,Arial,sans-serif;padding:24px;}}
    a{{color:#2563eb;text-decoration:underline;}}
  </style>
  <script>
    // Trigger deep link immediately; reveal fallback if blocked by the browser.
    window.addEventListener('load', function() {{
      try {{ window.location.replace('{destJs}'); }} catch (e) {{}}
      setTimeout(function() {{
        var f = document.getElementById('fallback');
        if (f) f.style.display = 'inline';
      }}, 1200);
    }});
  </script>
</head>
<body>
  <p>Redirecting… If you are not redirected automatically, <a id=""fallback"" style=""display:none"" href=""{destHtml}"">tap here</a>.</p>
</body>
</html>";

                Response.Headers["Cache-Control"] = "no-store, max-age=0";
                Response.Headers["Pragma"] = "no-cache";
                Response.Headers["X-Content-Type-Options"] = "nosniff";

                return new ContentResult
                {
                    Content = html,
                    ContentType = "text/html; charset=utf-8",
                    StatusCode = 200
                };
            }

            // Regular web links → normal 302
            return Redirect(safeDest);
        }

        // --- helpers ---

        private static string ClassifyClickType(string normalizedDest, string scheme)
        {
            // scheme is pre-normalized by TryNormalizeAllowedDestination
            if (string.Equals(scheme, "tel", StringComparison.OrdinalIgnoreCase)) return "call";
            if (string.Equals(scheme, "wa", StringComparison.OrdinalIgnoreCase)) return "whatsapp";
            if (string.Equals(scheme, "whatsapp", StringComparison.OrdinalIgnoreCase)) return "whatsapp";

            // http/https → still treat WhatsApp hosts as whatsapp
            if (normalizedDest.StartsWith("https://wa.me/", StringComparison.OrdinalIgnoreCase)) return "whatsapp";
            if (normalizedDest.StartsWith("https://api.whatsapp.com/", StringComparison.OrdinalIgnoreCase)) return "whatsapp";

            return "web";
        }

        private static string JsEscape(string s) =>
            s.Replace("\\", "\\\\").Replace("'", "\\'").Replace("\r", "").Replace("\n", "");

        /// <summary>
        /// Accepts: http/https/tel/wa/whatsapp, plus shorthand wa.me/... and api.whatsapp.com/...
        /// Returns normalized absolute string and a normalized scheme hint ("http","https","tel","wa","whatsapp").
        /// </summary>
        private static bool TryNormalizeAllowedDestination(string? input, out string normalized, out string scheme)
        {
            normalized = string.Empty;
            scheme = string.Empty;
            if (string.IsNullOrWhiteSpace(input)) return false;

            var cleaned = new string(input.Trim().Where(c => !char.IsControl(c)).ToArray());

            // Shorthand WhatsApp hosts without scheme → prefix https://
            if (!cleaned.Contains("://", StringComparison.Ordinal))
            {
                if (cleaned.StartsWith("wa.me/", StringComparison.OrdinalIgnoreCase) ||
                    cleaned.StartsWith("api.whatsapp.com/", StringComparison.OrdinalIgnoreCase))
                {
                    var guess = "https://" + cleaned;
                    if (Uri.TryCreate(guess, UriKind.Absolute, out var waAbs))
                    {
                        normalized = waAbs.AbsoluteUri;
                        scheme = "https";
                        return true;
                    }
                }
            }

            // WhatsApp custom schemes (wa:, whatsapp:)
            if (cleaned.StartsWith("wa:", StringComparison.OrdinalIgnoreCase))
            {
                normalized = cleaned; scheme = "wa"; return true;
            }
            if (cleaned.StartsWith("whatsapp:", StringComparison.OrdinalIgnoreCase))
            {
                normalized = cleaned; scheme = "whatsapp"; return true;
            }

            // Absolute URIs
            if (Uri.TryCreate(cleaned, UriKind.Absolute, out var uri))
            {
                // tel:
                if (uri.Scheme.Equals("tel", StringComparison.OrdinalIgnoreCase))
                {
                    normalized = uri.ToString(); scheme = "tel"; return true;
                }

                // http/https (including WhatsApp hosts)
                if (uri.Scheme.Equals(Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) ||
                    uri.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase))
                {
                    normalized = uri.AbsoluteUri;
                    scheme = uri.Scheme; // "http" or "https"
                    return true;
                }
            }

            return false;
        }
    }
}


//// 📄 Features/CampaignTracking/Controllers/CampaignTrackingController.cs
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using xbytechat.api;
//using xbytechat.api.Features.CampaignTracking.Services;
//using xbytechat.api.Features.CampaignTracking.Worker;

//namespace xbytechat.api.Features.CampaignTracking.Controllers
//{
//    [ApiController]
//    [Route("r")] // /r/{token}
//    public class CampaignTrackingController : ControllerBase
//    {
//        private readonly ILogger<CampaignTrackingController> _log;
//        private readonly IClickTokenService _token;
//        private readonly IClickEventQueue _queue;
//        private readonly AppDbContext _db;

//        public CampaignTrackingController(
//            ILogger<CampaignTrackingController> log,
//            IClickTokenService token,
//            IClickEventQueue queue,
//            AppDbContext db)
//        {
//            _log = log;
//            _token = token;
//            _queue = queue;
//            _db = db;
//        }

//        [HttpGet("{token}")]
//        [AllowAnonymous]
//        public async Task<IActionResult> RedirectByToken([FromRoute] string token, CancellationToken ct)
//        {
//            // 1) Validate token
//            if (!_token.TryValidate(token, out var p, out var reason))
//            {
//                _log.LogWarning("Tracking token rejected. reason={Reason}", reason);
//                return BadRequest("Invalid token.");
//            }

//            // 2) Normalize + classify destination
//            if (!TryNormalizeAllowedDestination(p!.to, out var safeDest, out var scheme))
//            {
//                _log.LogWarning("Rejected destination for cid {Cid}: {Dest}", p.cid, p.to);
//                return BadRequest("Invalid destination.");
//            }

//            // 3) Capture client info
//            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "0.0.0.0";
//            var ua = Request.Headers.UserAgent.ToString();
//            var now = DateTime.UtcNow;

//            // classify click type
//            var clickType = scheme switch
//            {
//                "tel" => "call",
//                "wa" => "whatsapp",
//                _ => "web"
//            };

//            // 4) Write-through (guaranteed persistence)
//            try
//            {
//                await _db.CampaignClickLogs.AddAsync(new CampaignClickLog
//                {
//                    Id = Guid.NewGuid(),
//                    CampaignSendLogId = p.cid,
//                    ButtonIndex = p.bi,
//                    ButtonTitle = p.bt,
//                    Destination = safeDest,
//                    ClickedAt = now,
//                    Ip = ip,
//                    UserAgent = ua,
//                    ClickType = clickType
//                }, ct);
//                await _db.SaveChangesAsync(ct);

//                _log.LogInformation(
//                    "CLICK WRITE-THROUGH cid={Cid} idx={Idx} type={Type} dest={Dest}",
//                    p.cid, p.bi, clickType, safeDest);
//            }
//            catch (Exception ex)
//            {
//                _log.LogError(ex, "Write-through insert failed. cid={Cid}", p.cid);
//            }

//            // 5) Enqueue for async worker (best effort)
//            try
//            {
//                var enq = _queue.TryWrite(new ClickEvent(
//                    CampaignSendLogId: p.cid,
//                    ButtonIndex: p.bi,
//                    ButtonTitle: p.bt,
//                    Destination: safeDest,
//                    ClickedAtUtc: now,
//                    Ip: ip,
//                    UserAgent: ua,
//                    ClickType: clickType   // <<< required by the record
//                ));
//                _log.LogInformation("CLICK ENQUEUE cid={Cid} idx={Idx} enqueued={Enqueued}", p.cid, p.bi, enq);
//            }
//            catch (Exception ex)
//            {
//                _log.LogError(ex, "Queue write threw. cid={Cid}", p.cid);
//            }

//            // 6) First-click fast path
//            try
//            {
//                await _db.Database.ExecuteSqlRawAsync(
//                    @"update ""CampaignSendLogs""
//                        set ""IsClicked""=TRUE, ""ClickedAt""=NOW() at time zone 'utc'
//                      where ""Id""={0} and ""IsClicked""=FALSE;",
//                    p.cid);
//            }
//            catch (Exception ex)
//            {
//                _log.LogDebug(ex, "First-click update skipped.");
//            }

//            // 7) Redirect handling
//            if (scheme == "tel" || scheme == "wa")
//            {
//                // Small HTML shim to trigger deep-link reliably on mobile
//                var html = $@"<!doctype html><html><head>
//<meta http-equiv='refresh' content='0;url={safeDest}'>
//</head><body>
//<p>If you are not redirected automatically, <a href='{safeDest}'>tap here</a>.</p>
//</body></html>";
//                return Content(html, "text/html");
//            }

//            return Redirect(safeDest); // http/https
//        }

//        private static bool TryNormalizeAllowedDestination(string? input, out string normalized, out string scheme)
//        {
//            normalized = string.Empty;
//            scheme = string.Empty;
//            if (string.IsNullOrWhiteSpace(input)) return false;

//            var cleaned = new string(input.Trim().Where(c => !char.IsControl(c)).ToArray());

//            // WhatsApp deep links
//            if (cleaned.StartsWith("wa:", StringComparison.OrdinalIgnoreCase))
//            {
//                normalized = cleaned; scheme = "wa"; return true;
//            }
//            if (cleaned.StartsWith("https://wa.me/", StringComparison.OrdinalIgnoreCase))
//            {
//                normalized = cleaned; scheme = "wa"; return true;
//            }

//            // Absolute URIs
//            if (Uri.TryCreate(cleaned, UriKind.Absolute, out var uri))
//            {
//                if (uri.Scheme.Equals(Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) ||
//                    uri.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase))
//                {
//                    normalized = uri.ToString(); scheme = uri.Scheme; return true;
//                }
//                if (uri.Scheme.Equals("tel", StringComparison.OrdinalIgnoreCase))
//                {
//                    normalized = uri.ToString(); scheme = "tel"; return true;
//                }
//            }
//            return false;
//        }
//    }
//}


//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using xbytechat.api;
//using xbytechat.api.Features.CampaignTracking.Services;
//using xbytechat.api.Features.CampaignTracking.Worker;

//namespace xbytechat.api.Features.CampaignTracking.Controllers
//{
//    [ApiController]
//    [Route("r")] // /r/{token}
//    public class CampaignTrackingController : ControllerBase
//    {
//        private readonly ILogger<CampaignTrackingController> _log;
//        private readonly IClickTokenService _token;
//        private readonly IClickEventQueue _queue;
//        private readonly AppDbContext _db;

//        public CampaignTrackingController(
//            ILogger<CampaignTrackingController> log,
//            IClickTokenService token,
//            IClickEventQueue queue,
//            AppDbContext db)
//        {
//            _log = log;
//            _token = token;
//            _queue = queue;
//            _db = db;
//        }

//        [HttpGet("{token}")]
//        [AllowAnonymous]
//        public async Task<IActionResult> RedirectByToken([FromRoute] string token, CancellationToken ct)
//        {
//            // 1) Validate token
//            if (!_token.TryValidate(token, out var p, out var reason))
//            {
//                _log.LogWarning("Tracking token rejected. reason={Reason}", reason);
//                return BadRequest("Invalid token.");
//            }

//            // 2) Validate destination
//            if (!TryNormalizeAllowedDestination(p!.to, out var safeDest))
//            {
//                _log.LogWarning("Rejected destination for cid {Cid}: {Dest}", p.cid, p.to);
//                return BadRequest("Invalid destination.");
//            }

//            // 3) Capture client info
//            var ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "0.0.0.0";
//            var ua = Request.Headers.UserAgent.ToString();
//            var now = DateTime.UtcNow;

//            // 4) **Write-through**: insert immediately (guaranteed persistence)
//            try
//            {
//                await _db.CampaignClickLogs.AddAsync(new CampaignClickLog
//                {
//                    Id = Guid.NewGuid(),
//                    CampaignSendLogId = p.cid,
//                    ButtonIndex = p.bi,
//                    ButtonTitle = p.bt,
//                    Destination = safeDest,
//                    ClickedAt = now,
//                    Ip = ip,
//                    UserAgent = ua
//                }, ct);
//                await _db.SaveChangesAsync(ct);
//                _log.LogInformation("CLICK WRITE-THROUGH inserted for cid={Cid} idx={Idx}", p.cid, p.bi);
//            }
//            catch (Exception ex)
//            {
//                _log.LogError(ex, "Write-through insert failed; will still try queue. cid={Cid}", p.cid);
//            }

//            // 5) Enqueue for aggregates / downstream processing (best-effort)
//            try
//            {
//                var enq = _queue.TryWrite(new ClickEvent(
//                    CampaignSendLogId: p.cid,
//                    ButtonIndex: p.bi,
//                    ButtonTitle: p.bt,
//                    Destination: safeDest,
//                    ClickedAtUtc: now,
//                    Ip: ip,
//                    UserAgent: ua
//                ));
//                _log.LogInformation("CLICK ENQUEUE cid={Cid} idx={Idx} enqueued={Enqueued}", p.cid, p.bi, enq);
//            }
//            catch (Exception ex)
//            {
//                _log.LogError(ex, "Queue write threw (non-fatal). cid={Cid}", p.cid);
//            }

//            // 6) First-click fast path (non-blocking)
//            try
//            {
//                await _db.Database.ExecuteSqlRawAsync(
//                    @"update ""CampaignSendLogs""
//                        set ""IsClicked"" = TRUE,
//                            ""ClickedAt""  = NOW() at time zone 'utc'
//                      where ""Id"" = {0} and ""IsClicked"" = FALSE;",
//                    p.cid);
//            }
//            catch (Exception ex)
//            {
//                _log.LogDebug(ex, "First-click update skipped.");
//            }

//            // 7) Always redirect
//            return Redirect(safeDest);
//        }

//        private static bool TryNormalizeAllowedDestination(string? input, out string normalized)
//        {
//            normalized = string.Empty;
//            if (string.IsNullOrWhiteSpace(input)) return false;

//            var cleaned = new string(input.Trim().Where(c => !char.IsControl(c)).ToArray());
//            if (!Uri.TryCreate(cleaned, UriKind.Absolute, out var uri)) return false;

//            if (!uri.Scheme.Equals(Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) &&
//                !uri.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase))
//                return false;

//            normalized = uri.ToString();
//            return true;
//        }
//    }
//}
