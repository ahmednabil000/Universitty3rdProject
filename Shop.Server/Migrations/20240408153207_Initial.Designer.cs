﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Server.Models;

#nullable disable

namespace Shop.Server.Migrations
{
    [DbContext(typeof(DbAa7408UniversityprojectContext))]
    [Migration("20240408153207_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shop.Server.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .HasColumnType("int")
                        .HasColumnName("admin_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("password");

                    b.HasKey("AdminId");

                    b.ToTable("Admin", (string)null);
                });

            modelBuilder.Entity("Shop.Server.Models.Bill", b =>
                {
                    b.Property<int>("BId")
                        .HasColumnType("int")
                        .HasColumnName("B_id");

                    b.Property<int?>("CId")
                        .HasColumnType("int")
                        .HasColumnName("c_id");

                    b.Property<string>("CName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("c_name");

                    b.Property<int?>("PId")
                        .HasColumnType("int")
                        .HasColumnName("p_id");

                    b.Property<string>("PName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("p_name");

                    b.HasKey("BId");

                    b.HasIndex("CId");

                    b.HasIndex("PId");

                    b.ToTable("bill", (string)null);
                });

            modelBuilder.Entity("Shop.Server.Models.Customer", b =>
                {
                    b.Property<int>("CId")
                        .HasColumnType("int")
                        .HasColumnName("c_id");

                    b.Property<string>("CName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("c_name");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("password");

                    b.Property<string>("RePassword")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("re_password");

                    b.HasKey("CId");

                    b.ToTable("customer", (string)null);
                });

            modelBuilder.Entity("Shop.Server.Models.Feedback", b =>
                {
                    b.Property<string>("CName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("c_name");

                    b.Property<int>("CNumber")
                        .HasColumnType("int")
                        .HasColumnName("c_number");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("city");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.ToTable("feedback", (string)null);
                });

            modelBuilder.Entity("Shop.Server.Models.Order", b =>
                {
                    b.Property<int>("OId")
                        .HasColumnType("int")
                        .HasColumnName("o_id");

                    b.Property<int?>("CId")
                        .HasColumnType("int")
                        .HasColumnName("c_id");

                    b.Property<string>("CName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("c_name");

                    b.Property<int?>("PId")
                        .HasColumnType("int")
                        .HasColumnName("p_id");

                    b.Property<string>("PName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("p_name");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.HasKey("OId");

                    b.HasIndex("CId");

                    b.HasIndex("PId");

                    b.ToTable("order", (string)null);
                });

            modelBuilder.Entity("Shop.Server.Models.Product", b =>
                {
                    b.Property<int>("PId")
                        .HasColumnType("int")
                        .HasColumnName("p_id");

                    b.Property<string>("PDesc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("p_desc");

                    b.Property<string>("PName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("p_name");

                    b.Property<int>("PPrice")
                        .HasColumnType("int")
                        .HasColumnName("p_price");

                    b.HasKey("PId");

                    b.ToTable("product", (string)null);
                });

            modelBuilder.Entity("Shop.Server.Models.Bill", b =>
                {
                    b.HasOne("Shop.Server.Models.Customer", "Customer")
                        .WithMany("Bills")
                        .HasForeignKey("CId")
                        .HasConstraintName("FK_bill_customer");

                    b.HasOne("Shop.Server.Models.Product", "Product")
                        .WithMany("Bills")
                        .HasForeignKey("PId")
                        .HasConstraintName("FK_bill_product");

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shop.Server.Models.Order", b =>
                {
                    b.HasOne("Shop.Server.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CId")
                        .HasConstraintName("FK_order_customer");

                    b.HasOne("Shop.Server.Models.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("PId")
                        .HasConstraintName("FK_order_product");

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shop.Server.Models.Customer", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Shop.Server.Models.Product", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
