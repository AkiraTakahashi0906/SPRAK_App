using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Xps;

namespace SPRAK_App.ViewModels
{
    public class PrintViewModel : BindableBase
    {
        public PrintViewModel()
        {
            PrintButton = new DelegateCommand(PrintButtonExecute);
        }
        public DelegateCommand PrintButton { get; }

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
            tb.Text = "TEST";
            tb.FontSize = 24;
            Canvas.SetTop(tb, 100);
            Canvas.SetLeft(tb, 100);
            canvas.Children.Add(tb);
            page.Children.Add(canvas);

            // 5. 印刷の実行
            writer.Write(page, ticket);
        }
    }
}
