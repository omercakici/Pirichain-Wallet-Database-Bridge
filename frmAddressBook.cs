using ComponentFactory.Krypton.Toolkit;
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
    public partial class frmAddressBook : KryptonForm
    {
        public frmAddressBook()
        {
            InitializeComponent();

        }
        public frmAddressBook(string add)
        {
            InitializeComponent();
            txtAddress.Text = add;
            txtLabel.Focus();
            currentAddress = add;
        }



        private void frmAddressBook_Load(object sender, EventArgs e)
        {
            lblLabel.Text = frmLogin.rmGlobal.GetString("label");
            lblAddress.Text = frmLogin.rmGlobal.GetString("address");
            btnAddNew.Text = frmLogin.rmGlobal.GetString("addNew");
            btnDelete.Text = frmLogin.rmGlobal.GetString("delete");
            btnSubmit.Text = frmLogin.rmGlobal.GetString("Submit");
            this.Text = frmLogin.rmGlobal.GetString("addressBook");
            addressList();
        }
        void addressList()
        {

            var t = Data.addressBook.listAddress();
            dataGridView1.DataSource = t;
            dataGridView1.Columns[1].Width = 310;
        
        }

        bool addNew = false;

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            addNew = true;
            editMode = false;
            btnSubmit.Enabled = true;
            btnAddNew.Enabled = false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtLabel.Text) || String.IsNullOrEmpty(txtAddress.Text))
                MessageBox.Show(frmLogin.rmGlobal.GetString("errFillAllFields"), frmLogin.rmGlobal.GetString("error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (addNew)
                {
                    Data.addressBook.addAddress(txtLabel.Text, txtAddress.Text);
                    MessageBox.Show(frmLogin.rmGlobal.GetString("messageAddressAdded"), frmLogin.rmGlobal.GetString("result"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    addressList();
                }
                else if (editMode)
                {
                    Data.addressBook.editAddress(currentAddress, txtLabel.Text, txtAddress.Text);
                    MessageBox.Show(frmLogin.rmGlobal.GetString("messageAddressUpdated"), frmLogin.rmGlobal.GetString("result"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    addressList();
                    currentAddress = "";
                    editMode = false;
                    btnAddNew.Enabled = true;
                    btnSubmit.Enabled = false;
                
                }
                
            }
        }
        bool editMode = false;
        string currentAddress = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            editMode = true;
            addNew = false;
            btnAddNew.Enabled = false;
            btnSubmit.Enabled = true;
            btnDelete.Enabled = true;
            txtLabel.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            currentAddress = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(String.Format(frmLogin.rmGlobal.GetString("confirmDelete"), currentAddress), frmLogin.rmGlobal.GetString("confirm"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Data.addressBook.remove(currentAddress);
                btnSubmit.Enabled = false;
                btnAddNew.Enabled = true;
                addressList();
            
            }
        }
    }
}
