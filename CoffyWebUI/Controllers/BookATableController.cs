using CoffyWebUI.Dtos.BookingDtos;
using CoffyWebUI.Dtos.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CoffyWebUI.Controllers
{
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7113/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                ViewBag.location = values.Select(x => x.Location).FirstOrDefault();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
        {
            createBookingDto.Description = "Rezervasyon Alındı";

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7113/api/Contact");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                ViewBag.location = values.Select(x => x.Location).FirstOrDefault();
            }

            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7113/api/Booking", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            else
            {
                var errorContent=await responseMessage.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorContent);
            }
                return View();
        }
    }
}
