using FluentValidation;
using Nabd.Application.DTOs.Requests.Auth;

namespace Nabd.Application.Validators.Configuration.Auth
{
    public class DeleteAccountRequestValidator : AbstractValidator<DeleteAccountRequest>
    {
        public DeleteAccountRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Invalid email format");

            RuleFor(x => x.ConfirmationText)
                .NotEmpty()
                .WithMessage("Confirmation text is required")
                .Must(x => x?.Trim().ToUpper() == "DELETE")
                .WithMessage("You must type 'DELETE' to confirm account deletion");
        }
    }
}
