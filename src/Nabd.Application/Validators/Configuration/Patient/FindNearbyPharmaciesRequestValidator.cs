using FluentValidation;
using Nabd.Application.DTOs.Requests.Patient;

namespace Nabd.Application.Validators.Configuration.Patient
{
    public class FindNearbyPharmaciesRequestValidator : AbstractValidator<FindNearbyPharmaciesRequest>
    {
        public FindNearbyPharmaciesRequestValidator()
        {
            RuleFor(x => x.Latitude)
                .NotEmpty()
                .WithMessage("Latitude is required")
                .InclusiveBetween(-90, 90)
                .WithMessage("Latitude must be between -90 and 90 degrees");

            RuleFor(x => x.Longitude)
                .NotEmpty()
                .WithMessage("Longitude is required")
                .InclusiveBetween(-180, 180)
                .WithMessage("Longitude must be between -180 and 180 degrees");
        }
    }
}
