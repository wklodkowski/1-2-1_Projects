using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.BLL.Invoices.Enums;
using WpfApp.BLL.Invoices.Models;
using WpfApp.BLL.Invoices.Services.Interfaces;

namespace WpfApp.BLL.Invoices.Services
{
    public class AverageCalculationService : ICalculationInvoiceService
    {
        public CalculationEnum GetCalculationType()
        {
            throw new NotImplementedException();
        }

        public decimal GetAmount(List<InvoiceModel> invoices)
        {
            throw new NotImplementedException();
        }
    }
}
