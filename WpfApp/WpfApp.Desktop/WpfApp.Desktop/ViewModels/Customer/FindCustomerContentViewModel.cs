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
        private string _panelMainMessage = "Loading...";
        private string _panelSubMessage = "Please wait !";

        public FindCustomerContentViewModel(ICustomerService customerService, ICustomerDesktopMapper customerDesktopMapper)
        {
            _customerService = customerService;
            _customerDesktopMapper = customerDesktopMapper;
            _customersList = new ObservableCollection<CustomerContentModel>();
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

        private void RegisterSwitchCustomerMessage()
        {
            Messenger.Default.Register<FindCustomerContentMessage>(this, HandleRegisterSwitchCustomerMessage);
        }

        //private async void HandleRegisterSwitchCustomerMessage(FindCustomerContentMessage findCustomerContentMessage)
        //{
        //try
        //{
        //    IsLoadingPanelVisible = true;
        //    var customers = Task.Run(() => GetCustomers(findCustomerContentMessage.CustomerContentModel));

        //    await customers.ContinueWith(
        //        manifest =>
        //        {
        //            if (manifest.Result == null)
        //                throw new InvalidOperationException();

        //            IsLoadingPanelVisible = false;
        //        });

        //    foreach (var customer in await customers)
        //    {
        //        CustomerList.Add(customer);
        //    }
        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine(e);
        //    throw;
        //}           
        //}

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
            

            try
            {
                var customerModel = _customerDesktopMapper.ToCustomerModel(customerContentModel);
                var customerModelList = _customerService.GetCustomers(customerModel);
                var result = new List<CustomerContentModel>();

                foreach (var customer in customerModelList)
                {
                    result.Add(_customerDesktopMapper.ToCustomerContentModel(customer));
                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
