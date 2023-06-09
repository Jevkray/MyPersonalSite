var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.Run();
