using System.Collections.Generic;
using WpfApp.BLL.Reports.Models;

namespace WpfApp.BLL.Reports.Services.Interfaces
{
    public interface IReportService
    {
        List<ReportModel> GetAllReportsForClient(int clientId);
    }
}
