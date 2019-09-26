using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.BLL.Invoices.Mappers.Interfaces;
using WpfApp.BLL.Invoices.Models;
using WpfApp.DAL.Invoices.Models;

namespace WpfApp.BLL.Invoices.Mappers
{
    public class InvoiceMapper : IInvoiceMapper
    {
        public InvoiceModel ToInvoiceModel(Invoice invoice)
        {
            var result = new InvoiceModel
            {
                InvoiceId = invoice.InvoiceId,
                Amount = invoice.Amount,
                GenerationDate = invoice.GenerationDate,
                InvoiceNumber = invoice.InvoiceNumber,
            };

            return result;
        }
    }
}
