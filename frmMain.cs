using ComponentFactory.Krypton.Toolkit;
using PiriChainWalletDataBridge.components;
using PiriChainWalletDataBridge.Data;
using PiriChainWalletDataBridge.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiriChainWalletDataBridge
{
    public partial class frmMain : KryptonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

       

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       
        void loadLanguage()
        {
            var rm = frmLogin.rmGlobal;
            this.Text = rm.GetString("frmEntrance_LblTitle");
            langToolStripMenuItem.Text = rm.GetString("lang");
            
            walletToolStripMenuItem.Text = rm.GetString("menuWallet");
            addWalletToolStripMenuItem.Text = rm.GetString("menuAddWallet");
            removeWalletToolStripMenuItem.Text = rm.GetString("menuDeleteWallet");
            selectWalletToolStripMenuItem.Text = rm.GetString("menuSelectWallet");
            addressBookToolStripMenuItem.Text = rm.GetString("menuAddressBook");
            getMyKeyWordsToolStripMenuItem.Text = rm.GetString("menuGetMyWords");
            restoreMyWalletToolStripMenuItem.Text = rm.GetString("menuRestoreMyWallet");
            aboutToolStripMenuItem.Text = rm.GetString("menuAbout");
            lblTitle.Text = rm.GetString("welcome");
            pushDataToolStripMenuItem.Text = rm.GetString("menuDatabase");
            sendPiriOrTokenToolStripMenuItem.Text = rm.GetString("menuSendCoin");
            
            tbMyTransactions.Text = rm.GetString("myTransactions");
            tbGlobalTransactions.Text = rm.GetString("globalTransactions");
            toolStripReceive.Text = rm.GetString("receive");
            cmbMyTransactionsPage.Text = rm.GetString("transactionList");
            lblLoading.Text = rm.GetString("loading");
        
        }
        public static string currentAddress = "";

        Task t = null;
        private void frmMain_Load(object sender, EventArgs e)
        {
            panelLoading.Width = this.Width;
            panelLoading.Height = this.Height;
            panelLoading.Top = 0;
            panelLoading.Left = 0;
            picLogo.Left = this.Width / 2-(picLogo.Width/2); 
            picLogo.Top = this.Height / 2 - picLogo.Height;
            lblLoading.Left = this.Width / 2- (lblLoading.Width/2);
            lblLoading.Top = this.Height / 2 + lblLoading.Height;
            progressMainFuncs.Left = this.Width / 2 - (progressMainFuncs.Width / 2);
            progressMainFuncs.Top = this.Height / 2 + progressMainFuncs.Height+50;
            progressMainFuncs.Maximum = 100;
            progressOperation.Top = this.Height / 2 + progressOperation.Height + 125;
            progressOperation.Left = this.Width / 2 - (progressOperation.Width / 2)-200;
            loadLanguage();
            splitContainer1.Size = new System.Drawing.Size(110, 500);
            

            listAddress();
            listTransactions();
            listGlobalTransactions();
           // new PiriSocket().initialize();
            panelLoading.Visible = false;


        }



        string currentPri = "";
        void listAddress()
        {
            var walletList = Data.Data.Wallet.listWallet();
            if (walletList.Count == 0)
            {
                var req = address.generateAddress<Request.addresResponse>();
                Data.Data.Wallet.addWallet(req.publicKey, req.pub, req.pri);
                walletList = Data.Data.Wallet.listWallet();
            }
            lblCurrentAddress.Text = walletList[0].base58;
            currentPri = walletList[0].privateKey;
            currentAddress = walletList[0].base58;
            loadBalanceList();
            selectWalletToolStripMenuItem.DropDownItems.Clear();
            getMyKeyWordsToolStripMenuItem.DropDownItems.Clear();
            removeWalletToolStripMenuItem.DropDownItems.Clear();
            ToolStripMenuItem[] items = new ToolStripMenuItem[walletList.Count]; // You would obviously calculate this value at runtime

            ToolStripMenuItem[] gitems = new ToolStripMenuItem[walletList.Count]; // You would obviously calculate this value at runtime
            ToolStripMenuItem[] ritems = new ToolStripMenuItem[walletList.Count]; // You would obviously calculate this value at runtime

            int c = 0;
            foreach (var item in walletList)
            {

                items[c] = new ToolStripMenuItem();
                items[c].Name = "dynamicItem" + c.ToString();
                items[c].Tag = item.privateKey;

                items[c].Text = item.base58;
                items[c].Click += frmMainSelectAddress_Click;
                c++;
                Application.DoEvents();

            }

            c = 0;
            foreach (var item in walletList)
            {

                gitems[c] = new ToolStripMenuItem();
                gitems[c].Name = "dynamicKeywordItem" + c.ToString();
                gitems[c].Tag = item.privateKey;
                gitems[c].Text = item.base58;
                gitems[c].Click += frmWalletGetMenuKeyword;
                c++;
                Application.DoEvents();

            }

            c = 0;
            foreach (var item in walletList)
            {

                ritems[c] = new ToolStripMenuItem();
                ritems[c].Name = "dynamicKeywordItemRemove" + c.ToString();
                ritems[c].Tag = item.privateKey;
                ritems[c].Text = item.base58;
                ritems[c].Click += frmWalletRemove;
                c++;
                Application.DoEvents();

            }
            removeWalletToolStripMenuItem.DropDownItems.AddRange(ritems);
            selectWalletToolStripMenuItem.DropDownItems.AddRange(items);
            getMyKeyWordsToolStripMenuItem.DropDownItems.AddRange(gitems);
        
        }
        void frmWalletRemove(object sender, EventArgs e)
        {

            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

            if (clickedItem != null)
            {
                if (MessageBox.Show("Are you sure DELETE " + clickedItem.Text + " wallet?! You cannot recover if you didnt save keywords!", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    Data.Data.Wallet.removeWallet(clickedItem.Text);
                    listAddress();
                }

            }

        }
        void frmWalletGetMenuKeyword(object sender, EventArgs e)
        {

            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

            if (clickedItem != null)
            {
                var result = Data.Data.Wallet.getMnemonic(clickedItem.Tag.ToString());
                new frmMnemonic(result.mnemonic).ShowDialog();
                
            }

        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
        private void listTransactions(int skip=0)
        {
            var list = Data.Data.Wallet.listTransactions(currentAddress,skip,50);
            myTransactionsPanel.Controls.Clear();
            if (list != null)
            {
                list.doc.Reverse();
                foreach (var item in list.doc)
                {
                    DateTime d = UnixTimeStampToDateTime(item.timeStamp);
                    var tx = new transactionItem(item.symbol, item.transactionHash, item.from, item.to, item.amount,item.blockHeight, d,item.confirmationCount,item.confirmed,item.validatorNodes);
                    tx.Dock = DockStyle.Top;
                    progressOperation.Text = "Tx: [" + item.transactionHash + "]"; 
                    myTransactionsPanel.Controls.Add(tx);
                    progressMainFuncs.Increment(1);
                    progressMainFuncs.Invalidate();
                    Application.DoEvents();

                }
                if (cmbMyTransactionsPage.Items.Count == 0)
                {
                    cmbMyTransactionsPage.Items.Clear();
                    for (int i = 0; i < Convert.ToInt32(Math.Ceiling(Convert.ToDouble(list.count / 50))); i++)
                    {

                        cmbMyTransactionsPage.Items.Add(" Page " + (i + 1));

                    }
                }
                
                //contextMenuMyTrasnactions.Items.Add("test2");
            }
        }

        private void listGlobalTransactions()
        {
            var list = Data.Data.Wallet.listTransactions(0,50);
            tbGlobalTransactions.Controls.Clear();
            if (list != null && list.docs!=null)
            {
                list.docs.Reverse();
                foreach (var item in list.docs)
                {
                    DateTime d = UnixTimeStampToDateTime(item.timeStamp);
                    var tx = new transactionItem(item.symbol, item.transactionHash, item.from, item.to, item.amount, item.blockHeight, d, item.confirmationCount, item.confirmed, item.validatorNodes);
                    tx.Dock = DockStyle.Top;
                    progressOperation.Text ="Tx: ["+ item.transactionHash+"]";
                    tbGlobalTransactions.Controls.Add(tx);
                    progressMainFuncs.Increment(1);
                    progressMainFuncs.Invalidate();
                    Application.DoEvents();

                }
            }
        }

        private void loadBalanceList()
        {
            System.Threading.Thread.Sleep(1000);
            splitContainer1.Panel1.Controls.Clear();
            var balanceList = Data.Data.Wallet.listBalanceList(currentAddress);
            if (balanceList != null)
            {
                balanceList.Reverse();
                foreach (var item in balanceList)
                {
                    var v = new balanceItem(item.name, item.symbol, item.balance, item.logo);
                    v.Dock = DockStyle.Top;
                    Application.DoEvents();
                    splitContainer1.Panel1.Controls.Add(v);
                    
                }
            
            }
        }

        void frmMainSelectAddress_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            currentAddress = clickedItem.Text;
            currentPri = clickedItem.Tag.ToString();
            lblCurrentAddress.Text = clickedItem.Text;
            loadBalanceList();
            listTransactions();
        }

        private void pushDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmDatabaseBridge(currentAddress,currentPri).ShowDialog();
        }

        private void addWalletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var req = address.generateAddress<Request.addresResponse>();
            Data.Data.Wallet.addWallet(req.publicKey, req.pub, req.pri);
            listAddress();
            MessageBox.Show(frmLogin.rmGlobal.GetString("msgWalletAddedSucc"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
        
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            var currentLang = frmLogin.ToEnum<frmLogin.langs>("EN");
            try
            {
                frmLogin.rmGlobal = frmLogin.langList[currentLang];
                loadLanguage();
            }
            catch (KeyNotFoundException thEx)
            {
                frmLogin.rmGlobal = frmLogin.langList[frmLogin.langs.EN];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error Occured!");
            }
        }

        private void türkçeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentLang = frmLogin.ToEnum<frmLogin.langs>("TR");
            try
            {
                frmLogin.rmGlobal = frmLogin.langList[currentLang];
                loadLanguage();
            }
            catch (KeyNotFoundException thEx)
            {
                frmLogin.rmGlobal = frmLogin.langList[frmLogin.langs.EN];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error Occured!");
            }
        }

        private void lblCurrentAddress_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblCurrentAddress.Text);
            MessageBox.Show("Copied", "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void listAddressBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void addressBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var a = new frmAddressBook();

            a.Show();
        }

        private void sendPiriOrTokenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var t = new frmTransfer(currentAddress,currentPri);
            t.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new frmQrCode(currentAddress).ShowDialog();
        }

        private void toolStripReceive_Click(object sender, EventArgs e)
        {
            new frmQrCode(currentAddress).ShowDialog();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutBox about = new aboutBox();
            about.ShowDialog();
        }

        int currentPage = 0;
        private void btnMyTransactionPageNext_Click(object sender, EventArgs e)
        {
            currentPage++;
            if (cmbMyTransactionsPage.Items.Count > currentPage)
            {
                listTransactions(currentPage);
                cmbMyTransactionsPage.SelectedIndex = currentPage;
            }

        }

        private void cmbMyTransactionsPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbMyTransactionsPage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            currentPage = cmbMyTransactionsPage.SelectedIndex;
            listTransactions(currentPage);

        }

        private void btnMyTransactionPagePrior_Click(object sender, EventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                listTransactions(currentPage);
                cmbMyTransactionsPage.SelectedIndex = currentPage;
            }
        }

        private void btnMyTransactionPageFirst_Click(object sender, EventArgs e)
        {
            currentPage = 0;
            listTransactions(0);
            cmbMyTransactionsPage.SelectedIndex = 0;
        }

        private void btnMyTransactionPageLast_Click(object sender, EventArgs e)
        {
            currentPage = cmbMyTransactionsPage.Items.Count-1;
            listTransactions(currentPage);
            cmbMyTransactionsPage.SelectedIndex = currentPage;
        }
    }
}
