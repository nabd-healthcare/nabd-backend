using FluentValidation;
using Nabd.Application.DTOs.Requests.Prescription;

namespace Nabd.Application.Validators.Prescription
{
    public class SharePrescriptionRequestValidator : AbstractValidator<SharePrescriptionRequest>
    {
        public SharePrescriptionRequestValidator()
        {
            RuleFor(x => x.ExpirationHours)
                .GreaterThan(0).WithMessage("Expiration must be greater than 0")
                .LessThanOrEqualTo(168).WithMessage("Expiration cannot exceed 168 hours (7 days)");

            RuleFor(x => x.MessageToPharmacy)
                .MaximumLength(500).WithMessage("Message cannot exceed 500 characters")
                .When(x => !string.IsNullOrEmpty(x.MessageToPharmacy));
        }
    }
}
