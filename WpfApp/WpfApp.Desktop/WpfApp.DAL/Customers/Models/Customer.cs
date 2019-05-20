using System.Collections.Generic;
using WpfApp.DAL.Reports.Models;

namespace WpfApp.DAL.Customers.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Report> Report { get; set; }
    }
}
