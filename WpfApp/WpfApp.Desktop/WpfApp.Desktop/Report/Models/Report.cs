using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace WpfApp.Desktop.Report.Models
{
    public class Report : ObservableObject
    {
        private int _id;
        private string _firstName;
        private string _lastName;

        public int Id
        {
            get => _id;
            set { Set<int>(() => this.Id, ref _id, value); }
        }

        public string FirstName
        {
            get => _firstName;
            set { Set(() => _firstName, ref _firstName, value); }
        }

        public string LastName
        {
            get => _lastName;
            set { Set(() => _lastName, ref _lastName, value); }
        }
    }
}
