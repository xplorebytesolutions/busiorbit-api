// ✅ Step 1: Final interface
using xbytechat.api.Features.MessagesEngine.DTOs;
using xbytechat.api.Helpers;
using System.Threading.Tasks;
using System.IO.Pipelines;
using xbytechat.api.Features.MessageManagement.DTOs;

namespace xbytechat.api.Features.MessagesEngine.Services
{
    public interface IMessageEngineService
    {

        Task<ResponseResult> SendTemplateMessageAsync(SendMessageDto dto); //
        Task<ResponseResult> SendTextDirectAsync(TextMessageSendDto dto);
        Task<ResponseResult> SendAutomationReply(TextMessageSendDto dto);
        Task<ResponseResult> SendTemplateMessageSimpleAsync(Guid businessId, SimpleTemplateMessageDto dto);
        Task<ResponseResult> SendImageCampaignAsync(Guid campaignId, Guid businessId, string triggeredBy);
        Task<ResponseResult> SendImageTemplateMessageAsync(ImageTemplateMessageDto dto, Guid businessId);
        Task<ResponseResult> SendPayloadAsync(Guid businessId, object payload);
    }
}
