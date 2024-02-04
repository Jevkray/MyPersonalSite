using JevKrayPersonalSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JevKrayPersonalSite.Controllers
{
    public class HomeNewController : Controller
    {
        private readonly ILogger<HomeNewController> _logger;

        public HomeNewController(ILogger<HomeNewController> logger)
        {
            _logger = logger;
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Education()
        {
            return View();
        }

        public IActionResult Skills()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }


        public IActionResult Resume()
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