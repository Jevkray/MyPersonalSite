using Microsoft.AspNetCore.Mvc;
using JevKrayPersonalSite.Models;
using System.Diagnostics;
using JevKrayPersonalSite.Services;

namespace JevKrayPersonalSite.Controllers
{
    public class UpdatesController : Controller
    {
        private readonly ILogger<UpdatesController> _logger;

        public UpdatesController(ILogger<UpdatesController> logger)
        {
            _logger = logger;
        }
        public IActionResult Updates()
        {
            GitHubLogger.GetCommits();
            var html = System.IO.File.ReadAllText("PrivateData/GitHubLog.html");
            ViewBag.Html = $"<div>{html}</div>";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
