using AutoMapper;
using Coffy.DtoLayer.AboutDto;
using Coffy.EntityLayer.Entities;

namespace CoffyApi.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
            CreateMap<About, GetAboutDto>().ReverseMap();

            
        }
    }
}
