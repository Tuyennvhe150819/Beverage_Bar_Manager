using Coffee_Management_Software.DAO;
using Coffee_Management_Software.Models;
using Coffee_Management_Software.Repository;
using Coffee_Management_Software.Repository.impl;
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
    public partial class frmLogin : Form
    {
        IEmployeeRepository employeeRepository = new EmployeeRepository();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim().ToLower();
            string password = txtPassword.Text.Trim();
            Account account = new Account();
            try
            {
                account = employeeRepository.GetAccountByUserNameAndPassword(username, password);
                if(account != null)
                {
                    if ((bool)account.Status)
                    {
                        MessageBox.Show("Đăng nhập thành công !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Directional directional = new Directional(account);
                        directional.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản bị khóa, Vui lòng liên hệ Quản Lý!");
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }                    
        }

        private void tbl_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có thật sự muốn thoát chương trình?","THÔNG BÁO!",MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
