using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using WpfApp.Desktop.Common.Pages.Interfaces;
using WpfApp.Desktop.Home.Consts;

namespace WpfApp.Desktop.Home.ViewModels
{
    public class HomeViewModel : ViewModelBase, IPageViewModel
    {
        public string Name => HomeConsts.HomeMainPage;
    }
}
