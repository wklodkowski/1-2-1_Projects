﻿using System;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using WpfApp.Desktop.Models.Report.Messages;
using WpfApp.Desktop.Pages.Report.Enums;
using WpfApp.Desktop.Pages.Report.Models;
using WpfApp.Desktop.Views.Report;

namespace WpfApp.Desktop.ViewModels.Report
{
    public class FindReportViewModel : ViewModelBase
    {
        private FrameworkElement _contentControlFindReportContentView;

        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICommand FindReportContentCommand { get; set; }

        public FindReportViewModel()
        {
            RegisterSwitchReportMessage();
            FindReportContentCommand = new RelayCommand(FindReportContent);
        }

        public void RegisterSwitchReportMessage()
        {
            Messenger.Default.Register<SwitchReportViewMessageModel>(this, (switchReportViewMessage) =>
            {
                SwitchReportView(switchReportViewMessage.ReportPage);
            });
        }

        public void FindReportContent()
        {
            var findReportContentModel = new FindReportContentMessage
            {
                ClientId = ClientId,
                FirstName = FirstName,
                LastName = LastName
            };
            SwitchReportView(FindReportPage.FindReportContent);
            Messenger.Default.Send(findReportContentModel);            
        }

        public FrameworkElement ContentControlFindReportContentView
        {
            get => _contentControlFindReportContentView;
            set
            {
                _contentControlFindReportContentView = value;
                RaisePropertyChanged("ContentControlFindReportContentView");
            }
        }

        public void SwitchReportView(FindReportPage findReportPage)
        {
            switch (findReportPage)
            {
                case FindReportPage.Blank:
                    break;
                case FindReportPage.FindReportContent:
                    ContentControlFindReportContentView = new FindReportContentView();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(findReportPage), findReportPage, null);
            }
        }
    }
}
