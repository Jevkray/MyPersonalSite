using JevKrayPersonalSite.DAL;
using JevKrayPersonalSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text;

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
