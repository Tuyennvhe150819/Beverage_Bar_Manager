using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coffee_Management_Software.DTO;
using Coffee_Management_Software.Models;

namespace Coffee_Management_Software.Repository
{
    interface IEmployeeRepository
    {
        List<EmployeeDTO> GetEmployeeInfro(int page, int recordNum);
        public int CountTotalRecordEmp();
        void ResetPasswordByUserName(string username, string password);
        public void DeleteEmployeeAndAccount(Employee employee);
        Employee GetEmployeeById(int id);
        void InsertEmployee(Employee employee);
        int GetEmployeeIdLast();
        void UpdateEmployeeAndAccount(Employee employee, Account account);
        void InsertAccount(Account account);
        Account GetAccountByIdEmployee(int id);

        Account GetAccountByUserNameAndPassword(string username, string password);

        bool CheckEmpExistByID(int id);


    }
}
