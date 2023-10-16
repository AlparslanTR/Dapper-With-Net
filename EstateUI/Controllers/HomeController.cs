using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EstateUI.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}