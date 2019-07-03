using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WpfApp.DAL.Reports.Models;

namespace WpfApp.DAL.Customers.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }

        public ICollection<Report> Reports { get; set; }
    }
}