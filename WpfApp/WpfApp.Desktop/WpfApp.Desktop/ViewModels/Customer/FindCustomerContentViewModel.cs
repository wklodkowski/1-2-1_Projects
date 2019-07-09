using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using WpfApp.Desktop.Models.Customer;
using WpfApp.Desktop.Models.Customer.Messages;

namespace WpfApp.Desktop.ViewModels.Customer
{
    public class FindCustomerContentViewModel : ViewModelBase
    {
        private ObservableCollection<CustomerContentModel> _customersList;

        public FindCustomerContentViewModel()
        {
            RegisterSwitchCustomerMessage();
        }

        public ObservableCollection<CustomerContentModel> CustomerList
        {
            get => _customersList;
            set
            {
                _customersList = value;
                RaisePropertyChanged("CustomerList");
            }
        }

        private void RegisterSwitchCustomerMessage()
        {
            Messenger.Default.Register<FindCustomerContentMessage>(this, HandleRegisterSwitchCustomerMessage);
        }

        private void HandleRegisterSwitchCustomerMessage(FindCustomerContentMessage findCustomerContentMessage)
        {
            CustomerList = new ObservableCollection<CustomerContentModel>();

            foreach (var customer in findCustomerContentMessage.Customers)
            {
                CustomerList.Add(customer);
            }
        }
    }
}
