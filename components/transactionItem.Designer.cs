namespace PiriChainWalletDataBridge.components
{
    partial class transactionItem
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
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTransactionHash = new System.Windows.Forms.LinkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlValidators = new System.Windows.Forms.Panel();
            this.lblConfirmationNode = new System.Windows.Forms.Label();
            this.lblBlockNumberText = new System.Windows.Forms.Label();
            this.lblConfirmationCountText = new System.Windows.Forms.Label();
            this.lblBlockNumber = new System.Windows.Forms.Label();
            this.lblConfirmationCount = new System.Windows.Forms.Label();
            this.lblConfirmed = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(9, 51);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFrom.Size = new System.Drawing.Size(285, 13);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "PRTMRdsmVMCydZocVnBhobskk86DsfU9cx2CveDaUsT";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(452, 51);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(285, 13);
            this.lblTo.TabIndex = 0;
            this.lblTo.Text = "PRTMRdsmVMCydZocVnBhobskk86DsfU9cx2CveDaUsT";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAmount.Location = new System.Drawing.Point(9, 73);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(82, 24);
            this.lblAmount.TabIndex = 0;
            this.lblAmount.Text = "Amount";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDate.Location = new System.Drawing.Point(396, 77);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(58, 16);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "lblDate";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTransactionHash);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pnlValidators);
            this.panel1.Controls.Add(this.lblConfirmationNode);
            this.panel1.Controls.Add(this.lblBlockNumberText);
            this.panel1.Controls.Add(this.lblConfirmationCountText);
            this.panel1.Controls.Add(this.lblBlockNumber);
            this.panel1.Controls.Add(this.lblConfirmationCount);
            this.panel1.Controls.Add(this.lblConfirmed);
            this.panel1.Controls.Add(this.lblFrom);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblTo);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblAmount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(851, 183);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblTransactionHash
            // 
            this.lblTransactionHash.AutoSize = true;
            this.lblTransactionHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTransactionHash.Location = new System.Drawing.Point(142, 15);
            this.lblTransactionHash.Name = "lblTransactionHash";
            this.lblTransactionHash.Size = new System.Drawing.Size(69, 16);
            this.lblTransactionHash.TabIndex = 5;
            this.lblTransactionHash.TabStop = true;
            this.lblTransactionHash.Text = "linkLabel1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PiriChainWalletDataBridge.Properties.Resources.check;
            this.pictureBox2.Location = new System.Drawing.Point(66, 101);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pnlValidators
            // 
            this.pnlValidators.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlValidators.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlValidators.Location = new System.Drawing.Point(5, 145);
            this.pnlValidators.Name = "pnlValidators";
            this.pnlValidators.Size = new System.Drawing.Size(839, 31);
            this.pnlValidators.TabIndex = 3;
            // 
            // lblConfirmationNode
            // 
            this.lblConfirmationNode.AutoSize = true;
            this.lblConfirmationNode.Location = new System.Drawing.Point(16, 129);
            this.lblConfirmationNode.Name = "lblConfirmationNode";
            this.lblConfirmationNode.Size = new System.Drawing.Size(93, 13);
            this.lblConfirmationNode.TabIndex = 2;
            this.lblConfirmationNode.Text = "ConfirmationCount";
            // 
            // lblBlockNumberText
            // 
            this.lblBlockNumberText.AutoSize = true;
            this.lblBlockNumberText.Location = new System.Drawing.Point(481, 104);
            this.lblBlockNumberText.Name = "lblBlockNumberText";
            this.lblBlockNumberText.Size = new System.Drawing.Size(93, 13);
            this.lblBlockNumberText.TabIndex = 2;
            this.lblBlockNumberText.Text = "ConfirmationCount";
            // 
            // lblConfirmationCountText
            // 
            this.lblConfirmationCountText.AutoSize = true;
            this.lblConfirmationCountText.Location = new System.Drawing.Point(238, 104);
            this.lblConfirmationCountText.Name = "lblConfirmationCountText";
            this.lblConfirmationCountText.Size = new System.Drawing.Size(93, 13);
            this.lblConfirmationCountText.TabIndex = 2;
            this.lblConfirmationCountText.Text = "ConfirmationCount";
            // 
            // lblBlockNumber
            // 
            this.lblBlockNumber.AutoSize = true;
            this.lblBlockNumber.Location = new System.Drawing.Point(573, 104);
            this.lblBlockNumber.Name = "lblBlockNumber";
            this.lblBlockNumber.Size = new System.Drawing.Size(93, 13);
            this.lblBlockNumber.TabIndex = 2;
            this.lblBlockNumber.Text = "ConfirmationCount";
            // 
            // lblConfirmationCount
            // 
            this.lblConfirmationCount.AutoSize = true;
            this.lblConfirmationCount.Location = new System.Drawing.Point(333, 104);
            this.lblConfirmationCount.Name = "lblConfirmationCount";
            this.lblConfirmationCount.Size = new System.Drawing.Size(93, 13);
            this.lblConfirmationCount.TabIndex = 2;
            this.lblConfirmationCount.Text = "ConfirmationCount";
            // 
            // lblConfirmed
            // 
            this.lblConfirmed.AutoSize = true;
            this.lblConfirmed.Location = new System.Drawing.Point(16, 108);
            this.lblConfirmed.Name = "lblConfirmed";
            this.lblConfirmed.Size = new System.Drawing.Size(57, 13);
            this.lblConfirmed.TabIndex = 2;
            this.lblConfirmed.Text = "Confirmed:";
            this.lblConfirmed.Click += new System.EventHandler(this.lblConfirmed_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PiriChainWalletDataBridge.Properties.Resources.right_arrow;
            this.pictureBox1.Location = new System.Drawing.Point(379, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // transactionItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "transactionItem";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(861, 193);
            this.Load += new System.EventHandler(this.transactionItem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblConfirmationCount;
        private System.Windows.Forms.Label lblConfirmed;
        private System.Windows.Forms.Panel pnlValidators;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblConfirmationCountText;
        private System.Windows.Forms.Label lblBlockNumberText;
        private System.Windows.Forms.Label lblBlockNumber;
        private System.Windows.Forms.Label lblConfirmationNode;
        private System.Windows.Forms.LinkLabel lblTransactionHash;
    }
}
