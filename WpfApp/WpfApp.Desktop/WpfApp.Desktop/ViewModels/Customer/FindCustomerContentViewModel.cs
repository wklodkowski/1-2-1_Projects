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
using WpfApp.BLL.Customers.Models;
using WpfApp.BLL.Customers.Services.Interfaces;
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

        private bool _isLoadingPanelVisible;

        public FindCustomerContentViewModel(ICustomerService customerService, ICustomerDesktopMapper customerDesktopMapper)
        {
            _customerService = customerService;
            _customerDesktopMapper = customerDesktopMapper;
            _customersList = new ObservableCollection<CustomerContentModel>();
            RegisterSwitchCustomerMessage();
        }

        public bool IsLoadingPanelVisible
        {
            get
            {
                return _isLoadingPanelVisible;
            }
            set
            {
                _isLoadingPanelVisible = value;
                RaisePropertyChanged("IsLoadingPanelVisible");
            }
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
            IsLoadingPanelVisible = true;
            var customers = Task.Run(async () => await GetCustomersAsync(findCustomerContentMessage.CustomerContentModel)).ConfigureAwait(false).GetAwaiter().GetResult();

            foreach (var customer in customers)
            {
                CustomerList.Add(customer);
            }
        }

        private async Task<List<CustomerContentModel>> GetCustomersAsync(CustomerContentModel customerContentModel)
        {
            var customerModel = _customerDesktopMapper.ToCustomerModel(customerContentModel);
            var customerModelList = await _customerService.GetCustomersAsync(customerModel);
            var result = new List<CustomerContentModel>();

            foreach (var customer in customerModelList)
            {
               result.Add(_customerDesktopMapper.ToCustomerContentModel(customer)); 
            }

            return result;
        }
    }
}
