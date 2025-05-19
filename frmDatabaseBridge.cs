using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.OleDb;
using System.Data.SqlClient;
using ComponentFactory.Krypton.Toolkit;
using PiriChainWalletDataBridge.Library;
using PiriChainWalletDataBridge.OOP;
namespace PiriChainWalletDataBridge
{
    public partial class frmDatabaseBridge : KryptonForm
    {
        string currentAddress=null;
        string currentPrivateKey = null;
        public frmDatabaseBridge(string address,string privateKey)
        {
            InitializeComponent();
            currentAddress=address;
            currentPrivateKey = privateKey;
        }

        public enum databaseType
        { 
            MONGO=0,
            MSSQL=1,
            POSTGRE=4,
            MYSQL=2,
            ORACLE=3,
            ACCESS=5,
            SQLITE=6
        }

        public databaseType type = new databaseType();


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            KryptonRadioButton btn = sender as KryptonRadioButton;
            if (btn.Tag.ToString()=="1")
                btnExpress.Visible=true;
            else
                btnExpress.Visible=false;
            Enum.TryParse(btn.Tag.ToString(), out type);

            switch (type)
            {
                case databaseType.MONGO:
                    break;
                case databaseType.MSSQL:
                    break;
                case databaseType.POSTGRE:
                    txtHost.Text = "localhost";
                    txtPort.Text = "5432";

                    break;
                case databaseType.MYSQL:
                    txtPort.Text = "3306";
                    txtHost.Text = "localhost";
                    break;
                case databaseType.ORACLE:
                    break;
                case databaseType.ACCESS:
                    break;
                case databaseType.SQLITE:
                    break;
                default:
                    break;
            }
        }

        private void frmDatabaseBridge_Load(object sender, EventArgs e)
        {
            loadLang();
            loadBalance();
            
        }

        void loadBalance()
        {
            var result=PiriChainWalletDataBridge.Data.Data.Wallet.getBalance(currentAddress);
            lblYourBalance.Text = result.balance.ToString()+" PIRI";
        
        }

        void loadLang()
        {
            chckNotSendIfTxExists.Text = frmLogin.rmGlobal.GetString("notSendIfTxExists");
            chckSendOnlyBelowFields.Text = frmLogin.rmGlobal.GetString("sendOnlyBelowFields");
            lblAnnoucement.Text = frmLogin.rmGlobal.GetString("dataAnnoucement");
            //lblReaminingTimeToEndText.Text = frmLogin.rmGlobal.GetString("remainingTimeToEnd");
            lblYourBalanceText.Text = frmLogin.rmGlobal.GetString("yourPiriBalance");
            grpOperationSpeed.Values.Heading = frmLogin.rmGlobal.GetString("operationSpeed");
            grpEncryptionLevel.Values.Heading = frmLogin.rmGlobal.GetString("encrytionLevel");
            //lblSpendPiri.Text = frmLogin.rmGlobal.GetString("spendFee");
            lblNormalSpeed.Text = frmLogin.rmGlobal.GetString("normalSpeed");
            lblFastSpeed.Text = frmLogin.rmGlobal.GetString("fastSpeed");
            lblLigthingSpeed.Text = frmLogin.rmGlobal.GetString("lightingSpeed");
            lblBothKeyValue.Text = frmLogin.rmGlobal.GetString("bothKeyValue");
            lblOnlyKey.Text = frmLogin.rmGlobal.GetString("onlyKey");
            lblNoEnc.Text = frmLogin.rmGlobal.GetString("noEncryption");
            btnStartToPush.Text = frmLogin.rmGlobal.GetString("start");
        }
        private IDatabase IDb;
        void newConnection()
        {
            switch (this.type)
            {
                case databaseType.MSSQL:
                    IDb=new MSSQL();
                    IDb.connect(txtHost.Text, txtDB.Text, txtUser.Text, txtPassword.Text);
                break;
                case databaseType.MYSQL:
                    IDb = new MYSQL();
                    IDb.connect(txtHost.Text, txtDB.Text, txtUser.Text, txtPassword.Text);
                break;
                case databaseType.POSTGRE:
                    IDb = new PostgreSQL();
                    IDb.connect(txtHost.Text, txtDB.Text, txtUser.Text, txtPassword.Text);
                break;
                default:
                    break;
            }
        
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                 lstTables.Items.Clear();


                 var type = this.type;
                 newConnection();
                 type = databaseType.MSSQL;
                 btnDisconnect.Text = "Disconnect";
                 btnDisconnect.Visible = true;
                 grpBindArea.Visible = false;
                 lstTables.Visible = true;
                 DataTable tq = IDb.getTables();
                 if (tq != null)
                     for (int i = 0; i < tq.Rows.Count; i++)
                     {
                         lstTables.Items.Add(tq.Rows[i][2].ToString());

                     }
                  

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            txtHost.Text=".\\SQLEXPRESS";
        }
        DataTable data = new DataTable();
        SqlDataAdapter adap = new SqlDataAdapter();

        bool selectFromListTables = true;

        private void lstTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
            var type = this.type;
                
            kryptonDataGridView1.DataSource =data= IDb.listRecords(lstTables.SelectedItem.ToString());
            
            splitContainer2.Enabled = true;
            selectFromListTables = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void lstTables_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

        private void lstTables_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void chckSendOnlyBelowFields_CheckedChanged(object sender, EventArgs e)
        {
            checkListFields.Items.Clear();
            if (chckSendOnlyBelowFields.Checked)
            {
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    checkListFields.Items.Add(data.Columns[i].Caption,true);
                    
                
                }
            
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            var type = this.type;
            btnDisconnect.Visible = false;
            splitContainer2.Enabled = false;
            IDb.disConnect();
            grpBindArea.Visible = true;
             lstTables.Visible = false;
             if (pushTimer!=null)
                 pushTimer.Enabled = false;
             timer.Enabled = false;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var type = this.type;
            try
            {
                switch (type)
                {
                    case databaseType.MSSQL:
                        kryptonDataGridView1.DataSource = data = ((MSSQL)IDb).runSQL(txtSQL.Text);
                        break;
                    case databaseType.MYSQL:
                        kryptonDataGridView1.DataSource = data = ((MYSQL)IDb).runSQL(txtSQL.Text);
                        break;
                    case databaseType.POSTGRE:
                        kryptonDataGridView1.DataSource = data = ((PostgreSQL)IDb).runSQL(txtSQL.Text);
                        break;
                }
            }
            catch (Exception ex)
            {
             //   MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            selectFromListTables = false;

        }

        bool checkAndInsertTxColumn(string tableName)
        {
            try
            {
                return IDb.addTxColumn(tableName);        
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
            }
        }

        void updateOrInsertTx(string tableName,string firstFieldName,string firstFieldValue,string tx)
        {
            var type = this.type;
            try
            {
               checkAndInsertTxColumn(tableName);
               IDb.updateAndInsertColumn(tableName, tx, firstFieldName, firstFieldValue);
            }
            catch (Exception ex)
            {
                AppendText(ex.Message, Color.Red);
            }
        }

        bool started = false;
        private void btnStartToPush_Click(object sender, EventArgs e)
        {
            if (!started)
            {
                if (MessageBox.Show(frmLogin.rmGlobal.GetString("areyousure_senddata"), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    lstTables.Enabled = false;
                    startPush();
                    startTimer();
                    started = true;
                    btnStartToPush.Text = "STOP!";
                }
            }
            else
            {
                if (MessageBox.Show(frmLogin.rmGlobal.GetString("areYouSureStopOperation"), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (pushTimer!=null)
                    pushTimer.Enabled = false;
                    if (timer!=null)
                    timer.Enabled = false;
                    btnStartToPush.Text = "START!";
                    started = false;
                }
            }
            
        }

        void startTimer()
        {
            timer.Enabled = true;
            timer.Interval = 5250;
            timer.Tick += timer_Tick;
        }
        int timerCount = 0;
        void timer_Tick(object sender, EventArgs e)
        {
            timerCount++;
            if (data!=null && data.Rows!=null)
                if (data.Rows.Count > 0)
                {
                    long islemSayisi = g;
                    long kalanIslem = Convert.ToInt64(data.Rows.Count) - g;
                    if (islemSayisi > 0 && timerCount%2==0)
                    {
                        long kalanSure = timerCount * kalanIslem / islemSayisi;
                        int gun = Convert.ToInt32(Math.Floor(Convert.ToDouble(kalanSure / 60 / 60 / 24)));
                        int saat = Convert.ToInt32(Math.Floor(Convert.ToDouble((kalanSure / 60 / 60) % 24)));
                        int dakika = Convert.ToInt32(Math.Floor(Convert.ToDouble((kalanSure / 60) % 60)));
                        long saniye = kalanSure % 60;
                        lblReaminingTimeToEnd.Text = String.Format(" {0} " + frmLogin.rmGlobal.GetString("days") + " {1} " + frmLogin.rmGlobal.GetString("hours") + " {2} " + frmLogin.rmGlobal.GetString("minutes") + " {3} " + frmLogin.rmGlobal.GetString("seconds") +" "+frmLogin.rmGlobal.GetString("left"), gun, saat, dakika, saniye);
                        int gecenGun=Convert.ToInt32(Math.Floor(Convert.ToDouble(timerCount / 60 / 60 / 24)));
                        int gecenSaat = Convert.ToInt32(Math.Floor(Convert.ToDouble((timerCount / 60 / 60) % 24)));
                        int gecenDakika = Convert.ToInt32(Math.Floor(Convert.ToDouble((timerCount / 60) % 60)));
                        int gecenSaniye = timerCount % 60;
                        lblTimer.Text = String.Format(" {0} " + frmLogin.rmGlobal.GetString("days") + " {1} " + frmLogin.rmGlobal.GetString("hours") + " {2} " + frmLogin.rmGlobal.GetString("minutes") + " {3} " + frmLogin.rmGlobal.GetString("seconds") , gecenGun, gecenSaat, gecenDakika, gecenSaniye);
                    }
                }
        }

        
        Timer timer = new Timer();
        Timer pushTimer = new Timer();
      
        void startPush()
        {
            g = 0;
            pushTimer = new Timer();
            pushTimer.Enabled = true;
            pushTimer.Interval = 400;
            pushTimer.Tick += pushTimer_Tick;
            if (selectFromListTables)
                data = IDb.listAllRecords();
            lblRemainingOp.Text ="1/"+data.Rows.Count.ToString();
            progressBarOp.Maximum = data.Rows.Count;
            grpEncryptionLevel.Enabled = false;
            
            
        }
        public void AppendText(string text, Color color)
        {
            txtLogs.SuspendLayout();
            txtLogs.SelectionColor = color;
            txtLogs.AppendText(
                text+"\n");
            txtLogs.ScrollToCaret();
            txtLogs.ResumeLayout();
        }

        int getEncLevel()
        {
            if (lblNoEnc.Checked)
                return 0;
            if (lblOnlyKey.Checked)
                return 1;
            if (lblBothKeyValue.Checked)
                return 2;
            else
                return 0;
        
        }
        int g = 0;
        void pushTimer_Tick(object sender, EventArgs e)
        {

            if (g>0 && g%7==0)
                loadBalance();
            
            lblRemainingOp.Text = (g+1)+"/" + data.Rows.Count.ToString();
           List<Request.valuePair> req= new List<Request.valuePair>();
           List<string> column = new List<string>();
           List<string> row = new List<string>();



           bool doNotContinue = false;
           for (int k = 0; k < data.Columns.Count; k++)
           {
               if (chckNotSendIfTxExists.Checked)
               if (data.Columns[k].Caption.Replace("\"", "") == "tx" && !String.IsNullOrEmpty(data.Rows[g]["tx"].ToString()))
               {
                   doNotContinue=true;
               }
               if (chckSendOnlyBelowFields.Checked)
               { 
                   int pos=checkListFields.Items.IndexOf(data.Columns[k].Caption.ToString());
                    if (checkListFields.GetItemChecked(pos))
                        req.Add(new Request.valuePair { key = "customData[]", val = "{\"key\":\"" + data.Columns[k].Caption.Replace("\"", "") + "\",\"value\":\"" + data.Rows[g][k].ToString().Replace("\"", "") + "\",\"enc\":" + getEncLevel() + "}" });
               }
               else
               req.Add(new Request.valuePair { key = "customData[]", val = "{\"key\":\"" + data.Columns[k].Caption.Replace("\"", "") + "\",\"value\":\"" + data.Rows[g][k].ToString().Replace("\"", "") + "\",\"enc\":" + getEncLevel() + "}" });
           }
           if (!doNotContinue)
           {
               var locked = false;
               try
               {
                   while (locked)
                       Application.DoEvents();
                   progressBarOp.Value = g + 1;
                   locked = true;
                   Data.Data.Wallet.transferResult result = PiriChainWalletDataBridge.Data.Data.Wallet.pushData(currentPrivateKey, currentAddress, -1, null, 0, req);
                   locked = false;
                   lblLastOp.Text = result.error == 0 ? result.tx : result.data;

                  

                   if (result.error == 0)
                   {
                       updateOrInsertTx(IDb.globalTableName, data.Columns[0].Caption.Replace("\"", ""), data.Rows[g][0].ToString().Replace("\"", ""), result.tx);

                   }
                   else
                   {
                       if (result.data.ToLower() == "insufficent piricoin balance" || result.data.ToLower() == "ınsufficient piricoin balance")
                       {
                           
                           if (pushTimer != null)
                               pushTimer.Enabled = false;
                           if (timer != null)
                               timer.Enabled = false;
                                btnStartToPush.Text = "START!";
                                started = false;
                       }
                   }

                  
                   AppendText(DateTime.Now.ToLongTimeString() + " - " + lblLastOp.Text, Color.DarkGreen);

                   if (g >= data.Rows.Count)
                   {
                       pushTimer.Enabled = false;
                       pushTimer.Dispose();
                       pushTimer = null;
                       timerCount = 0;
                       timer.Enabled = false;
                       AppendText(DateTime.Now.ToLongTimeString() + " - " + frmLogin.rmGlobal.GetString("operationEnd"), Color.Black);
                       MessageBox.Show(frmLogin.rmGlobal.GetString("operationEnd"), frmLogin.rmGlobal.GetString("success"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                       grpEncryptionLevel.Enabled = true;
                       lstTables.Enabled = true;
                       return;

                   }
               }
               catch (Exception ex)
               {

                   AppendText(DateTime.Now.ToLongTimeString() + " - " + ex.Message, Color.Red);
               }
           }
           else
           {
               progressBarOp.Value = g + 1;
              
           }
           g++;
           if (g >= data.Rows.Count)
           {
               pushTimer.Enabled = false;
               pushTimer.Dispose();
               pushTimer = null;
               timerCount = 0;
               timer.Enabled = false;
               AppendText(DateTime.Now.ToLongTimeString() + " - " + frmLogin.rmGlobal.GetString("operationEnd"), Color.Black);
               MessageBox.Show(frmLogin.rmGlobal.GetString("operationEnd"), frmLogin.rmGlobal.GetString("success"), MessageBoxButtons.OK, MessageBoxIcon.Information);
               grpEncryptionLevel.Enabled = true;
               lstTables.Enabled = true;
               return;

           }
           

        }

        private void lblYourBalance_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonLabel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmDatabaseBridge_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pushTimer != null)
            {
                pushTimer.Enabled = false;
                pushTimer.Dispose();
                pushTimer = null;
                timer.Enabled = false;
                timer.Dispose();
                timer = null;
            }
        }

        private void panelMiddleControls_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kryptonHeaderGroup1_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lstTables_MouseClick_1(object sender, MouseEventArgs e)
        {
            splitContainer2.Enabled = true;
            selectFromListTables = true;
        }

        private void kryptonRadioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }



    

       
    }
}
