﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MyStoreFront1.Models;
using System;

namespace MyStoreFront1.Migrations
{
    [DbContext(typeof(JoshTestContext))]
    [Migration("20180309191705_TrackingNumber")]
    partial class TrackingNumber
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MyStoreFront1.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("MyStoreFront1.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("DateLastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid>("TrackingNumber");

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("MyStoreFront1.Models.CartProduct", b =>
                {
                    b.Property<int>("CartId")
                        .HasColumnName("CartID");

                    b.Property<int>("ProductsId")
                        .HasColumnName("ProductsID");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DateLastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("Quantity");

                    b.HasKey("CartId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CartProducts");
                });

            modelBuilder.Entity("MyStoreFront1.Models.Genres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DateLastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MyStoreFront1.Models.LineItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OrderID");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductId");

                    b.ToTable("LineItems");
                });

            modelBuilder.Entity("MyStoreFront1.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DateLastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<decimal>("ShippingTotal")
                        .HasColumnType("money");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("money");

                    b.Property<decimal>("Tax")
                        .HasColumnType("money");

                    b.Property<Guid>("TrackingNumber")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("MyStoreFront1.Models.OrderProducts", b =>
                {
                    b.Property<int>("ProductsId")
                        .HasColumnName("ProductsID");

                    b.Property<int>("OrderId")
                        .HasColumnName("OrderID");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DateLastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("Quantity");

                    b.HasKey("ProductsId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("MyStoreFront1.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<DateTime?>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("DateLastModified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .HasMaxLength(500);

                    b.Property<int?>("GenreId");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<decimal?>("Price")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MyStoreFront1.Models.Review", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<bool>("IsApproved");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Rating");

                    b.Property<string>("UserId");

                    b.HasKey("ID");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MyStoreFront1.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MyStoreFront1.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyStoreFront1.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MyStoreFront1.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MyStoreFront1.Models.CartProduct", b =>
                {
                    b.HasOne("MyStoreFront1.Models.Cart", "Cart")
                        .WithMany("CartProducts")
                        .HasForeignKey("CartId")
                        .HasConstraintName("FK_CartProducts_Cart");

                    b.HasOne("MyStoreFront1.Models.Products", "Products")
                        .WithMany("CartProducts")
                        .HasForeignKey("ProductsId")
                        .HasConstraintName("FK_CartProducts_Product");
                });

            modelBuilder.Entity("MyStoreFront1.Models.LineItem", b =>
                {
                    b.HasOne("MyStoreFront1.Models.Order", "Order")
                        .WithMany("LineItems")
                        .HasForeignKey("OrderID");

                    b.HasOne("MyStoreFront1.Models.Products", "Product")
                        .WithMany("LineItems")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("MyStoreFront1.Models.Order", b =>
                {
                    b.HasOne("MyStoreFront1.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("MyStoreFront1.Models.OrderProducts", b =>
                {
                    b.HasOne("MyStoreFront1.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK_OrderProducts_Order");

                    b.HasOne("MyStoreFront1.Models.Products", "Products")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductsId")
                        .HasConstraintName("FK_OrderProducts_Product");
                });

            modelBuilder.Entity("MyStoreFront1.Models.Products", b =>
                {
                    b.HasOne("MyStoreFront1.Models.Genres", "Genre")
                        .WithMany("Products")
                        .HasForeignKey("GenreId");
                });

            modelBuilder.Entity("MyStoreFront1.Models.Review", b =>
                {
                    b.HasOne("MyStoreFront1.Models.Products", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId");

                    b.HasOne("MyStoreFront1.Models.ApplicationUser", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
