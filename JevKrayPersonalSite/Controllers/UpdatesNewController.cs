using Microsoft.AspNetCore.Mvc;
using JevKrayPersonalSite.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using JevKrayPersonalSite.PrivateServices.PrivateBackgroundServices;
using System.Text;
using JevKrayPersonalSite.DAL;

namespace JevKrayPersonalSite.Controllers
{
    public class UpdatesNewController : Controller
    {
        private readonly ILogger<UpdatesNewController> _logger;
        private readonly JevkSiteDbContext _dbContext;

        public UpdatesNewController(JevkSiteDbContext dbContext, ILogger<UpdatesNewController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<IActionResult> Updates()
        {
            string filePath = "PrivateData/GitHubLog.html"; // Путь к файлу с данными GitHub

            var html = new StringBuilder();

            html.AppendLine("<div>");

            foreach (var commit in _dbContext.Commits)
            {
                html.AppendLine("<div class=\"updates-element plr-3 p-2 coloredboder-update block2050\">");
                html.AppendLine($"<div><b>Author:</b> {commit.AuthorName}</div>");
                html.AppendLine($"<div><b>Date:</b> {commit.Date.ToString("yyyy/MM/dd в HH:mm")}</div>");
                html.AppendLine("<br>");
                html.AppendLine("<div style=\"margin-left: 20px;\">");
                html.AppendLine($"{commit.Message}");
                html.AppendLine("</div>");
                html.AppendLine("<br>");
                html.AppendLine($"<div><a class=\"updates-githublink\" href=\"{commit.Link}\">Github</a></div>");
                html.AppendLine("</div>");
            }

            html.AppendLine("</div>");

            ViewBag.Html = html.ToString().Replace("\r\n", "");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
