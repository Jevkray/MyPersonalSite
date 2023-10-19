using JevKrayPersonalSite.PrivateServices.PrivateBackgroundServices;

namespace JevKrayPersonalSite.Workers
{
    public class Worker : BackgroundService
    {
        private readonly GitHubLogger _gitHubLogger;

        public Worker(GitHubLogger gitHubLogger)
        {
            _gitHubLogger = gitHubLogger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _gitHubLogger.GetCommitsAsync();
                await Task.Delay(300000);
            }
        }
    }
}
