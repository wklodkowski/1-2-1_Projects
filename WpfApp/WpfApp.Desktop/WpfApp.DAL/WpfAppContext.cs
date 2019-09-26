using System.Data.Entity;
using WpfApp.DAL.Customers.Models;
using WpfApp.DAL.Invoices.Models;
using WpfApp.DAL.Reports.Models;

namespace WpfApp.DAL
{
    public class WpfAppContext : DbContext
    {
        public WpfAppContext() :base(@"Data Source=WKLODKOWSKI-R;Initial Catalog=WpfApp;Integrated Security=True")
        {            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}