using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight;
using WpfApp.Desktop.Common.Pages.Enum;

namespace WpfApp.Desktop.Controls
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        public PageHost()
        {
            InitializeComponent();
        }

        public ViewModelBase CurrentPageViewModel
        {
            get => (ViewModelBase)GetValue(CurrentPageViewModelProperty);
            set => SetValue(CurrentPageViewModelProperty, value);
        }

        public static readonly DependencyProperty CurrentPageViewModelProperty =
            DependencyProperty.Register(nameof(CurrentPageViewModel),
                typeof(ViewModelBase), typeof(PageHost),
                new UIPropertyMetadata());

        //private static object CurrentPagePropertyChanged(DependencyObject dependencyObject, object value)
        //{
        //    var currentPage = (ApplicationPage)value;
        //    var currentPageViewModel = dependencyObject.GetValue(CurrentPageViewModelProperty);

        //    var newPageFrame = (dependencyObject as PageHost).NewPage;
        //    var oldPageFrame = (dependencyObject as PageHost).OldPage;

        //    if (newPageFrame.Content is UserControl page &&
        //        page.ToApplicationPage() == currentPage)
        //    {
        //        // Just update the view model
        //        page.ViewModelObject = currentPageViewModel;

        //        return value;
        //    }

        //}
    }
}
