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
    public partial class Directional : Form
    {
        IAttendanceRepository attendanceRepository = new AttendanceRepository();
        IEmployeeRepository employeeRepository = new EmployeeRepository();
        Account account = new Account();
        Attendance attendance = new Attendance();
        bool flagAttend1 = true;
        Timer t;
        Shift shift;
        public Directional()
        {
            InitializeComponent();
        }
        public Directional(Account account)
        {
            InitializeComponent();
            this.account = account;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tbl_Time.Text = DateTime.Now.ToLongTimeString();
            tbl_date.Text = DateTime.Now.ToLongDateString();
        }

        private void Direction_Load(object sender, EventArgs e)
        {
            timer1.Start();
            if (account.Role.Equals("manager")) btn_System.Enabled = true;
            Employee employee = employeeRepository.GetEmployeeById(account.IdEmployee);
            shift = attendanceRepository.GetShiftByID((int)employee.IdShift);
            t = new Timer();
            t.Interval = 500;
            t.Tick += t_Tick;
            SetTextButton();
            t.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            SetTextButton();
            if (ts1.TotalSeconds <= 0)
            {
                btn_Shift.Enabled = false;
                btn_Shift.Text = "ĐIỂM DANH";
            }
            
        }
        //ham tinh h diem danh 
        TimeSpan ts1;
        void SetTextButton()
        {
            TimeSpan tsNow = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            TimeSpan ts0 = new TimeSpan(0, 10, 0);
            TimeSpan ts = new TimeSpan(0, 0, 0);
            try
            {
                attendance = attendanceRepository.GetAttendance(account.IdEmployee);
                if (tsNow.Subtract(shift.StartTime.Value) <= ts0 || (tsNow.Subtract(shift.EndTime.Value) >= ts && tsNow.Subtract(shift.EndTime.Value) <= ts0))
                {
                    if (attendance == null)
                    {
                        TimeSpan tsShift = shift.StartTime.Value.Add(ts0);
                        ts1 = tsShift.Subtract(tsNow);
                        if (ts1 <= ts0)
                        {
                            btn_Shift.Enabled = true;
                            btn_Shift.Text = "ĐIỂM DANH 1\n" + ts1;
                        }
                    }
                    else
                    {
                        TimeSpan tsShift = shift.EndTime.Value.Add(ts0);
                        ts1 = tsShift.Subtract(tsNow);
                        if (ts1 <= ts0)
                        {
                            btn_Shift.Enabled = true;
                            btn_Shift.Text = "ĐIỂM DANH 2\n" + ts1;
                        }
                        flagAttend1 = false;
                    }
                }
            }
             catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void btn_Shift_Click(object sender, EventArgs e)
        {            
            try
            {
                if (flagAttend1)
                {

                    Attendance attendance = new Attendance();
                    attendance.IdEmployee = account.IdEmployee;
                    attendance.Attendance1St = true;
                    attendance.Attendance2Nd = false;
                    attendance.AttendanceDate = DateTime.Now;
                    attendanceRepository.InserAttendance(attendance);
                    MessageBox.Show("Điểm danh lần 1 thành công", "THÔNG BÁO!", MessageBoxButtons.OK);
                }
                else
                {
                    Attendance attendance = attendanceRepository.GetAttendance(account.IdEmployee);
                    attendance.Attendance2Nd = true;
                    attendanceRepository.UpdateAttendance(attendance);
                    MessageBox.Show("Điểm danh lần 2 thành công", "THÔNG BÁO!", MessageBoxButtons.OK);
                }
                btn_Shift.Enabled = false;
                btn_Shift.Text = "Điểm danh";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            
        }

        private void btn_Sale_Click(object sender, EventArgs e)
        {
            frmSale sale = new frmSale(account);
            this.Hide();
            sale.ShowDialog();
            this.Show();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            frmLogin login = new frmLogin();
            this.Close();
            login.Show();
        }

        private void txt_Profile_Click(object sender, EventArgs e)
        {
            frmProfile profile = new frmProfile(account);
            profile.ShowDialog();
            this.Show();
        }

        private void btn_System_Click(object sender, EventArgs e)
        {
            Management management = new Management(account);
            this.Hide();
            management.ShowDialog();
            this.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
