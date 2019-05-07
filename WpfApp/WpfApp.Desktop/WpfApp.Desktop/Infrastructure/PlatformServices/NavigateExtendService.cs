using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using GalaSoft.MvvmLight.Ioc;
using WpfApp.Desktop.Infrastructure.PlatformServices.Interfaces;

namespace WpfApp.Desktop.Infrastructure.PlatformServices
{
    public class NavigateExtendService : INavigateExtendService
    {
        private readonly Dictionary<string, Type> _pagesByKey;
        private readonly List<string> _historic;
        private string _currentPageKey;

        public string CurrentPageKey
        {
            get => _currentPageKey;

            private set
            {
                if (_currentPageKey == value)
                {
                    return;
                }

                _currentPageKey = value;
                OnPropertyChanged("CurrentPageKey");
            }
        }
        public object Parameter { get; private set; }

        public NavigateExtendService()
        {
            _pagesByKey = new Dictionary<string, Type>();
            _historic = new List<string>();
        }
        public void GoBack()
        {
            if (_historic.Count <= 1)
                return;

            _historic.RemoveAt(_historic.Count - 1);
            NavigateTo(_historic.Last(), null);
        }
        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public virtual void NavigateTo(string pageKey, object parameter)
        {
            lock (_pagesByKey)
            {
                if (!_pagesByKey.ContainsKey(pageKey))
                {
                    throw new ArgumentException($"No such page: {pageKey} ", nameof(pageKey));
                }

                var frame = GetDescendantFromName(Application.Current.MainWindow, "MainContent") as ContentControl;

                if (frame != null)
                {
                    frame.DataContext = _pagesByKey[pageKey];
                }

                Parameter = parameter;
                _historic.Add(pageKey);
                CurrentPageKey = pageKey;
            }
        }

        public void Configure(string key, Type pageType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(key))
                {
                    _pagesByKey[key] = pageType;
                }
                else
                {
                    _pagesByKey.Add(key, pageType);
                }
            }
        }

        private static FrameworkElement GetDescendantFromName(DependencyObject parent, string name)
        {
            var count = VisualTreeHelper.GetChildrenCount(parent);

            if (count < 1)
            {
                return null;
            }

            for (var i = 0; i < count; i++)
            {
                if (VisualTreeHelper.GetChild(parent, i) is FrameworkElement frameworkElement)
                {
                    if (frameworkElement.Name == name)
                    {
                        return frameworkElement;
                    }

                    frameworkElement = GetDescendantFromName(frameworkElement, name);
                    if (frameworkElement != null)
                    {
                        return frameworkElement;
                    }
                }
            }
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
