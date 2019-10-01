using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using WpfApp.BLL.Customers.Models;
using WpfApp.BLL.Customers.Services.Interfaces;
using WpfApp.BLL.Invoices.Services.Interfaces;
using WpfApp.Desktop.Mappers.Customer.Interfaces;
using WpfApp.Desktop.Models.Customer;
using WpfApp.Desktop.Models.Customer.Messages;
using WpfApp.Desktop.Pages.Customer.Enums;
using WpfApp.Desktop.Pages.Customer.Models;

namespace WpfApp.Desktop.ViewModels.Customer
{
    public class FindCustomerContentViewModel : ViewModelBase
    {
        private ObservableCollection<CustomerContentModel> _customersList;
        private readonly ICustomerService _customerService;
        private readonly ICustomerDesktopMapper _customerDesktopMapper;

        private bool _isLoadingPanelVisible;
        private string _panelMainMessage = "Loading...";
        private string _panelSubMessage = "Please wait !";

        //public ICommand SelectRowCommand { get; set; }
        public ICommand GenerateReportCommand { get; set; }
        public CustomerContentModel SelectedCustomer { get; set; }

        public FindCustomerContentViewModel(ICustomerService customerService, ICustomerDesktopMapper customerDesktopMapper)
        {
            _customerService = customerService;
            _customerDesktopMapper = customerDesktopMapper;
            _customersList = new ObservableCollection<CustomerContentModel>();
            //SelectRowCommand = new RelayCommand(SelectRow);
            GenerateReportCommand = new RelayCommand(GenerateReport);
            RegisterSwitchCustomerMessage();
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

        public ObservableCollection<CustomerContentModel> CustomerList
        {
            get => _customersList;
            set
            {
                _customersList = value;
                RaisePropertyChanged("CustomerList");
            }
        }

        //public void SelectRow()
        //{
        //    int i;
        //    i = 10;
        //}

        public void GenerateReport()
        {
            var swithchFindCustomerView = new SwitchCustomerViewMessageModel
            {
                CustomerPage = FindCustomerPage.FindCustomerContentReport
            };
            Messenger.Default.Send(swithchFindCustomerView);
            Messenger.Default.Send(new FindCustomerContentReportMessage{ClientId = SelectedCustomer.CustomerId});
        }

        private void RegisterSwitchCustomerMessage()
        {
            Messenger.Default.Register<FindCustomerContentMessage>(this, HandleRegisterSwitchCustomerMessage);
        }

        private void HandleRegisterSwitchCustomerMessage(FindCustomerContentMessage findCustomerContentMessage)
        {
            IsLoadingPanelVisible = true;
            Task.Run(() => GetCustomers(findCustomerContentMessage.CustomerContentModel)).ContinueWith(
                manifest =>
                {
                    if (manifest.Result == null)
                        throw new InvalidOperationException();

                    if (Application.Current.Dispatcher != null)
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            IsLoadingPanelVisible = false;
                            foreach (var customer in manifest.Result)
                            {
                                CustomerList.Add(customer);
                            }
                        });
                });
        }

        private List<CustomerContentModel> GetCustomers(CustomerContentModel customerContentModel)
        {
            var customerModel = _customerDesktopMapper.ToCustomerModel(customerContentModel);
            var customerModelList = _customerService.GetCustomers(customerModel);
            return customerModelList.Select(customer => _customerDesktopMapper.ToCustomerContentModel(customer)).ToList();
        }

        // Do Task.Run vol 2

        //private async void HandleRegisterSwitchCustomerMessage(FindCustomerContentMessage findCustomerContentMessage)
        //{

        //    IsLoadingPanelVisible = true;

        //    var customers = await Task.Run(() => GetCustomers(findCustomerContentMessage.CustomerContentModel));


        //    IsLoadingPanelVisible = false;
        //    foreach (var customer in customers)
        //    {
        //        CustomerList.Add(customer);
        //    }

        //}

        //Do async metod
        //https://stackoverflow.com/questions/41957837/context-savechangesasync-is-blocking

        //private async void HandleRegisterSwitchCustomerMessage(FindCustomerContentMessage findCustomerContentMessage)
        //{

        //    IsLoadingPanelVisible = true;
        //    var customerModelList = await _customerService.GetCustomersAsync(_customerDesktopMapper.ToCustomerModel(findCustomerContentMessage.CustomerContentModel));
        //    var result = new List<CustomerContentModel>();

        //    foreach (var customer in customerModelList)
        //    {
        //        result.Add(_customerDesktopMapper.ToCustomerContentModel(customer));
        //    }

        //    IsLoadingPanelVisible = false;
        //    foreach (var customer in result)
        //    {
        //        CustomerList.Add(customer);
        //    }
        //}
    }
}
