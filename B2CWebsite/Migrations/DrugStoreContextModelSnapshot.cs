﻿// <auto-generated />
using System;
using B2CWebsite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace B2CWebsite.Migrations
{
    [DbContext(typeof(DrugStoreContext))]
    partial class DrugStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("B2CWebsite.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("AccountID");

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("varchar(12)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.HasKey("AccountId")
                        .HasName("PK__Accounts__349DA586F32C672E");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("B2CWebsite.Models.Category", b =>
                {
                    b.Property<int>("CatId")
                        .HasColumnType("int")
                        .HasColumnName("CatID");

                    b.Property<string>("CatName")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("Levels")
                        .HasColumnType("int");

                    b.Property<string>("MetaCover")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MetaDesc")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MetaKey")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MetaSchemeMarkup")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("Ordering")
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int")
                        .HasColumnName("ParentID");

                    b.Property<bool?>("Published")
                        .HasColumnType("bit");

                    b.Property<string>("Thumb")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("CatId")
                        .HasName("PK__Category__6A1C8ADA87E24470");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("B2CWebsite.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("varchar(12)");

                    b.HasKey("CustomerId")
                        .HasName("PK__Customer__A4AE64B8DB55DEEF");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("B2CWebsite.Models.Manufacturer", b =>
                {
                    b.Property<int>("ManuId")
                        .HasColumnType("int")
                        .HasColumnName("ManuID");

                    b.Property<string>("ManuAddress")
                        .HasColumnType("text");

                    b.Property<string>("ManuCountry")
                        .HasColumnType("text");

                    b.Property<string>("ManuEmail")
                        .HasColumnType("text");

                    b.Property<string>("ManuName")
                        .HasColumnType("text");

                    b.Property<int?>("ManuPhone")
                        .HasColumnType("int");

                    b.HasKey("ManuId")
                        .HasName("PK__Manufact__4135BFA56496A086");

                    b.ToTable("Manufacturer", (string)null);
                });

            modelBuilder.Entity("B2CWebsite.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerID");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<bool?>("Paid")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int")
                        .HasColumnName("PaymentID");

                    b.Property<DateTime?>("ShipDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("TransactId")
                        .HasColumnType("int")
                        .HasColumnName("TransactID");

                    b.HasKey("OrderId")
                        .HasName("PK__Orders__C3905BAFADC07772");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TransactId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("B2CWebsite.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .HasColumnType("int")
                        .HasColumnName("OrderDetailID");

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("OrderID");

                    b.Property<int?>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ShipDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("Sid")
                        .HasColumnType("int")
                        .HasColumnName("SID");

                    b.Property<int?>("Total")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId")
                        .HasName("PK__OrderDet__D3B9D30C8A92814B");

                    b.HasIndex("OrderId");

                    b.HasIndex("Sid");

                    b.ToTable("OrderDetail", (string)null);
                });

            modelBuilder.Entity("B2CWebsite.Models.Page", b =>
                {
                    b.Property<int>("PageId")
                        .HasColumnType("int")
                        .HasColumnName("PageID");

                    b.Property<string>("Alias")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Contents")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("MetaDesc")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MetaKey")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("Ordering")
                        .HasColumnType("int");

                    b.Property<string>("PageName")
                        .HasColumnType("text");

                    b.Property<bool?>("Published")
                        .HasColumnType("bit");

                    b.Property<string>("Thumb")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Title")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("PageId")
                        .HasName("PK__Pages__C565B124DEBCD68C");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("B2CWebsite.Models.Price", b =>
                {
                    b.Property<int>("PriceId")
                        .HasColumnType("int")
                        .HasColumnName("PriceID");

                    b.Property<int?>("Price1")
                        .HasColumnType("int")
                        .HasColumnName("Price");

                    b.Property<int?>("Sid")
                        .HasColumnType("int")
                        .HasColumnName("SID");

                    b.HasKey("PriceId")
                        .HasName("PK__Price__4957584FA22168B9");

                    b.HasIndex("Sid");

                    b.ToTable("Price", (string)null);
                });

            modelBuilder.Entity("B2CWebsite.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("RoleID");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RoleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleId")
                        .HasName("PK__Roles__8AFACE3ADFFAD443");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("B2CWebsite.Models.Supplement", b =>
                {
                    b.Property<int>("Sid")
                        .HasColumnType("int")
                        .HasColumnName("SID");

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<bool?>("BestSeller")
                        .HasColumnType("bit");

                    b.Property<int?>("CatId")
                        .HasColumnType("int")
                        .HasColumnName("CatID");

                    b.Property<string>("Directions")
                        .HasColumnType("text");

                    b.Property<bool?>("HomeFlag")
                        .HasColumnType("bit");

                    b.Property<string>("InactiveIngredient")
                        .HasColumnType("text");

                    b.Property<string>("Ingredient")
                        .HasColumnType("text");

                    b.Property<int?>("ManuId")
                        .HasColumnType("int")
                        .HasColumnName("ManuID");

                    b.Property<string>("OtherInfo")
                        .HasColumnType("text");

                    b.Property<string>("Slink")
                        .HasColumnType("text")
                        .HasColumnName("SLink");

                    b.Property<string>("Sname")
                        .HasColumnType("text")
                        .HasColumnName("SName");

                    b.Property<string>("Thumb")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Uses")
                        .HasColumnType("text");

                    b.Property<string>("Warnings")
                        .HasColumnType("text");

                    b.HasKey("Sid")
                        .HasName("PK__Suppleme__CA1959701EC1FCBA");

                    b.HasIndex("CatId");

                    b.HasIndex("ManuId");

                    b.ToTable("Supplement", (string)null);
                });

            modelBuilder.Entity("B2CWebsite.Models.TransactStatus", b =>
                {
                    b.Property<int>("TransactId")
                        .HasColumnType("int")
                        .HasColumnName("TransactID");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TransactId")
                        .HasName("PK__Transact__4400DE75A0475FE7");

                    b.ToTable("TransactStatus", (string)null);
                });

            modelBuilder.Entity("B2CWebsite.Models.Account", b =>
                {
                    b.HasOne("B2CWebsite.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK__Accounts__RoleID__49C3F6B7");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("B2CWebsite.Models.Order", b =>
                {
                    b.HasOne("B2CWebsite.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__Orders__Customer__403A8C7D");

                    b.HasOne("B2CWebsite.Models.TransactStatus", "Transact")
                        .WithMany("Orders")
                        .HasForeignKey("TransactId")
                        .HasConstraintName("FK__Orders__Transact__412EB0B6");

                    b.Navigation("Customer");

                    b.Navigation("Transact");
                });

            modelBuilder.Entity("B2CWebsite.Models.OrderDetail", b =>
                {
                    b.HasOne("B2CWebsite.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__OrderDeta__Order__5FB337D6");

                    b.HasOne("B2CWebsite.Models.Supplement", "SidNavigation")
                        .WithMany("OrderDetails")
                        .HasForeignKey("Sid")
                        .HasConstraintName("FK__OrderDetail__SID__60A75C0F");

                    b.Navigation("Order");

                    b.Navigation("SidNavigation");
                });

            modelBuilder.Entity("B2CWebsite.Models.Price", b =>
                {
                    b.HasOne("B2CWebsite.Models.Supplement", "SidNavigation")
                        .WithMany("Prices")
                        .HasForeignKey("Sid")
                        .HasConstraintName("FK__Price__SID__5CD6CB2B");

                    b.Navigation("SidNavigation");
                });

            modelBuilder.Entity("B2CWebsite.Models.Supplement", b =>
                {
                    b.HasOne("B2CWebsite.Models.Category", "Cat")
                        .WithMany("Supplements")
                        .HasForeignKey("CatId")
                        .HasConstraintName("FK__Supplemen__CatID__59FA5E80");

                    b.HasOne("B2CWebsite.Models.Manufacturer", "Manu")
                        .WithMany("Supplements")
                        .HasForeignKey("ManuId")
                        .HasConstraintName("FK__Supplemen__ManuI__59063A47");

                    b.Navigation("Cat");

                    b.Navigation("Manu");
                });

            modelBuilder.Entity("B2CWebsite.Models.Category", b =>
                {
                    b.Navigation("Supplements");
                });

            modelBuilder.Entity("B2CWebsite.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("B2CWebsite.Models.Manufacturer", b =>
                {
                    b.Navigation("Supplements");
                });

            modelBuilder.Entity("B2CWebsite.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("B2CWebsite.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("B2CWebsite.Models.Supplement", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("Prices");
                });

            modelBuilder.Entity("B2CWebsite.Models.TransactStatus", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
