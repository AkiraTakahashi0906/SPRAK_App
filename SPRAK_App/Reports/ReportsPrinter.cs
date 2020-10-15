using SPRAK_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Xps;

namespace SPRAK_App.Reports
{
    public static class ReportsPrinter
    {
        public static void Print(PrintViewModel viewModel)
        {
            //Set up the WPF Control to be printed
            var fixedDoc = new FixedDocument();
            var objReportToPrint = new ReportSample();
            var ReportToPrint = objReportToPrint as UserControl;
            ReportToPrint.DataContext = viewModel;
            var pageContent = new PageContent();
            var fixedPage = new FixedPage();

            //Create first page of document
            fixedPage.Children.Add(ReportToPrint);
            ((IAddChild)pageContent).AddChild(fixedPage);
            fixedDoc.Pages.Add(pageContent);

            SendFixedDocumentToPrinter(fixedDoc);
        }
        private static void SendFixedDocumentToPrinter(FixedDocument fixedDocument)
        {
            XpsDocumentWriter xpsdw;

            PrintDocumentImageableArea imgArea = null;
            //こちらのオーバーロードだと、プリンタ選択ダイアログが出る。
            xpsdw = PrintQueue.CreateXpsDocumentWriter(ref imgArea);

            //var ps = new LocalPrintServer();
            //var pq = ps.DefaultPrintQueue;
            ////こちらのオーバーロードだと、プリンタ選択ダイアログを飛ばして既定のプリンタにスプールされる
            //xpsdw = PrintQueue.CreateXpsDocumentWriter(pq);
            //xpsdw.Write(fixedDocument);
        }

    }
}
