using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.BLL.Invoices.Enums;

namespace WpfApp.BLL.Invoices.Models
{
    public class InvoiceCalculationModel
    {
        public CalculationEnum CalculationType { get; set; }
        public decimal Amount { get; set; }
    }
}
