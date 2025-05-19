namespace PiriChainWalletDataBridge.components
{
    partial class balanceItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lblCoinBalance = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblCoinName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.lblCoinBalance);
            this.kryptonPanel1.Controls.Add(this.pictureBox1);
            this.kryptonPanel1.Controls.Add(this.lblCoinName);
            this.kryptonPanel1.Location = new System.Drawing.Point(3, 2);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.kryptonPanel1.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlToolTip;
            this.kryptonPanel1.Size = new System.Drawing.Size(136, 118);
            this.kryptonPanel1.StateNormal.Color1 = System.Drawing.Color.White;
            this.kryptonPanel1.StateNormal.Color2 = System.Drawing.Color.LightGray;
            this.kryptonPanel1.StateNormal.ColorAngle = 45F;
            this.kryptonPanel1.StateNormal.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.OneNote;
            this.kryptonPanel1.StateNormal.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.kryptonPanel1.TabIndex = 2;
            this.kryptonPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.kryptonPanel1_Paint);
            // 
            // lblCoinBalance
            // 
            this.lblCoinBalance.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ItalicControl;
            this.lblCoinBalance.Location = new System.Drawing.Point(1, 90);
            this.lblCoinBalance.Name = "lblCoinBalance";
            this.lblCoinBalance.Size = new System.Drawing.Size(86, 20);
            this.lblCoinBalance.TabIndex = 3;
            this.lblCoinBalance.Values.Text = "kryptonLabel1";
            // 
            // lblCoinName
            // 
            this.lblCoinName.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.lblCoinName.Location = new System.Drawing.Point(1, 70);
            this.lblCoinName.Name = "lblCoinName";
            this.lblCoinName.Size = new System.Drawing.Size(94, 20);
            this.lblCoinName.TabIndex = 2;
            this.lblCoinName.Values.Text = "kryptonLabel1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.ErrorImage = global::PiriChainWalletDataBridge.Properties.Resources.check;
            this.pictureBox1.InitialImage = global::PiriChainWalletDataBridge.Properties.Resources.logo_750;
            this.pictureBox1.Location = new System.Drawing.Point(26, 6);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // balanceItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.kryptonPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.Name = "balanceItem";
            this.Size = new System.Drawing.Size(140, 129);
            this.Load += new System.EventHandler(this.balanceItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblCoinBalance;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblCoinName;

    }
}
