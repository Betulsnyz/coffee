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
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            _contactService.TAdd(new Contact()
            {
                FooterDescription = createContactDto.FooterDescription,
                Location = createContactDto.Location,
                Mail  = createContactDto.Mail,
                PhoneNumber = createContactDto.PhoneNumber,
                FooterTitle = createContactDto.FooterTitle,
                OpenDays = createContactDto.OpenDays,
                OpenDaysDescription = createContactDto.OpenDaysDescription,
                OpenHours = createContactDto.OpenHours
            });
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
            _contactService.TUpdate(new Contact()
            {
                PhoneNumber = updateContactDto.PhoneNumber, 
                Mail = updateContactDto.Mail,   
                ContactID = updateContactDto.ContactID,
                FooterDescription = updateContactDto.FooterDescription,
                Location = updateContactDto.Location,
                FooterTitle= updateContactDto.FooterTitle,
                OpenDays = updateContactDto.OpenDays,
                OpenHours= updateContactDto.OpenHours,
                OpenDaysDescription = updateContactDto.OpenDaysDescription
            });
            return Ok("iletişim başarılı bir şekilde güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetbyID(id);
            return Ok(value);
        }
    }
}
