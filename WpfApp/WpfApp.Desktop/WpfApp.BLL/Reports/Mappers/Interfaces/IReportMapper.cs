using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.BLL.Reports.Models;
using WpfApp.DAL.Reports.Models;

namespace WpfApp.BLL.Reports.Mappers.Interfaces
{
    public interface IReportMapper
    {
        ReportModel ToReportModel(Report report);
    }
}
