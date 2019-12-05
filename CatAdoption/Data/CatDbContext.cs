using CatAdoption.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatAdoption.Data
{
    public class CatDbContext : DbContext
    {
        public DbSet<Cat> Cats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=Cats;Trusted_Connection=True;";

            optionsBuilder.UseSqlServer(connectionString);

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
                },
                new Cat()
                {
                    CatId = 2,
                    Name = "Kyrie",
                    Gender = "Male",
                    Age = 4,
                    Bio = "He has a lot to say..."
                },
                new Cat()
                {
                    CatId = 3,
                    Name = "Crusher",
                    Gender = "Male",
                    Age = 4,
                    Bio = "His neck is a little crooked."
                },
                new Cat()
                {
                    CatId = 4,
                    Name = "Kelly",
                    Gender = "Female",
                    Age = 4,
                    Bio = "Not a real cat."
                });

        }
    }
}
