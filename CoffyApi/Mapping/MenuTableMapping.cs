using AutoMapper;
using Coffy.DtoLayer.MenuTableDto;
using Coffy.DtoLayer.MessageDto;
using Coffy.EntityLayer.Entities;

namespace CoffyApi.Mapping
{
    public class MenuTableMapping:Profile
    {
        public MenuTableMapping()
        {
                CreateMap<MenuTable,CreateMenuTableDto>().ReverseMap();
                CreateMap<MenuTable,UpdateMenuTableDto>().ReverseMap();
                CreateMap<MenuTable,GetMenuTableDto>().ReverseMap();
                CreateMap<MenuTable,ResultMenuTableDto>().ReverseMap();
        }
    }
}
