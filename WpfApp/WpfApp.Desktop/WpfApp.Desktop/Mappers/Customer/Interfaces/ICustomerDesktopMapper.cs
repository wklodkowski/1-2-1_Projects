using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.BLL.Customers.Models;
using WpfApp.Desktop.Models.Customer;

namespace WpfApp.Desktop.Mappers.Customer.Interfaces
{
    public interface ICustomerDesktopMapper
    {
        CustomerContentModel ToCustomerContentModel(CustomerModel customerModel);
        CustomerModel ToCustomerModel(CustomerContentModel customerContentModel);
    }
}
