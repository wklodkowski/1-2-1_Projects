using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using WpfApp.Desktop.Common.Pages.Enum;
using WpfApp.Desktop.Common.Pages.Models;
using WpfApp.Desktop.Views.Report;

namespace WpfApp.Desktop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private FrameworkElement _contentControlView;

        public ICommand FindReportCommand { get; set; }

        public MainViewModel()
        {
            RegisterSwitchMessage();
            FindReportCommand = new RelayCommand(FindReport);

        }

        public void RegisterSwitchMessage()
        {
            Messenger.Default.Register<SwitchViewMessageModel>(this, (switchViewMessage) =>
            {
                SwitchView(switchViewMessage.Page);
            });
        }

        public FrameworkElement ContentControlView
        {
            get => _contentControlView;
            set
            {
                _contentControlView = value;
                RaisePropertyChanged("ContentControlView");
            }
        }

        public void FindReport()
        {
            SwitchView(ApplicationPage.FindReport);
        }

        public void SwitchView(ApplicationPage page)
        {
            switch (page)
            {
                case ApplicationPage.Home:
                    break;
                case ApplicationPage.FindReport:
                    ContentControlView = new FindReportView();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(page), page, null);
            }
        }
    }
}
