using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMovie.Models
{
    public class InvoiceCategory
    {
        public int ID { get; set; }
        public string Category { get; set; }

        // Relation：InvoiceCategory[1] -> [M]ElectronicInvoice
        public ICollection<ElectronicInvoice> ElectronicInvoices { get; set; }
    }
}
