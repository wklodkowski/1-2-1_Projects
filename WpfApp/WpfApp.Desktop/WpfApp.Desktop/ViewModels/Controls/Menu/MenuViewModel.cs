using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace WpfApp.Desktop.ViewModels.Controls.Menu
{
    public class MenuViewModel : ViewModelBase
    {
        public List<MenuItemViewModel> Items { get; set; }
    }
}
