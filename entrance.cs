using ComponentFactory.Krypton.Toolkit;
using PiriChainWalletDataBridge.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace PiriChainWalletDataBridge
{
     
         
    public partial class frmLogin : KryptonForm
    {

        public static T ToEnum<T>(string value, bool ignoreCase = true)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }

        public static Dictionary<langs, ResourceManager> langList = new Dictionary<langs, ResourceManager>();
        public static ResourceManager rmGlobal = null;
        public static langs currentLang;
        public frmLogin()
        {
            InitializeComponent();
            CultureInfo ci = CultureInfo.InstalledUICulture;
            string lang = ci.Name.Split('-')[ci.Name.Split('-').Length - 1];
            currentLang = ToEnum<langs>(lang);
            langList.Add(langs.TR,new ResourceManager("PiriChainWalletDataBridge.lang_tr", Assembly.GetExecutingAssembly()));
            langList.Add(langs.EN, new ResourceManager("PiriChainWalletDataBridge.lang_en", Assembly.GetExecutingAssembly()));
            for (int i = 0; i < kryptonComboBox1.Items.Count; i++)
            {
                if (kryptonComboBox1.Items[i].ToString().ToLower().EndsWith(lang.ToLower()))
                    kryptonComboBox1.Text = kryptonComboBox1.Items[i].ToString();
            
            }
                try
                {
                    rmGlobal = langList[currentLang];
                }
                catch (KeyNotFoundException thEx)
                {
                    rmGlobal = langList[langs.EN];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected Error Occured!");
                }
        }

       

        public enum langs
        {
            TR,
            EN
        }
        public static void changeLang(langs lnPrm)
        {
            rmGlobal = langList[lnPrm];
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
            loadLang();
            checkFilePassword();
            btnLogin.Focus();

           
        }

        private void checkFilePassword()
        {
            if (!File.Exists(Application.StartupPath + "\\user.dat"))
            {
                frmCreatePassword pass = new frmCreatePassword();
                pass.ShowDialog();
                
            }
        }
        public void loadLang()
        {

            this.Text = rmGlobal.GetString("welcome");
            lblTitle.Text = rmGlobal.GetString("frmEntrance_LblTitle");
            lblYourPassword.Text = rmGlobal.GetString("frmEntrance_lblYourPassword");
            btnLogin.Text = rmGlobal.GetString("login");
            btnRescueWallet.Text = rmGlobal.GetString("RescueMyWallet");
            lblLanguage.Text = rmGlobal.GetString("lang");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void kryptonDropButton1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonDropButton1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lang = kryptonComboBox1.Text.Split('-')[kryptonComboBox1.Text.Split('-').Length - 1];
            currentLang = ToEnum<langs>(lang);
            try
            {
                rmGlobal = langList[currentLang];
                this.loadLang();
            }
            catch (KeyNotFoundException thEx)
            {
                rmGlobal = langList[langs.EN];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected Error Occured!");
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string pass = File.ReadAllText(Application.StartupPath + "\\user.dat");
            var passSalt = AES.DecryptString(pass, "E546C8DF278CD5931069B522E695D4F2");
            if (textBox1.Text == passSalt)
            {
                btnLogin.Text = "Loading...Wait";
                btnLogin.Enabled = false;
                frmMain main = new frmMain();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(rmGlobal.GetString("errWrongPass"), rmGlobal.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
