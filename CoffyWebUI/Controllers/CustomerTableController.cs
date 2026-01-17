using Microsoft.AspNetCore.Mvc;

namespace CoffyWebUI.Controllers
{
    public class CustomerTableController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
