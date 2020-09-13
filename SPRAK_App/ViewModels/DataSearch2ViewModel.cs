using Prism.Commands;
using Prism.Mvvm;
using SPRAK.Domain.Repositories;
using SPRAK.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SPRAK_App.ViewModels
{
    public class DataSearch2ViewModel : BindableBase
    {
        private IPartsListRipository _partsListRipository;
        public DataSearch2ViewModel() : this(Factories.CreatePartsList())
        {
        }
        public DataSearch2ViewModel(IPartsListRipository partsListRipository)
        {
            _partsListRipository = partsListRipository;
            SearchButton1 = new DelegateCommand(SearchButton1Execute);
            SearchButton2 = new DelegateCommand(SearchButton2Execute);
            SearchButton3 = new DelegateCommand(SearchButton3Execute);
            SearchButton4 = new DelegateCommand(SearchButton4Execute);
            NarrowDownSearchButton = new DelegateCommand(NarrowDownSearchButtonExecute);
            NarrowDownLikeSearchButton = new DelegateCommand(NarrowDownLikeSearchButtonExecute);
        }
        public DelegateCommand SearchButton1 { get; }
        public DelegateCommand SearchButton2 { get; }
        public DelegateCommand SearchButton3 { get; }
        public DelegateCommand SearchButton4 { get; }
        public DelegateCommand NarrowDownSearchButton { get; }
        public DelegateCommand NarrowDownLikeSearchButton { get; }

        private DataTable _viewDataTable = new DataTable();
        public DataTable ViewDataTable
        {
            get { return _viewDataTable; }
            set
            {
                SetProperty(ref _viewDataTable, value);
            }
        }

        private string _narrowDownText;
        public string NarrowDownText
        {
            get { return _narrowDownText; }
            set
            {
                SetProperty(ref _narrowDownText, value);
            }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                SetProperty(ref _searchText, value);
            }
        }

        private void SearchButton1Execute()
        {
            ViewDataTable.Clear();
            DataSet dataSet = new DataSet();
            DataTable table = new DataTable("Table");

            // カラム名の追加
            table.Columns.Add("教科");
            table.Columns.Add("点数", Type.GetType("System.Int32"));
            table.Columns.Add("氏名");
            table.Columns.Add("クラス名");

            // DataSetにDataTableを追加
            dataSet.Tables.Add(table);

            // DataRowクラスを使ってデータを追加
            DataRow dr = table.NewRow();
            dr["教科"] = "国語";
            dr["点数"] = 90;
            dr["氏名"] = "田中　一郎";
            dr["クラス名"] = "A";
            dataSet.Tables["Table"].Rows.Add(dr);

            // Rows.Addメソッドを使ってデータを追加
            table.Rows.Add("数学", 80, "田中　一郎", "A");
            table.Rows.Add("英語", 70, "田中　一郎", "A");
            table.Rows.Add("国語", 60, "鈴木　二郎", "A");
            table.Rows.Add("数学", 50, "鈴木　二郎", "A");
            table.Rows.Add("英語", 80, "鈴木　二郎", "A");
            table.Rows.Add("国語", 70, "佐藤　三郎", "B");
            table.Rows.Add("数学", 80, "佐藤　三郎", "B");
            table.Rows.Add("英語", 90, "佐藤　三郎", "B");

            NarrowDownText = "教科";
            ViewDataTable = table;

        }

        private void SearchButton2Execute()
        {
            ViewDataTable.Clear();
            DataSet dataSet = new DataSet();
            DataTable table = new DataTable("Table");

            // カラム名の追加
            table.Columns.Add("部品番号");
            table.Columns.Add("数量", Type.GetType("System.Int32"));
            table.Columns.Add("名称");

            // DataSetにDataTableを追加
            dataSet.Tables.Add(table);

            // Rows.Addメソッドを使ってデータを追加
            table.Rows.Add("T34F3456-123", 8, "testPar1ts");
            table.Rows.Add("T34F3476-163", 2, "te2stParts");
            table.Rows.Add("F34F3450-123", 8, "testP2arts");
            table.Rows.Add("G34J2456-163", 3, "testParts");
            table.Rows.Add("H34F3456-123", 5, "tes3tPa9rts");
            table.Rows.Add("T34F3450-103", 6, "te8stParts");
            table.Rows.Add("T34H3476-163", 1, "testParts");
            table.Rows.Add("F34F3453-103", 2, "testPa5rts");
            table.Rows.Add("G34F2406-163", 3, "testParts");
            table.Rows.Add("H34F3456-123", 5, "tes4tParts");


            NarrowDownText = "部品番号";
            ViewDataTable = table;
        }

        private void SearchButton3Execute()
        {
        }

        private void SearchButton4Execute()
        {
        }

        private void NarrowDownSearchButtonExecute()
        {
            //sample
            //dt_2 = dt_1.Select(" [単価] >= '" + int_1.ToString + "' ").CopyToDataTable
            try
            {
                var tmp = ViewDataTable.Select("[" + NarrowDownText + "] = '" + SearchText + "'").CopyToDataTable();
                ViewDataTable.Clear();
                ViewDataTable = tmp;
            }
            catch
            {
                ViewDataTable.Clear();
            }
        }

        private void NarrowDownLikeSearchButtonExecute()
        {
            try
            {
                var tmp = ViewDataTable.Select("[" + NarrowDownText + "] Like '%" + SearchText + "%'").CopyToDataTable();
                ViewDataTable.Clear();
                ViewDataTable = tmp;
            }
            catch
            {
                ViewDataTable.Clear();
            }
        }

    }
}
