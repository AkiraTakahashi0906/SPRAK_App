using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using SPRAK.Domain.Entity;
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
            CanCloseFlg = false;
        }

        public string Title => "MessageBoxサンプル";
        public event Action<IDialogResult> RequestClose;

        private bool _canCloseFlg;
        public bool CanCloseFlg
        {
            get { return _canCloseFlg; }
            set { SetProperty(ref _canCloseFlg, value); }
        }

        private string _listSaveTextBox;
        public string ListSaveTextBox
        {
            get { return _listSaveTextBox; }
            set { SetProperty(ref _listSaveTextBox, value); }
        }

        private string _pyrotechnicPartsNumber;
        public string PyrotechnicPartsNumber
        {
            get { return _pyrotechnicPartsNumber; }
            set { SetProperty(ref _pyrotechnicPartsNumber, value); }
        }

        private DateTime _pyrotechnicEffectiveDate;
        public DateTime PyrotechnicEffectiveDate
        {
            get { return _pyrotechnicEffectiveDate; }
            set { SetProperty(ref _pyrotechnicEffectiveDate, value); }
        }

        public DelegateCommand OkCommand { get; }
        public DelegateCommand YesCommand { get; }
        public DelegateCommand NoCommand { get; }
        public DelegateCommand OKButton { get; }

        private void OKButtonExecute()
        {
            CanCloseFlg = true;
            var p = new DialogParameters();
            var pyrotechnic = new PyrotechnicEntity(1, PyrotechnicPartsNumber, PyrotechnicEffectiveDate);
            p.Add(nameof(ListSaveTextBox), pyrotechnic);
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, p));
        }

        public bool CanCloseDialog()
        {
            //return true;//画面が閉じれるかどうか
            return CanCloseFlg;
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
