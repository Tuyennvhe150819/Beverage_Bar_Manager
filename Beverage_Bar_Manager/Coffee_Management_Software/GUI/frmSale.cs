using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Coffee_Management_Software.DTO;
using Coffee_Management_Software.FunctionCheckAndConvert;
using Coffee_Management_Software.Models;
using Coffee_Management_Software.Repository;
using Coffee_Management_Software.Repository.impl;

namespace Coffee_Management_Software.GUI
{
    public partial class frmSale : Form
    {
        TableRepository tableRepository = new TableRepository();
        CategoryRepository categoryRepository = new CategoryRepository();
        IFoodRepository foodRepository = new FoodRepository();
        IBillRepository billRepository = new BillRepository();
        List<FoodInBillDTO> bills = new List<FoodInBillDTO>();
        Account account = new Account();
        TableOr table = new TableOr();
        Bill bill = new Bill();
        FCV fcv = new FCV();

        bool flagClickTable = false;
        int weight = 100, height = 100;
        bool flagUpdate = false;
        public frmSale()
        {
            InitializeComponent();
        }
        public frmSale(Account account )
        {
            InitializeComponent();
            this.account = account;
        }


        void loadTable()
        {
            flp_Table.Controls.Clear();
            try
            {
                List<TableOr> tables = tableRepository.GetAllTableToSale();
                foreach (TableOr item in tables)
                {
                    Button btn = new Button() { Width = weight, Height = height };
                    btn.Text = item.Name + Environment.NewLine + item.Status;
                    btn.Click += btn_Click;
                    btn.Tag = item;

                    switch (item.Status)
                    {
                        case "Trống":
                            btn.BackColor = Color.Aqua;
                            break;
                        default:
                            btn.BackColor = Color.LightPink;
                            break;
                    }
                    flp_Table.Controls.Add(btn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }  
        }
        void LoadCategoryToPanel(List<FoodCategory> categories)
        {
            int count = 0;
            foreach(var item in categories)
            {
                Button btn = new Button();
                btn.Font = new Font("Microsoft Sans Serif", 12f);
                btn.Text = item.Name;
                btn.Size = new Size(130, 90); ;
                btn.Top = count * 100 + 5;
                btn.Visible = true;
                btn.BackColor = Color.Honeydew;
                pan_Cate.Controls.Add(btn);
                count++;
                btn.Tag = item;
                btn.Click += CategoryChange;
            }
        }

        void LoadFoodByCateId(int idCate)
        {
            try
            {
                lv_Food.Items.Clear();
                List<Food> foods = foodRepository.GetListFoodByIDCate(idCate);
                ImageList images = new ImageList();
                images.ImageSize = new Size(100, 100);
                lv_Food.TileSize = new Size(230, 130);
                foreach (var item in foods)
                {
                    string pic = item.Picture;
                    try
                    {
                        images.Images.Add(Image.FromFile(pic));
                    }
                    catch (Exception)
                    {
                        images.Images.Add(Image.FromFile("Image/food.png"));
                    }
                }
                lv_Food.LargeImageList = images;
                int count = 0;
                foreach (var item in foods)
                {
                    lv_Food.Items.Add(item.Name, count);
                    string[] price = item.Price.ToString().Split(".");
                    lv_Food.Items[count].SubItems.Add("Price: " + price[0]);
                    lv_Food.Items[count].SubItems.Add("Size: " + item.Size);
                    lv_Food.Items[count].SubItems.Add(item.Id.ToString());
                    lv_Food.Items[count].SubItems.Add(price[0]);
                    lv_Food.Items[count].SubItems.Add(item.Size);
                    count++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        void CalculateCost()
        {
            double sum = 0;
            foreach(var item in bills)
            {
                sum += item.Cost;
            }
            txt_TotalPrice.Text = fcv.FormatNumber(sum);
        }
        void AddProductToBill(FoodInBillDTO bill)
        {
            bool dublicate = false;           
            foreach(var item in bills)
            {
                if(item.ProductID == bill.ProductID)
                {
                    item.Quality++;
                    item.Cost = item.Quality * item.Price;
                    dublicate = true;
                }
                
            }
            if (!dublicate) bills.Add(bill);
            CalculateCost();
        }

        void LoadBillToDatagridViewBill()
        {
            dgv_Bill.DataSource = null;           
            dgv_Bill.DataSource = bills;
        }

        private void Sale_Load(object sender, EventArgs e)
        {
            loadTable();
            try
            {
                timer1.Start();
                List<FoodCategory> categories = categoryRepository.GetCategoriesIsActive();
                LoadCategoryToPanel(categories);
                LoadFoodByCateId(categories[0].Id);
                dgv_Bill.AutoGenerateColumns = false;
                dgv_Bill.Columns.Add("pid", "Mã");
                dgv_Bill.Columns["pid"].Width = 40;
                dgv_Bill.Columns["pid"].DataPropertyName = "ProductID";
                dgv_Bill.Columns["pid"].Visible = false;

                dgv_Bill.Columns.Add("pName", "Tên");
                dgv_Bill.Columns["pName"].Width = 100;
                dgv_Bill.Columns["pName"].DataPropertyName = "ProductName";

                dgv_Bill.Columns.Add("pSize", "Size");
                dgv_Bill.Columns["pSize"].Width = 45;
                dgv_Bill.Columns["pSize"].DataPropertyName = "Size";

                dgv_Bill.Columns.Add("price", "Giá");
                dgv_Bill.Columns["price"].Width = 70;
                dgv_Bill.Columns["price"].DataPropertyName = "Price";

                dgv_Bill.Columns.Add("pQuant", "SL");
                dgv_Bill.Columns["pQuant"].Width = 30;
                dgv_Bill.Columns["pQuant"].DataPropertyName = "Quality";

                DataGridViewButtonColumn addCol = new DataGridViewButtonColumn();
                addCol.Name = " ";
                addCol.Text = "+";
                addCol.Width = 29;
                addCol.DefaultCellStyle.BackColor = Color.Green;
                addCol.UseColumnTextForButtonValue = true;
                dgv_Bill.Columns.Add(addCol);

                DataGridViewButtonColumn subCol = new DataGridViewButtonColumn();
                subCol.Name = " ";
                subCol.Text = "-";
                subCol.Width = 29;
                subCol.DefaultCellStyle.BackColor = Color.Yellow;
                subCol.UseColumnTextForButtonValue = true;
                dgv_Bill.Columns.Add(subCol);

                dgv_Bill.Columns.Add("cost", "Tổng");
                dgv_Bill.Columns["cost"].DataPropertyName = "Cost";

                DataGridViewButtonColumn delCol = new DataGridViewButtonColumn();
                delCol.Name = " ";
                delCol.Text = "X";
                delCol.Width = 30;
                delCol.DefaultCellStyle.BackColor = Color.Red;
                delCol.UseColumnTextForButtonValue = true;
                dgv_Bill.Columns.Add(delCol);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void CategoryChange(object sender, EventArgs e)
        {
            try
            {               
                int idCate = ((sender as Button).Tag as FoodCategory).Id;
                LoadFoodByCateId(idCate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            flagClickTable = true;
            try
            {
                bills = new List<FoodInBillDTO>();
                table = ((sender as Button).Tag as TableOr);
                if (table.Status.ToLower().Equals("có người"))
                {
                    flagUpdate = true;
                    bill = billRepository.GetBillByIdTable(table.Id);
                    List<BillDetail> billDetails = billRepository.GetBillDetailsByIdBill(bill.Id);
                    foreach (var item in billDetails)
                    {
                        Food food = foodRepository.GetFoodInfoById(item.IdFood);
                        int id = item.IdFood;
                        string name = food.Name;
                        double price = (double)food.Price;
                        string size = food.Size;
                        int quality = (int)item.Quality;
                        double cost = (double)food.Price * (int)item.Quality;
                        AddProductToBill(new FoodInBillDTO(id, name, price, size, quality, cost));
                    }
                    LoadBillToDatagridViewBill();
                }
                else
                {
                    txt_TotalPrice.Clear();
                    flagUpdate = false;
                    dgv_Bill.DataSource = null;
                }
                txt_Table.Text = table.Name;
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


        private void button2_Click(object sender, EventArgs e)
        {
            if(bills.Count <= 0)
            {
                this.Close();
            }
            else
            {
                if (MessageBox.Show("Có hóa đơn đang được tạo. Bạn vẫn muốn thoát?", "THÔNG BÁO!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    this.Close();
                }
            }
        }

        private void lv_Food_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (!flagClickTable)
                {
                    MessageBox.Show("Bạn cần chọn bàn trước khi tạo hóa đơn.", "THÔNG BÁO!", MessageBoxButtons.OK);
                }
                else
                {
                    
                    string idStr = lv_Food.SelectedItems[0].SubItems[3].Text;
                    int id = int.Parse(idStr);
                    string priceStr = lv_Food.SelectedItems[0].SubItems[4].Text;
                    double price = Convert.ToDouble(priceStr);
                    string size = lv_Food.SelectedItems[0].SubItems[5].Text;
                    string name = lv_Food.SelectedItems[0].SubItems[0].Text;
                    AddProductToBill(new FoodInBillDTO(id, name, price, size, 1, price));
                    LoadBillToDatagridViewBill();
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void dgv_Bill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            try
            {
                if (e.ColumnIndex == 8)
                {
                    bills.RemoveAt(e.RowIndex);
                    CalculateCost();
                    LoadBillToDatagridViewBill();
                }
                if (e.ColumnIndex == 6)
                {
                    if (bills[e.RowIndex].Quality > 0)
                    {
                        bills[e.RowIndex].Quality--;
                        bills[e.RowIndex].Cost = bills[e.RowIndex].Quality * bills[e.RowIndex].Price;
                        if (bills[e.RowIndex].Quality == 0) bills.RemoveAt(e.RowIndex);
                    }
                    CalculateCost();
                    LoadBillToDatagridViewBill();
                }
                if (e.ColumnIndex == 5)
                {
                    bills[e.RowIndex].Quality++;
                    bills[e.RowIndex].Cost = bills[e.RowIndex].Quality * bills[e.RowIndex].Price;
                    CalculateCost();
                    LoadBillToDatagridViewBill();
                }
            }
            catch (Exception)
            {
                return;
            }           
        }

        private void btn_Pay_Click(object sender, EventArgs e)
        {
            try
            {
                if (bills.Count > 0)
                {
                    frmBill frmbill = new frmBill(bills, table, account.IdEmployee,bill,flagUpdate);
                    frmbill.ShowDialog();
                    if (frmbill.flagAction)
                    {
                        bills = new List<FoodInBillDTO>();
                        dgv_Bill.DataSource = null;
                        loadTable();
                        txt_Table.Clear();
                        txt_TotalPrice.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Chưa có sản phẩm trong hóa đơn", "THÔNG BÁO!", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lv_Food_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_TT_Click(object sender, EventArgs e)
        {            
            try
            {
                if (flagUpdate)
                {
                    if (MessageBox.Show("Bạn muốn cập nhật sản phẩm cho bàn " + table.Name, "THÔNG BÁO!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        billRepository.DeleteBillDetailByIdBill(bill.Id);
                        billRepository.InsertBillDetailById(bills, bill.Id);
                        bills = new List<FoodInBillDTO>();
                        dgv_Bill.DataSource = null;
                        loadTable();
                        txt_Table.Clear();
                        txt_TotalPrice.Clear();
                        flagUpdate = false;
                    }  
                }
                else
                {
                    if (bills.Count > 0)
                    {
                        if (MessageBox.Show("Bạn muốn tạo hóa đơn cho " + table.Name, "THÔNG BÁO!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            billRepository.InsertBillAndBillDetail(bills, false, account.IdEmployee, table);
                            bills = new List<FoodInBillDTO>();
                            dgv_Bill.DataSource = null;
                            loadTable();
                            txt_Table.Clear();
                            txt_TotalPrice.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa có sản phẩm trong hóa đơn", "THÔNG BÁO!", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        
    }
}
