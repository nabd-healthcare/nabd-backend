using Nabd.Core.Enums.Appointments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nabd.Application.DTOs.Requests.Consultation
{
    public class CreateConsultationTypeRequest
    {
        [Required(ErrorMessage = "Consultation type is required")]
        public ConsultationTypeEnum ConsultationTypeEnum { get; set; }
    }
}
