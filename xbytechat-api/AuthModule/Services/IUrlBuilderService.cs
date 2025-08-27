namespace xbytechat.api.AuthModule.Services
{
    public interface IUrlBuilderService
    {

        string GenerateCampaignTrackingUrl(Guid campaignSendLogId, string buttonType, string finalDestinationUrl, string contactPhone);
    }
}
