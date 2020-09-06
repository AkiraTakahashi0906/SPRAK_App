using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ZXing;

namespace SPRAK.Domain.Helpers
{
    public static class BarcodeImageCreate
    {
        public static void CreatePng(string barcodeText, string filePath)
        {
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
            using (var bitmap = bacodeWriter.Write(barcodeText))
            {
                // 画像として保存
                bitmap.Save(filePath, ImageFormat.Png);
            }

        }
    }
}
