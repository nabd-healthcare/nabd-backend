using AutoMapper;
using Nabd.Application.DTOs.Requests.Patient;
using Nabd.Application.DTOs.Responses.Patient;
using Nabd.Core.Entities.Identity;
using Nabd.Core.Entities.Shared;

namespace Nabd.Application.Mappers
{
    public class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            #region Patient Mappings
            CreateMap<Patient, PatientResponse>();
            CreateMap<Patient, PatientBasicResponse>();
            CreateMap<CreatePatientRequest, Patient>();
            CreateMap<UpdatePatientRequest, Patient>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            #endregion

            #region Medical History Mappings
            CreateMap<MedicalHistoryItem, MedicalHistoryItemResponse>();
            CreateMap<CreateMedicalHistoryItemRequest, MedicalHistoryItem>();
            CreateMap<UpdateMedicalHistoryItemRequest, MedicalHistoryItem>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            #endregion
        }
    }
}
