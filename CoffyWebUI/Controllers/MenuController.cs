using CoffyWebUI.Dtos.BasketDtos;
using CoffyWebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CoffyWebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            //id = int.Parse(TempData["customerSelectedTable"].ToString());
            ViewBag.v = id;
            //TempData["customerSelectedTable"] = id;

            var client = _httpClientFactory.CreateClient();


            var responseMessage = await client.GetAsync("https://localhost:7113/api/Product/ProductListWithCategory");

            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsondata);
            return View(values);

        }
        [HttpPost]
        public async Task<IActionResult> AddBasket(int id, int menuTableId)
        {

            if (menuTableId == 0)
            {
                return BadRequest("MenuTableId 0 geliyor");
            }
            CreateBasketDto createBasketDto = new CreateBasketDto
            {
                ProductID = id,
                MenuTableID = menuTableId
            };

            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createBasketDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7113/api/Basket", stringContent);

            var client2 = _httpClientFactory.CreateClient();
            //var jsondata2 = JsonConvert.SerializeObject(updateCategoryDto);
            //StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            await client2.GetAsync("https://localhost:7113/api/MenuTables/ChangeMenuTableStatusToTrue?id="+menuTableId);


            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Json(createBasketDto);
        }
    }
}
