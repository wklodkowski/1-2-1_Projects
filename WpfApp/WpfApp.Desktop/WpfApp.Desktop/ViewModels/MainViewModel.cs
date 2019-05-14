using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using WpfApp.Desktop.Common.Pages.Enum;

namespace WpfApp.Desktop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Report;
        public ViewModelBase CurrentPageViewModel { get; set; }

        public MainViewModel()
        {

        }

        public void GoToPage(ApplicationPage page, ViewModelBase viewModel = null)
        {
            CurrentPageViewModel = viewModel;
            var different = CurrentPage != page;
            CurrentPage = page;

            if (!different)
                RaisePropertyChanged(nameof(CurrentPage));
        }
    }
}
