using Microsoft.AspNetCore.Mvc;

namespace CoffyWebUI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFound404Page()
        {
            return View();
        }
    }
}
