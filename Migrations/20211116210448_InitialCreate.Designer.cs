﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegionofTexasASP.Models;

namespace Final_Project.Migrations
{
    [DbContext(typeof(RegionofTexasDbContext))]
    [Migration("20211116210448_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21");

            modelBuilder.Entity("RegionofTexasASP.Models.FoodReviewer", b =>
                {
                    b.Property<int>("FoodReviewerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("FoodReviewerID");

                    b.ToTable("FoodReviewers");
                });

            modelBuilder.Entity("RegionofTexasASP.Models.Resturant", b =>
                {
                    b.Property<int>("ResturantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Rating")
                        .HasColumnType("REAL");

                    b.HasKey("ResturantID");

                    b.ToTable("Resturants");
                });

            modelBuilder.Entity("RegionofTexasASP.Models.ReviewResturant", b =>
                {
                    b.Property<int>("ResturantID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FoodReviewerID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ResturantID", "FoodReviewerID");

                    b.HasIndex("FoodReviewerID");

                    b.ToTable("ReviewResturants");
                });

            modelBuilder.Entity("RegionofTexasASP.Models.ReviewResturant", b =>
                {
                    b.HasOne("RegionofTexasASP.Models.FoodReviewer", "FoodReviewer")
                        .WithMany("ReviewResturants")
                        .HasForeignKey("FoodReviewerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RegionofTexasASP.Models.Resturant", "resturant")
                        .WithMany("ReviewResturants")
                        .HasForeignKey("ResturantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
