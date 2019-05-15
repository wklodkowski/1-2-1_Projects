using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;

namespace WpfApp.Desktop.ViewModels.Report
{
    public class FindReportViewModel : ViewModelBase
    {
        private FrameworkElement _contentControlFindReportView;
        public ICommand SubmitSearchCommand { get; set; }

        public FindReportViewModel()
        {
        }

        public FrameworkElement ContentControlFindReportView
        {
            get => _contentControlFindReportView;
            set
            {
                _contentControlFindReportView = value;
                RaisePropertyChanged("ContentControlFindReportView");
            }
        }
    }
}
