using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using WpfApp.BLL.Invoices.Services.Interfaces;
using WpfApp.Desktop.Mappers.Invoice.Interfaces;
using WpfApp.Desktop.Models.Customer.Messages;
using WpfApp.Desktop.Models.Invoice;

namespace WpfApp.Desktop.ViewModels.Customer
{
    public class FindCustomerContentReportViewModel : ViewModelBase
    {
        private ObservableCollection<InvoiceCalculationContentModel> _calculationContentModels;
        private readonly IInvoiceService _invoiceService;
        private readonly IInvoiceDesktopMapper _invoiceDesktopMapper;

        public FindCustomerContentReportViewModel(IInvoiceService invoiceService, IInvoiceDesktopMapper invoiceDesktopMapper)
        {
            _invoiceService = invoiceService;
            _invoiceDesktopMapper = invoiceDesktopMapper;
            _calculationContentModels = new ObservableCollection<InvoiceCalculationContentModel>();
            RegisterFindCustomerContentReportMessage();
        }

        public ObservableCollection<InvoiceCalculationContentModel> CalculationContentModels
        {
            get => _calculationContentModels;
            set
            {
                _calculationContentModels = value;
                RaisePropertyChanged("CalculationContentModels");
            }
        }

        private void RegisterFindCustomerContentReportMessage()
        {
            Messenger.Default.Register<FindCustomerContentReportMessage>(this, HandleFindCustomerContentReportMessage);
        }

        private void HandleFindCustomerContentReportMessage(FindCustomerContentReportMessage findCustomerContentReportMessage)
        {
            var customerInvoiceCalculatorResult = _invoiceService.GetInvoiceCalculationsForCustomer(findCustomerContentReportMessage.ClientId);
            var customerInvoicesCalculatorModelResult = customerInvoiceCalculatorResult.Select(x => _invoiceDesktopMapper.ToInvoiceCalculationContentModel(x)).ToList();

            foreach (var customerInvoiceCalculationContentModel in customerInvoicesCalculatorModelResult)
            {
                CalculationContentModels.Add(customerInvoiceCalculationContentModel);
            }
        }
    }
}
