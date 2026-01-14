using AutoMapper;
using Coffy.DtoLayer.SliderDto;
using Coffy.EntityLayer.Entities;

namespace CoffyApi.Mapping
{
    public class SliderMapping : Profile
    {
        public SliderMapping()
        {
            CreateMap<Slider, ResultSliderDto>().ReverseMap();
        }
    }
}
