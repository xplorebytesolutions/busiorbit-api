namespace xbytechat.api.Helpers
{
    /// <summary>
    /// Represents a standardized response structure for service layer results.
    /// </summary>
    public class ResponseResult
    {
        public bool Success { get; set; }                  // ✅ Whether operation succeeded
        public string Message { get; set; }                // ✅ User-friendly message
        public object? Data { get; set; }                  // Optional payload (if needed)

        // ✅ WhatsApp-specific diagnostics
        public string? ErrorMessage { get; set; }          // Error from API or exception
        public string? RawResponse { get; set; }           // Full API raw response

        public string? MessageId { get; set; } // 🌐 WhatsApp WAMID (Message ID)

        public Guid? LogId { get; set; } // ✅ Unique ID of MessageLog for tracking
                                         // ✅ Factory method for successful result

        public string? Token { get; set; }

        public string? RefreshToken { get; set; }
        public static ResponseResult SuccessInfo(string message, object? data = null, string? raw = null)
        {
            return new ResponseResult
            {
                Success = true,
                Message = message,
                Data = data,
                RawResponse = raw
            };
        }

        // ❌ Factory method for error result
        public static ResponseResult ErrorInfo(string message, string? error = null, string? raw = null)
        {
            return new ResponseResult
            {
                Success = false,
                Message = message,
                ErrorMessage = error,
                RawResponse = raw
            };
        }
    }
}
