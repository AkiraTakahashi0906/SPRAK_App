using Prism.Commands;
using Prism.Mvvm;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using SPRAK.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

namespace SPRAK_App.ViewModels
{
    public class ReactiveProperty2ViewModel : BindableBase
    {
        public ReactiveProperty2ViewModel()
        {
            this.Input = new ReactiveProperty<string>(""); // デフォルト値を指定してReactivePropertyを作成
            this.Output = this.Input
                .Delay(TimeSpan.FromSeconds(1)) // 1秒間待機して
                .Select(x => x.ToUpper()) // 大文字に変換して
                .ToReactiveProperty(); // ReactiveProperty化する

            this.ClearCommand = this.Input
                .Select(x => !string.IsNullOrWhiteSpace(x)) // Input.Valueが空じゃないとき
                .ToReactiveCommand(); // 実行可能なCommandを作る
            this.ClearCommand.Subscribe(_ => {
                                                                    this.Input.Value = "";
                                                                    model.Age = 10;
                                                                   });


            this.Name = model
                .ObserveProperty(x => x.Name) // Nameプロパティを監視するIObservableに変換
                .ToReactiveProperty(); // ReactivePropertyに変換

            this.Age = model
                .ObserveProperty(x => x.Age) // Ageプロパティを監視するIObservableに変換
                .Select(x => (x+100).ToString()) // LINQで加工して
                .ToReactiveProperty(); // ReactivePropertyに変換1
        }

        public ReactiveProperty<string> Input { get; private set; }
        public ReactiveProperty<string> Output { get; private set; }
        public ReactiveProperty<string> Name { get; private set; }
        public ReactiveProperty<string> Age { get; private set; }

        public ReactiveCommand ClearCommand { get; private set; }
        public Person model = new Person();
    }
}
