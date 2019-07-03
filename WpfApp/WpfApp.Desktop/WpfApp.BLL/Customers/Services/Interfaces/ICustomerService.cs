using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.BLL.Customers.Models;

namespace WpfApp.BLL.Customers.Services.Interfaces
{
    public interface ICustomerService
    {
        void CreateCustomer(CustomerModel customer);
        Task<List<CustomerModel>> GetCustomersAsync(CustomerModel customerModel);
    }
}
