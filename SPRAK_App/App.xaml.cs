using SPRAK_App.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using SPRAK_App.ViewModels;

namespace SPRAK_App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<PartsListView>();
            containerRegistry.RegisterDialog<ListSaveView, ListSaveViewModel>();
            containerRegistry.RegisterForNavigation<DataSearchView>();
            containerRegistry.RegisterForNavigation<PrintView>();
            containerRegistry.RegisterForNavigation<DataEditView>();
        }
    }
}
