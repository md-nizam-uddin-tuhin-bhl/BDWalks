﻿// <auto-generated />
using System;
using BDWalksAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BDWalksAPI.Migrations
{
    [DbContext(typeof(BDWalkDbContext))]
    [Migration("20230913002707_seed data for difficuly and region")]
    partial class seeddatafordifficulyandregion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BDWalksAPI.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("766b3e6c-5c11-45f6-bc0d-0171a24857ff"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("5ba1df2a-0d81-4c68-bc46-d754068a71a5"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("9b99b0df-f4e6-4e7b-ae65-02ab2f5c9181"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("BDWalksAPI.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0ce38c42-8184-4d45-96c3-be74625dcfe7"),
                            Code = "Dha",
                            Name = "Dhaka",
                            RegionImageUrl = "www.http://Dhaka.com"
                        },
                        new
                        {
                            Id = new Guid("b6433f36-693e-469c-a754-3e78a90a5534"),
                            Code = "Bar",
                            Name = "Barisal",
                            RegionImageUrl = "www.http://Barisal.com"
                        },
                        new
                        {
                            Id = new Guid("454186c6-0fdf-4fc2-8d4d-5f6d592441ba"),
                            Code = "Sy",
                            Name = "Sylhet",
                            RegionImageUrl = "www.http://Sylhet.com"
                        });
                });

            modelBuilder.Entity("BDWalksAPI.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("walks");
                });

            modelBuilder.Entity("BDWalksAPI.Models.Domain.Walk", b =>
                {
                    b.HasOne("BDWalksAPI.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BDWalksAPI.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
