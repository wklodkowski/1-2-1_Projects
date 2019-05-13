using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using WpfApp.Desktop.ViewModels.Controls.Input;

namespace WpfApp.Desktop.ViewModels.Report
{
    public class FindReportMenuViewModel : ViewModelBase
    {
        public InputViewModel ClientId { get; set; }
        public InputViewModel FirstName { get; set; }
        public InputViewModel LastName { get; set; }

        public ICommand SearchComand { get; set; }

        public FindReportMenuViewModel()
        {
            SearchComand = new RelayCommand(SearchCommand);
        }

        public void SearchCommand()
        {
            
        }
    }
}
