using CoffyWebUI.Dtos.DiscountDtos;
using CoffyWebUI.Dtos.SliderDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoffyWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOfferComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultOfferComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();


            var responseMessage = await client.GetAsync("https://localhost:7113/api/Discount");

            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsondata);
            return View(values);

        }
    }
}
