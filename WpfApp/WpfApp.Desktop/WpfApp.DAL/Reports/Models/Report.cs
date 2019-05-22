using System;
using WpfApp.DAL.Customers.Models;

namespace WpfApp.DAL.Reports.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public int Number { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreationDate { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}