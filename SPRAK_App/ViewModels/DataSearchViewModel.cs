using Prism.Commands;
using Prism.Mvvm;
using SPRAK.Domain.Repositories;
using SPRAK.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Permissions;

namespace SPRAK_App.ViewModels
{
    public class ViewData
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
    }

    public class DataSearchViewModel : BindableBase
    {
        private IPartsListRipository _partsListRipository;
        public DataSearchViewModel():this(Factories.CreatePartsList())
        {
        }
        public DataSearchViewModel(IPartsListRipository partsListRipository)
        {
            _partsListRipository = partsListRipository;

            SearchButton1 = new DelegateCommand(SearchButton1Execute);
            SearchButton2 = new DelegateCommand(SearchButton2Execute);
            SearchButton3 = new DelegateCommand(SearchButton3Execute);
            SearchButton4 = new DelegateCommand(SearchButton4Execute);
        }

        public DelegateCommand SearchButton1 { get; }
        public DelegateCommand SearchButton2 { get; }
        public DelegateCommand SearchButton3 { get; }
        public DelegateCommand SearchButton4 { get; }

        private void SearchButton1Execute()
        {
            ViewDatas.Clear();
            ViewData v = new ViewData();
            v.Field1 = "id";
            v.Field2 = "body";
            v.Field3 = "poet";
            ViewDatas.Add(v);
            ViewDatas.Add(v);
            v.Field1 = "id2";
            v.Field2 = "body2222";
            v.Field3 = "poet22ghskfjak2";
            ViewDatas.Add(v);
            ViewDatas.Add(v);
            Field1Text = "akira";
        }

        private void SearchButton2Execute()
        {
            ViewDatas.Clear();
            ViewData v = new ViewData();
            v.Field1 = "id";
            v.Field2 = "body22222222222222222";
            v.Field3 = "poet2";
            ViewDatas.Add(v);
            ViewDatas.Add(v);
            Field1Text = "akira";
        }

        private void SearchButton3Execute()
        {
            Field1Text = "akira";
            var partsList = _partsListRipository.GetPartsList(1);
        }

        private void SearchButton4Execute()
        {
        }

        private ObservableCollection<ViewData> _viewDatas = new ObservableCollection<ViewData>();
        public ObservableCollection<ViewData> ViewDatas
        {
            get { return _viewDatas; }
            set
            {
                SetProperty(ref _viewDatas, value);
            }
        }

        private string _field1Text;
        public string  Field1Text
        {
            get { return _field1Text; }
            set
            {
                SetProperty(ref _field1Text, value);
            }
        }
    }
}
