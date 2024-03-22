using JevKrayPersonalSite.Models;
using Microsoft.EntityFrameworkCore;

namespace JevKrayPersonalSite.DAL
{
    public class JevkSiteDbContext : DbContext
    {
        public DbSet<CommitModel> Commits { get; set; }

        public DbSet<CapchaSessionModel> CapchaSessions { get; set; }

        public DbSet<ProjectModel> Projects { get; set; }

        public DbSet<ProjectPictureModel> ProjectPictures { get; set; }

        public JevkSiteDbContext(DbContextOptions<JevkSiteDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectModel>()
                .HasMany(p => p.ProjectPictures)
                .WithOne()
                .HasForeignKey(p => p.ProjectId);

            modelBuilder.Entity<CommitModel>().HasData(
                new CommitModel { Id = 1, AuthorName = "test", Date = DateTime.Now, Link = "https://google.com", Name = "test", Message = "test" }
                );

            base.OnModelCreating(modelBuilder);
        }

        public async Task DeleteExpiredCapchaSessions()
        {
            var expirationTime = DateTime.Now.AddMinutes(-5);

            var expiredSessions = await CapchaSessions
                .Where(session => session.CreatedAt < expirationTime)
                .ToListAsync();

            CapchaSessions.RemoveRange(expiredSessions);
            await SaveChangesAsync();
        }
    }
}
