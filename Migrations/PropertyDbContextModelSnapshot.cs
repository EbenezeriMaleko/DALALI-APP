﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Webapp.Data;

#nullable disable

namespace Webapp.Migrations
{
    [DbContext(typeof(PropertyDbContext))]
    partial class PropertyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("Webapp.Models.Property", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("BLOB");

                    b.Property<int>("NumberOfBathrooms")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfBedrooms")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PropertyName")
                        .HasColumnType("TEXT");

                    b.Property<double>("SquareFootage")
                        .HasColumnType("REAL");

                    b.HasKey("PropertyId");

                    b.ToTable("AgentTable");
                });
#pragma warning restore 612, 618
        }
    }
}