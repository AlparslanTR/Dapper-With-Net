using EstateAPI.Dtos.Contact;
using EstateUI.Services.Email;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EstateUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService _emailService;

        public HomeController(IEmailService emailService)
        {
           _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public async Task <IActionResult> Contact(ContactDto request)
        {
            await _emailService.SendMail(request);
            return View();
        }
    }
}