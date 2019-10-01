using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
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
        private FrameworkElement _contentControlFindCustomerContentView;

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICommand FindCustomerContentCommand { get; set; }

        public FindCustomerViewModel()
        {
            RegisterSwitchCustomerMessage();
            FindCustomerContentCommand = new RelayCommand(FindCustomerContent);
        }

        public void RegisterSwitchCustomerMessage()
        {
            Messenger.Default.Register<SwitchCustomerViewMessageModel>(this, (switchCustomerViewMessage) =>
            {
                SwitchCustomerView(switchCustomerViewMessage.CustomerPage);
            });
        }

        public void FindCustomerContent()
        {
            var findCustomerContentMessage = new FindCustomerContentMessage()
            {
                CustomerContentModel = new CustomerContentModel
                {
                    CustomerId = CustomerId,
                    FirstName = FirstName,
                    LastName = LastName
                }
            };
            SwitchCustomerView(FindCustomerPage.FindCustomerContent);
            Messenger.Default.Send(findCustomerContentMessage);
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
                case FindCustomerPage.FindCustomerContentReport:
                    ContentControlFindCustomerContentView = new FindCustomerContentReportView();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(findCustomerPage), findCustomerPage, null);
            }
        }

        //private async Task GetCustomer(CustomerModel customerModel)
        //{
        //    var result = await _customerService.GetCustomersAsync(customerModel);
        //    var customerContentModelList = GetFindCustomerContentMessage(result);

        //    if (Application.Current.Dispatcher != null)
        //        Application.Current.Dispatcher.Invoke(() =>
        //        {
        //            SwitchCustomerView(FindCustomerPage.FindCustomerContent);
        //        });
        //    Messenger.Default.Send(customerContentModelList);
        //}
    }
}
