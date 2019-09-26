using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using WpfApp.BLL.Customers.Mappers;
using WpfApp.BLL.Customers.Mappers.Interfaces;
using WpfApp.BLL.Customers.Services;
using WpfApp.BLL.Customers.Services.Interfaces;
using WpfApp.BLL.Invoices.Mappers;
using WpfApp.BLL.Invoices.Mappers.Interfaces;
using WpfApp.BLL.Invoices.Services;
using WpfApp.BLL.Invoices.Services.Interfaces;
using WpfApp.BLL.Reports.Mappers;
using WpfApp.BLL.Reports.Mappers.Interfaces;
using WpfApp.BLL.Reports.Services;
using WpfApp.BLL.Reports.Services.Interfaces;

namespace WpfApp.Infrastructure.DI
{
    public class WpfAppBllModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Report
            builder.RegisterType<ReportService>().As<IReportService>();
            builder.RegisterType<ReportMapper>().As<IReportMapper>();

            //Customer
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<CustomerMapper>().As<ICustomerMapper>();

            //Invoice
            builder.RegisterType<InvoiceMapper>().As<IInvoiceMapper>();
            builder.RegisterType<InvoiceService>().As<IInvoiceService>();

            //https://medium.com/@cfryerdev/dependency-injection-composition-root-418a1bb19130
        }
    }
}
