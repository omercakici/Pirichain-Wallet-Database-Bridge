using ComponentFactory.Krypton.Toolkit;
using PiriChainWalletDataBridge.Data;
using PiriChainWalletDataBridge.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PiriChainWalletDataBridge
{
    public partial class frmTransfer : KryptonForm
    {
        string currAddress="", currPri = "";
        public frmTransfer(string currAdd,string currPri)
        {
            InitializeComponent();
            currAddress = currAdd;
            this.currPri = currPri;
        }
        List<string> t = new List<string>();

        private void frmTransfer_Load(object sender, EventArgs e)
        {
            lblAsset.Text = frmLogin.rmGlobal.GetString("AssetName");
            lblAmount.Text = frmLogin.rmGlobal.GetString("Amount");
            lblToAddress.Text = frmLogin.rmGlobal.GetString("receipt");
            this.Text = frmLogin.rmGlobal.GetString("transferInterface");
            btnSend.Text = "Transfer";
            var a = Data.addressBook.listAddress();
            foreach (var m in a)
            {
                t.Add(m.label + " -" + m.address);
            }
            loadBalanceList();
            //cmbReceipt.DataSource = t;
        }
        List<float> balanceDic = new List<float>();
        List<int> assetDic = new List<int>();
        private void loadBalanceList()
        {
            
            var balanceList = Data.Data.Wallet.listBalanceList(currAddress);
            if (balanceList != null)
            {
                
                foreach (var item in balanceList)
                {
                    balanceDic.Add(item.balance);
                    assetDic.Add(item.assetID);
                    cmbAssetList.Items.Add(item.name + " \t\t\t\t " + item.balance+" "+item.symbol);

                }

            }
        }

        private void cmbReceipt_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void cmbReceipt_KeyUp(object sender, KeyEventArgs e)
        {
            this.cmbReceipt.Items.Clear();
            List<string> listNew = new List<string>();
            foreach (var item in t)
            {
                if (item.Contains(cmbReceipt.Text))
                {
                    listNew.Add(item);
                }
            }
            this.cmbReceipt.Items.AddRange(listNew.ToArray());
            this.cmbReceipt.SelectionStart = this.cmbReceipt.Text.Length;
            Cursor = Cursors.Default;
            this.cmbReceipt.DroppedDown = true;
        }
        float currentQuantity = 0;
        int currAssetID = 0;
        private void cmbAssetList_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentQuantity = balanceDic[cmbAssetList.SelectedIndex];
            currAssetID = assetDic[cmbAssetList.SelectedIndex];
            trackBar1.Maximum = (int)currentQuantity;
            
            trackBar1.SmallChange =(int)Math.Floor(currentQuantity / 100);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Maximum > 0)
            {
                txtAmount.Text = trackBar1.Value.ToString();
            
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar)
                    && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            
            char sepratorChar = 's';
            if (e.KeyChar == ',')
            {
                // check if it's in the beginning of text not accept
                if (txtAmount.Text.Length == 0) e.Handled = true;
                // check if it's in the beginning of text not accept
                if (txtAmount.SelectionStart == 0) e.Handled = true;
                // check if there is already exist a '.' , ','
                if (alreadyExist(txtAmount.Text, ref sepratorChar)) e.Handled = true;
                //check if '.' or ',' is in middle of a number and after it is not a number greater than 99
                if (txtAmount.SelectionStart != txtAmount.Text.Length && e.Handled == false)
                {
                    // '.' or ',' is in the middle
                    string AfterDotString = txtAmount.Text.Substring(txtAmount.SelectionStart);

                    if (AfterDotString.Length > 8)
                    {
                        e.Handled = true;
                    }
                }
            }
            //check if a number pressed

            if (Char.IsDigit(e.KeyChar))
            {
                //check if a coma or dot exist
                if (alreadyExist(txtAmount.Text, ref sepratorChar))
                {
                    int sepratorPosition = txtAmount.Text.IndexOf(sepratorChar);
                    string afterSepratorString = txtAmount.Text.Substring(sepratorPosition + 1);
                    if (txtAmount.SelectionStart > sepratorPosition && afterSepratorString.Length > 7)
                    {
                        e.Handled = true;
                    }

                }
            }


        }


        private bool alreadyExist(string _text, ref char KeyChar)
        {
            if (_text.IndexOf(',') > -1)
            {
                KeyChar = ',';
                return true;
            }
           
            return false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var receiptAddress = "";

            try
            { 
            
            
            

            if (cmbReceipt.Text.Contains("-"))
            {
                receiptAddress = cmbReceipt.Text.Split('-')[1];
            }
            else
                receiptAddress = cmbReceipt.Text;
            btnSend.Enabled = false;
            if (!String.IsNullOrEmpty(txtAmount.Text) && !String.IsNullOrEmpty(receiptAddress) && currAssetID != 0)
            {
                var result = Data.Data.Wallet.transferAsset(currPri, currAddress, currAssetID, receiptAddress, Convert.ToDecimal(txtAmount.Text));
                btnSend.Enabled = true;
                if (result.error == 1)
                    MessageBox.Show(result.data, frmLogin.rmGlobal.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {

                    MessageBox.Show(frmLogin.rmGlobal.GetString("messageTransferSucc") + " Your Tx: " + result.tx, frmLogin.rmGlobal.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSend.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show(frmLogin.rmGlobal.GetString("errFillAllFields"), frmLogin.rmGlobal.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSend.Enabled = true; 
            }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error", "An Error Occured!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            for (int k = 0; k < 5000000; k++)
            {
                try
                {
                    
                    var req = address.generateAddress<Request.addresResponse>();
                    var result = Data.Data.Wallet.transferAsset(currPri, currAddress, currAssetID, req.pub,Convert.ToDecimal(0.0002));

                    //MessageBox.Show(Newtonsoft.Json.JsonConvert.SerializeObject(result));
                    this.Text = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(50);
                }
                catch (Exception ex)
                {
                    this.Text = ex.Message;
                }

            }
        }
    }
}
