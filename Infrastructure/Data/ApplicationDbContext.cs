using Core.Entities.ContentEntity;
using Core.Entities.DocumentEntity;
using Core.Entities.HistoryEntity;
using Core.Entities.ProjectEntity;
using Core.Entities.ProjectUserEntity;
using Core.Entities.RefreshTokenEntity;
using Core.Entities.UserEntity;
using Infrastructure.Data.SeedData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options) { }
        public DbSet<Document> Document { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<ProjectUser> ProjectUser { get; set; }
        public DbSet<Content> Content { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new FileConfiguration());
            builder.ApplyConfiguration(new HistoryConfiguration());
            builder.ApplyConfiguration(new ProjectConfiguration());
            builder.ApplyConfiguration(new RefreshTokenConfiguration());
            builder.ApplyConfiguration(new ProjectUserConfiguration());
            builder.ApplyConfiguration(new ContentConfiguration());
            builder.Seed();
            base.OnModelCreating(builder);
        }
    }
}
