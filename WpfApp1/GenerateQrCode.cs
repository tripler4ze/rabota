using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using static QRCoder.QRCodeGenerator;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1 {
    public class QRCodeGenerator
    {
        private static object text;
        

        public static Bitmap GenerateQRCode(string productName)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCode qrCode = new(qrGenerator.CreateQrCode(text, ECCLevel.Q));
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }

        private QRCodeData CreateQrCode(object text, object q)
        {
            throw new NotImplementedException();
        }
    }
}



