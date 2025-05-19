using ComponentFactory.Krypton.Toolkit;
using PiriChainWalletDataBridge.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PiriChainWalletDataBridge
{
    public partial class frmCreatePassword : KryptonForm
    {
        public frmCreatePassword()
        {
            InitializeComponent();
        }

        private void frmCreatePassword_Load(object sender, EventArgs e)
        {
            loadLanguage();
        }

        void loadLanguage()
        {

            this.Text = frmLogin.rmGlobal.GetString("welcome");
            lblTitle.Text = frmLogin.rmGlobal.GetString("createNewPassword");
            lblDefPass.Text = frmLogin.rmGlobal.GetString("enterNewPassword");
            lblDefPass2.Text = frmLogin.rmGlobal.GetString("enterNewPasswordAgain");
            button1.Text =  frmLogin.rmGlobal.GetString("Submit");
        }

        private void frmCreatePassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 5)
                MessageBox.Show(frmLogin.rmGlobal.GetString("errorMustbeLeast5Ch"), frmLogin.rmGlobal.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (textBox1.Text != textBox2.Text)
                MessageBox.Show(frmLogin.rmGlobal.GetString("errorPasswordNotMatched"), frmLogin.rmGlobal.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                var enc = AES.EncryptString(textBox1.Text, "E546C8DF278CD5931069B522E695D4F2");
                File.WriteAllText(Application.StartupPath + "\\user.dat", enc);

                
            
            }
        }
    }
}
