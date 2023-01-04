﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OnlineClothes.Persistence.Context;

#nullable disable

namespace OnlineClothes.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230104152300_v1.1")]
    partial class v11
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ClotheCategoryProductSerial", b =>
                {
                    b.Property<int>("ClotheCategoriesId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductSerialsId")
                        .HasColumnType("integer");

                    b.HasKey("ClotheCategoriesId", "ProductSerialsId");

                    b.HasIndex("ProductSerialsId");

                    b.ToTable("ClotheCategoryProductSerial");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.AccountCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("AccountCarts");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.AccountTokenCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("ExpiredAtStamp")
                        .HasColumnType("numeric(20,0)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("TokenCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TokenType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("AccountTokens");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.AccountUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("LastLogin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizeEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AccountUsers");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.ClotheBrand", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ClotheBrands");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.ClotheCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ClotheCategories");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.MaterialType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MaterialType");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<double>("TotalPaid")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.Product", b =>
                {
                    b.Property<string>("Sku")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("InStock")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int?>("SerialId")
                        .HasColumnType("integer");

                    b.Property<int?>("SizeType")
                        .HasColumnType("integer");

                    b.HasKey("Sku");

                    b.HasIndex("SerialId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.ProductSerial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BrandId")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("ProductSerial");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.CartItem", b =>
                {
                    b.Property<int>("CartId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductDetailId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("CartId", "ProductDetailId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<string>("ProductSku")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("OrderId", "ProductSku");

                    b.HasIndex("ProductSku");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.ProductInMaterial", b =>
                {
                    b.Property<int>("MaterialId")
                        .HasColumnType("integer");

                    b.Property<string>("ProductSku")
                        .HasColumnType("text");

                    b.HasKey("MaterialId", "ProductSku");

                    b.HasIndex("ProductSku");

                    b.ToTable("ProductInMaterial");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.SerialInCategory", b =>
                {
                    b.Property<int>("SerialId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.HasKey("SerialId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductInCategories");
                });

            modelBuilder.Entity("ClotheCategoryProductSerial", b =>
                {
                    b.HasOne("OnlineClothes.Domain.Entities.Aggregate.ClotheCategory", null)
                        .WithMany()
                        .HasForeignKey("ClotheCategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineClothes.Domain.Entities.Aggregate.ProductSerial", null)
                        .WithMany()
                        .HasForeignKey("ProductSerialsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.AccountCart", b =>
                {
                    b.HasOne("OnlineClothes.Domain.Entities.Aggregate.AccountUser", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.Order", b =>
                {
                    b.HasOne("OnlineClothes.Domain.Entities.Aggregate.AccountUser", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.Product", b =>
                {
                    b.HasOne("OnlineClothes.Domain.Entities.Aggregate.ProductSerial", "ProductSerial")
                        .WithMany()
                        .HasForeignKey("SerialId");

                    b.Navigation("ProductSerial");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.ProductSerial", b =>
                {
                    b.HasOne("OnlineClothes.Domain.Entities.Aggregate.ClotheBrand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.CartItem", b =>
                {
                    b.HasOne("OnlineClothes.Domain.Entities.Aggregate.AccountCart", "Cart")
                        .WithMany("Items")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("OnlineClothes.Domain.Entities.Aggregate.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineClothes.Domain.Entities.Aggregate.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductSku")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.ProductInMaterial", b =>
                {
                    b.HasOne("OnlineClothes.Domain.Entities.Aggregate.MaterialType", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineClothes.Domain.Entities.Aggregate.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductSku")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.SerialInCategory", b =>
                {
                    b.HasOne("OnlineClothes.Domain.Entities.Aggregate.ClotheCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineClothes.Domain.Entities.Aggregate.ProductSerial", "ProductSerial")
                        .WithMany()
                        .HasForeignKey("SerialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("ProductSerial");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.AccountCart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.ClotheBrand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.Product", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
