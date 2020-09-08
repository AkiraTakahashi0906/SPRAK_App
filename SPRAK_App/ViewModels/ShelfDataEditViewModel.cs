using Prism.Commands;
using Prism.Mvvm;
using SPRAK.Domain.Entity;
using SPRAK.Domain.Helpers;
using SPRAK.Domain.Repositories;
using SPRAK.Domain.Services;
using SPRAK.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Printing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Xps;

namespace SPRAK_App.ViewModels
{
    public class ShelfDataEditViewModel : BindableBase
    {
        private IShelfBoxRepository _shelfBoxRepository;
        private IMessageService _messageService;

        public ShelfDataEditViewModel() :this(new MessageService(),Factories.CreateShelfBoxData())
        {
        }
        public ShelfDataEditViewModel(IMessageService messageService,IShelfBoxRepository shelfBoxRepository )
        {
            _shelfBoxRepository = shelfBoxRepository;
            _messageService = messageService;
            ShelfDatas = _shelfBoxRepository.GetSheflAll();
            BoxUpdateShelfDatas= _shelfBoxRepository.GetSheflAll();
            BoxDatas = _shelfBoxRepository.GetBoxAll();

            AddNewButton = new DelegateCommand(AddNewButtonExecute);
            BoxSelectedButton = new DelegateCommand(BoxSelectedButtonExecute);
            PrintButton = new DelegateCommand(PrintButtonExecute);
            UpdateButton = new DelegateCommand(UpdateButtonExecute);
        }

        public DelegateCommand AddNewButton { get; }
        public DelegateCommand BoxSelectedButton { get; }
        public DelegateCommand PrintButton { get; }
        public DelegateCommand UpdateButton { get; }

        private void PrintBoxBarcode(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                // FileStreamからBitmapDecoderを作成します。
                // BitmapCacheOptionをOnLoadにすることで画像データをメモリにキャッシュします。
                var decoder = BitmapDecoder.Create(fs, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                ImageSource = decoder.Frames[0];
            }
            //コンパイルするためにはWPFアプリケーションのプロジェクトに
            //「System.Printing」と「ReachFramework」の参照設定を加える必要があります。
            //WPFアプリケーションで印刷を行うにはこれらの参照設定が必要になります。
            // 1.各種オブジェクトの生成
            LocalPrintServer lps = new LocalPrintServer();
            PrintQueue queue = lps.DefaultPrintQueue;
            XpsDocumentWriter writer = PrintQueue.CreateXpsDocumentWriter(queue);

            // 2. 用紙サイズの設定
            PrintTicket ticket = queue.DefaultPrintTicket;
            ticket.PageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA4);
            ticket.PageOrientation = PageOrientation.Portrait;

            // 3. FixedPage の生成
            FixedPage page = new FixedPage();

            // 4. 印字データの作成
            Canvas canvas = new Canvas();
            TextBlock tb = new TextBlock();

            Image image = new Image();
            image.Source = ImageSource;

            Canvas.SetTop(image, 200);
            Canvas.SetLeft(image, 100);
            canvas.Children.Add(image);

            tb.Text = SelectedBoxData.BoxSetAssyNo;
            tb.FontSize = 24;
            Canvas.SetTop(tb, 100);
            Canvas.SetLeft(tb, 100);
            canvas.Children.Add(tb);
            page.Children.Add(canvas);

            // 5. 印刷の実行
            writer.Write(page, ticket);
        }

        private void UpdateButtonExecute()
        {
            if (_messageService.Question("更新しますか？") == MessageBoxResult.OK)
            {
                _messageService.ShowDialog("更新しました。");
            }
        }

        private void PrintButtonExecute()
        {
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Barcode.png");
            BarcodeImageCreate.CreatePng(SelectedBoxData.BoxBarcodeText, filePath);
            PrintBoxBarcode(filePath);
        }

        private void BoxSelectedButtonExecute()
        {
            UpdateBoxInstallationLocationText = SelectedBoxData.BoxInstallationLocation;
            UpdateBoxAssyNoText = SelectedBoxData.BoxSetAssyNo;
        }

        private void AddNewButtonExecute()
        {
            var id = _shelfBoxRepository.GetLatestBoxId();
            var barcodeText = "C2P-" + id;
            var addBoxData = new BoxDataEntity(id,
                                                                     SelectedShelfData.Shelfd,
                                                                     barcodeText,
                                                                     BoxInstallationLocationText,
                                                                     BoxAssyNoText);
            _shelfBoxRepository.AddNewBox(addBoxData);
        }

        private List<BoxDataEntity> _BoxDatas = new List<BoxDataEntity>();
        public List<BoxDataEntity> BoxDatas
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

        private List<ShelfDataEntity> _shelfDatas = new List<ShelfDataEntity>();
        public List<ShelfDataEntity> ShelfDatas
        {
            get { return _shelfDatas; }
            set
            {
                SetProperty(ref _shelfDatas, value);
            }
        }

        private ShelfDataEntity _selectedShelfData;
        public ShelfDataEntity SelectedShelfData
        {
            get { return _selectedShelfData; }
            set
            {
                SetProperty(ref _selectedShelfData, value);
            }
        }

        private string _boxInstallationLocationText;
        public string BoxInstallationLocationText
        {
            get { return _boxInstallationLocationText; }
            set
            {
                SetProperty(ref _boxInstallationLocationText, value);
            }
        }

        private string _boxAssyNoText;
        public string BoxAssyNoText
        {
            get { return _boxAssyNoText; }
            set
            {
                SetProperty(ref _boxAssyNoText, value);
            }
        }

        private string _updateBoxInstallationLocationText;
        public string UpdateBoxInstallationLocationText
        {
            get { return _updateBoxInstallationLocationText; }
            set
            {
                SetProperty(ref _updateBoxInstallationLocationText, value);
            }
        }

        private string _updateBoxAssyNoText;
        public string UpdateBoxAssyNoText
        {
            get { return _updateBoxAssyNoText; }
            set
            {
                SetProperty(ref _updateBoxAssyNoText, value);
            }
        }

        private List<ShelfDataEntity> _boxUpdateShelfDatas = new List<ShelfDataEntity>();
        public List<ShelfDataEntity> BoxUpdateShelfDatas
        {
            get { return _boxUpdateShelfDatas; }
            set
            {
                SetProperty(ref _boxUpdateShelfDatas, value);
            }
        }

        private ShelfDataEntity _boxUpdateSelectedShelfData;
        public ShelfDataEntity BoxUpdateSelectedShelfData
        {
            get { return _boxUpdateSelectedShelfData; }
            set
            {
                SetProperty(ref _boxUpdateSelectedShelfData, value);
            }
        }

        private BitmapSource _imageSource;
        public BitmapSource ImageSource
        {
            get { return _imageSource; }
            set
            {
                SetProperty(ref _imageSource, value);
            }
        }

    }
}
