using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.BLL.Invoices.Models
{
    public class InvoiceModel
    {
        public int InvoiceId { get; set; }
        public int InvoiceNumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime GenerationDate { get; set; }
    }
}
