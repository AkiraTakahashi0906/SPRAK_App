using SPRAK_App.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

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

        }
    }
}
