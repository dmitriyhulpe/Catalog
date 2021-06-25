﻿// <auto-generated />
using System;
using Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Catalog.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Catalog.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("CategoryID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Catalog.Models.Member", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("MemberName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("MemberID");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("Catalog.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Price")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("ProductName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Catalog.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.HasKey("TransactionID");

                    b.HasIndex("MemberID");

                    b.HasIndex("ProductID");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("MemberProduct", b =>
                {
                    b.Property<int>("CartMemberMemberID")
                        .HasColumnType("int");

                    b.Property<int>("CartProductProductID")
                        .HasColumnType("int");

                    b.HasKey("CartMemberMemberID", "CartProductProductID");

                    b.HasIndex("CartProductProductID");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("MemberProduct1", b =>
                {
                    b.Property<int>("WishlistMemberMemberID")
                        .HasColumnType("int");

                    b.Property<int>("WishlistProductProductID")
                        .HasColumnType("int");

                    b.HasKey("WishlistMemberMemberID", "WishlistProductProductID");

                    b.HasIndex("WishlistProductProductID");

                    b.ToTable("WishList");
                });

            modelBuilder.Entity("Catalog.Models.Product", b =>
                {
                    b.HasOne("Catalog.Models.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Catalog.Models.Transaction", b =>
                {
                    b.HasOne("Catalog.Models.Member", "Member")
                        .WithMany("Transaction")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catalog.Models.Product", "Product")
                        .WithMany("Transaction")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("MemberProduct", b =>
                {
                    b.HasOne("Catalog.Models.Member", null)
                        .WithMany()
                        .HasForeignKey("CartMemberMemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catalog.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("CartProductProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MemberProduct1", b =>
                {
                    b.HasOne("Catalog.Models.Member", null)
                        .WithMany()
                        .HasForeignKey("WishlistMemberMemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Catalog.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("WishlistProductProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Catalog.Models.Category", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("Catalog.Models.Member", b =>
                {
                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("Catalog.Models.Product", b =>
                {
                    b.Navigation("Transaction");
                });
#pragma warning restore 612, 618
        }
    }
}
