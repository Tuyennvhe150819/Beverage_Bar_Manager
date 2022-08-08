using Coffee_Management_Software.FunctionCheckAndConvert;
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
    public partial class frmProfile : Form
    {
        IEmployeeRepository employeeRepository = new EmployeeRepository();
        IAttendanceRepository attendanceRepository = new AttendanceRepository();
        Account account = new Account();
        FCV fcv = new FCV();
        public frmProfile()
        {
            InitializeComponent();
        }
        public frmProfile(Account account)
        {
            InitializeComponent();
            this.account = account;
        }

        private void btn_Out_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ChangePass_Click(object sender, EventArgs e)
        {
            frmChangePassWord changePassWord = new frmChangePassWord(account);
            changePassWord.ShowDialog();
            this.Show();
        }

        private void frmProfile_Load(object sender, EventArgs e)
        {
            try
            {
                Employee employee = employeeRepository.GetEmployeeById(account.IdEmployee);
                int count = attendanceRepository.CountAttendByIdEmpAndMonht(account.IdEmployee);
                Shift shift = attendanceRepository.GetShiftByID((int)employee.IdShift);
                int totalTimes = (int)shift.Time * count;
                float toTalSlary = (float)(totalTimes * employee.Salary);
                tbl_Name.Text = employee.Name;
                tbl_Address.Text = employee.Address;
                tbl_Phone.Text = employee.Phone;
                tbl_Cmt.Text = employee.Cmt;
                tbl_Salary.Text =fcv.FormatNumber(employee.Salary) + " vnđ";
                tbl_Time.Text = totalTimes+" giờ";
                tbl_Total.Text = fcv.FormatNumber(toTalSlary)+" vnđ";
                Image img = Image.FromFile(employee.Photo);
                pic_Avt.Image = img;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
