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
    [Migration("20230109140419_v1.6.1")]
    partial class v161
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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

                    b.Property<int?>("AvatarImageId")
                        .HasColumnType("integer");

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

                    b.HasIndex("AvatarImageId");

                    b.ToTable("AccountUsers");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

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

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.Category", b =>
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

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.ImageObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AltName")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalPaid")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("BrandId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsPublish")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int?>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.ProductSku", b =>
                {
                    b.Property<string>("Sku")
                        .HasColumnType("text");

                    b.Property<decimal>("AddOnPrice")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("InStock")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.HasKey("Sku");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductSkus");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.CartItem", b =>
                {
                    b.Property<int>("CartId")
                        .HasColumnType("integer");

                    b.Property<string>("ProductSkuId")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("CartId", "ProductSkuId");

                    b.HasIndex("ProductSkuId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<string>("ProductSkuId")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("OrderId", "ProductSkuId");

                    b.HasIndex("ProductSkuId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.ProductCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategories");
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

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.AccountUser", b =>
                {
                    b.HasOne("OnlineClothes.Domain.Entities.Aggregate.ImageObject", "AvatarImage")
                        .WithMany()
                        .HasForeignKey("AvatarImageId");

                    b.Navigation("AvatarImage");
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
                    b.HasOne("OnlineClothes.Domain.Entities.Aggregate.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.ProductSku", b =>
                {
                    b.HasOne("OnlineClothes.Domain.Entities.Aggregate.Product", "Product")
                        .WithMany("ProductSkus")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.CartItem", b =>
                {
                    b.HasOne("OnlineClothes.Domain.Entities.Aggregate.AccountCart", "Cart")
                        .WithMany("Items")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineClothes.Domain.Entities.Aggregate.ProductSku", "ProductSku")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductSkuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("ProductSku");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.OrderItem", b =>
                {
                    b.HasOne("OnlineClothes.Domain.Entities.Aggregate.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineClothes.Domain.Entities.Aggregate.ProductSku", "ProductSku")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductSkuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("ProductSku");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.ProductCategory", b =>
                {
                    b.HasOne("OnlineClothes.Domain.Entities.Aggregate.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineClothes.Domain.Entities.Aggregate.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.AccountCart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.Category", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.Order", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.Product", b =>
                {
                    b.Navigation("ProductCategories");

                    b.Navigation("ProductSkus");
                });

            modelBuilder.Entity("OnlineClothes.Domain.Entities.Aggregate.ProductSku", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
