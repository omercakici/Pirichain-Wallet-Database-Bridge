using ComponentFactory.Krypton.Toolkit;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiriChainWalletDataBridge
{
    public partial class frmQrCode : KryptonForm
    {
        public frmQrCode(string address)
        {
            InitializeComponent();
            this.Text =  address;
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(address, QRCodeGenerator.ECCLevel.Q))
            using (QRCode qrCode = new QRCode(qrCodeData))
            {
                Bitmap qrCodeImage = qrCode.GetGraphic(20);
                pictureBox1.Image = qrCodeImage;
            }
        }


        private void frmQrCode_Load(object sender, EventArgs e)
        {

        }
    }
}
