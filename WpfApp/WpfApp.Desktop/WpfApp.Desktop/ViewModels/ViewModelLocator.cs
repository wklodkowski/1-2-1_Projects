using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using WpfApp.Desktop.ViewModels.Report;

namespace WpfApp.Desktop.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            RegisterViewModels();
        }

        public MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();

        public FindReportViewModel ReportViewModel => SimpleIoc.Default.GetInstance<FindReportViewModel>();

        private static void RegisterViewModels()
        {
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<FindReportViewModel>();
        }
    }   
}
