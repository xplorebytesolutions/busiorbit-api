using FluentValidation;
using xbytechat_api.WhatsAppSettings.DTOs;

namespace xbytechat_api.WhatsAppSettings.Validators
{
    public class SaveWhatsAppSettingValidator : AbstractValidator<SaveWhatsAppSettingDto> // ✅ Inherit properly
    {
        public SaveWhatsAppSettingValidator()
        {
            RuleFor(x => x.BusinessId)
                .NotEmpty().WithMessage("BusinessId is required.");

            RuleFor(x => x.ApiUrl)
                .NotEmpty().WithMessage("API URL is required.")
                .MaximumLength(500).WithMessage("API URL must not exceed 500 characters.");

            RuleFor(x => x.ApiToken)
                .NotEmpty().WithMessage("API Token is required.")
                .MaximumLength(1000).WithMessage("API Token must not exceed 1000 characters.");

            RuleFor(x => x.WhatsAppBusinessNumber)
                .NotEmpty().WithMessage("WhatsApp Business Number is required.")
                .MaximumLength(20).WithMessage("WhatsApp Business Number must not exceed 20 characters.");

            RuleFor(x => x.SenderDisplayName)
                .MaximumLength(100).WithMessage("Sender Display Name must not exceed 100 characters.")
                .When(x => !string.IsNullOrEmpty(x.SenderDisplayName));
        }
    }
}
