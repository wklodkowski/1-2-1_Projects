using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WpfApp.Desktop.Pages.Main.Enum;
using WpfApp.Desktop.Pages.Main.Models;

namespace WpfApp.Desktop.ViewModels.Home
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand ChangeToSecondViewCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send<SwitchViewMessageModel>(new SwitchViewMessageModel { Page = ApplicationPage.Home});
                });
            }
        }
    }
}
