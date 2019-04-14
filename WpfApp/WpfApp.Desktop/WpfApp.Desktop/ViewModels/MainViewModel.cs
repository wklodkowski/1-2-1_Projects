using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using WpfApp.Desktop.Infrastructure.Consts;
using WpfApp.Desktop.Infrastructure.PlatformServices.Interfaces;

namespace WpfApp.Desktop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigateExtendService _navigateExtendService;

        public MainViewModel(INavigateExtendService navigateExtendService)
        {
            _navigateExtendService = navigateExtendService;
            GoToReportCommand = new RelayCommand(GoToReportMethod);
        }

        public ICommand GoToReportCommand { get; private set; }

        private RelayCommand _reportCommand;

        public RelayCommand ReportCommand
        {
            get
            {
                return _reportCommand
                       ?? (_reportCommand = new RelayCommand(
                           () =>
                           {
                               _navigateExtendService.NavigateTo("ReportView");
                           }));
            }
        }

        private void GoToReportMethod()
        {
            _navigateExtendService.NavigateTo(NavigationViews.ReportView);
        }
    }
}
