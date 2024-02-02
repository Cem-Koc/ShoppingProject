﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingProject.Data.Context;

#nullable disable

namespace ShoppingProject.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ShoppingProject.Entity.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9a99ad62-b618-4dca-a254-5843255ab008"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2024, 2, 3, 0, 5, 10, 832, DateTimeKind.Local).AddTicks(1430),
                            IsDeleted = false,
                            Name = "Kazak"
                        },
                        new
                        {
                            Id = new Guid("9ec7d5a6-ee4a-4f21-885a-21a89e95559d"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2024, 2, 3, 0, 5, 10, 832, DateTimeKind.Local).AddTicks(1433),
                            IsDeleted = false,
                            Name = "T-Shirt"
                        });
                });

            modelBuilder.Entity("ShoppingProject.Entity.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2399fb31-9b98-4933-8681-3d6972de53d7"),
                            CategoryId = new Guid("9a99ad62-b618-4dca-a254-5843255ab008"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2024, 2, 3, 0, 5, 10, 832, DateTimeKind.Local).AddTicks(1584),
                            Description = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.",
                            IsDeleted = false,
                            Name = "Polo Yaka Kazak",
                            Price = 1500m,
                            Quantity = 200
                        },
                        new
                        {
                            Id = new Guid("33916a30-d643-47f7-b422-cd519dc1befe"),
                            CategoryId = new Guid("9ec7d5a6-ee4a-4f21-885a-21a89e95559d"),
                            CreatedBy = "Admin Test",
                            CreatedDate = new DateTime(2024, 2, 3, 0, 5, 10, 832, DateTimeKind.Local).AddTicks(1589),
                            Description = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.",
                            IsDeleted = false,
                            Name = "Polo Yaka T-Shirt",
                            Price = 500m,
                            Quantity = 100
                        });
                });

            modelBuilder.Entity("ShoppingProject.Entity.Entities.Product", b =>
                {
                    b.HasOne("ShoppingProject.Entity.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ShoppingProject.Entity.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
