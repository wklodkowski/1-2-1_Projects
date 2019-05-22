using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using WpfApp.BLL.Reports.Services.Interfaces;
using WpfApp.Desktop.Models.Report;
using WpfApp.Desktop.Models.Report.Messages;

namespace WpfApp.Desktop.ViewModels.Report
{
    public class FindReportContentViewModel : ViewModelBase
    {
        private ObservableCollection<ReportContentModel> _reportList;
        private readonly IReportService _reportService;

        public FindReportContentViewModel(IReportService reportService)
        {
            _reportService = reportService;
            RegisterSwitchReportMessage();
        }

        public ObservableCollection<ReportContentModel> ReportsList
        {
            get => _reportList;
            set
            {
                _reportList = value;
                RaisePropertyChanged("ReportsList");
            }
        }

        private void RegisterSwitchReportMessage()
        {
            Messenger.Default.Register<FindReportContentMessage>(this, HandleRegisterSwitchReportMessage);
        }

        private void HandleRegisterSwitchReportMessage(FindReportContentMessage message)
        {
            //TODO: Read dynamic data from services

            //var reportsForClient = _reportService.GetAllReportsForClient(message.ClientId);

            ReportsList = new ObservableCollection<ReportContentModel>();
    
            //CustomersList.Add(new ReportModel
            //{
            //    ClientId = 1,
            //    FirstName = "John",
            //    LastName = "Doe"
            //});

            //CustomersList.Add(new CustomerModel
            //{
            //    ClientId = 2,
            //    FirstName = "Diana",
            //    LastName = "Markovic"
            //});

            //CustomersList.Add(new CustomerModel
            //{
            //    ClientId = 3,
            //    FirstName = "Peter",
            //    LastName = "Czech"
            //});
        }
    }
}
