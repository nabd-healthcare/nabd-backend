using AutoMapper;
using Nabd.Application.DTOs.Requests.Review;
using Nabd.Application.DTOs.Responses.Review;
using Nabd.Core.Entities.System.Review;

namespace Nabd.Application.Mappers
{
    public class ReviewMappingProfile : Profile
    {
        public ReviewMappingProfile()
        {
            #region Doctor Review Mappings
            CreateMap<DoctorReview, DoctorReviewResponse>();
            CreateMap<CreateDoctorReviewRequest, DoctorReview>();
            CreateMap<UpdateDoctorReviewRequest, DoctorReview>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            #endregion


        }
    }
}
