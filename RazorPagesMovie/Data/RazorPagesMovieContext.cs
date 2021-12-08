using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;
using System.ComponentModel.DataAnnotations;         // 對應 [DataType(DataType.Date)]
using System.ComponentModel.DataAnnotations.Schema;  // 對應 [Column(TypeName = "decimal(18,4)")]

namespace RazorPagesMovie.Data
{
    public class RazorPagesMovieContext : DbContext
    {
        public RazorPagesMovieContext(DbContextOptions<RazorPagesMovieContext> options)
            : base(options)
        {
        }
        // 新增 Table 名稱
        public DbSet<RazorPagesMovie.Models.Movie> Movie { get; set; }
        public DbSet<RazorPagesMovie.Models.ElectronicInvoice> ElectronicInvoice { get; set; }
        public DbSet<RazorPagesMovie.Models.InvoiceCategory> InvoiceCategory { get; set; }
        public DbSet<RazorPagesMovie.Models.Company> Company { get; set; }

        // SeedData
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // SeedData：InvoiceCategory
            modelBuilder.Entity<InvoiceCategory>().HasData(
                new Models.InvoiceCategory { ID = 1, Category = "Electronic Invoice" },
                new Models.InvoiceCategory { ID = 2, Category = "Cash Register Uniform Invoice" },
                new Models.InvoiceCategory { ID = 3, Category = "Duplicate Uniform Invoice" },
                new Models.InvoiceCategory { ID = 4, Category = "Triplicate Uniform Invoice" }
                );

            // SeedData：Company
            modelBuilder.Entity<Company>().HasData(
                new Models.Company { ID = 1, UnifiedBusinessNumber = "12345678", CompanyName = "RShop", TotalPaidinCapital = 50000, LocationOfCompany = "CZ Road", /*DateOfRegistration = 2021 / 12 / 8*/ }
                );
        }
    }
}
