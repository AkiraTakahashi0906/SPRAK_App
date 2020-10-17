using Prism.Commands;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SPRAK.Domain.Entity;
using SPRAK.Domain.Repositories;
using SPRAK.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace SPRAK_App.ViewModels
{
    public class ReactivePropertyViewModel : BindableBase
    {
        private IShelfBoxRepository _shelfBoxRepository;

        // Disposeが必要なReactivePropertyやReactiveCommandを集約させるための仕掛け
        private CompositeDisposable Disposable { get; } = new CompositeDisposable();

        public ReactivePropertyViewModel():this(Factories.CreateShelfBoxData())
        {
        }

        public ReactivePropertyViewModel(IShelfBoxRepository shelfBoxRepository)
        {
            _shelfBoxRepository = shelfBoxRepository;
            BoxDatas = new ObservableCollection<BoxDataEntity>(_shelfBoxRepository.GetBoxAll());
            BoxDatas2.Value = new ObservableCollection<BoxDataEntity>(_shelfBoxRepository.GetBoxAll());
            Name.Value = "akiraFirst";

            //Index2.Subscribe(x => Console.WriteLine($"Subscribe: {x}")).AddTo(this.Disposable); // 1個 Subscribe: 初期値 
            Index2.Subscribe(x => {
                                                Console.WriteLine($"Subscribe: {x}");
                                                Index = x;
                                                }).AddTo(this.Disposable); // いろいろ行う Subscribe: 初期値 

            //NameTest = new ReactiveProperty<string>()
            //.SetValidateNotifyError(x => string.IsNullOrEmpty(x) ? "空文字はダメ" : null);

            NameTest = new ReactiveProperty<string>(mode: ReactivePropertyMode.Default | ReactivePropertyMode.IgnoreInitialValidationError)
                                                                             .SetValidateNotifyError(x => string.IsNullOrEmpty(x) ? "空文字はダメ" : null).AddTo(this.Disposable); ;

            // デフォルト値が true の設定
            IsChecked = new ReactivePropertySlim<bool>(true).AddTo(this.Disposable);
            // ReactiveProperty は IObservable なので ReactiveCommand にできる
            SampleCommand = IsChecked.ToReactiveCommand().AddTo(this.Disposable);
            // ReactiveCommand は IObservable なので Select で加工して ReactiveProperty に出来る
            Message = SampleCommand.Select(_ => DateTime.Now.ToString())
                .ToReadOnlyReactivePropertySlim().AddTo(this.Disposable);

            ButtonCommand.Subscribe(_ => ButtonAction());

            this.Input = new ReactiveProperty<string>(""); // デフォルト値を指定してReactivePropertyを作成
            this.Output = this.Input
                .Delay(TimeSpan.FromSeconds(1)) // 1秒間待機して
                .Select(x => x.ToUpper()) // 大文字に変換して
                .ToReactiveProperty(); // ReactiveProperty化する

        }

        public ReactiveProperty<string> Input { get; private set; }
        public ReactiveProperty<string> Output { get; private set; }

        public ReactiveCommand ButtonCommand { get; } = new ReactiveCommand();
        private void ButtonAction() {
            Console.WriteLine("RX1");
            Console.WriteLine("RX2");
            Console.WriteLine("RX3");
        }

        public void Dispose()
        {
            // まとめてDisposeする
            Disposable.Dispose();
        }

        private DelegateCommand updateButton;
        public DelegateCommand UpdateButton =>
        updateButton ?? (updateButton = new DelegateCommand(UpdateButtonExecute));

        public ReactivePropertySlim<string> Name { get; } = new ReactivePropertySlim<string>();

        public ReactivePropertySlim<ObservableCollection<BoxDataEntity>> BoxDatas2 { get; } = new ReactivePropertySlim<ObservableCollection<BoxDataEntity>>();
        public ReactivePropertySlim<BoxDataEntity> SelectedBoxData2 { get; } = new ReactivePropertySlim<BoxDataEntity>();
        public ReactivePropertySlim<int> Index2 { get; } = new ReactivePropertySlim<int>();
        public ReactiveProperty<string> NameTest { get; }

        // コマンドのソース用
        public ReactivePropertySlim<bool> IsChecked { get; }
        // コマンドを押したときに更新するメッセージ
        public ReadOnlyReactivePropertySlim<string> Message { get; }
        // コマンド
        public ReactiveCommand SampleCommand { get; }

        private void UpdateButtonExecute()
        {
            Name.Value = "akira2";
            SelectedBoxData= new BoxDataEntity(1, 1, "1", "1", "1");
            SelectedBoxData2.Value = new BoxDataEntity(1, 1, "1", "1", "1");

            //Index = 1;
            Index2.Value = 1;
            //Dispose();
        }

        private ObservableCollection<BoxDataEntity> _BoxDatas = new ObservableCollection<BoxDataEntity>();
        public ObservableCollection<BoxDataEntity> BoxDatas
        {
            get { return _BoxDatas; }
            set
            {
                SetProperty(ref _BoxDatas, value);
            }
        }

        private BoxDataEntity _selectedBoxData;
        public BoxDataEntity SelectedBoxData
        {
            get { return _selectedBoxData; }
            set
            {
                SetProperty(ref _selectedBoxData, value);
            }
        }

        private int _index;
        public int Index
        {
            get { return _index; }
            set
            {
                SetProperty(ref _index, value);
            }
        }

    }
}
