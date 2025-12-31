using Microsoft.AspNetCore.Mvc;

namespace CoffyWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
