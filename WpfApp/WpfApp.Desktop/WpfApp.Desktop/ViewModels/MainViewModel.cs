using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using WpfApp.Desktop.Common.Pages.Interfaces;
using WpfApp.Desktop.Report.ViewModels;

namespace WpfApp.Desktop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ICommand _changePageCommand;
        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        public MainViewModel()
        {
            PageViewModels.Add(new ReportViewModel());
            CurrentPageViewModel = PageViewModels[0];
        }

        public List<IPageViewModel> PageViewModels => _pageViewModels ?? (_pageViewModels = new List<IPageViewModel>());

        public IPageViewModel CurrentPageViewModel
        {
            get => _currentPageViewModel;
            set
            {
                if (_currentPageViewModel == value)
                    return;

                _currentPageViewModel = value;
                RaisePropertyChanged();
            }
        }

        public ICommand ChangePageCommand => _changePageCommand ?? (_changePageCommand = new RelayCommand<IPageViewModel>(ChangeViewModel));

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }
    }
}
