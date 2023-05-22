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

        public DbSet<Projeto_ESFase2.Models.User> Users { get; set; } 
        public DbSet<Projeto_ESFase2.Models.Competition> Competitions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Competition>().ToTable("Competition");

        }
    }
}
