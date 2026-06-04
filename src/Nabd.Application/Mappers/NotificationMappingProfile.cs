using AutoMapper;
using Nabd.Application.DTOs.Requests.Notification;
using Nabd.Application.DTOs.Responses.Notification;
using Nabd.Core.Entities.System;

namespace Nabd.Application.Mappers
{
    public class NotificationMappingProfile : Profile
    {
        public NotificationMappingProfile()
        {
            #region Notification Mappings
            CreateMap<Notification, NotificationResponse>();
            CreateMap<CreateNotificationRequest, Notification>();
            #endregion
        }
    }
}
