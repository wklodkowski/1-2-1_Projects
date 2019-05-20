using System.Collections.Generic;
using System.Linq;
using WpfApp.BLL.Reports.Mappers.Interfaces;
using WpfApp.BLL.Reports.Models;
using WpfApp.BLL.Reports.Services.Interfaces;
using WpfApp.DAL;

namespace WpfApp.BLL.Reports.Services
{
    public class ReportService : IReportService
    {
        private readonly WpfAppContext _wpfAppContext;
        private readonly IReportMapper _reportMapper;

        public ReportService(WpfAppContext wpfAppContext, IReportMapper reportMapper)
        {
            _wpfAppContext = wpfAppContext;
            _reportMapper = reportMapper;
        }

        public List<ReportModel> GetAllReportsForClient(int clientId)
        {
            var clientReports = _wpfAppContext.Reports.Where(x => x.CustomerId == clientId).ToList();
            var result = new List<ReportModel>();

            foreach (var report in clientReports)
            {
                var reportModel = _reportMapper.ToReportModel(report);
                result.Add(reportModel);
            }

            return result;
        }
    }
}
