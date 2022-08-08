using Coffee_Management_Software.DAO;
using Coffee_Management_Software.DTO;
using Coffee_Management_Software.Models;
using Coffee_Management_Software.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Management_Software.Repository.impl
{
    class EmployeeRepository : IEmployeeRepository
    {
        public bool CheckEmpExistByID(int id) => EmployeeDAO.Instance.CheckEmpExistByID(id);

        public int CountTotalRecordEmp() => EmployeeDAO.Instance.CountTotalRecordEmp();
        public void DeleteEmployeeAndAccount(Employee employee) => EmployeeDAO.Instance.DeleteEmployeeAndAccount(employee);

        public Account GetAccountByIdEmployee(int id) => EmployeeDAO.Instance.GetAccountByIdEmployee(id);

        public Account GetAccountByUserNameAndPassword(string username, string password) => EmployeeDAO.Instance.GetAccountByUserNameAndPassword(username, password);

        public Employee GetEmployeeById(int id) => EmployeeDAO.Instance.GetEmployeeById(id);

        public int GetEmployeeIdLast() => EmployeeDAO.Instance.GetEmployeeIdLast();

        public List<EmployeeDTO> GetEmployeeInfro(int page, int recordNum) => EmployeeDAO.Instance.GetEmployeeInfro(page, recordNum);

        public void InsertAccount(Account account) => EmployeeDAO.Instance.InsertAccount(account);

        public void InsertEmployee(Employee employee) => EmployeeDAO.Instance.InsertEmployee(employee);

        public void ResetPasswordByUserName(string username, string password) => EmployeeDAO.Instance.ResetPasswordByUserName(username, password);

        public void UpdateEmployeeAndAccount(Employee employee, Account account) => EmployeeDAO.Instance.UpdateEmployeeAndAccount(employee, account);
    }
}
