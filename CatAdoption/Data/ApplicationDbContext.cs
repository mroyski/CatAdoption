using System;
using System.Collections.Generic;
using System.Text;
using CatAdoption.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CatAdoption.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Cat> Cats { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=CatAdoption;Trusted_Connection=True;";

            optionsBuilder.UseSqlServer(connectionString);
            //.UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>().HasData(
                new Cat()
                {
                    CatId = 1,
                    Name = "Herbert",
                    Gender = "Male",
                    Age = 4,
                    Bio = "A fluffy and handsome cuddle muffin."
                });
        }
    }
}
