using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PiriChainWalletDataBridge.components
{
    public partial class nodeItem : UserControl
    {
        public nodeItem(string nodeName)
        {
            InitializeComponent();
            lblNodeName.Text = nodeName;
        }
    }
}
