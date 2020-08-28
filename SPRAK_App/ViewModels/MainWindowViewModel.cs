using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using SPRAK_App.Views;
using System.Windows;

namespace SPRAK_App.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

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
        }

        public DelegateCommand PartsListButton { get; }
        public DelegateCommand ListSaveButton { get; }

        private void PartsListButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(PartsListView));
        }

        private void ListSaveButtonExecute()
        {
            var tmp = 1;
            var p = new DialogParameters();
            p.Add(nameof(ListSaveViewModel.ListSaveTextBox), tmp);
            _dialogService.ShowDialog(nameof(ListSaveView),p, ListSaveClose);
        }

        private void ListSaveClose(IDialogResult dialogResult)
        {
            if (dialogResult.Result== ButtonResult.OK)
            {
                MessageBox.Show(dialogResult.Parameters.GetValue<string>(nameof(ListSaveViewModel.ListSaveTextBox)));
            }
        }

    }
}
