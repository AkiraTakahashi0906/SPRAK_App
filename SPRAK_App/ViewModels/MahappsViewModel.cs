using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SPRAK_App.ViewModels
{
    public class MahappsViewModel : BindableBase
    {
        //https://qiita.com/HAGITAKO/items/c43b6cfe0e0d86ad1410
        public MetroWindow Metro { get; set; } = System.Windows.Application.Current.MainWindow as MetroWindow;
        public MahappsViewModel()
        {
            ShowMessageCommandExecute();
        }
        private async void ShowMessageCommandExecute()
        {
            await Metro.ShowMessageAsync("This is the title", "Some message");
        }
    }
}
