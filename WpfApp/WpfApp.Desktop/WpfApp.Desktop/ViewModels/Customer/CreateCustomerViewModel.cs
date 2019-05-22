using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using WpfApp.BLL.Customers.Models;
using WpfApp.BLL.Customers.Services.Interfaces;

namespace WpfApp.Desktop.ViewModels.Customer
{
    public class CreateCustomerViewModel : ViewModelBase
    {
        private readonly ICustomerService _customerService;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }

        public ICommand AddCustomerCommand { get; set; }

        public CreateCustomerViewModel(ICustomerService customerService)
        {
            _customerService = customerService;
            AddCustomerCommand = new RelayCommand(AddCustomer);
        }

        public void AddCustomer()
        {
            var customerModel = new CustomerModel
            {
                FirstName = FirstName,
                LastName = LastName,
                Address = Address,
                Telephone = Telephone
            };

            _customerService.CreateCustomer(customerModel);
        }
    }
}
