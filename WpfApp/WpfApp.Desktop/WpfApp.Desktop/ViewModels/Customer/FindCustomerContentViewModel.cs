using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using WpfApp.BLL.Customers.Services.Interfaces;
using WpfApp.Desktop.Common.AsyncMessenger;
using WpfApp.Desktop.Mappers.Customer.Interfaces;
using WpfApp.Desktop.Models.Customer;
using WpfApp.Desktop.Models.Customer.Messages;

namespace WpfApp.Desktop.ViewModels.Customer
{
    public class FindCustomerContentViewModel : ViewModelBase
    {
        private ObservableCollection<CustomerContentModel> _customersList;
        private readonly ICustomerService _customerService;
        private readonly ICustomerDesktopMapper _customerDesktopMapper;

        public FindCustomerContentViewModel(ICustomerService customerService, ICustomerDesktopMapper customerDesktopMapper)
        {
            _customerService = customerService;
            _customerDesktopMapper = customerDesktopMapper;
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
            //Messenger.Default.Register<FindCustomerContentMessage>(this, HandleRegisterSwitchCustomerMessage);
            Messenger.Default.RegisterAsyncMessage<FindCustomerContentMessage>(HandleRegisterSwitchCustomerMessageAsync);
        }

        private async Task<bool> HandleRegisterSwitchCustomerMessageAsync(FindCustomerContentMessage findCustomerContentMessage)
        {
            CustomerList = new ObservableCollection<CustomerContentModel>();
            var customerModel = _customerDesktopMapper.ToCustomerModel(findCustomerContentMessage);
            var customerModelList = await _customerService.GetCustomersAsync(customerModel);

            foreach (var customer in customerModelList)
            {
                var customerContentModel = _customerDesktopMapper.ToCustomerContentModel(customer);
                CustomerList.Add(customerContentModel);
            }

            return true;
        }

        //private void HandleRegisterSwitchCustomerMessage(FindCustomerContentMessage findCustomerContentMessage)
        //{
        //    CustomerList = new ObservableCollection<CustomerContentModel>();
        //    var customerModel = _customerDesktopMapper.ToCustomerModel(findCustomerContentMessage);
        //    var customerModelList = _customerService.GetCustomers(customerModel);

        //    foreach (var customer in customerModelList)
        //    {
        //        var customerContentModel = _customerDesktopMapper.ToCustomerContentModel(customer);
        //        CustomerList.Add(customerContentModel);
        //    }
        //}
    }
}
