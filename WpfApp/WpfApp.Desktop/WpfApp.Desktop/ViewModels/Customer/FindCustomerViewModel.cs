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
using WpfApp.Desktop.Common.Pages.Customer.Enums;
using WpfApp.Desktop.Common.Pages.Customer.Models;
using WpfApp.Desktop.Models.Customer.Messages;
using WpfApp.Desktop.Views.Customer;

namespace WpfApp.Desktop.ViewModels.Customer
{
    public class FindCustomerViewModel : ViewModelBase
    {
        private FrameworkElement _contentControlFindCustomerContentView;

        public int ClientId { get; set; }
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
            var findCustomerContentModel = new FindCustomerContentMessage
            {
                CustomerId = ClientId,
                FirstName = FirstName,
                LastName = LastName
            };

            SwitchCustomerView(FindCustomerPage.FindCustomerContent);
            Messenger.Default.Send(findCustomerContentModel);
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
    }
}
