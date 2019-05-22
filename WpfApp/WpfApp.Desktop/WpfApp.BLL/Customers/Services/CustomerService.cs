using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.BLL.Customers.Mappers.Interfaces;
using WpfApp.BLL.Customers.Models;
using WpfApp.BLL.Customers.Services.Interfaces;
using WpfApp.DAL;

namespace WpfApp.BLL.Customers.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly WpfAppContext _wpfAppContext;
        private readonly ICustomerMapper _customerMapper;

        public CustomerService(WpfAppContext wpfAppContext, ICustomerMapper customerMapper)
        {
            _wpfAppContext = wpfAppContext;
            _customerMapper = customerMapper;
        }

        public void CreateCustomer(CustomerModel customer)
        {
            var customerDb = _customerMapper.ToCustomer(customer);
            _wpfAppContext.Customers.Add(customerDb);
            _wpfAppContext.SaveChanges();
        }

        public List<CustomerModel> GetCustomersByLastName(string lastName)
        {
            var customersDb = _wpfAppContext.Customers.Where(c => c.LastName == lastName).ToList();
            return customersDb.Select(customer => _customerMapper.ToCustomerModel(customer)).ToList();
        }
    }
}
