using AutoMapper;
using Nabd.Application.DTOs.Common.Address;
using Nabd.Core.Entities.Common;
using Nabd.Core.Entities.Shared;

namespace Nabd.Application.Mappers
{
    public class CommonMappingProfile : Profile
    {
        public CommonMappingProfile()
        {
            #region Address Mappings
            CreateMap<Address, AddressResponse>();
            CreateMap<CreateAddressRequest, Address>();
            CreateMap<UpdateAddressRequest, Address>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            #endregion
        }
    }
}
