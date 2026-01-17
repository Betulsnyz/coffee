using AutoMapper;
using Coffy.DtoLayer.MessageDto;
using Coffy.EntityLayer.Entities;

namespace CoffyApi.Mapping
{
    public class MessageMapping:Profile
    {
        public MessageMapping()
        {
                CreateMap<CreateMessageDto,Message>().ReverseMap();
                CreateMap<ResultMessageDto,Message>().ReverseMap();
                CreateMap<UpdateMessageDto,Message>().ReverseMap();
                CreateMap<GetMessageDto,Message>().ReverseMap();
        }
    }
}
