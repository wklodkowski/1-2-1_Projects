using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.BLL.Invoices.Models
{
    public class InvoiceCalculationModel
    {
        public string CalculationType { get; set; }
        public decimal Amount { get; set; }
    }
}
