using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace JevKrayPersonalSite.Routing
{
    public static class RoutingConfiguration
    {
        public static void ConfigureRoutes(IEndpointRouteBuilder endpoints, bool selectedV2)
        {
            if (selectedV2 == false)
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=AboutMeOld}/{action=AboutMe}/{id?}");

                endpoints.MapControllerRoute(
                    name: "updates",
                    pattern: "Updates",
                    defaults: new { controller = "UpdatesOld", action = "Updates" });

                endpoints.MapControllerRoute(
                    name: "projects",
                    pattern: "Projects",
                    defaults: new { controller = "ProjectsOld", action = "Projects" });
            }
            else
            {
                //Home Controller
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=HomeNew}/{action=Home}/{id?}");

                endpoints.MapControllerRoute(
                    name: "education",
                    pattern: "Education",
                    defaults: new { controller = "HomeNew", action = "Education" });

                endpoints.MapControllerRoute(
                    name: "info",
                    pattern: "Info",
                    defaults: new { controller = "HomeNew", action = "Info" });

                endpoints.MapControllerRoute(
                    name: "privacy",
                    pattern: "Privacy",
                    defaults: new { controller = "HomeNew", action = "Privacy" });

                endpoints.MapControllerRoute(
                    name: "resume",
                    pattern: "Resume",
                    defaults: new { controller = "HomeNew", action = "Resume" });

                endpoints.MapControllerRoute(
                    name: "skills",
                    pattern: "Skills",
                    defaults: new { controller = "HomeNew", action = "Skills" });

                //Projects Controller
                endpoints.MapControllerRoute(
                    name: "projects",
                    pattern: "Projects",
                    defaults: new { controller = "ProjectsNew", action = "Projects" });

                //Updates Controller
                endpoints.MapControllerRoute(
                    name: "updates",
                    pattern: "Updates",
                    defaults: new { controller = "UpdatesNew", action = "Updates" });
            }

            endpoints.MapControllerRoute(
                name: "mailapi",
                pattern: "mailsender",
                defaults: new { controller = "Mailapi", api = "Mailsender" });
        }
    }
}