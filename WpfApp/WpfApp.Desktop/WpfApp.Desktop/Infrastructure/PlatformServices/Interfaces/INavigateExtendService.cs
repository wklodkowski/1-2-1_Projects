using System;
using GalaSoft.MvvmLight.Views;

namespace WpfApp.Desktop.Infrastructure.PlatformServices.Interfaces
{
    public interface INavigateExtendService : INavigationService
    {
        object Parameter { get; }
        void Configure(string key, Type pageType);
    }
}
