using Microsoft.AspNetCore.Mvc;

namespace EstateUI.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
