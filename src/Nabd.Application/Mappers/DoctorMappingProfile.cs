using AutoMapper;
using Nabd.Application.DTOs.Requests.Doctor;
using Nabd.Application.DTOs.Responses.Doctor;
using Nabd.Core.Entities.Common;
using Nabd.Core.Entities.Identity;
using Nabd.Core.Entities.Medical.Consultations;
using Nabd.Core.Entities.Medical.Schedules;
using Nabd.Core.Entities.Shared;

namespace Nabd.Application.Mappers
{
    public class DoctorMappingProfile : Profile
    {
        public DoctorMappingProfile()
        {
            #region Doctor Mappings
            CreateMap<Doctor, DoctorResponse>();
            CreateMap<Doctor, DoctorBasicResponse>();
            CreateMap<CreateDoctorRequest, Doctor>();
            CreateMap<UpdateDoctorRequest, Doctor>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            #endregion

            #region Doctor Availability Mappings
            CreateMap<DoctorAvailability, DoctorAvailabilityResponse>();
            CreateMap<CreateDoctorAvailabilityRequest, DoctorAvailability>();
            CreateMap<UpdateDoctorAvailabilityRequest, DoctorAvailability>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            #endregion

            #region Doctor Override Mappings
            CreateMap<DoctorOverride, DoctorOverrideResponse>();
            CreateMap<CreateDoctorOverrideRequest, DoctorOverride>();
            #endregion

            #region Doctor Consultation Mappings
            CreateMap<DoctorConsultation, DoctorConsultationResponse>();
            CreateMap<CreateDoctorConsultationRequest, DoctorConsultation>();
            CreateMap<UpdateDoctorConsultationRequest, DoctorConsultation>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            #endregion

            #region Doctor Document Mappings
            CreateMap<DoctorDocument, DoctorDocumentResponse>();
            CreateMap<CreateDoctorDocumentRequest, DoctorDocument>();
            CreateMap<UpdateDoctorDocumentRequest, DoctorDocument>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            #endregion
        }
    }
}
