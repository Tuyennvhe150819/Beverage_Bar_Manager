using Coffee_Management_Software.DTO;
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
    public partial class frmBillPrint : Form
    {
        IEmployeeRepository employeeRepository = new EmployeeRepository();
        IBillRepository billRepository = new BillRepository();
        ITableRepository tableRepository = new TableRepository();
        IFoodRepository foodRepository = new FoodRepository();
        FCV fcv = new FCV();
        int billID;
        public frmBillPrint()
        {
            InitializeComponent();
        }
        public frmBillPrint(int billID)
        {
            InitializeComponent();
            this.billID = billID;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        int pos = 0;
        double totolCost = 0;
        private void BillPrint_Load(object sender, EventArgs e)
        {
           
            try
            {
                List<BillDetail> billDetails = billRepository.GetBillDetailsByIdBill(billID);
                Bill bill = billRepository.GetBillById(billID);
                Employee employee = employeeRepository.GetEmployeeById((int)bill.IdEmployee);
                TableOr table = tableRepository.GetTableInfoById((int)bill.IdTable);
                foreach (var item in billDetails)
                {
                    Food food = foodRepository.GetFoodInfoById(item.IdFood);
                    int id = item.IdFood;
                    string name = food.Name;
                    double price = (double)food.Price;
                    string size = food.Size;
                    int quality = (int)item.Quality;
                    double cost = (double)food.Price * (int)item.Quality;

                    Label tblname = new Label();
                    tblname.Text = name;
                    tblname.Location = new Point(0, pos);
                    tblname.Font = new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular);
                    tblname.Size = new Size(200, 15);

                    Label tblSL = new Label();
                    tblSL.Text = quality.ToString();
                    tblSL.Location = new Point(130, pos+ 20);
                    tblSL.Font = new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular);
                    tblSL.Size = new Size(50, 15);

                    Label tblPrice = new Label();
                    tblPrice.Text = fcv.FormatNumber(price);
                    tblPrice.Location = new Point(200, pos + 20);
                    tblPrice.Font = new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular);
                    tblPrice.Size = new Size(50, 15);

                    Label tblTotal = new Label();
                    tblTotal.Text = fcv.FormatNumber(cost);
                    tblTotal.Location = new Point(300, pos + 20);
                    tblTotal.Font = new Font("Bahnschrift Light Condensed", 10, FontStyle.Regular);
                    tblTotal.Size = new Size(50, 15);

                    pan_Bill.Controls.Add(tblname);
                    pan_Bill.Controls.Add(tblSL);
                    pan_Bill.Controls.Add(tblPrice);
                    pan_Bill.Controls.Add(tblTotal);
                    pos += 30;
                    totolCost += cost;
                }
                tbl_datetime.Text = bill.DateCheckOut.ToString();
                tbl_IdBill.Text = bill.Id.ToString();
                tbl_NameEmp.Text = employee.Name;
                tbl_Table.Text = table.Name;
                tbl_totalcost.Text = fcv.FormatNumber(totolCost) + " vnđ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pan_Bill_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
