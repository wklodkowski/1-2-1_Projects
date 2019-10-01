using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.BLL.Invoices.Models;
using WpfApp.Desktop.Mappers.Invoice.Interfaces;
using WpfApp.Desktop.Models.Invoice;

namespace WpfApp.Desktop.Mappers.Invoice
{
    public class InvoiceDesktopMapper : IInvoiceDesktopMapper
    {
        public InvoiceCalculationContentModel ToInvoiceCalculationContentModel(InvoiceCalculationModel invoiceCalculationModel)
        {
            return new InvoiceCalculationContentModel
            {
                CalculationType = invoiceCalculationModel.CalculationType.ToString(),
                Amount = invoiceCalculationModel.Amount.ToString(CultureInfo.CurrentCulture)
            };
        }
    }
}
