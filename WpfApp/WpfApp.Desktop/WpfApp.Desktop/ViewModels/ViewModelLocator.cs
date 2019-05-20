using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using WpfApp.Desktop.Mappers.Report;
using WpfApp.Desktop.Mappers.Report.Interfaces;
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
        public FindReportViewModel ReportViewModel => ServiceLocator.Current.GetInstance<FindReportViewModel>();
        public FindReportContentViewModel FindReportContentViewModel => ServiceLocator.Current.GetInstance<FindReportContentViewModel>();

        private static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<WpfAppInfrastructureModule>();
            RegisterViewModels(builder);
            RegisterMappers(builder);

            var container = builder.Build();
            var csl = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => csl);
        }

        private static void RegisterViewModels(ContainerBuilder builder)
        {
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<FindReportViewModel>();
            builder.RegisterType<FindReportContentViewModel>();
        }

        private static void RegisterMappers(ContainerBuilder builder)
        {
            builder.RegisterType<ReportMapper>().As<IReportMapper>();
        }
    }
}