using System.Buffers;
using System.Text.Json;

namespace xbytechat.api.Features.Webhooks.Pinnacle.Services.Adapters;

public sealed class PinnacleToMetaAdapter : IPinnacleToMetaAdapter
{
    public JsonElement ToMetaEnvelope(JsonElement p)
    {
        var buf = new ArrayBufferWriter<byte>();     // not IDisposable
        using var w = new Utf8JsonWriter(buf);       // IS IDisposable

        w.WriteStartObject();
        w.WritePropertyName("entry");
        w.WriteStartArray();
        w.WriteStartObject();                         // entry[0]
        w.WritePropertyName("changes");
        w.WriteStartArray();
        w.WriteStartObject();                         // changes[0]
        w.WritePropertyName("value");
        w.WriteStartObject();

        if (!TryMapStatuses(p, w) && !TryMapMessages(p, w))
        {
            w.WritePropertyName("provider_raw");
            p.WriteTo(w);
        }

        w.WriteEndObject(); // value
        w.WriteEndObject(); // change
        w.WriteEndArray();  // changes
        w.WriteEndObject(); // entry[0]
        w.WriteEndArray();  // entry
        w.WriteEndObject(); // root
        w.Flush();

        var ros = new ReadOnlySequence<byte>(buf.WrittenMemory);
        using var doc = JsonDocument.Parse(ros);
        return doc.RootElement.Clone();               // detach from doc
    }
    private static bool TryMapStatuses(JsonElement p, Utf8JsonWriter w)
    {
        // Heuristics for Pinnacle status payloads; adjust keys if your schema differs.
        // Accept shapes:
        // { "status":"delivered","messageId":"wamid...","timestamp":169... }
        // { "data": { "status":"read","id":"wamid...","ts":169... } }
        string? id = null, status = null;
        long? ts = null;

        if (p.TryGetProperty("messageId", out var mid) && mid.ValueKind == JsonValueKind.String) id = mid.GetString();
        if (p.TryGetProperty("id", out var pid) && pid.ValueKind == JsonValueKind.String) id ??= pid.GetString();
        if (p.TryGetProperty("status", out var st) && st.ValueKind == JsonValueKind.String) status = st.GetString();

        if (p.TryGetProperty("timestamp", out var t))
        {
            if (t.ValueKind == JsonValueKind.Number) ts = t.GetInt64();
            else if (t.ValueKind == JsonValueKind.String && long.TryParse(t.GetString(), out var n)) ts = n;
        }

        if (p.TryGetProperty("data", out var d) && d.ValueKind == JsonValueKind.Object)
        {
            if (id is null && d.TryGetProperty("id", out var did) && did.ValueKind == JsonValueKind.String) id = did.GetString();
            if (status is null && d.TryGetProperty("status", out var ds) && ds.ValueKind == JsonValueKind.String) status = ds.GetString();
            if (ts is null && d.TryGetProperty("ts", out var dts) && dts.ValueKind == JsonValueKind.Number) ts = dts.GetInt64();
        }

        if (id is null || status is null) return false;

        w.WritePropertyName("statuses");
        w.WriteStartArray();
        w.WriteStartObject();
        w.WriteString("id", id);
        w.WriteString("status", status);
        if (ts.HasValue) w.WriteNumber("timestamp", ts.Value);
        w.WriteEndObject();
        w.WriteEndArray();
        return true;
    }

    private static bool TryMapMessages(JsonElement p, Utf8JsonWriter w)
    {
        // Click shape example:
        // { "click": { "title":"Contact Sales", "contextId":"wamid..", "from":"91..." } }
        if (p.TryGetProperty("click", out var c) && c.ValueKind == JsonValueKind.Object)
        {
            var title = c.TryGetProperty("title", out var t) ? t.GetString() : null;
            var ctxId = c.TryGetProperty("contextId", out var ctx) ? ctx.GetString() : null;
            var from = c.TryGetProperty("from", out var f) ? f.GetString() : null;

            if (!string.IsNullOrWhiteSpace(title) && !string.IsNullOrWhiteSpace(ctxId))
            {
                w.WritePropertyName("messages");
                w.WriteStartArray();
                w.WriteStartObject();
                w.WriteString("type", "button");
                w.WriteString("from", from ?? "");
                w.WritePropertyName("button");
                w.WriteStartObject();
                w.WriteString("text", title!);
                w.WriteEndObject();
                w.WritePropertyName("context");
                w.WriteStartObject();
                w.WriteString("id", ctxId!);
                w.WriteEndObject();
                w.WriteEndObject();
                w.WriteEndArray();
                return true;
            }
        }

        // Inbound text example:
        // { "message": { "from":"91...", "body":"hi", "type":"text" } }
        if (p.TryGetProperty("message", out var m) && m.ValueKind == JsonValueKind.Object)
        {
            var type = m.TryGetProperty("type", out var tp) ? tp.GetString() : "text";
            var from = m.TryGetProperty("from", out var fr) ? fr.GetString() : "";
            var body = m.TryGetProperty("body", out var bd) ? bd.GetString() : "";

            w.WritePropertyName("messages");
            w.WriteStartArray();
            w.WriteStartObject();
            w.WriteString("type", type ?? "text");
            w.WriteString("from", from ?? "");
            if ((type ?? "text") == "text")
            {
                w.WritePropertyName("text");
                w.WriteStartObject();
                w.WriteString("body", body ?? "");
                w.WriteEndObject();
            }
            w.WriteEndObject();
            w.WriteEndArray();
            return true;
        }

        return false;
    }
}
