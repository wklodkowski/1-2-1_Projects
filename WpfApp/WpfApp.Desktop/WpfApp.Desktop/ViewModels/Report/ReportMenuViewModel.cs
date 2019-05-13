using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using WpfApp.Desktop.ViewModels.Controls.Menu;

namespace WpfApp.Desktop.ViewModels.Report
{
    public class ReportMenuViewModel : ViewModelBase
    {
        public ViewModelBase Content { get; set; }

        public ReportMenuViewModel()
        {
            Content = new MenuViewModel
            {
                Items = new List<MenuItemViewModel>
                {
                    new MenuItemViewModel{ Text = "Search Report"},
                    new MenuItemViewModel{ Text = "Client Report"}
                }
            };
        }
    }
}
