using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp.Desktop.Models.Customer.Messages
{
    public class FindCustomerContentMessage
    {
        public List<CustomerContentModel> Customers { get; set; }
    }
}
