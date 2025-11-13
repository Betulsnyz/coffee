using Microsoft.AspNetCore.Mvc;

namespace CoffyWebUI.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
