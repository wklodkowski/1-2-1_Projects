using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace WpfApp.Desktop.ViewModels.Controls.Input
{
    public class InputViewModel : ViewModelBase
    {
        public string Label { get; set; }
        public string Text { get; set; }

        public ICommand SearchCommand { get; set; }

        public InputViewModel()
        {
            SearchCommand = new RelayCommand(Search);
        }

        public void Search()
        {
            
        }
    }
}
