using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;         // 對應 [DataType(DataType.Date)]
using System.ComponentModel.DataAnnotations.Schema;  // 對應 [Column(TypeName = "decimal(18,4)")]

namespace RazorPagesMovie.Models
{
    public class Company
    {
        // 1. CompanyID
        public int ID { get; set; }

        // 2. Unified Business No. 統一編號
        public string UnifiedBusinessNumber { get; set; }
        
        // 3. 公司名稱
        public string CompanyName { get; set; }

        // 4. 實收資本額
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalPaidinCapital { get; set; }

        // 5. 公司所在地
        public string LocationOfCompany { get; set; }

        // 6. 核准設立日期
        [DataType(DataType.Date)]
        public DateTime DateOfRegistration { get; set; }

        // 7. CreatedOn
        public DateTimeOffset CreatedOn { get; set; }

        // 8. LatestUpdatedOn
        public DateTimeOffset LatestUpdatedOn { get; set; }

        // Relation：Company[1] -> [M]ElectronicInvoice
        public ICollection<ElectronicInvoice> ElectronicInvoices { get; set; }
    }
}
