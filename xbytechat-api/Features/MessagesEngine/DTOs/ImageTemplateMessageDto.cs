using xbytechat.api.Features.CampaignModule.DTOs;

public class ImageTemplateMessageDto
{
    public Guid BusinessId { get; set; }
    public string RecipientNumber { get; set; }
    public string TemplateName { get; set; }
    public string LanguageCode { get; set; } = "en_US";
    public string HeaderImageUrl { get; set; }
    public List<string> TemplateParameters { get; set; } = new();
    public List<CampaignButtonDto> ButtonParameters { get; set; } = new();

    // ✅ Add these two for flow tracking
    public Guid? CTAFlowConfigId { get; set; }
    public Guid? CTAFlowStepId { get; set; }
    public string? TemplateBody { get; set; }
}
