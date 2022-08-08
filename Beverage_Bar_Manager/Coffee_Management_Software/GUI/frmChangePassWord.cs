
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_Management_Software.GUI
{
    public partial class frmChangePassWord : Form
    {
        IEmployeeRepository employeeRepository = new EmployeeRepository();
        Account account = new Account();
        public frmChangePassWord()
        {
            InitializeComponent();
        }
        public frmChangePassWord(Account account)
        {
            InitializeComponent();
            this.account = account;
        }

        private void tbl_Close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        bool CheckInsertPass()
        {
            string oldPass = txt_Old.Text.Trim();
            string newPass = txt_New.Text.Trim();
            string rePass = txt_ReNew.Text.Trim();

            if (oldPass.Equals(""))
            {
                MessageBox.Show("Mật khẩu cũ không được để trống.");
                txt_Old.Focus();
                return false;
            }
            if (newPass.Equals(""))
            {
                MessageBox.Show("Mật khẩu mới không được để trống.");
                txt_New.Focus();
                return false;
            }
            if (!rePass.Equals(newPass))
            {
                MessageBox.Show("Nhập lại mật khẩu không đúng.");
                txt_ReNew.Focus();
                return false;
            }
            Regex regPass = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$");
            if (!regPass.IsMatch(newPass))
            {
                MessageBox.Show("Mật khẩu cần có:\n" +
                    "Ít nhất một chữ cái tiếng Anh viết hoa\n" +
                    "Ít nhất một chữ cái tiếng Anh viết thường \n" +
                    "Ít nhất một chữ số \n" +
                    "Ít nhất một ký tự đặc biệt \n" +
                    "Độ dài tối thiểu 8");
                txt_New.Focus();
                return false;
            }
            return true;
        }
        private void btn_UpdatePassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckInsertPass())
                {
                    Account acc = employeeRepository.GetAccountByUserNameAndPassword(account.Username, txt_Old.Text.Trim());
                    if (acc == null)
                    {
                        MessageBox.Show("Mật khẩu cũ không chính xác !");
                        txt_Old.Focus();
                    }
                    else
                    {
                        employeeRepository.ResetPasswordByUserName(account.Username, txt_New.Text.Trim());
                        MessageBox.Show("Đổi mật khẩu thành công !", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        frmLogin login = new frmLogin();
                        login.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btn_ShowOld_Click(object sender, EventArgs e)
        {
            if (txt_Old.PasswordChar == '*')
            {
                btn_nShowOld.BringToFront();
                txt_Old.PasswordChar = '\0';
            }
        }

        private void btn_nShowOld_Click(object sender, EventArgs e)
        {
            if (txt_Old.PasswordChar == '\0')
            {
                btn_ShowOld.BringToFront();
                txt_Old.PasswordChar = '*';
            }
        }

        private void btn_ShowNew_Click(object sender, EventArgs e)
        {
            if (txt_New.PasswordChar == '*')
            {
                btn_nShowNew.BringToFront();
                txt_New.PasswordChar = '\0';
            }
        }

        private void btn_nShowNew_Click(object sender, EventArgs e)
        {
            if (txt_New.PasswordChar == '*')
            {
                btn_ShowNew.BringToFront();
                txt_New.PasswordChar = '\0';
            }
        }

        private void btn_ShowRe_Click(object sender, EventArgs e)
        {
            if (txt_ReNew.PasswordChar == '*')
            {
                btn_nShowRe.BringToFront();
                txt_ReNew.PasswordChar = '\0';
            }
        }

        private void btn_nShowRe_Click(object sender, EventArgs e)
        {
            if (txt_ReNew.PasswordChar == '*')
            {
                btn_ShowRe.BringToFront();
                txt_ReNew.PasswordChar = '\0';
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
