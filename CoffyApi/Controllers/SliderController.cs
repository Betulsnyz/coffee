using AutoMapper;
using Coffy.BusinessLayer.Abstract;
using Coffy.DtoLayer.DiscountDto;
using Coffy.DtoLayer.SliderDto;
using Coffy.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;
        public SliderController(ISliderService sliderService, IMapper mapper)
        {
            _sliderService = sliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto createSliderDto)
        {
            _sliderService.TAdd(new Slider()
            {
                Description1 = createSliderDto.Description1,
                Description2 = createSliderDto.Description2,
                Description3 = createSliderDto.Description3,
                Title1 = createSliderDto.Title1,
                Title2 = createSliderDto.Title2,
                Title3 = createSliderDto.Title3
            });
            return Ok("Öne çıkan bilgisi eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetbyID(id);
            _sliderService.TDelete(value);
            return Ok("öne çıkan bilgisi silindi");
        }
        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderdto updateSliderdto)
        {
            _sliderService.TUpdate(new Slider()
            {
                SliderID= updateSliderdto.SliderID,
                Title1 = updateSliderdto.Title1,
                Title2 = updateSliderdto.Title2,
                Title3 = updateSliderdto.Title3,
                Description1 = updateSliderdto.Description1,
                Description2 = updateSliderdto.Description2,
                Description3 = updateSliderdto.Description3
            });
            return Ok("öne çıkan bilgisi güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            var value = _sliderService.TGetbyID(id);
            return Ok(value);
        }
    }
}
