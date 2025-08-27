namespace xbytechat.api.Features.Tracking.Services
{
    public interface IUrlBuilderService
    {

        string GenerateCampaignTrackingUrl(Guid campaignSendLogId, string buttonType, string finalDestinationUrl, string contactPhone);
    }
}
