using Microsoft.AspNetCore.Mvc;

namespace CoffyWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
