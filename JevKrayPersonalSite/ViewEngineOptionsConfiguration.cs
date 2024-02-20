using Microsoft.AspNetCore.Mvc.Razor;

public static class ViewEngineOptionsConfiguration
{
    public static void ConfigureViewEngineOptions(IServiceCollection services, bool useNewVersion)
    {
        services.Configure<RazorViewEngineOptions>(options =>
        {
            options.ViewLocationFormats.Clear();

            if (!useNewVersion)
            {
                options.ViewLocationFormats.Add("/Views/OldViews/{2}/{1}/{0}.cshtml");
                options.ViewLocationFormats.Add("/Views/OldViews/{1}/{0}.cshtml");
                options.ViewLocationFormats.Add("/Views/OldViews/{0}.cshtml");

                options.ViewLocationFormats.Add("/Views/OldViews/AboutMe/{0}.cshtml");
                options.ViewLocationFormats.Add("/Views/OldViews/Home/{0}.cshtml");
                options.ViewLocationFormats.Add("/Views/OldViews/Shared/{0}.cshtml");

                options.ViewLocationFormats.Add("/Views/OldViews/Projects/{0}.cshtml");
                options.ViewLocationFormats.Add("/Views/OldViews/Updates/{0}.cshtml");
            }
            else
            {
                options.ViewLocationFormats.Add("/Views/NewViews/{2}/{1}/{0}.cshtml");
                options.ViewLocationFormats.Add("/Views/NewViews/{1}/{0}.cshtml");
                options.ViewLocationFormats.Add("/Views/NewViews/{0}.cshtml");

                options.ViewLocationFormats.Add("/Views/NewViews/Home/{0}.cshtml");
                options.ViewLocationFormats.Add("/Views/NewViews/Shared/{0}.cshtml");

                options.ViewLocationFormats.Add("/Views/NewViews/Projects/{0}.cshtml");
                options.ViewLocationFormats.Add("/Views/NewViews/Updates/{0}.cshtml");
            }
        });
    }
}
