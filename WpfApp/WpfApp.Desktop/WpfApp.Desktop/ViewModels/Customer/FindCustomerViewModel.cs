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
using WpfApp.BLL.Customers.Models;
using WpfApp.BLL.Customers.Services.Interfaces;
using WpfApp.Desktop.Common.AsyncCommand;
using WpfApp.Desktop.Common.AsyncCommand.Interfaces;
using WpfApp.Desktop.Mappers.Customer.Interfaces;
using WpfApp.Desktop.Models.Customer;
using WpfApp.Desktop.Models.Customer.Messages;
using WpfApp.Desktop.Pages.Customer.Enums;
using WpfApp.Desktop.Pages.Customer.Models;
using WpfApp.Desktop.Views.Customer;

namespace WpfApp.Desktop.ViewModels.Customer
{
    public class FindCustomerViewModel : ViewModelBase
    {
        private readonly ICustomerService _customerService;
        private readonly ICustomerDesktopMapper _customerDesktopMapper;
        private FrameworkElement _contentControlFindCustomerContentView;

        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IAsyncCommand FindCustomerContentCommand { get; set; }

        public FindCustomerViewModel(ICustomerService customerService, ICustomerDesktopMapper customerDesktopMapper)
        {
            _customerService = customerService;
            _customerDesktopMapper = customerDesktopMapper;
            RegisterSwitchCustomerMessage();
            FindCustomerContentCommand = new AsyncCommand<bool>(FindCustomerContent);
        }

        public void RegisterSwitchCustomerMessage()
        {
            Messenger.Default.Register<SwitchCustomerViewMessageModel>(this, (switchCustomerViewMessage) =>
            {
                SwitchCustomerView(switchCustomerViewMessage.CustomerPage);
            });
        }

        public async Task<bool> FindCustomerContent()
        {
            var customerModel = new CustomerModel
            {
                CustomerId = ClientId,
                FirstName = FirstName,
                LastName = LastName
            };

            var result = await _customerService.GetCustomersAsync(customerModel);
            var customerContentModelList = GetFindCustomerContentMessage(result);

            SwitchCustomerView(FindCustomerPage.FindCustomerContent);
            Messenger.Default.Send(customerContentModelList);

            return true;
        }

        public FrameworkElement ContentControlFindCustomerContentView
        {
            get => _contentControlFindCustomerContentView;
            set
            {
                _contentControlFindCustomerContentView = value;
                RaisePropertyChanged("ContentControlFindCustomerContentView");
            }
        }

        public void SwitchCustomerView(FindCustomerPage findCustomerPage)
        {
            switch (findCustomerPage)
            {
                case FindCustomerPage.Blank:
                    break;
                case FindCustomerPage.FindCustomerContent:
                    ContentControlFindCustomerContentView = new FindCustomerContentView();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(findCustomerPage), findCustomerPage, null);
            }
        }

        private FindCustomerContentMessage GetFindCustomerContentMessage(List<CustomerModel> customerModelList)
        {
            var findCustomerContentMessage = new FindCustomerContentMessage
            {
                Customers = new List<CustomerContentModel>()
            };

            foreach (var customerModel in customerModelList)
            {
                findCustomerContentMessage.Customers.Add(_customerDesktopMapper.ToCustomerContentModel(customerModel));
            }

            return findCustomerContentMessage;
        }
    }
}
