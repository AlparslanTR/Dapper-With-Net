using EstateAPI.Dtos.Category;
using EstateAPI.Dtos.Estate;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EstateUI.ViewComponents.HomePagePopulationCity
{
    public class HomePagePopulationCity : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
