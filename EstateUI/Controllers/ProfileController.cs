using Microsoft.AspNetCore.Mvc;

namespace EstateUI.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MyProfile()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult MyProfile()
        //{
        //    return View();
        //}
    }
}
