using Microsoft.AspNetCore.Http;
using Nabd.Core.Enums.Doctor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nabd.Application.DTOs.Requests.Doctor
{
    public class UpdateDoctorDocumentRequest
    {
        public IFormFile? DocumentFile { get; set; }

        public DoctorDocumentType? Type { get; set; }
    }
}
