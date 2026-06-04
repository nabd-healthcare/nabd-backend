using AutoMapper;
using Nabd.Application.DTOs.Requests.Consultation;
using Nabd.Application.DTOs.Responses.Consultation;
using Nabd.Core.Entities.Medical.Consultations;

namespace Nabd.Application.Mappers
{
    public class ConsultationMappingProfile : Profile
    {
        public ConsultationMappingProfile()
        {
            #region Consultation Type Mappings
            CreateMap<ConsultationType, ConsultationTypeResponse>();
            CreateMap<CreateConsultationTypeRequest, ConsultationType>();
            #endregion
        }
    }
}
