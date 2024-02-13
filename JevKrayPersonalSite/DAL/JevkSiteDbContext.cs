using JevKrayPersonalSite.Models;
using Microsoft.EntityFrameworkCore;

namespace JevKrayPersonalSite.DAL
{
    public class JevkSiteDbContext : DbContext
    {
        public DbSet<CommitModel> Commits { get; set; }

        public JevkSiteDbContext(DbContextOptions<JevkSiteDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommitModel>().HasData(
                new CommitModel { Id = 1, AuthorName = "test", Date = DateTime.Now, Link = "https://google.com", Name = "test", Message = "test" }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
