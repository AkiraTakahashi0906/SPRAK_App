using Prism.Commands;
using Prism.Mvvm;
using SPRAK.Domain.Entity;
using SPRAK_App.Reports;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Printing;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Xps;
using ZXing;

namespace SPRAK_App.ViewModels
{
    public class PrintViewModel : BindableBase
    {
        public PrintViewModel()
        {
            PrintButton = new DelegateCommand(PrintButtonExecute);
            BarcodeButton = new DelegateCommand(BarcodeButtonExecute);
            BarcodeButton2 = new DelegateCommand(BarcodeButton2Execute);
            ClearButton = new DelegateCommand(ClearButtonExecute);
            XamlPrintButton = new DelegateCommand(XamlPrintButtonExecute);
            Text = "akira";

            var lists = new List<PartsListEtity>();

            for (int i=0 ; i < 35; i++)
            {
                lists.Add(new PartsListEtity(i, 12345, "test1", "tessft1", i));
            }

            PartsList = lists;
        }
        public DelegateCommand PrintButton { get; }
        public DelegateCommand BarcodeButton { get; }
        public DelegateCommand BarcodeButton2 { get; }
        public DelegateCommand ClearButton { get; }
        public DelegateCommand XamlPrintButton { get; }

        private void XamlPrintButtonExecute()
        {
            var insertCount = 0;
            var rowSetting = 15;
            PrintPartsList = new List<PartsListEtity>();
            foreach (var partslist in PartsList)
            {
                PrintPartsList.Add(partslist);
                insertCount++;
                if (insertCount== rowSetting)
                {
                    ReportsPrinter.Print(this);
                    PrintPartsList.Clear();
                    insertCount = 0;
                }
            }
            ReportsPrinter.Print(this);
        }

        private void ClearButtonExecute()
        {
            DisplayedImagePath = null;
        }

        private void BarcodeButton2Execute()
        {
            DisplayedImagePath = null;
            //Nuget ZXing.Net
            var bacodeWriter = new BarcodeWriter();

            // バーコードの種類
            bacodeWriter.Format = BarcodeFormat.CODE_128;

            // サイズ
            bacodeWriter.Options.Height = 100;
            bacodeWriter.Options.Width = 300;

            // バーコード左右の余白
            bacodeWriter.Options.Margin = 30;

            // バーコードのみ表示するか
            // falseにするとテキストも表示する
            bacodeWriter.Options.PureBarcode = false;

            // バーコードBitmapを作成
            using (var bitmap = bacodeWriter.Write("Test99999"))
            {
                // 画像として保存
                var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Barcode2.png");
                bitmap.Save(filePath, ImageFormat.Png);
                DisplayedImagePath = filePath;
            }
            using (var fs = new FileStream(DisplayedImagePath, FileMode.Open, FileAccess.Read))
            {
                // FileStreamからBitmapDecoderを作成します。
                // BitmapCacheOptionをOnLoadにすることで画像データをメモリにキャッシュします。
                var decoder = BitmapDecoder.Create(fs, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                ImageSource = decoder.Frames[0];
            }
        }

        private void BarcodeButtonExecute()
        {
            DisplayedImagePath = null;
            //Nuget ZXing.Net
            var bacodeWriter = new BarcodeWriter();

            // バーコードの種類
            bacodeWriter.Format = BarcodeFormat.CODE_128;

            // サイズ
            bacodeWriter.Options.Height = 100;
            bacodeWriter.Options.Width = 300;

            // バーコード左右の余白
            bacodeWriter.Options.Margin = 30;

            // バーコードのみ表示するか
            // falseにするとテキストも表示する
            bacodeWriter.Options.PureBarcode = false;

            // バーコードBitmapを作成
            using (var bitmap = bacodeWriter.Write("Test11111"))
            {
                // 画像として保存
                var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Barcode2.png");
                bitmap.Save(filePath, ImageFormat.Png);
                DisplayedImagePath = filePath;
            }

            using (var fs = new FileStream(DisplayedImagePath, FileMode.Open, FileAccess.Read))
            {
                // FileStreamからBitmapDecoderを作成します。
                // BitmapCacheOptionをOnLoadにすることで画像データをメモリにキャッシュします。
                var decoder = BitmapDecoder.Create(fs, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                ImageSource = decoder.Frames[0];
            }

        }

        private void PrintButtonExecute()
        {
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
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Barcode2.png");

            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(filePath, UriKind.Relative);
            bitmapImage.EndInit();
            image.Source = bitmapImage;

            Canvas.SetTop(image, 200);
            Canvas.SetLeft(image, 200);
            canvas.Children.Add(image);

            tb.Text = "TEST";
            tb.FontSize = 24;
            Canvas.SetTop(tb, 100);
            Canvas.SetLeft(tb, 100);
            canvas.Children.Add(tb);
            page.Children.Add(canvas);

            // 5. 印刷の実行
            writer.Write(page, ticket);
        }

        private string _displayedImagePath;
        public string DisplayedImagePath
        {
            get { return _displayedImagePath; }
            set
            {
                SetProperty(ref _displayedImagePath, value);
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

        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                SetProperty(ref _text, value);
            }
        }

        private List<PartsListEtity> _partsList;
        public List<PartsListEtity> PartsList
        {
            get { return _partsList; }
            set
            {
                SetProperty(ref _partsList, value);
            }
        }

        private List<PartsListEtity> _printPartsList;
        public List<PartsListEtity> PrintPartsList
        {
            get { return _printPartsList; }
            set
            {
                SetProperty(ref _printPartsList, value);
            }
        }

    }
}
