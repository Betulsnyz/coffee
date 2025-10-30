using AutoMapper;
using Coffy.DtoLayer.ContactDto;
using Coffy.EntityLayer.Entities;

namespace CoffyApi.Mapping
{
    public class ContactMapping :Profile
    {
        public ContactMapping()
        {
            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, CreateContactDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();
            CreateMap<Contact, GetContactDto>().ReverseMap();
        }
        
    }
}
