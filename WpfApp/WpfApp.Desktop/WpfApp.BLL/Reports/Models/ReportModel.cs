using System;

namespace WpfApp.BLL.Reports.Models
{
    public class ReportModel
    {
        public int ReportId { get; set; }
        public int Number { get; set; }
        public decimal Amount { get; set; }
        public string CreationDate { get; set; }
    }
}
