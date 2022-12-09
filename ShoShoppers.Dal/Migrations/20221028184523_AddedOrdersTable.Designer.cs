﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoShoppers.Dal.Contexts;

#nullable disable

namespace ShoShoppers.Dal.Migrations
{
    [DbContext(typeof(ShoShoppersContext))]
    [Migration("20221028184523_AddedOrdersTable")]
    partial class AddedOrdersTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ShoShoppers.Dal.Entities.Base.BaseEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("BaseEntity");
                });

            modelBuilder.Entity("ShoShoppers.Dal.Entities.Base.BaseEntityForSale", b =>
                {
                    b.HasBaseType("ShoShoppers.Dal.Entities.Base.BaseEntity");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageColor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ItemAmmount")
                        .HasColumnType("int");

                    b.Property<bool>("ItemInProduction")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.ToTable("BaseEntityForSale");
                });

            modelBuilder.Entity("ShoShoppers.Dal.Entities.Email", b =>
                {
                    b.HasBaseType("ShoShoppers.Dal.Entities.Base.BaseEntity");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("ShoShoppers.Dal.Entities.Order", b =>
                {
                    b.HasBaseType("ShoShoppers.Dal.Entities.Base.BaseEntity");

                    b.Property<DateTime>("DateOfOrder")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateToFinishOrderAndDiliver")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsOrderDone")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("OrderPrice")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("PostOffice")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserItems")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserPhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserSurname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ShoShoppers.Dal.Entities.Review", b =>
                {
                    b.HasBaseType("ShoShoppers.Dal.Entities.Base.BaseEntity");

                    b.Property<string>("ImageLink")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.ToTable("Rewievs");
                });

            modelBuilder.Entity("ShoShoppers.Dal.Entities.ItemsForSale.IndividualDesign", b =>
                {
                    b.HasBaseType("ShoShoppers.Dal.Entities.Base.BaseEntityForSale");

                    b.ToTable("IndividualDesigns");
                });

            modelBuilder.Entity("ShoShoppers.Dal.Entities.ItemsForSale.Pin", b =>
                {
                    b.HasBaseType("ShoShoppers.Dal.Entities.Base.BaseEntityForSale");

                    b.ToTable("Pins");
                });

            modelBuilder.Entity("ShoShoppers.Dal.Entities.ItemsForSale.Shopper", b =>
                {
                    b.HasBaseType("ShoShoppers.Dal.Entities.Base.BaseEntityForSale");

                    b.ToTable("Shoppers");
                });

            modelBuilder.Entity("ShoShoppers.Dal.Entities.Base.BaseEntityForSale", b =>
                {
                    b.HasOne("ShoShoppers.Dal.Entities.Base.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("ShoShoppers.Dal.Entities.Base.BaseEntityForSale", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShoShoppers.Dal.Entities.Email", b =>
                {
                    b.HasOne("ShoShoppers.Dal.Entities.Base.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("ShoShoppers.Dal.Entities.Email", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShoShoppers.Dal.Entities.Order", b =>
                {
                    b.HasOne("ShoShoppers.Dal.Entities.Base.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("ShoShoppers.Dal.Entities.Order", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShoShoppers.Dal.Entities.Review", b =>
                {
                    b.HasOne("ShoShoppers.Dal.Entities.Base.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("ShoShoppers.Dal.Entities.Review", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShoShoppers.Dal.Entities.ItemsForSale.IndividualDesign", b =>
                {
                    b.HasOne("ShoShoppers.Dal.Entities.Base.BaseEntityForSale", null)
                        .WithOne()
                        .HasForeignKey("ShoShoppers.Dal.Entities.ItemsForSale.IndividualDesign", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShoShoppers.Dal.Entities.ItemsForSale.Pin", b =>
                {
                    b.HasOne("ShoShoppers.Dal.Entities.Base.BaseEntityForSale", null)
                        .WithOne()
                        .HasForeignKey("ShoShoppers.Dal.Entities.ItemsForSale.Pin", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ShoShoppers.Dal.Entities.ItemsForSale.Shopper", b =>
                {
                    b.HasOne("ShoShoppers.Dal.Entities.Base.BaseEntityForSale", null)
                        .WithOne()
                        .HasForeignKey("ShoShoppers.Dal.Entities.ItemsForSale.Shopper", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}