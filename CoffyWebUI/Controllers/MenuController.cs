using Microsoft.AspNetCore.Mvc;

namespace CoffyWebUI.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
