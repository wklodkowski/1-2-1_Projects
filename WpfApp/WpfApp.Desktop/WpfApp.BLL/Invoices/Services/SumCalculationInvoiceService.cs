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
    public class SumCalculationInvoiceService : ICalculationInvoiceService
    {
        public CalculationEnum GetCalculationType()
        {
            return CalculationEnum.Sum;
        }

        public decimal GetAmount(List<InvoiceModel> invoices)
        {
            return invoices.Sum(invoice => invoice.Amount);
        }
    }
}
