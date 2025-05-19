using ComponentFactory.Krypton.Toolkit;
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
    public partial class frmMnemonic : KryptonForm
    {
        public frmMnemonic(string mn)
        {
            InitializeComponent();
            kryptonRichTextBox1.Text = mn;
            label1.Text = frmLogin.rmGlobal.GetString("donotshaermnemonic");
        }

        private void frmMnemonic_Load(object sender, EventArgs e)
        {

        }
    }
}
