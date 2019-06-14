using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.BLL.Customers.Models;
using WpfApp.Desktop.Mappers.Customer.Interfaces;
using WpfApp.Desktop.Models.Customer;
using WpfApp.Desktop.Models.Customer.Messages;

namespace WpfApp.Desktop.Mappers.Customer
{
    public class CustomerDesktopMapper : ICustomerDesktopMapper
    {
        public CustomerContentModel ToCustomerContentModel(CustomerModel customerModel)
        {
            var result = new CustomerContentModel
            {
                CustomerId = customerModel.CustomerId,
                FirstName = customerModel.FirstName,
                LastName = customerModel.LastName,
                Address = customerModel.Address,
                Telephone = customerModel.Telephone
            };

            return result;
        }

        public CustomerModel ToCustomerModel(CustomerContentModel customerContentModel)
        {
            var result = new CustomerModel
            {
                CustomerId = customerContentModel.CustomerId,
                FirstName = customerContentModel.FirstName,
                LastName = customerContentModel.LastName,
                Address = customerContentModel.Address,
                Telephone = customerContentModel.Telephone
            };

            return result;
        }

        public CustomerModel ToCustomerModel(FindCustomerContentMessage findCustomerContentMessage)
        {
            var result = new CustomerModel
            {
                CustomerId = findCustomerContentMessage.CustomerId,
                FirstName = findCustomerContentMessage.FirstName,
                LastName = findCustomerContentMessage.LastName,
                Address = findCustomerContentMessage.Address,
                Telephone = findCustomerContentMessage.Telephone
            };

            return result;
        }
    }
}
