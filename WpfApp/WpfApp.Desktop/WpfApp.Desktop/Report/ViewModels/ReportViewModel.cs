using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using WpfApp.Desktop.Common.Pages.Interfaces;
using WpfApp.Desktop.Report.Consts;

namespace WpfApp.Desktop.Report.ViewModels
{
    public class ReportViewModel : ViewModelBase, IPageViewModel
    {
        public string Name => ReportConsts.ReportMainPage;
    }
}
