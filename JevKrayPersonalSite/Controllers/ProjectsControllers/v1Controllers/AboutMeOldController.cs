using JevKrayPersonalSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JevKrayPersonalSite.Controllers.ProjectsControllers.OldControllers
{
    public class AboutMeOldController : Controller
    {
        private readonly ILogger<AboutMeOldController> _logger;

        public AboutMeOldController(ILogger<AboutMeOldController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult AboutMe()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
