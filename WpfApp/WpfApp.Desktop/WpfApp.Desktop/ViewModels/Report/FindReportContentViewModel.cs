using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using WpfApp.Desktop.Models.Reports;
using WpfApp.Desktop.Models.Reports.Messages;

namespace WpfApp.Desktop.ViewModels.Report
{
    public class FindReportContentViewModel : ViewModelBase
    {
        private ObservableCollection<CustomerModel> _customersList;

        public ObservableCollection<CustomerModel> CustomersList
        {
            get => _customersList;
            set
            {
                _customersList = value;
                RaisePropertyChanged("CustomersList");
            }
        }

        public FindReportContentViewModel()
        {
            RegisterSwitchReportMessage();
        }

        public void RegisterSwitchReportMessage()
        {
            Messenger.Default.Register<FindReportContentModel>(this, HandleMessage);
        }

        private void HandleMessage(FindReportContentModel message)
        {
            //TODO: Read dynamic data from services

            CustomersList = new ObservableCollection<CustomerModel>();

            CustomersList.Add(new CustomerModel
            {
                ClientId = 1,
                FirstName = "John",
                LastName = "Doe"
            });

            CustomersList.Add(new CustomerModel
            {
                ClientId = 2,
                FirstName = "Diana",
                LastName = "Markovic"
            });

            CustomersList.Add(new CustomerModel
            {
                ClientId = 3,
                FirstName = "Peter",
                LastName = "Czech"
            });
        }
    }
}
