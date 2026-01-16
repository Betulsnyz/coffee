using AutoMapper;
using Coffy.BusinessLayer.Abstract;
using Coffy.DtoLayer.ContactDto;
using Coffy.DtoLayer.DiscountDto;
using Coffy.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _discountService.TGetListAll();
            return Ok(_mapper.Map<List<ResultDiscountDto>>(values));
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            createDiscountDto.Status = false;
            var value = _mapper.Map<Discount>(createDiscountDto);

            _discountService.TAdd(value);
            return Ok("indirim  başarılı bir şekilde oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetbyID(id);
            _discountService.TDelete(value);
            return Ok("indirim başarılı bir şekilde silindi");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            updateDiscountDto.Status = false;
            var value = _mapper.Map<Discount>(updateDiscountDto);

            _discountService.TUpdate(value);
            return Ok("indirim başarılı bir şekilde güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountService.TGetbyID(id);
            return Ok(_mapper.Map<GetDiscountDto>(value));
        }

        [HttpGet("ChangeStatusToTrue/{id}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _discountService.TChangeStatusToTrue(id);
            return Ok("Ürün İndirimi Aktifleştirildi");
        }

        [HttpGet("ChangeStatusToFalse/{id}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _discountService.TChangeStatusToFalse(id);
            return Ok("Ürün İndirimi Pasif Hale Getirildi");
        }

        [HttpGet("GetListByStatusTrue")]
        public IActionResult GetListByStatusTrue()
        {
            return Ok(_discountService.TGetListByStatusTrue());
        }

    }
}
