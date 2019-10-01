using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.BLL.Invoices.Models;
using WpfApp.Desktop.Models.Invoice;

namespace WpfApp.Desktop.Mappers.Invoice.Interfaces
{
    public interface IInvoiceDesktopMapper
    {
        InvoiceCalculationContentModel ToInvoiceCalculationContentModel(InvoiceCalculationModel invoiceCalculationModel);
    }
}
