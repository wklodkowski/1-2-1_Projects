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
using WpfApp.Desktop.Common.Pages.Main.Enum;
using WpfApp.Desktop.Common.Pages.Main.Models;
using WpfApp.Desktop.Views.Customer;
using WpfApp.Desktop.Views.Report;

namespace WpfApp.Desktop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private FrameworkElement _contentControlView;

        public ICommand FindReportCommand { get; set; }
        public ICommand CreateCustomerCommand { get; set; }
        public ICommand FindCustomerCommand { get; set; }

        public MainViewModel()
        {
            RegisterSwitchMessage();
            FindReportCommand = new RelayCommand(FindReport);
            CreateCustomerCommand = new RelayCommand(CreateCustomer);
            FindCustomerCommand = new RelayCommand(FindCustomer);
        }

        public void RegisterSwitchMessage()
        {
            Messenger.Default.Register<SwitchViewMessageModel>(this, (switchViewMessage) =>
            {
                SwitchView(switchViewMessage.Page);
            });
        }

        public FrameworkElement ContentControlView
        {
            get => _contentControlView;
            set
            {
                _contentControlView = value;
                RaisePropertyChanged("ContentControlView");
            }
        }

        public void FindReport()
        {
            SwitchView(ApplicationPage.FindReports);
        }

        public void CreateCustomer()
        {
            SwitchView(ApplicationPage.CreateCustomer);
        }

        public void FindCustomer()
        {
            SwitchView(ApplicationPage.FindCustomers);
        }

        public void SwitchView(ApplicationPage page)
        {
            switch (page)
            {
                case ApplicationPage.Home:
                    break;
                case ApplicationPage.FindReports:
                    ContentControlView = new FindReportView();
                    break;
                case ApplicationPage.CreateCustomer:
                    ContentControlView = new CreateCustomerView();
                    break;
                case ApplicationPage.FindCustomers:
                    ContentControlView = new FindCustomerView();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(page), page, null);
            }
        }
    }
}
