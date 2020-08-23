using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using SPRAK_App.Views;

namespace SPRAK_App.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        private IRegionManager _regionManager;

        private string _title = "SPRAK Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            PartsListButton = new DelegateCommand(PartsListButtonExecute);
        }

        public DelegateCommand PartsListButton { get; }

        private void PartsListButtonExecute()
        {
            _regionManager.RequestNavigate("ContentRegion", nameof(PartsListView));
        }

    }
}
