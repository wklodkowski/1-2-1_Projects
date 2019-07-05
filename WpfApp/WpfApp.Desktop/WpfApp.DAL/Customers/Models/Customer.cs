using System.Collections.Generic;
using WpfApp.DAL.Reports.Models;

namespace WpfApp.DAL.Customers.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }

        public ICollection<Report> Reports { get; set; }
    }
}