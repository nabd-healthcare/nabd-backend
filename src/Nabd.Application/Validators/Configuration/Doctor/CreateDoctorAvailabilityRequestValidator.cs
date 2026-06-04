using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Nabd.Application.DTOs.Requests.Doctor;

namespace Nabd.Application.Validators.Configuration.Doctor
{
    public class CreateDoctorAvailabilityRequestValidator : AbstractValidator<CreateDoctorAvailabilityRequest>
    {
        public CreateDoctorAvailabilityRequestValidator()
        {
            RuleFor(x => x.StartTime)
                .NotEmpty()
                .WithMessage("Start time is required");

            RuleFor(x => x.EndTime)
                .NotEmpty()
                .GreaterThan(x => x.StartTime)
                .WithMessage("End time must be after start time");
        }
    }
}
