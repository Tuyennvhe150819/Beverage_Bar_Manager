using Coffee_Management_Software.DTO;
using Coffee_Management_Software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_Management_Software.DAO
{
    class EmployeeDAO
    {
        private static EmployeeDAO instance = null;
        private static readonly object instanceLock = new object();
        private EmployeeDAO() { }
        public static EmployeeDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new EmployeeDAO();
                    }
                    return instance;
                }
            }
        }
        public List<EmployeeDTO> GetEmployeeInfro(int page, int recordNum)
        {
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                var employees = (from emp in db.Employees
                          join acc in db.Accounts
                          on emp.Id equals acc.IdEmployee
                          join s in db.Shifts
                          on emp.IdShift equals s.Id
                          select new EmployeeDTO
                          {
                              IdEmp = emp.Id,
                              NameEmp = emp.Name,
                              Phone = emp.Phone,
                              Address = emp.Address,
                              Cmt = emp.Cmt,
                              Role = acc.Role.ToLower().Equals("manager")?"Quản lý":"Nhân viên",
                              Status =(bool) acc.Status? "Đã được mở khóa" : "Đã khóa",
                              Username = acc.Username,
                              Gender = emp.Gender.ToLower().Equals("male")? "Nam":"Nữ",
                              Shi = s.Title,
                              Salary =double.Parse(emp.Salary.ToString()),
                              Image = emp.Photo,
                              Dob = (DateTime)emp.Dob
                            }).OrderBy(e => e.IdEmp).Skip((page - 1) * recordNum).Take(recordNum).ToList();
                return employees;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public int CountTotalRecordEmp()
        {
            int count = 0 ;
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                count = db.Employees.Count();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return count;
        }
        public void ResetPasswordByUserName(string username, string password)
        {
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                var account = db.Accounts.Where(e => e.Username.Equals(username)).FirstOrDefault();
                account.Password = password;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteEmployeeAndAccount (Employee employee)
        {
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                var emp = db.Employees.SingleOrDefault(e => e.Id == employee.Id);
                var acc = db.Accounts.SingleOrDefault(a => a.IdEmployee == employee.Id);
                db.Accounts.Remove(acc);
                db.Employees.Remove(emp);               
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Employee GetEmployeeById(int id)
        {
            Employee employee;
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                employee = db.Employees.Where(e => e.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return employee;
        }

        public void InsertEmployee(Employee employee)
        {
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int GetEmployeeIdLast()
        {
            int index;
            try
            {
                using Management_PRN211 db = new Management_PRN211();               
                index = int.Parse(db.Employees
                            .OrderByDescending(e => e.Id)
                            .Select(e => e.Id)
                            .First().ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return index;
        }
        public void UpdateEmployeeAndAccount(Employee employee, Account account)
        {
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                db.Entry<Employee>(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.Entry<Account>(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool CheckEmpExistByID(int id)
        {
            bool flag = false;
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                int count = db.Attendances.Where(a => a.IdEmployee.Equals(id)).Count();
                if(count <= 0)
                {
                    flag = true;
                }
                else
                {
                    int count1 = db.Bills.Where(b => b.IdEmployee.Equals(id)).Count();
                    if (count1 <= 0)
                    {
                        flag = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return flag;
        }
        #region Account
        public void InsertAccount(Account account)
        {
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                db.Accounts.Add(account);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Account GetAccountByIdEmployee(int id)
        {
            Account account;
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                account = db.Accounts.Where(a => a.IdEmployee == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }
        public Account GetAccountByUserNameAndPassword(string username, string password)
        {
           Account account;
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                account = db.Accounts.Where(a => a.Username.ToLower().Equals(username) && a.Password.Equals(password)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return account;
        }
        #endregion

    }
}
