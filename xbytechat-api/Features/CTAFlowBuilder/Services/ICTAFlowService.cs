using xbytechat.api.Features.CTAFlowBuilder.DTOs;
using xbytechat.api.Features.CTAFlowBuilder.Models;
using xbytechat.api.Helpers;

namespace xbytechat.api.Features.CTAFlowBuilder.Services
{
    public interface ICTAFlowService
    {
        // ✅ Used for flow creation and saving
        Task<Guid> CreateFlowWithStepsAsync(CreateFlowDto dto, Guid businessId, string createdBy);
        Task<ResponseResult> SaveVisualFlowAsync(SaveVisualFlowDto dto, Guid businessId, string createdBy);

        // ✅ Load flows
        Task<CTAFlowConfig?> GetFlowByBusinessAsync(Guid businessId);
        Task<CTAFlowConfig?> GetDraftFlowByBusinessAsync(Guid businessId);
        Task<List<VisualFlowSummaryDto>> GetAllPublishedFlowsAsync(Guid businessId);
        Task<List<VisualFlowSummaryDto>> GetAllDraftFlowsAsync(Guid businessId);

        // ✅ Load and manage flow steps
        Task<List<CTAFlowStep>> GetStepsForFlowAsync(Guid flowId);

        //Task<CTAFlowStep?> MatchStepByButtonAsync(Guid businessId, string buttonText, string buttonType);
        Task<CTAFlowStep?> MatchStepByButtonAsync(Guid businessId, string buttonText,string buttonType,string currentTemplateName,Guid? campaignId = null);


        Task<CTAFlowStep?> GetChainedStepAsync(Guid businessId, Guid? nextStepId);
        Task<CTAFlowStep?> GetChainedStepWithContextAsync(Guid businessId, Guid? nextStepId, Guid? trackingLogId);
        // ✅ Runtime logic
        Task<ResponseResult> ExecuteFollowUpStepAsync(Guid businessId, CTAFlowStep? currentStep, string recipientNumber);

        // ✅ Flow management
        Task<ResponseResult> PublishFlowAsync(Guid businessId, List<FlowStepDto> steps, string createdBy);
        Task<ResponseResult> DeleteFlowAsync(Guid id, Guid businessId);

        // ✅ Editor loading (visual builder)
        Task<SaveVisualFlowDto?> GetVisualFlowByIdAsync(Guid id);

      //  Task<ResponseResult> ExecuteVisualFlowAsync(Guid businessId, Guid startStepId, Guid trackingLogId);
        Task<ResponseResult> ExecuteVisualFlowAsync(Guid businessId, Guid startStepId, Guid trackingLogId, Guid? campaignSendLogId);
        Task<FlowButtonLink?> GetLinkAsync(Guid flowId, Guid sourceStepId, short buttonIndex);

        public interface IFlowRuntimeService
        {
            Task<NextStepResult> ExecuteNextAsync(NextStepContext context);
        }
    }
}


