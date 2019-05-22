using WpfApp.BLL.Customers.Models;
using WpfApp.DAL.Customers.Models;

namespace WpfApp.BLL.Customers.Mappers.Interfaces
{
    public interface ICustomerMapper
    {
        Customer ToCustomer(CustomerModel customerModel);
        CustomerModel ToCustomerModel(Customer customerModel);
    }
}
