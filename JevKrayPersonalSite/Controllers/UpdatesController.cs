using Microsoft.AspNetCore.Mvc;
using JevKrayPersonalSite.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using JevKrayPersonalSite.PrivateServices;

namespace JevKrayPersonalSite.Controllers
{
    public class UpdatesController : Controller
    {
        private readonly ILogger<UpdatesController> _logger;

        public UpdatesController(ILogger<UpdatesController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Updates()
        {
            var html = await GitHubLogger.GetCommits();
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
