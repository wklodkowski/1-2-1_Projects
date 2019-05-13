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
            RegisterControls();
        }

        public MainViewModel MainViewModel
        {
            get { return SimpleIoc.Default.GetInstance<MainViewModel>(); }
        }

        public ReportViewModel ReportViewModel
        {
            get { return SimpleIoc.Default.GetInstance<ReportViewModel>(); }
        }

        public FindReportMenuViewModel FindReportMenuViewModel
        {
            get { return SimpleIoc.Default.GetInstance<FindReportMenuViewModel>(); }
        }

        public FindReportInputViewModel FindReportInputViewModel
        {
            get { return SimpleIoc.Default.GetInstance<FindReportInputViewModel>(); }
        }

        private static void RegisterViewModels()
        {
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ReportViewModel>();
        }

        private static void RegisterControls()
        {
            SimpleIoc.Default.Register<FindReportMenuViewModel>();
            SimpleIoc.Default.Register<FindReportInputViewModel>();
        }
    }   
}
