using JevKrayPersonalSite.DAL;
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

#pragma warning disable CS1998 // В асинхронном методе отсутствуют операторы await, будет выполнен синхронный метод
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
#pragma warning restore CS1998 // В асинхронном методе отсутствуют операторы await, будет выполнен синхронный метод
        {
            var capchaCleanupTask = StartCapchaCleanupTask(stoppingToken);
            var gitHubUpdateTask = StartGitHubUpdateTask(stoppingToken);
        }

        private async Task StartCapchaCleanupTask(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<JevkSiteDbContext>();

                    try
                    {
                        await dbContext.DeleteExpiredCapchaSessions();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка во время удаления просроченных сеансов CAPTCHA: {ex.Message}");
                    }
                }
                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }

        private async Task StartGitHubUpdateTask(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var gitHubLogger = scope.ServiceProvider.GetRequiredService<GitHubLogger>();
                    await gitHubLogger.UpdateCommitsOnDB();
                }


                await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
            }
        }
    }
}
