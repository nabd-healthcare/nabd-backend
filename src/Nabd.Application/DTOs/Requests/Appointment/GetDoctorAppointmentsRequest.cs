using Nabd.Application.DTOs.Common.Pagination;
using Nabd.Core.Enums.Appointments;
using System;

namespace Nabd.Application.DTOs.Requests.Appointment
{
    public class GetDoctorAppointmentsRequest : PaginationParams
    {
        public GetDoctorAppointmentsRequest()
        {
            // Override default page size to 12 for doctor appointments
            PageSize = 12;
        }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public AppointmentStatus? Status { get; set; }
        public string SortBy { get; set; } = "appointmentDate";
        public string SortOrder { get; set; } = "desc";
    }
}
