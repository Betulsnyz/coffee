using CoffyWebUI.Dtos.SliderDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CoffyWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultSliderComponentPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultSliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            
            
            var responseMessage = await client.GetAsync("https://localhost:7113/api/Slider");

            var jsondata = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsondata);
            return View(values);

        }
    }
}
