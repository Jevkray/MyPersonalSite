using JevKrayPersonalSite.Models;
using JevKrayPersonalSite.Services.MailSender;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JevKrayPersonalSite.Controllers
{
    public class AboutMeController : Controller
    {
        private readonly ILogger<AboutMeController> _logger;

        public AboutMeController(ILogger<AboutMeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public ActionResult AboutMe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AboutMe(string Username, string Email, string Title, string Message)
        {
            var mail = CodeMail.CreatieMail(Username, Email, Title, Message);
            CodeMail.SendMail(mail);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
