using JevKrayPersonalSite.DAL;
using JevKrayPersonalSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace JevKrayPersonalSite.Controllers.ProjectsControllers.OldControllers
{
    public class UpdatesOldController : Controller
    {
        private readonly ILogger<UpdatesOldController> _logger;
        private readonly JevkSiteDbContext _dbContext;

        public UpdatesOldController(JevkSiteDbContext dbContext, ILogger<UpdatesOldController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<IActionResult> Updates()
        {
            var commits = await _dbContext.Commits.ToListAsync();

            return View(commits);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
