namespace JevKrayPersonalSite.Routing
{
    public static class RoutingConfiguration
    {
        public static void ConfigureRoutes(IEndpointRouteBuilder endpoints, bool useNewVersion)
        {
            if (useNewVersion == false)
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
                    pattern: "{controller=Home}/{action=Home}/{id?}");

                endpoints.MapControllerRoute(
                    name: "education",
                    pattern: "Education",
                    defaults: new { controller = "Home", action = "Education" });

                endpoints.MapControllerRoute(
                    name: "info",
                    pattern: "Info",
                    defaults: new { controller = "Home", action = "Info" });

                endpoints.MapControllerRoute(
                    name: "privacy",
                    pattern: "Privacy",
                    defaults: new { controller = "Home", action = "Privacy" });

                endpoints.MapControllerRoute(
                    name: "resume",
                    pattern: "Resume",
                    defaults: new { controller = "Home", action = "Resume" });

                endpoints.MapControllerRoute(
                    name: "skills",
                    pattern: "Skills",
                    defaults: new { controller = "Home", action = "Skills" });

                //Projects Controller
                endpoints.MapControllerRoute(
                    name: "projects",
                    pattern: "Projects",
                    defaults: new { controller = "Projects", action = "Projects" });

                //Updates Controller
                endpoints.MapControllerRoute(
                    name: "updates",
                    pattern: "Updates",
                    defaults: new { controller = "Updates", action = "Updates" });
            }

            endpoints.MapControllerRoute(
                name: "mailapi",
                pattern: "mailsender",
                defaults: new { controller = "Mailapi", api = "Mailsender" });
        }
    }
}