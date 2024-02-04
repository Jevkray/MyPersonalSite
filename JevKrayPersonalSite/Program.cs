using JevKrayPersonalSite.DAL;
using JevKrayPersonalSite.PrivateServices.PrivateBackgroundServices;
using JevKrayPersonalSite.Workers;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

bool selectedV2 = false;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHostedService<Worker>(); // ������������ Worker ��� HostedService
builder.Services.AddScoped<GitHubLogger>();

builder.Services.AddDbContext<JevkSiteDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

if (selectedV2 == false)
{
    builder.Services.Configure<RazorViewEngineOptions>(options =>
    {
        options.ViewLocationFormats.Clear();
        options.ViewLocationFormats.Add("/Views/OldViews/{2}/{1}/{0}.cshtml");
        options.ViewLocationFormats.Add("/Views/OldViews/{1}/{0}.cshtml");
        options.ViewLocationFormats.Add("/Views/OldViews/{0}.cshtml");

        options.ViewLocationFormats.Add("/Views/OldViews/AboutMe/{0}.cshtml");
        options.ViewLocationFormats.Add("/Views/OldViews/Home/{0}.cshtml");
        options.ViewLocationFormats.Add("/Views/OldViews/Shared/{0}.cshtml");

        options.ViewLocationFormats.Add("/Views/OldViews/Projects/{0}.cshtml");
        options.ViewLocationFormats.Add("/Views/OldViews/Updates/{0}.cshtml");
    });
}
else
{
    builder.Services.Configure<RazorViewEngineOptions>(options =>
    {
        options.ViewLocationFormats.Clear();
        options.ViewLocationFormats.Add("/Views/NewViews/{2}/{1}/{0}.cshtml");
        options.ViewLocationFormats.Add("/Views/NewViews/{1}/{0}.cshtml");
        options.ViewLocationFormats.Add("/Views/NewViews/{0}.cshtml");

        options.ViewLocationFormats.Add("/Views/NewViews/Home/{0}.cshtml");
        options.ViewLocationFormats.Add("/Views/NewViews/Shared/{0}.cshtml");

        options.ViewLocationFormats.Add("/Views/NewViews/Projects/{0}.cshtml");
        options.ViewLocationFormats.Add("/Views/NewViews/Updates/{0}.cshtml");
    });
}

var app = builder.Build();

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

if (selectedV2 == false)
{
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=AboutMeOld}/{action=AboutMe}/{id?}");

    app.MapControllerRoute(
        name: "updates",
        pattern: "Updates",
        defaults: new { controller = "UpdatesOld", action = "Updates" });

    app.MapControllerRoute(
        name: "projects",
        pattern: "Projects",
        defaults: new { controller = "ProjectsOld", action = "Projects" });
}
else
{
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=HomeNew}/{action=Home}/{id?}");

    app.MapControllerRoute(
        name: "updates",
        pattern: "Updates",
        defaults: new { controller = "UpdatesNew", action = "Updates" });

    app.MapControllerRoute(
        name: "projects",
        pattern: "Projects",
        defaults: new { controller = "ProjectsNew", action = "Projects" });
}

app.MapControllerRoute(
    name: "mailapi",
    pattern: "mailsender",
    defaults: new { controller = "Mailapi", api = "Mailsender" });

// ��������� Worker � ������� ������
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
