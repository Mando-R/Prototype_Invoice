using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;         // 對應 [DataType(DataType.Date)]
using System.ComponentModel.DataAnnotations.Schema;  // 對應 [Column(TypeName = "decimal(18,4)")]

namespace RazorPagesMovie.Models
{
    public class ElectronicInvoice
    {
        public ElectronicInvoice()
        {
            CreatedOn = DateTimeOffset.Now;
            LatestUpdatedOn = DateTimeOffset.Now;
        }
        // 1. ElectronicInvoiceID
        public int ID { get; set; }

        // 2. ExpenseOrRevenue 支出/收入
        public string InvoicePurpose { get; set; }

        // public InvoicePurposeList InvoicePurpose { get; set; }
        public enum InvoicePurposeList
        {
            [Display(Name = "支出")]
            Expense = 0,

            [Display(Name = "收入")]
            Revenue = 1
        }

        // 3. 發票日期
        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; }

        // 4. 發票金額
        [Column(TypeName = "decimal(18,4)")]
        public decimal InvoiceAmount { get; set; }

        // 5. CreatedOn
        public DateTimeOffset CreatedOn { get; set; }

        // 6. LatestUpdatedOn
        public DateTimeOffset LatestUpdatedOn { get; set; }

        // 7. CategoryID
        // Relation：ElectronicInvoice[M] -> [1]InvoiceCategory
        public int InvoiceCategoryID { get; set; }

        [ForeignKey("InvoiceCategoryID")]
        public InvoiceCategory InvoiceCategory { get; set; }

        // 8. CompanyID
        // Relation：ElectronicInvoice[M] -> [1]Company
        public int CompanyID { get; set; }
                     
        [ForeignKey("CompanyID")]
        public Company Company { get; set; }
    }
}
