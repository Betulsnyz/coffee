using CoffyWebUI.Dtos.RapidApiDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoffyWebUI.Controllers
{
    public class FoodRapidApiController : Controller
    {

        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=40&tags=under_30_minutes"),
                Headers =
    {
        { "x-rapidapi-key", "8bd6913c05mshcc94262f7f0b4f1p1e1504jsnf144f05476b3" },
        { "x-rapidapi-host", "tasty.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                //var value =JsonConvert.DeserializeObject<List<ResultTastyApi>>(body);
                //return View(value.ToList());

                var root=JsonConvert.DeserializeObject<RootTastyApi>(body);
                var values = root.Results;
                return View(values.ToList());
            }
            
        }
    }
}
