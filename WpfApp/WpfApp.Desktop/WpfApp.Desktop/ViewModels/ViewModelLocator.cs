using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using WpfApp.Desktop.Infrastructure.PlatformServices;
using WpfApp.Desktop.Infrastructure.PlatformServices.Interfaces;
using WpfApp.Desktop.Report.Extensions;
using WpfApp.Desktop.Report.ViewModels;

namespace WpfApp.Desktop.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ReportViewModel>();
            SetupNavigation();
        }

        public MainViewModel MainViewModel
        {
            get { return SimpleIoc.Default.GetInstance<MainViewModel>(); }
        }

        public ReportViewModel ReportViewModel
        {
            get { return SimpleIoc.Default.GetInstance<ReportViewModel>(); }
        }

        private static void SetupNavigation()
        {
            var navigation = new NavigateExtendService();
            
            navigation.AddReportNavigationViews();
            SimpleIoc.Default.Register<INavigateExtendService>(() => navigation);
        }
    }   
}
