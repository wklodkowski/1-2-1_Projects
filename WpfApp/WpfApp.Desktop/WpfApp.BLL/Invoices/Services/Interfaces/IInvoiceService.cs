using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.BLL.Invoices.Models;

namespace WpfApp.BLL.Invoices.Services.Interfaces
{
    public interface IInvoiceService
    {
        List<InvoiceCalculationModel> GetInvoiceCalculationsForCustomer(int customerId);
    }
}
