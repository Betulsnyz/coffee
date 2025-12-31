using Microsoft.AspNetCore.Mvc;

namespace CoffyWebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
