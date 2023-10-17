using Microsoft.AspNetCore.Mvc;

namespace EstateUI.ViewComponents.HomeFilter
{
    public class HomePageFilter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
