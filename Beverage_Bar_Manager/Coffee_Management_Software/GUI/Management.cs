using Coffee_Management_Software.FunctionCheckAndConvert;
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
using Coffee_Management_Software.Models;
using Coffee_Management_Software.DAO;
using Coffee_Management_Software.DTO;
using Coffee_Management_Software.Repository;
using Coffee_Management_Software.Repository.impl;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace Coffee_Management_Software.GUI
{
    public partial class Management : Form
    {
        FCV fcv = new FCV();
        IFoodRepository foodRepository = new FoodRepository();
        ITableRepository tableRepository = new TableRepository();
        ICategoryRepository categoryRepository = new CategoryRepository();
        IAttendanceRepository attendanceRepository = new AttendanceRepository();
        IEmployeeRepository employeeRepository = new EmployeeRepository();
        IBillRepository billRepository = new BillRepository();
        string pathAvt = "Image/user.png";
        int pageNumber = 1;
        int numberRecord = 20;
        List<BillDTO> billList;
        public Management()
        {
            InitializeComponent();
        }
        Account a;
        public Management(Account a)
        {
            this.a = a;
            InitializeComponent();
        }
        private void Management_Load(object sender, EventArgs e)
        {
            #region Food            
            LoadDataToDataGridviewFood(foodRepository.GetListFoodInfoByAll(flagSearch, idCate,nameFood,pageNumber,numberRecord));
            LoadDataToDataGridviewCate(categoryRepository.GetCategories());
            LoadDataToDataGridviewTable(tableRepository.GetAllTable(pageNumber, numberRecord));
            LoadDataToDataGridviewEmployee(employeeRepository.GetEmployeeInfro(pageNumber, numberRecord));
            LoadDataToComboBoxFoodCate(cbx_Cate);
            LoadDataToComboBoxFoodCate(cbx_CateSearch);
            LoadDataToComboBoxShift(cbx_Shift);
            billList = billRepository.GetBillShow();
            LoadDataToDgvBill(billList);
            ClearTextFood();
            #endregion
        }

        #region MethodEmployee
        Employee employee = new Employee();
        Account account = new Account();
        Shift shift = new Shift();
        int idE = 0;
        bool flagAddEmp = true;
        public bool EmployeeValidForm()
        {
            bool flag = true;
            string strError = "";
            if (txt_Account.Text.Trim().Equals("") || txt_EmpName.Text.Trim().Equals("") ||txt_EmpCmt.Text.Trim().Equals("") ||
                txt_Address.Text.Trim().Equals("") || num_Salary.Value == 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin !");
                return false;
            }
            Regex regEmName = new Regex(@"[a-zA-Z\s]+$");
            if (!regEmName.IsMatch(txt_EmpName.Text.Trim()))
            {
                flag = false;
                strError += "Họ và tên: Không thể chưa số hoặc ký tự đặc biệt.\n";
                txt_EmpName.Focus();
            }
            if (!flag)
            {
                MessageBox.Show(strError);
            }
            return flag;
        }
       
        void Clear()
        {
            txt_EmpId.Clear();
            txt_Account.Clear();
            txt_EmpName.Clear();
            rad_RoleEmp.Checked = true;
            rad_Unlock.Checked = true;
            txt_EmpCmt.Clear();
            txt_Phone.Clear();
            txt_Address.Clear();
            //cbx_Shift.SelectedIndex = 0;
            num_Salary.Value = 0;
            txt_TotalSalary.Clear();
            date_Dob.Value = DateTime.Today;
            txt_Account.ReadOnly = false;
            btn_ResetPassword.Enabled = false;
            btn_DeleteEmp.Enabled = false;
            Image img = Image.FromFile("Image/user.png");
            pb_AvtEmp.Image = img;
        }
        void LoadDataToDataGridviewEmployee(List<EmployeeDTO> employees)
        {
            dtg_Emp.DataSource = null;
            DataGridViewTextBoxColumn empId = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(empId, 50, "IdEmp", "Mã");
            DataGridViewTextBoxColumn empName = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(empName, 150, "NameEmp", "Họ và tên");
            DataGridViewTextBoxColumn username = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(username, 100, "Username", "Tài khoản");
            DataGridViewTextBoxColumn dob = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(dob, 100, "Dob", "Ngày sinh");
            DataGridViewTextBoxColumn gender = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(gender, 100, "Gender", "Giới tính");
            DataGridViewTextBoxColumn phone = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(phone, 120, "Phone", "Số điện thoại");
            DataGridViewTextBoxColumn address = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(address, 200, "Address", "Địa chỉ");
            DataGridViewTextBoxColumn cmt = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(cmt, 120, "Cmt", "CMT"); 
            DataGridViewTextBoxColumn shi = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(shi, 100, "Shi", "Ca làm");
            DataGridViewTextBoxColumn slary = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(slary, 130, "Salary", "Lương 1 giờ");
            DataGridViewTextBoxColumn role = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(role, 150, "Role", "Chức vụ");
            DataGridViewTextBoxColumn status = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(status, 150, "Status", "Trạng thái");
            DataGridViewTextBoxColumn img = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(img, 0, "Image", "Trạng thái");
            dtg_Emp.Columns.Add(empId);
            dtg_Emp.Columns.Add(empName);
            dtg_Emp.Columns.Add(username);
            dtg_Emp.Columns.Add(dob);
            dtg_Emp.Columns.Add(gender);
            dtg_Emp.Columns.Add(phone);
            dtg_Emp.Columns.Add(address);
            dtg_Emp.Columns.Add(cmt);
            dtg_Emp.Columns.Add(shi);
            dtg_Emp.Columns.Add(slary);
            dtg_Emp.Columns.Add(role);
            dtg_Emp.Columns.Add(status);
            dtg_Emp.Columns.Add(img);
            dtg_Emp.Columns[12].Visible = false;
            dtg_Emp.DataSource = employees.ToList();
        }

        void LoadDataToComboBoxShift(ComboBox comboBox)
        {
            try
            {
                List<Shift> shifts = attendanceRepository.GetShiftInfo();
                comboBox.DataSource = shifts;
                comboBox.DisplayMember = "Title";
                comboBox.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            
        }
        #endregion

        #region ActionEmployee
        private void btn_Avt_Click(object sender, EventArgs e)
        {
            pathAvt = fcv.LoadImageToPic(pb_AvtEmp);
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            flagAddEmp = true;
            fcv.ChangeTextButton(btn_AddEmp, btn_DeleteEmp, flagAddEmp);
            Clear(); 
        }

        private void btn_ExitEmp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Thao tác này sẽ đặt lại mật khẩu của tài khoản "+account.Username,"THÔNG BÁO!",MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    employeeRepository.ResetPasswordByUserName(account.Username,"12345678");
                }                               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        // xoa san pham
        private void btn_DeleteEmp_Click(object sender, EventArgs e)
        {
            try
            {
                bool flagCheckEmpExist = employeeRepository.CheckEmpExistByID(employee.Id);
                if (flagCheckEmpExist)
                {
                    frmAcceptDelete acceptDelete = new frmAcceptDelete(a);
                    acceptDelete.ShowDialog();
                    if (acceptDelete.checkpass)
                    {
                        employeeRepository.DeleteEmployeeAndAccount(employee);
                        LoadDataToDataGridviewEmployee(employeeRepository.GetEmployeeInfro(pageNumber, numberRecord));
                        flagAddEmp = true;
                        fcv.ChangeTextButton(btn_AddEmp, btn_DeleteEmp, flagAddEmp);
                        Clear();
                    }
                }
                else
                {
                    MessageBox.Show($"Không thể xóa nhân viên {employee.Name} khỏi hệ thống.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btn_AddEmp_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (EmployeeValidForm())
                {
                    if (flagAddEmp)
                    {
                        employee = new Employee();
                        account = new Account();
                    }
                    employee.Name = txt_EmpName.Text.Trim();
                    employee.Address = txt_Address.Text.Trim();
                    employee.Dob = date_Dob.Value;
                    employee.Photo = pathAvt;
                    employee.Phone = txt_Phone.Text.Trim();
                    employee.Salary = num_Salary.Value;
                    employee.DateJoin = DateTime.Today;
                    employee.Gender = rad_Male.Checked ? "Male" : "Female";
                    employee.Cmt = txt_EmpCmt.Text.Trim();
                    employee.IdShift = (int)cbx_Shift.SelectedValue;
                    account.Username = txt_Account.Text.Trim();
                    account.Role = rad_RoleMana.Checked ? "manager" : "employee";
                    account.Status = rad_Lock.Checked ? false : true;
                    if (flagAddEmp)
                    {   
                        
                        employeeRepository.InsertEmployee(employee);
                        account.IdEmployee = employeeRepository.GetEmployeeIdLast();
                        account.Password = "12345678";
                        employeeRepository.InsertAccount(account);
                    }
                    else
                    {
                        employeeRepository.UpdateEmployeeAndAccount(employee, account);
                        flagAddEmp = true;
                    }
                    Clear();
                    LoadDataToDataGridviewEmployee(employeeRepository.GetEmployeeInfro(pageNumber, numberRecord));
                    fcv.ChangeTextButton(btn_AddEmp, btn_DeleteEmp, flagAddEmp);
                    btn_ResetPassword.Enabled = false;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }           
        }

        bool checkDOB(int dob)
        {
            int yearNOw = DateTime.Now.Year;
            if (yearNOw - dob < 16)
            {
                MessageBox.Show("Bạn Phải trên 15 tuổi mới được đi làm !");
                return false;
            }
            return true;


        }

        private void dtg_Emp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                flagAddEmp = false;
                fcv.ChangeTextButton(btn_AddEmp, btn_DeleteEmp, flagAddEmp);
                if (e.RowIndex == -1) return;
                DataGridViewRow row = dtg_Emp.Rows[e.RowIndex];
                idE = int.Parse(row.Cells[0].Value.ToString());
                employee =  employeeRepository.GetEmployeeById(idE);
                account = employeeRepository.GetAccountByIdEmployee(idE);
                shift = attendanceRepository.GetShiftByID((int)employee.IdShift);
                txt_EmpId.Text = employee.Id.ToString();
                txt_Account.Text = account.Username;
                txt_EmpName.Text = employee.Name;
                if (account.Role.ToLower().Equals("employee")) rad_RoleEmp.Checked = true;
                else rad_RoleMana.Checked = true;
                if (!(bool)account.Status) rad_Lock.Checked = true;
                else rad_Unlock.Checked = true;
                if (employee.Gender.ToLower().Equals("nam")) rad_Male.Checked = true;
                else rad_Female.Checked = true;
                txt_EmpCmt.Text = employee.Cmt;
                txt_Phone.Text = employee.Phone;
                txt_Address.Text = employee.Address;
                num_Salary.Value = (decimal)employee.Salary;
                cbx_Shift.SelectedValue = employee.IdShift;
                date_Dob.Value = (DateTime)employee.Dob;
                pathAvt = employee.Photo;
                Image img = Image.FromFile(pathAvt);
                pb_AvtEmp.Image = img;
                btn_ResetPassword.Enabled = true;
                btn_DeleteEmp.Enabled = true;
                txt_Account.ReadOnly = true;
                int count = attendanceRepository.CountAttendByIdEmpAndMonht(idE);
                int totalTimes = (int)shift.Time * count;
                float toTalSlary = (float)(totalTimes * employee.Salary);
                txt_TotalSalary.Text = fcv.FormatNumber(toTalSlary);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void num_PageEmp_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                int totalRecord = employeeRepository.CountTotalRecordEmp();
                int max = totalRecord % numberRecord == 0 ? (totalRecord / numberRecord) : (totalRecord / numberRecord) + 1;
                num_PageEmp.Maximum = max;
                pageNumber = (int)num_PageEmp.Value;
                LoadDataToDataGridviewEmployee(employeeRepository.GetEmployeeInfro(pageNumber, numberRecord));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        #endregion

        #region Food
        #region MethodFood
        int idF = 0;
        bool flagAddFood = true;
        Food food = new Food();
        int flagSearch = 0;
        int idCate = 0;
        string nameFood = "";
        string pathFood = "";

        void LoadDataToComboBoxFoodCate(ComboBox comboBox)
        {
            List<CategoryDTO> listCates = categoryRepository.GetCategories().Where(f => f.StatusCate.Equals("Đang hoạt động")).ToList();
            comboBox.DataSource = listCates;
            comboBox.DisplayMember = "NameCate";
            comboBox.ValueMember = "IdCate";

        }
        void ClearTextFood()
        {
            txt_IDFood.Clear();
            txt_NameFood.Clear();
            txt_Price.Value = 0;
            cbx_Cate.SelectedIndex = 0;
            cbx_Size.SelectedIndex = 0;
            rad_Active.Checked = true;
            txt_Description.Clear();
            Image img = Image.FromFile("Image/food.png");
            pic_Food.Image = img;
        }
        void SetDGVTextColumn (DataGridViewTextBoxColumn tb,int w, string dName, string hText)
        {
            tb.Width = w;
            tb.DataPropertyName = dName;
            tb.HeaderText = hText;
        }
        void LoadDataToDataGridviewFood(List<FoodDTO> foods)
        {            
            dgv_Food.DataSource = null;
            DataGridViewTextBoxColumn foodId = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(foodId, 50, "IDFood", "Mã");
            DataGridViewTextBoxColumn foodName = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(foodName, 200, "NameFood", "Tên sản phẩm");
            DataGridViewTextBoxColumn cateName = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(cateName, 120, "NameCate", "Loại sản phẩm");
            DataGridViewTextBoxColumn foodSize = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(foodSize, 50, "Size", "Size");
            DataGridViewTextBoxColumn foodPrice = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(foodPrice, 150, "Price", "Đơn giá");
            DataGridViewTextBoxColumn foodDes = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(foodDes, 400, "Description", "Miêu tả");
            DataGridViewTextBoxColumn foodStatus = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(foodStatus, 150, "Status", "Trạng thái");
            DataGridViewTextBoxColumn idC = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(idC, 0, "IdCate", "");
            dgv_Food.Columns.Add(foodId);
            dgv_Food.Columns.Add(foodName);
            dgv_Food.Columns.Add(cateName);
            dgv_Food.Columns.Add(foodSize);
            dgv_Food.Columns.Add(foodPrice);
            dgv_Food.Columns.Add(foodDes);
            dgv_Food.Columns.Add(foodStatus);
            dgv_Food.Columns.Add(idC);
            dgv_Food.Columns[7].Visible = false;
            dgv_Food.DataSource = foods.ToList();
        }
        void SetMaxNumUpDown()
        {
            int totalRecord = foodRepository.CountTotalRecord(flagSearch, idCate, nameFood);
            int max = totalRecord % numberRecord == 0 ? (totalRecord / numberRecord) : (totalRecord / numberRecord) + 1;
            num_Page.Maximum = max;
            pageNumber = (int)num_Page.Value;
        }
        public bool FoodValidForm()
        {
            if (txt_NameFood.Text.Trim().Equals("") || txt_Description.Text.Trim().Equals("") || txt_Price.Value == 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin !");
                return false;
            }
            return true;
        }
        #endregion

        #region ActionFood
        private void dgv_Food_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            flagAddFood = false;
            fcv.ChangeTextButton(btn_AddFood,btn_DelFood, flagAddFood);
            if (e.RowIndex == -1) return;
            DataGridViewRow row = dgv_Food.Rows[e.RowIndex];
            idF = int.Parse(row.Cells[0].Value.ToString());
            food = foodRepository.GetFoodInfoById(idF);

            txt_IDFood.Text = food.Id.ToString();
            txt_NameFood.Text = food.Name;
            txt_Price.Value = (decimal)food.Price;
            cbx_Cate.SelectedValue = food.IdCatagory;
            cbx_Size.SelectedItem = food.Size.Trim();
            if ((bool)food.Status) rad_Active.Checked = true;
            else rad_NoActive.Checked = true;
            txt_Description.Text = food.Description;
            pathFood = food.Picture;
            Image img = Image.FromFile(pathFood);
            pic_Food.Image = img;            
        }
        private void btn_ResetFood_Click(object sender, EventArgs e)
        {
            flagAddFood = true;
            fcv.ChangeTextButton(btn_AddFood, btn_DelFood, flagAddFood);
            ClearTextFood();
        }
        private void btn_AddFood_Click(object sender, EventArgs e)
        {
            try
            {
                if (FoodValidForm())
                {
                    Food f = new Food();
                    f.Name = txt_NameFood.Text.Trim();
                    f.IdCatagory = (int)cbx_Cate.SelectedValue;
                    f.Price = txt_Price.Value;
                    f.Size = cbx_Size.SelectedItem.ToString();
                    f.Description = txt_Description.Text.Trim();
                    f.Picture = pathFood;
                    f.Status = (rad_Active.Checked ? true : false);
                    if (flagAddFood)
                    {
                        foodRepository.InsertFoodInfo(f);
                    }
                    else
                    {
                        f.Id = idF;
                        foodRepository.UpdateFoodInfo(f);
                        flagAddFood = true;
                    }
                    ClearTextFood();
                    flagSearch = 0;
                    LoadDataToDataGridviewFood(foodRepository.GetListFoodInfoByAll(flagSearch, idCate, nameFood, pageNumber, numberRecord));
                    fcv.ChangeTextButton(btn_AddFood, btn_DelFood, flagAddFood);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }            
           
        }
        private void btn_DelFood_Click(object sender, EventArgs e)
        {
            try
            {
                bool flagFood = foodRepository.CheckFoodEx(food.Id);
                if (flagFood)
                {
                    frmAcceptDelete acceptDelete = new frmAcceptDelete(a);
                    acceptDelete.ShowDialog();
                    if (acceptDelete.checkpass)
                    {
                        foodRepository.DeleteFoodInfo(food);
                        LoadDataToDataGridviewFood(foodRepository.GetListFoodInfoByAll(flagSearch, idCate, nameFood, pageNumber, numberRecord));
                        flagAddFood = true;
                        fcv.ChangeTextButton(btn_AddFood, btn_DelFood, flagAddFood);
                        ClearTextFood();
                    }
                }
                else
                {
                    MessageBox.Show($"Không thể xóa sản phẩm {food.Name} khỏi hệ thống");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void cbx_CateSearch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idCate = (int)cbx_CateSearch.SelectedValue;
            try
            {
                flagSearch = 1;
                SetMaxNumUpDown();
                LoadDataToDataGridviewFood(foodRepository.GetListFoodInfoByAll(flagSearch, idCate, nameFood, pageNumber, numberRecord));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                flagSearch = 2;
                nameFood = txt_SearchFood.Text.Trim();
                SetMaxNumUpDown();
                LoadDataToDataGridviewFood(foodRepository.GetListFoodInfoByAll(flagSearch, idCate, nameFood, pageNumber, numberRecord));
            }
             catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btn_LoadImaneFood_Click(object sender, EventArgs e)
        {
            pathFood = fcv.LoadImageToPic(pic_Food);
        }
        private void num_Page_ValueChanged(object sender, EventArgs e)
        {
            
            try
            {
                SetMaxNumUpDown();
                LoadDataToDataGridviewFood(foodRepository.GetListFoodInfoByAll(flagSearch, idCate, nameFood, pageNumber, numberRecord));
            }
             catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void btn_ExitFood_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #endregion

        #region Category
        #region MethodCate
        int idC = 0;
        bool flagAddCate = true;
        FoodCategory category = new FoodCategory();
        public bool LSPValidForm()
        {
            if (txt_NameCate.Text.Trim().Equals("") || txt_DesCate.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin !");
                return false;
            }
            return true;
        }
        void LoadDataToDataGridviewCate(List<CategoryDTO> cates)
        {
            dgv_Cate.DataSource = null;
            DataGridViewTextBoxColumn cateId = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(cateId, 50, "IDCate", "Mã");
            DataGridViewTextBoxColumn CateName = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(CateName, 200, "NameCate", "Tên loại sản phẩm");
            DataGridViewTextBoxColumn cateDes = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(cateDes, 400, "DesCate", "Miêu tả");
            DataGridViewTextBoxColumn cateStatus = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(cateStatus, 150, "StatusCate", "Trạng thái");
            dgv_Cate.Columns.Add(cateId);
            dgv_Cate.Columns.Add(CateName);
            dgv_Cate.Columns.Add(cateDes);
            dgv_Cate.Columns.Add(cateStatus);
            dgv_Cate.DataSource = cates.ToList();
        }

        void ClearTextCate()
        {
            txt_IDCate.Clear();
            txt_NameCate.Clear();
            txt_DesCate.Clear();
            rad_ActiveCate.Checked = true;
        }
        #endregion
        #region ActionCate
        private void btn_ExitCate_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_AddCate_Click(object sender, EventArgs e)
        {
            try
            {
                if (LSPValidForm())
                {
                    FoodCategory cate = new FoodCategory();
                    cate.Name = txt_NameCate.Text.Trim();
                    cate.Description = txt_DesCate.Text.Trim();
                    cate.Status = rad_ActiveCate.Checked ? true : false;
                    if (flagAddCate)
                    {
                        categoryRepository.InsertCate(cate);
                    }
                    else
                    {
                        cate.Id = idC;
                        categoryRepository.UpdateCate(cate);
                        flagAddCate = true;
                    }
                    ClearTextCate();
                    LoadDataToDataGridviewCate(categoryRepository.GetCategories());
                    LoadDataToComboBoxFoodCate(cbx_Cate);
                    LoadDataToComboBoxFoodCate(cbx_CateSearch);
                    fcv.ChangeTextButton(btn_AddCate, btn_DelateCate, flagAddCate);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }              
        }

        private void btn_DelateCate_Click(object sender, EventArgs e)
        {
            try
            {
                bool flagCate = categoryRepository.CheckCateEx(category.Id);
                if (flagCate)
                {
                    frmAcceptDelete acceptDelete = new frmAcceptDelete(a);
                    acceptDelete.ShowDialog();
                    if (acceptDelete.checkpass)
                    {
                        categoryRepository.DeleteCate(category);
                        LoadDataToDataGridviewCate(categoryRepository.GetCategories());
                        flagAddCate = true;
                        fcv.ChangeTextButton(btn_AddCate, btn_DelateCate, flagAddCate);
                        ClearTextCate();
                    }
                }
                else
                {
                    MessageBox.Show($"Không thể xóa loại sản phẩm {category.Name} khỏi hệ thống");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btn_ResetCate_Click(object sender, EventArgs e)
        {
            flagAddCate = true;
            fcv.ChangeTextButton(btn_AddCate, btn_DelateCate, flagAddCate);
            ClearTextCate();
        }
        private void dgv_Cate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            flagAddCate = false;
            fcv.ChangeTextButton(btn_AddCate, btn_DelateCate, flagAddCate);
            if (e.RowIndex == -1) return;
            DataGridViewRow row = dgv_Cate.Rows[e.RowIndex];
            idC = int.Parse(row.Cells[0].Value.ToString());
            category = categoryRepository.GetCateInfoById(idC);
            txt_IDCate.Text = category.Id.ToString();
            txt_NameCate.Text = category.Name;
            txt_DesCate.Text = category.Description;
            if ((bool)category.Status) rad_ActiveCate.Checked = true;
            else rad_NoActiveCate.Checked = true;

        }


        #endregion

        #endregion


        #region Table
        #region MethodTable
        bool flagAddTable = true;
        TableOr table = new TableOr();
        int idT = 0;
        void LoadDataToDataGridviewTable(List<TableDTO> tabs)
        {
            dgv_Table.DataSource = null;
            DataGridViewTextBoxColumn tableId = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(tableId, 100, "IDTable", "Mã");
            DataGridViewTextBoxColumn tableName = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(tableName, 300, "NameTable", "Tên bàn");
            DataGridViewTextBoxColumn tableStatus = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(tableStatus, 250, "Status", "Trạng thái");
            dgv_Table.Columns.Add(tableId);
            dgv_Table.Columns.Add(tableName);
            dgv_Table.Columns.Add(tableStatus);
            dgv_Table.DataSource = tabs;
        }
        void ClearTextTable()
        {
            txt_IdTable.Clear();
            txt_NameTable.Clear();
        }
        public bool TableValidForm()
        {
            if (txt_NameTable.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin !");
                return false;
            }
            return true;
        }
        #endregion
        #region ActionTable
        private void btn_AddTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (TableValidForm())
                {
                    TableOr t = new TableOr();
                    t.Name = txt_NameTable.Text.Trim();
                    t.Status = "Trống";
                    if (flagAddTable)
                    {
                        tableRepository.InsertTable(t);
                    }
                    else
                    {
                        t.Id = idT;
                        tableRepository.UpdateTable(t);
                        flagAddTable = true;
                    }
                }
                ClearTextTable();
                LoadDataToDataGridviewTable(tableRepository.GetAllTable(pageNumber, numberRecord));
                fcv.ChangeTextButton(btn_AddTable, btn_DelTable, flagAddTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
           
        }

        private void btn_DelTable_Click(object sender, EventArgs e)
        {
            try
            {
                bool flagTableEx = tableRepository.CheckTableExist(table.Id);
                if (flagTableEx)
                {
                    frmAcceptDelete acceptDelete = new frmAcceptDelete(a);
                    acceptDelete.ShowDialog();
                    if (acceptDelete.checkpass)
                    {
                        tableRepository.DeleteTable(table);
                        LoadDataToDataGridviewTable(tableRepository.GetAllTable(pageNumber, numberRecord));
                        flagAddTable = true;
                        fcv.ChangeTextButton(btn_AddTable, btn_DelTable, flagAddTable);
                        ClearTextTable();
                    }
                }
                else
                {
                    MessageBox.Show($"Không thể xóa {table.Name} khỏi hệ thống");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btn_ResetTable_Click(object sender, EventArgs e)
        {
            flagAddTable = true;
            fcv.ChangeTextButton(btn_AddTable, btn_DelTable, flagAddTable);
            ClearTextTable();
        }

        private void btn_ExitTable_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void num_PageTable_ValueChanged(object sender, EventArgs e)
        {
            int totalRecord = tableRepository.CountTotalRecordTable();
            int max = totalRecord % numberRecord == 0 ? (totalRecord / numberRecord) : (totalRecord / numberRecord) + 1;
            num_PageTable.Maximum = max;
            pageNumber = (int)num_PageTable.Value;
            LoadDataToDataGridviewTable(tableRepository.GetAllTable(pageNumber, numberRecord));
        }
        private void dgv_Table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                flagAddTable = false;
                fcv.ChangeTextButton(btn_AddTable, btn_DelTable, flagAddTable);
                if (e.RowIndex == -1) return;
                DataGridViewRow row = dgv_Table.Rows[e.RowIndex];
                idT = int.Parse(row.Cells[0].Value.ToString());
                table = tableRepository.GetTableInfoById(idT);
                txt_IdTable.Text = table.Id.ToString();
                txt_NameTable.Text = table.Name;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        #endregion

        #endregion

        void LoadDataToDgvBill(List<BillDTO> bills)
        {
            dgv_Bill.DataSource = null;
            DataGridViewTextBoxColumn billID = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(billID, 150, "IdBill", "Mã hóa đơn");
            DataGridViewTextBoxColumn revenueBill = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(revenueBill, 200, "Revenue", "Doanh thu bán hàng");
            DataGridViewTextBoxColumn datePay = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(datePay, 300, "DateOfPay", "Ngày thanh toán");
            DataGridViewTextBoxColumn emp = new DataGridViewTextBoxColumn();
            SetDGVTextColumn(emp, 200, "NameEmp", "Nhân viên lập hóa đơn");
            dgv_Bill.Columns.Add(billID);
            dgv_Bill.Columns.Add(revenueBill);
            dgv_Bill.Columns.Add(datePay);
            dgv_Bill.Columns.Add(emp);
            dgv_Bill.DataSource = bills;

        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            string filePath = "";
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel | *.xlsx | excel | *.xls";
            if (dgv_Bill.DataSource==null)
            {
                MessageBox.Show("ko co data");
            }
            if (dgv_Bill.DataSource != null)
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = dialog.FileName;
                }
                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                    return;
                }
                try
                {
                    using (ExcelPackage p = new ExcelPackage())
                    {

                        p.Workbook.Properties.Title = $"Báo cáo thống kê từ {dtp_From.Value.ToShortDateString()} đến {dtp_To.Value.ToShortDateString()}";
                        p.Workbook.Worksheets.Add("Bill Sheet");
                        ExcelWorksheet ws = p.Workbook.Worksheets[0];
                        ws.Name = "Bill Sheet";
                        ws.Cells.Style.Font.Size = 12;
                        ws.Cells.Style.Font.Name = "Calibri";
                        string[] arrColumnHeder =
                        {
                        "Mã hóa đơn",
                        "Doanh thu bán hàng",
                        "Ngày thanh toán",
                        "Nhân viên lập hóa đơn"
                         };
                        var countColHeader = arrColumnHeder.Count();
                        ws.Cells[1, 1].Value = $"Thống kê hóa đơn từ ngày {dtp_From.Value.ToShortDateString()} đến ngày {dtp_To.Value.ToShortDateString()}";
                        ws.Cells[1, 1, 1, countColHeader].Merge = true;
                        ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                        ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        int colIndex = 1;
                        int rowIndex = 2;

                        foreach (var item in arrColumnHeder)
                        {
                            var cell = ws.Cells[rowIndex, colIndex];

                            //set màu thành gray
                            var fill = cell.Style.Fill;
                            fill.PatternType = ExcelFillStyle.Solid;
                            fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                            //căn chỉnh các border
                            var border = cell.Style.Border;
                            border.Bottom.Style =
                                border.Top.Style =
                                border.Left.Style =
                                border.Right.Style = ExcelBorderStyle.Thin;

                            //gán giá trị
                            cell.Value = item;

                            colIndex++;
                        }
                        foreach (var item in billList)
                        {
                            colIndex = 1;
                            rowIndex++;
                            ws.Cells[rowIndex, colIndex++].Value = item.IdBill;
                            ws.Cells[rowIndex, colIndex++].Value = item.Revenue.ToString();
                            ws.Cells[rowIndex, colIndex++].Value = item.DateOfPay.ToString();
                            ws.Cells[rowIndex, colIndex++].Value = item.NameEmp;
                        }
                        Byte[] bin = p.GetAsByteArray();
                        File.WriteAllBytes(filePath, bin);
                    }


                    MessageBox.Show("Xuất excel thành công!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Có lỗi khi lưu file!");
                }
            }
            else
            {
                MessageBox.Show("ko co data");
            }
           
        }

        private void dgv_Bill_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
            try
            {
                if (e.RowIndex == -1) return;
                DataGridViewRow row = dgv_Bill.Rows[e.RowIndex];
                int idB = int.Parse(row.Cells[0].Value.ToString());
                frmBillPrint billPrint = new frmBillPrint(idB);
                billPrint.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void dtp_To_CloseUp(object sender, EventArgs e)
        {
            DateTime dateFrom = dtp_From.Value.Date;
            DateTime dateTo = dtp_To.Value.Date;
            List < BillDTO > list = billList.Where(b => b.DateOfPay >= dateFrom && b.DateOfPay <= dateTo).ToList();
            LoadDataToDgvBill(list);
        }

        private void txt_EmpCmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void dtp_To_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void date_Dob_ValueChanged(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rad_ActiveCate_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rad_Active_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pic_Food_Click(object sender, EventArgs e)
        {

        }

        private void cbx_CateSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void dgv_Food_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_Bill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
