using JevKrayPersonalSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JevKrayPersonalSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

        public IActionResult AboutSite()
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