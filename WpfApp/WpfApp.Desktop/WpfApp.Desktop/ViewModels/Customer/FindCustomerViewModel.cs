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
using WpfApp.Desktop.Common.AsyncCommand;
using WpfApp.Desktop.Common.AsyncCommand.Interfaces;
using WpfApp.Desktop.Common.AsyncMessenger;
using WpfApp.Desktop.Models.Customer.Messages;
using WpfApp.Desktop.Pages.Customer.Enums;
using WpfApp.Desktop.Pages.Customer.Models;
using WpfApp.Desktop.Views.Customer;

namespace WpfApp.Desktop.ViewModels.Customer
{
    public class FindCustomerViewModel : ViewModelBase
    {
        private FrameworkElement _contentControlFindCustomerContentView;

        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IAsyncCommand FindCustomerContentCommand { get; set; }

        public FindCustomerViewModel()
        {
            RegisterSwitchCustomerMessage();
            FindCustomerContentCommand = new AsyncCommand<bool>(FindCustomerContentAsync);
        }

        public void RegisterSwitchCustomerMessage()
        {
            Messenger.Default.Register<SwitchCustomerViewMessageModel>(this, (switchCustomerViewMessage) =>
            {
                SwitchCustomerView(switchCustomerViewMessage.CustomerPage);
            });
        }

        public async Task<bool> FindCustomerContentAsync()
        {
            var findCustomerContentModel = new FindCustomerContentMessage
            {
                CustomerId = ClientId,
                FirstName = FirstName,
                LastName = LastName
            };

            SwitchCustomerView(FindCustomerPage.FindCustomerContent);
            await Messenger.Default.SendAsync(findCustomerContentModel);

            return true;
        }

        //public void FindCustomerContent()
        //{
        //    var findCustomerContentModel = new FindCustomerContentMessage
        //    {
        //        CustomerId = ClientId,
        //        FirstName = FirstName,
        //        LastName = LastName
        //    };

        //    SwitchCustomerView(FindCustomerPage.FindCustomerContent);
        //    Messenger.Default.Send(findCustomerContentModel);
        //}

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
