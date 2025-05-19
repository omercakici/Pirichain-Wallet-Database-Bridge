using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PiriChainWalletDataBridge.Library;

namespace PiriChainWalletDataBridge.components
{
    public partial class balanceItem : UserControl
    {
        public balanceItem(string name,string symbol,float balance,string logoURL,float frozen=0)
        {
            InitializeComponent();
            lblCoinBalance.Text = balance.ToString()+" "+symbol;
            lblCoinName.Text = name + "(" + symbol + ")";
            try
            {
                if (name=="PIRI")
                    pictureBox1.Image = global::PiriChainWalletDataBridge.Properties.Resources.logo_256;
                else
                    pictureBox1.ImageLocation = logoURL;
            }
            catch { }
            

            
        }

        private void balanceItem_Load(object sender, EventArgs e)
        {

        }

        private void kryptonPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
