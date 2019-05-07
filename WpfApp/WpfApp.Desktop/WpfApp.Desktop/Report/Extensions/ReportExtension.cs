using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Desktop.Infrastructure.Consts;
using WpfApp.Desktop.Infrastructure.PlatformServices.Interfaces;
using WpfApp.Desktop.Report.ViewModels;
using WpfApp.Desktop.Report.Views;

namespace WpfApp.Desktop.Report.Extensions
{
    public static class ReportExtension
    {
        public static void AddReportNavigationViews(this INavigateExtendService service)
        {
            service.Configure(NavigationViews.ReportView, typeof(ReportViewModel));
            //service.Configure(NavigationViews.ReportView, new Uri(, UriKind.Relative));
        }
    }
}
