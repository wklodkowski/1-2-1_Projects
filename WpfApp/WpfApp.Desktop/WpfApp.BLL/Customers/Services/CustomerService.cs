using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.BLL.Customers.Mappers.Interfaces;
using WpfApp.BLL.Customers.Models;
using WpfApp.BLL.Customers.Services.Interfaces;
using WpfApp.DAL;
using WpfApp.DAL.Customers.Models;

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

        private List<Customer> GetCustomers(CustomerModel customerModel)
        {
            //  var query = someList.Where(a => (someCondition) ? a == "something" : true);
            //var query = someList.Where(a => a == "something");
            //if (condition)
            //{
            //    query = query.Where(b => b == "something else");
            //}
            //var result = query.ToList();

            return null;
        }
    }
}
