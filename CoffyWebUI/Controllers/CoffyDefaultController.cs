using Microsoft.AspNetCore.Mvc;

namespace CoffyWebUI.Controllers
{
    public class CoffyDefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
        
    }
}
