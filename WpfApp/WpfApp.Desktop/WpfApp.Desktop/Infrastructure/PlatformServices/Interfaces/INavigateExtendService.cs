using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;

namespace WpfApp.Desktop.Infrastructure.PlatformServices.Interfaces
{
    public interface INavigateExtendService : INavigationService
    {
        object Parameter { get; }
        void Configure(string key, Uri pageType);
    }
}
