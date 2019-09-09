using System.Data.Entity;
using WpfApp.DAL.Customers.Models;
using WpfApp.DAL.Reports.Models;

namespace WpfApp.DAL
{
    public class WpfAppContext : DbContext
    {
        public WpfAppContext() :base()
        {            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}