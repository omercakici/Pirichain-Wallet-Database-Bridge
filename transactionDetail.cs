using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiriChainWalletDataBridge.components
{
    public partial class transactionDetail : Form
    {

        protected Data.Data.Wallet.transactionItem item = new Data.Data.Wallet.transactionItem();

        public transactionDetail(string txHash)
        {
            InitializeComponent();
            loadLanguage();
            item = Data.Data.Wallet.getTransaction(txHash);
            lblTransactionHash.Text = item.transactionHash;
            lblFrom.Text = item.from;
            lblSignature.Text = item.signature;
            lblPubKey.Text = item.pub;
            lblBlockHeight.Text = item.blockHeight.ToString();
            lblAmount.Text = item.amount+" "+item.symbol;
            lblFee.Text = item.fee.ToString()+" PIRI";
            if (!String.IsNullOrEmpty(item.to))
                lblTo.Text = item.to;
            
            if (item.validatorNodes != null)
            {
                item.validatorNodes.Reverse();
                foreach (var n in item.validatorNodes)
                {
                    var v = new nodeItem(n.nodeName);
                    v.Dock = DockStyle.Left;
                    pnlValidators.Controls.Add(v);

                }
            }
            DateTime d = UnixTimeStampToDateTime(item.timeStamp);
            lblDateTime.Text = d.ToLongDateString() + "  " + d.ToLongTimeString();

        }
    
        void loadLanguage()
        {
            lblTextTransactionHash.Text = frmLogin.rmGlobal.GetString("transaction");
            lblTextBlockHeight.Text = frmLogin.rmGlobal.GetString("blockHeight");
            lblTextTo.Text = frmLogin.rmGlobal.GetString("to");
            lblTextFrom.Text = frmLogin.rmGlobal.GetString("from");
            lblTextAmount.Text=frmLogin.rmGlobal.GetString("Amount");
            lblTextValidators.Text = frmLogin.rmGlobal.GetString("validators");
            lblTextSignature.Text = frmLogin.rmGlobal.GetString("signature");
            lblTextPubKey.Text = frmLogin.rmGlobal.GetString("pubKey");
            lblTextMethod.Text = frmLogin.rmGlobal.GetString("method");
            lblTextDateTime.Text = frmLogin.rmGlobal.GetString("dateTime");
            lblFeeText.Text = frmLogin.rmGlobal.GetString("fee");

        }
        private void transactionDetail_Load(object sender, EventArgs e)
        {
            this.Text = item.transactionHash;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
