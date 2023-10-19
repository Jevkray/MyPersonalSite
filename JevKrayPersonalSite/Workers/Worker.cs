using JevKrayPersonalSite.PrivateServices.PrivateBackgroundServices;

namespace JevKrayPersonalSite.Workers
{
    public class Worker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public Worker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var gitHubLogger = scope.ServiceProvider.GetRequiredService<GitHubLogger>();
                    await gitHubLogger.UpdateCommitsOnDB();
                }

                await Task.Delay(600000);
            }
        }
    }
}
