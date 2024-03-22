using Microsoft.AspNetCore.Mvc.Razor;

public static class ViewEngineOptionsConfiguration
{
    public static void ConfigureViewEngineOptions(IServiceCollection services)
    {
        services.Configure<RazorViewEngineOptions>(options =>
        {
            options.ViewLocationFormats.Clear();

            options.ViewLocationFormats.Add("/Views/{2}/{1}/{0}.cshtml");
            options.ViewLocationFormats.Add("/Views/{1}/{0}.cshtml");
            options.ViewLocationFormats.Add("/Views/{0}.cshtml");

            options.ViewLocationFormats.Add("/Views/Home/{0}.cshtml");
            options.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");

            options.ViewLocationFormats.Add("/Views/Projects/{0}.cshtml");
            options.ViewLocationFormats.Add("/Views/Updates/{0}.cshtml");
        });
    }
}
