using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using WpfApp.BLL.Reports.Mappers;
using WpfApp.BLL.Reports.Mappers.Interfaces;
using WpfApp.BLL.Reports.Services;
using WpfApp.BLL.Reports.Services.Interfaces;

namespace WpfApp.Infrastructure.DI
{
    public class WpfAppBllModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ReportService>().As<IReportService>();
            builder.RegisterType<ReportMapper>().As<IReportMapper>();
        }
    }
}
