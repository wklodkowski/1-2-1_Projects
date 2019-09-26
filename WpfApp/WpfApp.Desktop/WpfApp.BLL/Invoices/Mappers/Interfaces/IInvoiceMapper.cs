using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.BLL.Invoices.Models;
using WpfApp.DAL.Invoices.Models;

namespace WpfApp.BLL.Invoices.Mappers.Interfaces
{
    public interface IInvoiceMapper
    {
        InvoiceModel ToInvoiceModel(Invoice invoice);
    }
}
