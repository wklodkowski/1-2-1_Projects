using WpfApp.BLL.Customers.Mappers.Interfaces;
using WpfApp.BLL.Customers.Models;
using WpfApp.DAL.Customers.Models;

namespace WpfApp.BLL.Customers.Mappers
{
    public class CustomerMapper : ICustomerMapper
    {
        public Customer ToCustomer(CustomerModel customerModel)
        {
            var result = new Customer
            {
                CustomerId = customerModel.CustomerId,
                FirstName = customerModel.FirstName,
                LastName = customerModel.LastName,
                Address = customerModel.Address,
                Telephone = customerModel.Telephone
            };

            return result;
        }

        public CustomerModel ToCustomerModel(Customer customerModel)
        {
            var result = new CustomerModel
            {
                CustomerId = customerModel.CustomerId,
                FirstName = customerModel.FirstName,
                LastName = customerModel.LastName,
                Address = customerModel.Address,
                Telephone = customerModel.Telephone
            };

            return result;
        }
    }
}
