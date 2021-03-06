﻿using System.Configuration;
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using WpfApp.Desktop.Mappers.Customer;
using WpfApp.Desktop.Mappers.Customer.Interfaces;
using WpfApp.Desktop.Mappers.Invoice;
using WpfApp.Desktop.Mappers.Invoice.Interfaces;
using WpfApp.Desktop.Mappers.Report;
using WpfApp.Desktop.Mappers.Report.Interfaces;
using WpfApp.Desktop.ViewModels.Customer;
using WpfApp.Desktop.ViewModels.Invoice;
using WpfApp.Desktop.ViewModels.Report;
using WpfApp.Infrastructure.DI;

namespace WpfApp.Desktop.ViewModels
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            Register();
        }

        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

        //Reports
        public FindReportViewModel FindReportViewModel => ServiceLocator.Current.GetInstance<FindReportViewModel>();
        public FindReportContentViewModel FindReportContentViewModel => ServiceLocator.Current.GetInstance<FindReportContentViewModel>();

        //Customers
        public CreateCustomerViewModel CreateCustomerViewModel => ServiceLocator.Current.GetInstance<CreateCustomerViewModel>();
        public FindCustomerViewModel FindCustomerViewModel => ServiceLocator.Current.GetInstance<FindCustomerViewModel>();
        public FindCustomerContentViewModel FindCustomerContentViewModel => ServiceLocator.Current.GetInstance<FindCustomerContentViewModel>();
        public FindCustomerContentReportViewModel FindCustomerContentReportViewModel => ServiceLocator.Current.GetInstance<FindCustomerContentReportViewModel>();

        //Invoices
        public FindInvoiceViewModel FindInvoiceViewModel => ServiceLocator.Current.GetInstance<FindInvoiceViewModel>();
        public FindInvoiceContentViewModel FindInvoiceContentViewModel => ServiceLocator.Current.GetInstance<FindInvoiceContentViewModel>();


        private static void Register()
        {
            var builder = new ContainerBuilder();
            //var connectionString = GetConnectionString();

            builder.RegisterModule(new WpfAppBllModule());
            //builder.RegisterModule(new WpfAppDalModule
            //{
            //    ConnectionString = connectionString
            //});

            RegisterViewModels(builder);
            RegisterMappers(builder);

            var container = builder.Build();
            var csl = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => csl);
        }

        private static void RegisterViewModels(ContainerBuilder builder)
        {
            builder.RegisterType<MainViewModel>();

            //Report
            builder.RegisterType<FindReportViewModel>();
            builder.RegisterType<FindReportContentViewModel>();

            //Customer
            builder.RegisterType<CreateCustomerViewModel>();
            builder.RegisterType<FindCustomerViewModel>();
            builder.RegisterType<FindCustomerContentViewModel>();
            builder.RegisterType<FindCustomerContentReportViewModel>();

            //Invoice
            builder.RegisterType<FindInvoiceViewModel>();
            builder.RegisterType<FindInvoiceContentViewModel>();
        }

        private static void RegisterMappers(ContainerBuilder builder)
        {
            builder.RegisterType<ReportDesktopMapper>().As<IReportDesktopMapper>();
            builder.RegisterType<CustomerDesktopMapper>().As<ICustomerDesktopMapper>();
            builder.RegisterType<InvoiceDesktopMapper>().As<IInvoiceDesktopMapper>();
        }

        private static string GetConnectionString()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["WpfAppContext"];
            return connectionString.ConnectionString;
        }
    }
}