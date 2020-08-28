using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace SPRAK_App.ViewModels
{
    public class ListSaveViewModel : BindableBase, IDialogAware
    {
        public ListSaveViewModel()
        {
            // 「OK」ボタン コマンド
            OkCommand = new DelegateCommand(
                () => this.RequestClose?.Invoke(new DialogResult(ButtonResult.OK)));

            // 「はい」ボタン コマンド
            YesCommand = new DelegateCommand(
                () => this.RequestClose?.Invoke(new DialogResult(ButtonResult.Yes)));

            // 「いいえ」ボタン コマンド
            NoCommand = new DelegateCommand(
                () => this.RequestClose?.Invoke(new DialogResult(ButtonResult.No)));

            OKButton = new DelegateCommand(OKButtonExecute);
        }

        public string Title => "MessageBoxサンプル";
        public event Action<IDialogResult> RequestClose;

        private string _listSaveTextBox;
        public string ListSaveTextBox
        {
            get { return _listSaveTextBox; }
            set { SetProperty(ref _listSaveTextBox, value); }
        }

        public DelegateCommand OkCommand { get; }
        public DelegateCommand YesCommand { get; }
        public DelegateCommand NoCommand { get; }

        public DelegateCommand OKButton { get; }

        private void OKButtonExecute()
        {
            var p = new DialogParameters();
            p.Add(nameof(ListSaveTextBox),"akira");
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, p));
        }

        public bool CanCloseDialog()
        {
            return true;//画面が閉じれるかどうか
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            ListSaveTextBox = parameters.GetValue<string>(nameof(ListSaveTextBox));
        }
    }
}
