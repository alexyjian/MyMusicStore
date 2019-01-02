using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.QrCode;


namespace CommonUtility
{
    /// <summary>
    /// 条码、二维码生成类
    /// </summary>
    public class BarQrCodeLib
    {
        /// <summary>
        /// 生成图片格式的条码
        /// </summary>
        /// <param name="content">要生成的条码的内容</param>
        /// <returns>图片格式的条码</returns>
        public static Bitmap GetBarCode(string content)
        {
            BarcodeWriter bw = new BarcodeWriter();
            //配置 
            bw.Format = BarcodeFormat.ITF;
            bw.Options = new ZXing.Common.EncodingOptions()
            {
                Width = 256,
                Height = 80,
                Margin=0
            };
            return bw.Write(content);
        }

        public static Bitmap GetQrCode(string content)
        {
            BarcodeWriter bw = new BarcodeWriter();
            QRCodeWriter qw = new QRCodeWriter();
            bw.Encoder = qw;
            bw.Format = BarcodeFormat.QR_CODE;
            bw.Options = new ZXing.Common.EncodingOptions()
            {
                Width = 256,
                Height = 256,
                Margin=0
            };
            return bw.Write(content);
        }
    }
}
