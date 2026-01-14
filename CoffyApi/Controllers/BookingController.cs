using Coffy.BusinessLayer.Abstract;
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

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
                Name = createBookingDto.Name,
                Phone = createBookingDto.Phone,
                Mail = createBookingDto.Mail,
                PersonCount = createBookingDto.PersonCount,
                Date = createBookingDto.Date,
                Description = createBookingDto.Description
            };
            _bookingService.TAdd(booking);
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
            Booking booking = new Booking()
            {
                BookingID = updateBookingDto.BookingID,
                Name = updateBookingDto.Name,
                Phone = updateBookingDto.Phone,
                Mail = updateBookingDto.Mail,
                PersonCount = updateBookingDto.PersonCount,
                Date = updateBookingDto.Date
            };
            _bookingService.TUpdate(booking);
            return Ok("Randevu başarılı bir şekilde güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetbyID(id);
            return Ok(value);
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
    }
}
