using AutoMapper;
using Coffy.BusinessLayer.Abstract;
using Coffy.DataAccessLayer.Concrete;
using Coffy.DtoLayer.BookingDto;
using Coffy.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;
        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(_mapper.Map<List<ResultBookingDto>>(values));
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var value = _mapper.Map<Booking>(createBookingDto);
            _bookingService.TAdd(value);
            return Ok("Randevu başarılı bir şekilde oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetbyID(id);
            _bookingService.TDelete(value);
            return Ok("Randevu başarılı bir şekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var value=_mapper.Map<Booking>(updateBookingDto);
            _bookingService.TUpdate(value);
            return Ok("Randevu başarılı bir şekilde güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetbyID(id);
            return Ok(_mapper.Map<GetBookingDto>(value));
        }

        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingService.TBookingStatusApproved(id);
            return Ok("Rezervasyon Açıklaması Değiştirildi");
        }

        [HttpGet("BookingStatusCancelled/{id}")]
        public IActionResult BookingStatusCancelled(int id)
        {
            _bookingService.TBookingStatusCancelled(id);
            return Ok("Rezervasyon Açıklaması Değiştirildi");
        }

        [HttpGet("GetBookingStatusApproved")]
        public IActionResult GetBookingStatusApproved()
        {
            var context = new CoffyContext();
            var values = context.Bookings.Where(x => x.Description == "Rezervasyon Onaylandı").ToList();
            return Ok(values.ToList());
        }

        [HttpGet("GetBookingStatusCanceled")]
        public IActionResult GetBookingStatusCanceled()
        {
            var context = new CoffyContext();
            var values = context.Bookings.Where(x => x.Description == "Rezervasyon İptal Edildi").ToList();
            return Ok(values.ToList());
        }
        [HttpGet("GetBookingStatusReceived")]
        public IActionResult GetBookingStatusReceived()
        {
            var context = new CoffyContext();
            var values = context.Bookings.Where(x => x.Description == "Rezervasyon Alındı").ToList();
            return Ok(values.ToList());

        }
    }
}
