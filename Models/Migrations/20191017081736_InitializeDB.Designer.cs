﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using sample_netcore.Models.Context;

namespace sample_netcore.Models.Migrations
{
    [DbContext(typeof(SampleDbContext))]
    [Migration("20191017081736_InitializeDB")]
    partial class InitializeDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("sample.domain.Models.Dish", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid>("DishCategoryId");

                    b.Property<string>("DishName");

                    b.Property<bool>("IsAvailable");

                    b.Property<double>("UnitPrice");

                    b.HasKey("Id");

                    b.HasIndex("DishCategoryId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("sample.domain.Models.DishCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DishCategoryName");

                    b.Property<bool>("IsAvailable");

                    b.HasKey("Id");

                    b.ToTable("DishCategories");
                });

            modelBuilder.Entity("sample.domain.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime?>("EmpBirthDate");

                    b.Property<string>("EmpName");

                    b.Property<bool>("IsActive");

                    b.HasKey("Id");

                    b.HasIndex("EmpName");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("sample.domain.Models.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("DiscountPercent");

                    b.Property<Guid?>("EmployeeId");

                    b.Property<double>("TotalAfterDiscount");

                    b.Property<double>("TotalBeforeDiscount");

                    b.HasKey("OrderId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("sample.domain.Models.OrderDetail", b =>
                {
                    b.Property<Guid>("OrderId");

                    b.Property<int>("DishId");

                    b.Property<int>("Quantity");

                    b.Property<Guid?>("TableId");

                    b.HasKey("OrderId", "DishId");

                    b.HasIndex("TableId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("sample_netcore.Models.Table", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsAvailable");

                    b.HasKey("Id");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("sample.domain.Models.Dish", b =>
                {
                    b.HasOne("sample.domain.Models.DishCategory", "DishCategory")
                        .WithMany("Dishs")
                        .HasForeignKey("DishCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("sample.domain.Models.Order", b =>
                {
                    b.HasOne("sample.domain.Models.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("sample.domain.Models.OrderDetail", b =>
                {
                    b.HasOne("sample_netcore.Models.Table", "Table")
                        .WithMany("OrderDetails")
                        .HasForeignKey("TableId");
                });
#pragma warning restore 612, 618
        }
    }
}