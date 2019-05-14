using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp.Desktop.Common.Pages.Enum;
using WpfApp.Desktop.Views.Report;

namespace WpfApp.Desktop.Converters.Pages
{
    public static class ApplicationPageToViewConverter
    {
        public static UserControl ToBasePage(this ApplicationPage page, object viewModel = null)
        {
            switch (page)
            {
                case ApplicationPage.Home:
                    break;
                case ApplicationPage.Report:
                    return new ReportView();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(page), page, null);
            }

            //https://stackoverflow.com/questions/21107957/how-to-dynamically-change-usercontrol-on-button-click-present-in-the-usercontr
            //http://strejczek.com/messenger-w-mvvm-light/
        }
    }
}
