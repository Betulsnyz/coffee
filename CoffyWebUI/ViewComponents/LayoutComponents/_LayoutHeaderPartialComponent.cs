using Microsoft.AspNetCore.Mvc;

namespace CoffyWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutHeaderPartialComponent :ViewComponent 
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
