﻿// <auto-generated />
using cs341.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace cs341.Migrations
{
    [DbContext(typeof(CartContext))]
    partial class CartContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("cs341.Models.CartEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EntryItemId");

                    b.Property<int?>("UserId");

                    b.Property<int>("quantitiy");

                    b.HasKey("Id");

                    b.HasIndex("EntryItemId");

                    b.HasIndex("UserId");

                    b.ToTable("CartEntries");
                });

            modelBuilder.Entity("cs341.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("cs341.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<string>("ImageLOC");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<int?>("PromotionId");

                    b.Property<decimal?>("SalePrice");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PromotionId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("cs341.Models.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.Property<decimal>("PercentOff");

                    b.HasKey("Id");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("cs341.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("IsAdmin");

                    b.Property<bool?>("IsGuest");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("cs341.Models.CartEntry", b =>
                {
                    b.HasOne("cs341.Models.Item", "EntryItem")
                        .WithMany()
                        .HasForeignKey("EntryItemId");

                    b.HasOne("cs341.Models.User")
                        .WithMany("Cart")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("cs341.Models.Item", b =>
                {
                    b.HasOne("cs341.Models.Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId");

                    b.HasOne("cs341.Models.Promotion")
                        .WithMany("SaleItems")
                        .HasForeignKey("PromotionId");
                });
#pragma warning restore 612, 618
        }
    }
}
