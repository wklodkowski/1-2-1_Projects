using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Desktop.Infrastructure.Consts;
using WpfApp.Desktop.Infrastructure.PlatformServices.Interfaces;

namespace WpfApp.Desktop.Report.Extensions
{
    public static class ReportExtension
    {
        public static void AddReportNavigationViews(this INavigateExtendService service)
        {
            service.Configure(NavigationViews.ReportView, new Uri($"{NavigationViews.ReportView}.xaml", UriKind.Relative));
            //service.Configure(NavigationViews.ReportView, new Uri(, UriKind.Relative));
        }
    }
}
