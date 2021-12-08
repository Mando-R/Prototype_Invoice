﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RazorPagesMovie.Data;

namespace RazorPagesMovie.Migrations
{
    [DbContext(typeof(RazorPagesMovieContext))]
    [Migration("20211208035948_InitialDB_202112081200")]
    partial class InitialDB_202112081200
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RazorPagesMovie.Models.Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("DateOfRegistration")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset>("LatestUpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("LocationOfCompany")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalPaidinCapital")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("UnifiedBusinessNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("RazorPagesMovie.Models.ElectronicInvoice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyID")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal>("InvoiceAmount")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("InvoiceCategoryID")
                        .HasColumnType("int");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvoicePurpose")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("LatestUpdatedOn")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("ID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("InvoiceCategoryID");

                    b.ToTable("ElectronicInvoice");
                });

            modelBuilder.Entity("RazorPagesMovie.Models.InvoiceCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("InvoiceCategory");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Category = "Electronic Invoice"
                        },
                        new
                        {
                            ID = 2,
                            Category = "Cash Register Uniform Invoice"
                        },
                        new
                        {
                            ID = 3,
                            Category = "Duplicate Uniform Invoice"
                        },
                        new
                        {
                            ID = 4,
                            Category = "Triplicate Uniform Invoice"
                        });
                });

            modelBuilder.Entity("RazorPagesMovie.Models.Movie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("RazorPagesMovie.Models.ElectronicInvoice", b =>
                {
                    b.HasOne("RazorPagesMovie.Models.Company", "Company")
                        .WithMany("ElectronicInvoices")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RazorPagesMovie.Models.InvoiceCategory", "InvoiceCategory")
                        .WithMany("ElectronicInvoices")
                        .HasForeignKey("InvoiceCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("InvoiceCategory");
                });

            modelBuilder.Entity("RazorPagesMovie.Models.Company", b =>
                {
                    b.Navigation("ElectronicInvoices");
                });

            modelBuilder.Entity("RazorPagesMovie.Models.InvoiceCategory", b =>
                {
                    b.Navigation("ElectronicInvoices");
                });
#pragma warning restore 612, 618
        }
    }
}
