﻿using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using SPRAK.Domain.Entity;
using SPRAK_App.Views;
using System.Threading.Tasks;
using System.Windows;

namespace SPRAK_App.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        public MetroWindow Metro { get; set; } = System.Windows.Application.Current.MainWindow as MetroWindow;

        private IRegionManager _regionManager;
        private IDialogService _dialogService;

        private string _title = "SPRAK Prism Application";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public MainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _dialogService = dialogService;

            PartsListButton = new DelegateCommand(PartsListButtonExecute);
            ListSaveButton = new DelegateCommand(ListSaveButtonExecute);
            DataSearchButton = new DelegateCommand(DataSearchButtonExecute);
            PrintButton = new DelegateCommand(PrintButtonExecute);
            EditButton = new DelegateCommand(EditButtonExecute);
            ShelfButton = new DelegateCommand(ShelfButtonExecute);
            DataSearch2Button = new DelegateCommand(DataSearch2ButtonExecute);
            MahappsViewButton = new DelegateCommand(MahappsViewButtonExecute);
            ReactivePropertyButton = new DelegateCommand(ReactivePropertyButtonExecute);
            ReactiveProperty2Button = new DelegateCommand(ReactiveProperty2ButtonExecute);
        }

        private DelegateCommand showMessageCommand;
        public DelegateCommand ShowMessageCommand =>
            showMessageCommand ?? (showMessageCommand = new DelegateCommand(ShowMessageCommandExecute));

        public DelegateCommand PartsListButton { get; }
        public DelegateCommand ListSaveButton { get; }
        public DelegateCommand DataSearchButton { get; }
        public DelegateCommand PrintButton { get; }
        public DelegateCommand EditButton { get; }
        public DelegateCommand ShelfButton { get; }
        public DelegateCommand DataSearch2Button { get; }
        public DelegateCommand MahappsViewButton { get; }
        public DelegateCommand ReactivePropertyButton { get; }
        public DelegateCommand ReactiveProperty2Button { get; }

        private async void ShowMessageCommandExecute()
        {
            await Metro.ShowMessageAsync("This is the title", "Some message");
        }

        private void ReactiveProperty2ButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(ReactiveProperty2View));
        }

        private void ReactivePropertyButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(ReactivePropertyView));
        }

        private  void MahappsViewButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(MahappsView));
        }

        private void ShelfButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(ShelfDataEditView));
        }

        private void EditButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(DataEditView));
        }

        private void PrintButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(PrintView));
        }

        private void DataSearchButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(DataSearchView));
        }

        private void PartsListButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(PartsListView));
        }

        private void DataSearch2ButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(DataSearch2View));
        }

        private void ListSaveButtonExecute()
        {
            var tmp = 1;
            var p = new DialogParameters();
            p.Add(nameof(ListSaveViewModel.ListSaveTextBox), tmp);
            _dialogService.ShowDialog(nameof(ListSaveView),p, ListSaveClose);//delegate
        }

        private void ListSaveClose(IDialogResult dialogResult)
        {
            if (dialogResult.Result== ButtonResult.OK)
            {
                var kayaku = dialogResult.Parameters.GetValue<PyrotechnicEntity>(nameof(ListSaveViewModel.ListSaveTextBox));
                MessageBox.Show(kayaku.PartsNumber);
            }
        }

    }
}
