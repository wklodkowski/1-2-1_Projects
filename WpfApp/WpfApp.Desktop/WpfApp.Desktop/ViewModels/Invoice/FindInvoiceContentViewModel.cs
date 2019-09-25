using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using WpfApp.Desktop.Models.Invoice;
using WpfApp.Desktop.Models.Invoice.Messages;

namespace WpfApp.Desktop.ViewModels.Invoice
{
    public class FindInvoiceContentViewModel : ViewModelBase
    {
        private ObservableCollection<InvoiceContentModel> _invoiceList;

        private bool _isLoadingPanelVisible;
        private string _panelMainMessage = "Loading...";
        private string _panelSubMessage = "Please wait !";

        public FindInvoiceContentViewModel()
        {
            RegisterSwitchInvoiceMessage();
        }

        public bool IsLoadingPanelVisible
        {
            get => _isLoadingPanelVisible;
            set
            {
                _isLoadingPanelVisible = value;
                RaisePropertyChanged("IsLoadingPanelVisible");
            }
        }

        public string PanelMainMessage
        {
            get => _panelMainMessage;
            set
            {
                _panelMainMessage = value;
                RaisePropertyChanged("PanelMainMessage");
            }
        }

        public string PanelSubMessage
        {
            get => _panelSubMessage;
            set
            {
                _panelSubMessage = value;
                RaisePropertyChanged("PanelSubMessage");
            }
        }

        public ObservableCollection<InvoiceContentModel> InvoiceList
        {
            get => _invoiceList;
            set
            {
                _invoiceList = value;
                RaisePropertyChanged("InvoiceList");
            }
        }

        private void RegisterSwitchInvoiceMessage()
        {
            Messenger.Default.Register<FindInvoiceContentMessage>(this, HandleRegisterSwitchInvoiceMessage);
        }

        private void HandleRegisterSwitchInvoiceMessage(FindInvoiceContentMessage findInvoiceContentMessage)
        {
            
        }
    }
}
