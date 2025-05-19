using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PiriChainWalletDataBridge.components
{
    public partial class transactionItem : UserControl
    {
        public transactionItem(string symbol, string txHash, string from, string to, float amount, int blockNum, DateTime dateTime, int confirmationCount, bool confirmed, List<Data.Data.Wallet.transactionItem._validator> nodes)
        {
            InitializeComponent();
            lblConfirmationCountText.Text = frmLogin.rmGlobal.GetString("confirmationCount");
            lblConfirmed.Text = frmLogin.rmGlobal.GetString("confirmed");
            lblBlockNumberText.Text = frmLogin.rmGlobal.GetString("blockHeight");
            lblConfirmationNode.Text = frmLogin.rmGlobal.GetString("confirmationNodes");
            lblAmount.Text = amount.ToString() + " " + symbol;
            lblTransactionHash.Text = txHash;
            lblTransactionHash.Click += lblTransactionHash_Click;
            lblBlockNumber.Text = blockNum.ToString();
            lblFrom.Text = from;
            if (confirmed)
                pictureBox2.Image = global::PiriChainWalletDataBridge.Properties.Resources.check;
            else
                pictureBox2.Image = global::PiriChainWalletDataBridge.Properties.Resources.error;
            lblConfirmationCount.Text = confirmationCount.ToString();
            if (frmMain.currentAddress == to)
            {
                lblTo.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                lblAmount.ForeColor = Color.Green;
                lblAmount.Text = "+ " + lblAmount.Text;
            }
            else if (frmMain.currentAddress == from)
            {
                lblFrom.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                lblAmount.ForeColor = Color.Red;
                lblAmount.Text = "- " + lblAmount.Text;
            }
            

            lblDate.Text = dateTime.ToLongDateString() + " - " + dateTime.ToLongTimeString();
            lblTo.Text = to;

            if (nodes!=null)
            {
                nodes.Reverse();
                foreach (var n in nodes)
                {
                    var v = new nodeItem(n.nodeName);
                    v.Dock = DockStyle.Left;
                    pnlValidators.Controls.Add(v);
                
                }
            }
        }

        void lblTransactionHash_Click(object sender, EventArgs e)
        {
            new transactionDetail(((LinkLabel)sender).Text).ShowDialog();
        }

        private void transactionItem_Load(object sender, EventArgs e)
        {
            
        }

        private void lblConfirmed_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTransactionHash_LinkClicked(object sender, EventArgs e)
        {

        }
    }
}
