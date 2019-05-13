using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using WpfApp.Desktop.ViewModels.Report;

namespace WpfApp.Desktop.Report.ViewModels
{
    public class ReportViewModel : ViewModelBase
    {
        public ReportMenuViewModel ReportMenu { get; set; }
    }
}
