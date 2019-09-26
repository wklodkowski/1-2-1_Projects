using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WpfApp.BLL.Invoices.Mappers.Interfaces;
using WpfApp.BLL.Invoices.Models;
using WpfApp.BLL.Invoices.Services.Interfaces;
using WpfApp.DAL;

namespace WpfApp.BLL.Invoices.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceMapper _invoiceMapper;

        public InvoiceService(IInvoiceMapper invoiceMapper)
        {
            _invoiceMapper = invoiceMapper;
        }

        public List<InvoiceCalculationModel> GetInvoiceCalculationsForCustomer(int customerId)
        {
            var invoiceModelList = GetAllInvoicesForCustomer(customerId);
            var calculationInstances = GetAllImplementationsForInvoiceCalculations();
            var invoicesCalculationsForCustomer = calculationInstances.Select(instance => new InvoiceCalculationModel
                {
                    CalculationType = instance.GetCalculationType().ToString(),
                    Amount = instance.GetAmount(invoiceModelList)
                })
                .ToList();

            return invoicesCalculationsForCustomer;
        }

        private List<InvoiceModel> GetAllInvoicesForCustomer(int customerId)
        {
            List<InvoiceModel> result = new List<InvoiceModel>();
            using (var wpfAppContext = new WpfAppContext())
            {
                //var invoicesDb = wpfAppContext.Invoices.Where(i => i.CustomerId == customerId);
                //result = invoicesDb.Select(x => _invoiceMapper.ToInvoiceModel(x)).ToList();
            }

            return result;
        }

        private IEnumerable<ICalculationInvoiceService> GetAllImplementationsForInvoiceCalculations()
        {
            var calculationInstance = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(ICalculationInvoiceService)) &&
                            t.GetConstructor(Type.EmptyTypes) != null)
                .Select(t => Activator.CreateInstance(t) as ICalculationInvoiceService);

            return calculationInstance;
        }
    }
}
