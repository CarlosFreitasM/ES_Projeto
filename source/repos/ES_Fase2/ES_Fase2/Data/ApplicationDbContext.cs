#nullable disable
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ES_Fase2.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ES_Fase2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<ES_Fase2.Models.User> Users { get; set; }
        public virtual DbSet<ES_Fase2.Models.Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("dbo.User");
            modelBuilder.Entity<Category>().ToTable("dbo.Category");

            modelBuilder.Entity<User>()
                .Property(p => p.Nome).IsRequired(required: false);
            modelBuilder.Entity<User>()
                .Property(p => p.Email).IsRequired(required: false);
            modelBuilder.Entity<User>()
                .Property(p => p.Password).IsRequired(required: false);
            modelBuilder.Entity<User>()
                .Property(p => p.Password).IsRequired(required: false);
            modelBuilder.Entity<Category>()
                .Property(p => p.Nome).IsRequired(required: false);


        }
    }


}