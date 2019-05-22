using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.BLL.Reports.Mappers.Interfaces;
using WpfApp.BLL.Reports.Models;
using WpfApp.DAL.Reports.Models;

namespace WpfApp.BLL.Reports.Mappers
{
    public class ReportMapper : IReportMapper
    {
        public ReportModel ToReportModel(Report report)
        {
            var result = new ReportModel
            {
                ReportId = report.ReportId,
                Number = report.Number,
                Amount = report.Amount,
                CreationDate = report.CreationDate.ToShortDateString()
            };

            return result;
        }
    }
}
