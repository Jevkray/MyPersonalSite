using System;
using System.Text;
using System.Xml.Linq;
using Octokit;

namespace JevKrayPersonalSite.Services
{
    public class GitHubLogger
    {
        public static async void GetCommits()
        {
            string path = "PrivateData/PrivateData.txt";
            string token = "";
            using (var sr = new System.IO.StreamReader(path))
            {
                for (int i = 1; i < 21; i++)
                    sr.ReadLine();
                    token = sr.ReadLine();
            }
            var client = new GitHubClient(new ProductHeaderValue("GitCommiter"));
            client.Credentials = new Credentials(token);
            var commits = await client.Repository.Commit.GetAll("Jevkray", "MyPersonalSite");

            var html = new StringBuilder();
            html.AppendLine("<div>");

            foreach (var commit in commits)
            {
                html.AppendLine("<div class=\"updates-element\" style=\"margin-bottom: 20px;\">");
                html.AppendLine("<hr style=\"color: black;\">");
                html.AppendLine($"<div><b>Author:</b> {commit.Commit.Author.Name}</div>");
                html.AppendLine($"<div><b>Date:</b> {commit.Commit.Author.Date.AddHours(3).ToString("yyyy/MM/dd в HH:mm")}</div>");
                html.AppendLine("<br>");
                html.AppendLine("<div style=\"margin-left: 20px;\">");
                html.AppendLine($"{commit.Commit.Message.Replace("\r\n", "\n").Replace("\n\n", "\n").Replace("\n", "<br>")}");
                html.AppendLine("</div>");
                html.AppendLine("<br>");
                html.AppendLine($"<div><a class=\"updates-githublink\" href=\"https://github.com/Jevkray/MyPersonalSite/commit/{commit.Sha}\">Github</a></div>");
                html.AppendLine("<hr style=\"color: black;\">");
                html.AppendLine("</div>");
            }

            html.AppendLine("</div>");

            File.WriteAllText("PrivateData/GitHubLog.html", html.ToString().Replace("\r\n", ""));
        }
    }
}
