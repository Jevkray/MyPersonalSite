using JevKrayPersonalSite.DAL;
using JevKrayPersonalSite.PrivateServices.PrivateBackgroundServices;
using JevKrayPersonalSite.Workers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHostedService<Worker>(); // Регистрируем Worker как HostedService
builder.Services.AddScoped<GitHubLogger>();

builder.Services.AddDbContext<JevkSiteDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();
//var worker = app.Services.GetRequiredService<Worker>();
//worker.StartAsync(CancellationToken.None);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AboutMe}/{action=AboutMe}/{id?}");

app.MapControllerRoute(
    name: "updates",
    pattern: "Updates",
    defaults: new { controller = "Updates", action = "Updates" });

app.MapControllerRoute(
    name: "projects",
    pattern: "Projects",
    defaults: new { controller = "Projects", action = "Projects" });

app.MapControllerRoute(
    name: "mailapi",
    pattern: "mailsender",
    defaults: new { controller = "Mailapi", api = "Mailsender" });

// Запускаем Worker в фоновом потоке
Task.Run(async () =>
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var worker = services.GetRequiredService<Worker>();
        await worker.StartAsync(default);
    }
});

app.Run();
