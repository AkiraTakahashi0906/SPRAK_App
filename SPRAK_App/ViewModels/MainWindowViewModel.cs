using Prism.Mvvm;

namespace SPRAK_App.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "SPRAK Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
