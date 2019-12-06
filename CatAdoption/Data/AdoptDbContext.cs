using CatAdoption.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatAdoption.Data
{
    public class AdoptDbContext : DbContext
    {
        public AdoptDbContext(DbContextOptions<AdoptDbContext> options)
        {
        }
        public DbSet<Adoption> Adoptions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=Adopt;Trusted_Connection=True;";

            optionsBuilder.UseSqlServer(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adoption>().HasData(
                new Adoption()
                {
                    AdoptionId = 1,
                    UserId = "mroyski@gmail.com",
                    CatId = 1,
                    Name = "Herbert",
                    Gender = "Male",
                    Age = 4,
                    Bio = "A fluffy and handsome cuddle muffin."
                });
        }
    }
}
