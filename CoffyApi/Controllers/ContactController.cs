using AutoMapper;
using Coffy.BusinessLayer.Abstract;
using Coffy.DtoLayer.CategoryDto;
using Coffy.DtoLayer.ContactDto;
using Coffy.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.TGetListAll();
            return Ok(_mapper.Map<List<ResultContactDto>>(values));
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            var value = _mapper.Map<Contact>(createContactDto);
            _contactService.TAdd(value);
            return Ok("iletişim başarılı bir şekilde oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetbyID(id);
            _contactService.TDelete(value);
            return Ok("iletişim başarılı bir şekilde silindi");
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var value=_mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(value);
            return Ok("iletişim başarılı bir şekilde güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetbyID(id);
            return Ok(_mapper.Map<GetContactDto>(value));
        }
    }
}
