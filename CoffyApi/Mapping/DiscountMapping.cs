using AutoMapper;
using Coffy.DtoLayer.DiscountDto;
using Coffy.EntityLayer.Entities;

namespace CoffyApi.Mapping
{
    public class DiscountMapping : Profile
    {
        public DiscountMapping() 
        {
            CreateMap<Discount, ResultDiscountDto>().ReverseMap();
            CreateMap<Discount, CreateDiscountDto>().ReverseMap();
            CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
            CreateMap<Discount, GetDiscountDto>().ReverseMap();

        }
    }
}
