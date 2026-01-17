using AutoMapper;
using Coffy.DtoLayer.NotificationDto;
using Coffy.EntityLayer.Entities;

namespace CoffyApi.Mapping
{
    public class NotificationMapping:Profile
    {
        public NotificationMapping()
        {
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
            CreateMap<Notification, GetNotificationDto>().ReverseMap();
        }
    }
}
