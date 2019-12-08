﻿// <auto-generated />
using CatAdoption.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CatAdoption.Migrations
{
    [DbContext(typeof(CatDbContext))]
    [Migration("20191208000315_NewSeedData")]
    partial class NewSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CatAdoption.Models.Cat", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CatId");

                    b.ToTable("Cats");

                    b.HasData(
                        new
                        {
                            CatId = 1,
                            Age = 4,
                            Bio = "A fluffy and handsome cuddle muffin.",
                            Gender = "Male",
                            ImagePath = "herbert.jpg",
                            Name = "Herbert"
                        },
                        new
                        {
                            CatId = 2,
                            Age = 4,
                            Bio = "He has a lot to say...",
                            Gender = "Male",
                            ImagePath = "kyrie.jpg",
                            Name = "Kyrie"
                        },
                        new
                        {
                            CatId = 3,
                            Age = 4,
                            Bio = "His neck is a little crooked.",
                            Gender = "Male",
                            ImagePath = "crusher.jpg",
                            Name = "Crusher"
                        },
                        new
                        {
                            CatId = 4,
                            Age = 4,
                            Bio = "Not a real cat.",
                            Gender = "Female",
                            ImagePath = "kelly.jpg",
                            Name = "Kelly"
                        },
                        new
                        {
                            CatId = 5,
                            Age = 2,
                            Bio = "Auspicious One",
                            Gender = "Female",
                            ImagePath = "shiva.jpg",
                            Name = "Shiva"
                        },
                        new
                        {
                            CatId = 6,
                            Age = 1,
                            Bio = "Fast as heck",
                            Gender = "Male",
                            ImagePath = "scooter.jpg",
                            Name = "Scooter"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
