using Microsoft.AspNetCore.Mvc;

namespace EstateUI.ViewComponents.HomePageLastAdded
{
    public class HomePageLastAdded : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
