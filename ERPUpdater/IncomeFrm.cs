using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERPUpdater
{
    public partial class IncomeFrm : Form
    {
        private bool _myTextBoxChanging = false;
        public IncomeFrm()
        {
            InitializeComponent();
            lblDate.Text = DateTime.Now.ToShortDateString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            decimal decAmount = decimal.Parse(txtAmounts.Text.Replace(",",""));
        }

       
    }
}
