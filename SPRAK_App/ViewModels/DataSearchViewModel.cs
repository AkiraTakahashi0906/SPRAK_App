using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
        public DataSearchViewModel()
        {
            ViewData v = new ViewData();
            v.Field1 = "id";
            v.Field2 = "body";
            v.Field3 = "poet";
            ViewDatas.Add(v);
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

    }
}
