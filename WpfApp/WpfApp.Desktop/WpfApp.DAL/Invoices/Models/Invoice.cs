using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.DAL.Invoices.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
    }
}
