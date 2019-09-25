using System.Data.Entity;
using WpfApp.DAL.Customers.Models;
using WpfApp.DAL.Reports.Models;

namespace WpfApp.DAL
{
    public class WpfAppContext : DbContext
    {
        public WpfAppContext() :base(@"Data Source=DESKTOP-2ASTG8P\SQLEXPRESS;Initial Catalog=WpfApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}