using Coffee_Management_Software.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_Management_Software.GUI
{
    public partial class frmAcceptDelete : Form
    {
        public bool checkpass = false;
        Account account;
        public frmAcceptDelete()
        {
            InitializeComponent();
        }
        public frmAcceptDelete(Account account)
        {
            InitializeComponent();
            this.account = account;
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_Accept_Click(object sender, EventArgs e)
        {           
            string pass = txt_Password.Text.Trim();
            if (account.Password.Equals(pass))
            {
                checkpass = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Bạn nhập sai mật khẩu");
            }
        }
    }
}
