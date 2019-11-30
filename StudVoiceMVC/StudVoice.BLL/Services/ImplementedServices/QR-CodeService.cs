using System;
using System.IO;
using System.Drawing;
using QRCoder;
using static QRCoder.QRCodeGenerator;

namespace StudVoice.BLL.Services.ImplementedServices
{
    public class QR_CodeService 
    {
        public Bitmap GenerateQrCode()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCode qrCode = qrGenerator.CreateQrCode("The payload aka the text which should be encoded.", QRCodeGenerator.ECCLevel.Q);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }
    }
}
