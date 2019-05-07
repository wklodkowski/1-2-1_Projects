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
using WpfApp.Desktop.Report.ViewModels;

namespace WpfApp.Desktop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigateExtendService _navigateExtendService;

        public MainViewModel(INavigateExtendService navigateExtendService)
        {
            _navigateExtendService = navigateExtendService;
        }

        public ICommand _reportCommand { get; private set; }

        public ICommand ReportCommand
        {
            get { return _reportCommand ?? (_reportCommand = new RelayCommand((() => { _navigateExtendService.NavigateTo(NavigationViews.ReportView); }))); }
        }
    }
}
