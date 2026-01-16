using AutoMapper;
using Coffy.BusinessLayer.Abstract;
using Coffy.DtoLayer.ProductDto;
using Coffy.DtoLayer.SocialMediaDto;
using Coffy.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _SocialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _SocialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_SocialMediaService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            _SocialMediaService.TAdd(new SocialMedia()
            {
                Title = createSocialMediaDto.Title,
                Url = createSocialMediaDto.Url,
                Icon = createSocialMediaDto.Icon
                
            });
            return Ok("sosyal medya bilgisi başarılı bir şekilde oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _SocialMediaService.TGetbyID(id);
            _SocialMediaService.TDelete(value);
            return Ok("sosyal medya bilgisi başarılı bir şekilde silindi");
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            _SocialMediaService.TUpdate(new SocialMedia()
            {
                Url = updateSocialMediaDto.Url,
                Title = updateSocialMediaDto.Title,
                SocialMediaID = updateSocialMediaDto.SocialMediaID,
                Icon = updateSocialMediaDto.Icon
            });
            return Ok("sosyal medya bilgisi başarılı bir şekilde güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var value = _SocialMediaService.TGetbyID(id);
            return Ok(value);
        }
    }
}
