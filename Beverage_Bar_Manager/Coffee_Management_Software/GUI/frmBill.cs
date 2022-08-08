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
using Coffee_Management_Software.DTO;
using Coffee_Management_Software.FunctionCheckAndConvert;
using Coffee_Management_Software.Models;
using Coffee_Management_Software.Repository;
using Coffee_Management_Software.Repository.impl;

namespace Coffee_Management_Software.GUI
{
    
    public partial class frmBill : Form
    {
        FCV fcv = new FCV();
        List<FoodInBillDTO> bills = new List<FoodInBillDTO>();
        Bill bill = new Bill();
        bool flagUpdate = false;
        TableOr table = new TableOr();
        Employee employee = new Employee();
        IEmployeeRepository employeeRepository = new EmployeeRepository();
        IBillRepository billRepository = new BillRepository();
        ITableRepository tableRepository = new TableRepository();
        public frmBill()
        {
            InitializeComponent();
        }

        public frmBill(List<FoodInBillDTO> bills, TableOr table,int empID, Bill bill, bool flagUpdate)
        {
            InitializeComponent();
            this.bills = bills;
            this.table = table;
            employee = employeeRepository.GetEmployeeById(empID);
            this.bill = bill;
            this.flagUpdate = flagUpdate;
        }
        double toalMoney(List<FoodInBillDTO> bills) {
            double total = 0;
            foreach(var item in bills)
            {
                total += (item.Quality * item.Price);
            }
            return total;
        }
        private void Bill_Load(object sender, EventArgs e)
        {
            timer1.Start();
            try
            {
                txt_Cash.Text = fcv.FormatNumber(toalMoney(bills));
                txt_Table.Text = table.Name;
                txt_Employee.Text = employee.Name;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }      
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tbl_Time.Text = DateTime.Now.ToLongTimeString();
            tbl_date.Text = DateTime.Now.ToShortDateString();
        }

        private void tbn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        Bitmap bmp;
        public bool flagAction = false;
        private void tbn_CreateBill_Click(object sender, EventArgs e)
        {            
            try
            {
                float money = float.Parse(txt_ExcessCash.Text.Trim());
                if (txt_Guest.Text.Trim().Equals("") || money < 0)
                {
                    MessageBox.Show("Chưa nhập số tiền của khách hàng.", "THÔNG BÁO!", MessageBoxButtons.OK);
                    txt_Guest.Focus();
                    tbl_star.Visible = true;
                }
                else
                {
                    if (MessageBox.Show("Bạn có muốn thanh toán hay không", "THÔNG BÁO!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        flagAction = true;
                        if (flagUpdate)
                        {
                            bill.Status = true;
                            bill.DateCheckOut = DateTime.Now;
                            billRepository.UpdateBillStatus(bill);
                            table.Status = "Trống";
                            tableRepository.UpdateTable(table);
                            billRepository.DeleteBillDetailByIdBill(bill.Id);
                            billRepository.InsertBillDetailById(bills, bill.Id);
                        }
                        else
                        {
                            billRepository.InsertBillAndBillDetail(bills, true, employee.Id, table);
                        }
                        guest = float.Parse(txt_Guest.Text);
                        printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 280, 600);
                        if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                        {
                            printDocument1.Print();
                        }
                        this.Close();
                    }
                }             
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");                
            }
        }
        
        
        int pos = 300;
        double total = 0, guest = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Highlands Coffee", new Font("Bahnschrift Condensed", 14), Brushes.Black, new Point(10,10));
            e.Graphics.DrawString("Địa chỉ: Đại học FPT. km 29 đại lộ Thăng Long, Thạch Hòa,", new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(10, 40));
            e.Graphics.DrawString("Thạch Thất, Hà Nội.", new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(10, 60));
            e.Graphics.DrawString("Điện thoại:  0972 655 358", new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(10, 80));
            e.Graphics.DrawString("HÓA ĐƠN THANH TOÁN", new Font("Bahnschrift Condensed", 14, FontStyle.Regular), Brushes.Black, new Point(70, 110));
            e.Graphics.DrawString("-----o0o-----", new Font("Britannic Bold", 10, FontStyle.Regular), Brushes.Black, new Point(110, 130));
            e.Graphics.DrawString("Ngày giờ:   "+ DateTime.Now.ToShortDateString()+" "+ DateTime.Now.ToLongTimeString(), new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(10, 160));
            e.Graphics.DrawString("Số Hóa Đơn:", new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(10, 180));
            e.Graphics.DrawString("Demo1", new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(160, 180));
            e.Graphics.DrawString("Quan ly:", new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(10, 200));
            e.Graphics.DrawString("Nguyen Van Tuyen", new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(160, 200));
            e.Graphics.DrawString("Bàn", new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(10, 220));
            e.Graphics.DrawString("Bàn số 3", new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(160, 220));
            e.Graphics.DrawString("--------------------------------------------------", new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(10, 240));
            e.Graphics.DrawString("Tên", new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(10, 260));
            e.Graphics.DrawString("Số lượng", new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(80, 260));
            e.Graphics.DrawString("Đơn giá", new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(150, 260));
            e.Graphics.DrawString("Thành tiền", new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(220, 260));
            e.Graphics.DrawString("--------------------------------------------------", new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(10, 280));
            foreach(var item in bills)
            {
                e.Graphics.DrawString(item.ProductName +" Size "+item.Size, new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(10, pos));
                e.Graphics.DrawString(item.Quality.ToString(), new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(80, pos+20));
                e.Graphics.DrawString(fcv.FormatNumber(item.Price), new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(150, pos+20));
                e.Graphics.DrawString(fcv.FormatNumber(item.Quality * item.Price), new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(220, pos + 20));
                pos += 40;
                total += item.Price  * item.Quality;
            }
            e.Graphics.DrawString("--------------------------------------------------", new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(10, pos + 20));
            e.Graphics.DrawString("Tổng tiền:", new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(10, pos + 40));
            e.Graphics.DrawString(fcv.FormatNumber(total), new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(220, pos + 40));
            e.Graphics.DrawString("Tiền khách trả:", new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(10, pos + 70));
            e.Graphics.DrawString(fcv.FormatNumber(guest), new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(220, pos + 70));
            e.Graphics.DrawString("Trả lại cho khách:", new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(10, pos + 100));
            e.Graphics.DrawString(fcv.FormatNumber((guest - total)), new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(220, pos + 100));
            e.Graphics.DrawString("--------------------------------------------------", new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular), Brushes.Black, new Point(10, pos + 130));
            
        }

        private void txt_Guest_TextChanged(object sender, EventArgs e)
        {
            var number = txt_Guest.Text;
            if (fcv.CheckStringIsNumber(number))
            {
                tbl_star.Visible = false;
                float guest = float.Parse(number);
                txt_ExcessCash.Text = fcv.FormatNumber(guest - toalMoney(bills));
            }
            else
            {
                tbl_star.Visible = true;
            }
        }

        private void txt_Guest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        
    }
}
