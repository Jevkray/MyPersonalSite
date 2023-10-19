using System.Diagnostics;
using System.Text;
using LibGit2Sharp;

namespace JevKrayPersonalSite.Services.BackgroundServices
{
    public class GitLogger
    {
        public static async void GetLogAsync()
        {
            using (var repo = new Repository("../"))
            {
                var commits = repo.Commits.QueryBy(new CommitFilter { SortBy = CommitSortStrategies.Topological | CommitSortStrategies.Time });
                var html = new StringBuilder();
                html.AppendLine("<div>");

                foreach (var commit in commits)
                {
                    html.AppendLine("<div style=\"margin-bottom: 20px;\">");
                    html.AppendLine("<hr>");
                    html.AppendLine($"<div><b>Author:</b> {commit.Author.Name}</div>");
                    html.AppendLine($"<div><b>Date:</b> {commit.Author.When.ToString("yyyy/MM/dd в HH:mm")}</div>");
                    html.AppendLine("<br>");
                    html.AppendLine("<div style=\"margin-left: 20px;\">");
                    html.AppendLine($"{commit.Message.Replace("\r\n", "\n").Replace("\n\n", "\n").Replace("\n", "<br>")}");
                    html.AppendLine("</div>");
                    html.AppendLine("<br>");
                    html.AppendLine("<hr>");
                    html.AppendLine("</div>");
                }

                html.AppendLine("</div>");

                File.WriteAllText("PrivateData/GitLog.html", html.ToString().Replace("\r\n", ""));
            }
        }
    }
}
