using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Nabd.Application.DTOs.Requests.Doctor;

namespace Nabd.Application.Validators.Configuration.Doctor
{
    public class UpdateDoctorDocumentRequestValidator : AbstractValidator<UpdateDoctorDocumentRequest>
    {
        public UpdateDoctorDocumentRequestValidator()
        {
            RuleFor(x => x.Type)
                .IsInEnum()
                .When(x => x.Type.HasValue)
                .WithMessage("Invalid document type");
        }
    }
}
