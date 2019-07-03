﻿using System.Data.Entity;
using WpfApp.DAL.Customers.Models;
using WpfApp.DAL.Reports.Models;

namespace WpfApp.DAL
{
    public class WpfAppContext : DbContext
    {
        public WpfAppContext(string connectionString):base(connectionString)
        {            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}