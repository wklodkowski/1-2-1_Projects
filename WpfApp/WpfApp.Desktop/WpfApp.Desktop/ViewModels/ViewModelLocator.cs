using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using WpfApp.Desktop.Report.ViewModels;

namespace WpfApp.Desktop.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            RegisterViewModels();
        }

        public MainViewModel MainViewModel
        {
            get { return SimpleIoc.Default.GetInstance<MainViewModel>(); }
        }

        public ReportViewModel ReportViewModel
        {
            get { return SimpleIoc.Default.GetInstance<ReportViewModel>(); }
        }

        private static void RegisterViewModels()
        {
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ReportViewModel>();
        }
    }   
}
