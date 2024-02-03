using JevKrayPersonalSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JevKrayPersonalSite.Controllers
{
    public class ProjectsOldController : Controller
    {
        private readonly ILogger<ProjectsOldController> _logger;

        public ProjectsOldController(ILogger<ProjectsOldController> logger)
        {
            _logger = logger;
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult GazorpGameStore()
        {
            return View();
        }

        public IActionResult Ferma()
        {
            return View();
        }

        public IActionResult WPumper()
        {
            return View();
        }

        public IActionResult SteamChecker()
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
