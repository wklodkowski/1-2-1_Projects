using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using WpfApp.Desktop.Models.Invoice;
using WpfApp.Desktop.Models.Invoice.Messages;
using WpfApp.Desktop.Pages.Invoice.Enums;
using WpfApp.Desktop.Views.Invoice;
using ArgumentOutOfRangeException = System.ArgumentOutOfRangeException;

namespace WpfApp.Desktop.ViewModels.Invoice
{
    public class FindInvoiceViewModel : ViewModelBase
    {
        private FrameworkElement _contentControlFindInvoiceContentView;

        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICommand FindInvoiceContentCommand { get; set; }

        public FindInvoiceViewModel()
        {
            FindInvoiceContentCommand = new RelayCommand(FindInvoiceContent);
        }

        public FrameworkElement ContentControlFindInvoiceContentView
        {
            get => _contentControlFindInvoiceContentView;
            set
            {
                _contentControlFindInvoiceContentView = value;
                RaisePropertyChanged("ContentControlFindInvoiceContentView");
            }
        }

        public void FindInvoiceContent()
        {
            var findInvoiceContentMessage = new FindInvoiceContentMessage
            {
                InvoiceId = InvoiceId,
                CustomerId = CustomerId,
                FirstName = FirstName,
                LastName = LastName

            };

            SwitchInvoiceView(FindInvoicePage.FindInvoiceContent);
            Messenger.Default.Send(findInvoiceContentMessage);
        }

        public void SwitchInvoiceView(FindInvoicePage findCustomerPage)
        {
            switch (findCustomerPage)
            {
                case FindInvoicePage.Blank:
                    break;
                case FindInvoicePage.FindInvoiceContent:
                    ContentControlFindInvoiceContentView = new FindInvoiceContentView();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(findCustomerPage), findCustomerPage, null);
            }
        }
    }
}
