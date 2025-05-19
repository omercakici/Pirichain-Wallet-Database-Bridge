namespace PiriChainWalletDataBridge
{
    partial class frmTransfer
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransfer));
            this.lblToAddress = new System.Windows.Forms.Label();
            this.lblAsset = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.cmbAssetList = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.cmbReceipt = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.btnSend = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonHeader1 = new ComponentFactory.Krypton.Toolkit.KryptonHeader();
            this.buttonSpecAny1 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.buttonSpecAny2 = new ComponentFactory.Krypton.Toolkit.ButtonSpecAny();
            this.trackBar1 = new ComponentFactory.Krypton.Toolkit.KryptonTrackBar();
            this.txtAmount = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.kryptonPalette1 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cmbAssetList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbReceipt)).BeginInit();
            this.SuspendLayout();
            // 
            // lblToAddress
            // 
            this.lblToAddress.AutoSize = true;
            this.lblToAddress.Location = new System.Drawing.Point(21, 118);
            this.lblToAddress.Name = "lblToAddress";
            this.lblToAddress.Size = new System.Drawing.Size(85, 13);
            this.lblToAddress.TabIndex = 2;
            this.lblToAddress.Text = "Receipt Address";
            // 
            // lblAsset
            // 
            this.lblAsset.AutoSize = true;
            this.lblAsset.Location = new System.Drawing.Point(21, 72);
            this.lblAsset.Name = "lblAsset";
            this.lblAsset.Size = new System.Drawing.Size(33, 13);
            this.lblAsset.TabIndex = 2;
            this.lblAsset.Text = "Asset";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(21, 164);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(43, 13);
            this.lblAmount.TabIndex = 2;
            this.lblAmount.Text = "Amount";
            // 
            // cmbAssetList
            // 
            this.cmbAssetList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssetList.DropDownWidth = 392;
            this.cmbAssetList.Location = new System.Drawing.Point(24, 88);
            this.cmbAssetList.Name = "cmbAssetList";
            this.cmbAssetList.Size = new System.Drawing.Size(438, 25);
            this.cmbAssetList.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbAssetList.StateActive.ComboBox.Border.Rounding = 5;
            this.cmbAssetList.StateActive.ComboBox.Content.Padding = new System.Windows.Forms.Padding(5);
            this.cmbAssetList.TabIndex = 7;
            this.cmbAssetList.SelectedIndexChanged += new System.EventHandler(this.cmbAssetList_SelectedIndexChanged);
            // 
            // cmbReceipt
            // 
            this.cmbReceipt.DropDownWidth = 434;
            this.cmbReceipt.Location = new System.Drawing.Point(24, 140);
            this.cmbReceipt.Name = "cmbReceipt";
            this.cmbReceipt.Size = new System.Drawing.Size(438, 25);
            this.cmbReceipt.StateActive.ComboBox.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.cmbReceipt.StateActive.ComboBox.Border.Rounding = 5;
            this.cmbReceipt.StateActive.ComboBox.Content.Padding = new System.Windows.Forms.Padding(5);
            this.cmbReceipt.TabIndex = 8;
            this.cmbReceipt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbReceipt_KeyUp);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(364, 180);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(98, 56);
            this.btnSend.StateCommon.Back.ColorAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Control;
            this.btnSend.StateCommon.Back.ColorStyle = ComponentFactory.Krypton.Toolkit.PaletteColorStyle.SolidAllLine;
            this.btnSend.StateCommon.Back.GraphicsHint = ComponentFactory.Krypton.Toolkit.PaletteGraphicsHint.AntiAlias;
            this.btnSend.StateCommon.Back.Image = global::PiriChainWalletDataBridge.Properties.Resources.money_transfer1;
            this.btnSend.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterLeft;
            this.btnSend.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSend.StateCommon.Border.Rounding = 10;
            this.btnSend.StateCommon.Border.Width = 2;
            this.btnSend.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Far;
            this.btnSend.TabIndex = 9;
            this.btnSend.Values.Text = "Transfer";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // kryptonHeader1
            // 
            this.kryptonHeader1.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecAny[] {
            this.buttonSpecAny1,
            this.buttonSpecAny2});
            this.kryptonHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonHeader1.HeaderStyle = ComponentFactory.Krypton.Toolkit.HeaderStyle.Custom1;
            this.kryptonHeader1.Location = new System.Drawing.Point(0, 0);
            this.kryptonHeader1.Name = "kryptonHeader1";
            this.kryptonHeader1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.kryptonHeader1.Size = new System.Drawing.Size(469, 31);
            this.kryptonHeader1.TabIndex = 10;
            this.kryptonHeader1.Values.Description = "Transfer Your Assets";
            this.kryptonHeader1.Values.Heading = "Transfer";
            this.kryptonHeader1.Values.Image = null;
            // 
            // buttonSpecAny1
            // 
            this.buttonSpecAny1.UniqueName = "61E1388DE7234815C784201009EDBEA4";
            // 
            // buttonSpecAny2
            // 
            this.buttonSpecAny2.UniqueName = "38DC1DF9BB7D4231F6A7315D06497763";
            // 
            // trackBar1
            // 
            this.trackBar1.DrawBackground = true;
            this.trackBar1.Location = new System.Drawing.Point(24, 209);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Blue;
            this.trackBar1.Size = new System.Drawing.Size(334, 20);
            this.trackBar1.StateTracking.Position.Color1 = System.Drawing.Color.DarkGoldenrod;
            this.trackBar1.TabIndex = 11;
            this.trackBar1.TrackBarSize = ComponentFactory.Krypton.Toolkit.PaletteTrackBarSize.Small;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(24, 183);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(334, 32);
            this.txtAmount.StateActive.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.txtAmount.StateActive.Border.Rounding = 5;
            this.txtAmount.StateActive.Content.Padding = new System.Windows.Forms.Padding(5);
            this.txtAmount.TabIndex = 12;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(300, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button2_Click);
            // 
            // kryptonPalette1
            // 
            this.kryptonPalette1.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office2010Silver;
            this.kryptonPalette1.FormStyles.FormCommon.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette1.FormStyles.FormCommon.StateCommon.Border.Rounding = 5;
            // 
            // frmTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(469, 242);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.kryptonHeader1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.cmbReceipt);
            this.Controls.Add(this.cmbAssetList);
            this.Controls.Add(this.lblAsset);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblToAddress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmTransfer";
            this.Palette = this.kryptonPalette1;
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Custom;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTransfer";
            this.Load += new System.EventHandler(this.frmTransfer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbAssetList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbReceipt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblToAddress;
        private System.Windows.Forms.Label lblAsset;
        private System.Windows.Forms.Label lblAmount;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbAssetList;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbReceipt;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSend;
        private ComponentFactory.Krypton.Toolkit.KryptonHeader kryptonHeader1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny1;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecAny buttonSpecAny2;
        private ComponentFactory.Krypton.Toolkit.KryptonTrackBar trackBar1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtAmount;
        private System.Windows.Forms.Button button1;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette1;
    }
}