using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projeto_ESFase2.Models;

namespace Projeto_ESFase2.Data
{
    public class ES2Context : DbContext
    {
        public ES2Context (DbContextOptions<ES2Context> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } 
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Nominee> Nominees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CompetitionNominee>()
                .HasKey(cn => new { cn.CompetitionId, cn.NomineeId });

            modelBuilder.Entity<CompetitionUser>()
                .HasKey(cu => new { cu.CompetitionId, cu.UserId });

            modelBuilder.Entity<CompetitionNominee>()
                .HasOne(cn => cn.Competition)
                .WithMany(c => c.CompetitionNominees)
                .HasForeignKey(cn => cn.CompetitionId);

            modelBuilder.Entity<CompetitionNominee>()
                .HasOne(cn => cn.Nominee)
                .WithMany(c => c.CompetitionNominees)
                .HasForeignKey(cn => cn.NomineeId);

            modelBuilder.Entity<CompetitionUser>()
                .HasOne(cu => cu.Competition)
                .WithMany(c => c.CompetitionUsers)
                .HasForeignKey(cu => cu.CompetitionId);

            modelBuilder.Entity<CompetitionUser>()
                .HasOne(cu => cu.User)
                .WithMany(u => u.CompetitionUsers)
                .HasForeignKey(cu => cu.UserId);
        }

    }
}
