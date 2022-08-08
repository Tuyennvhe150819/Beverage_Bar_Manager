using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Management_Software.DTO
{
    class EmployeeDTO
    {
        private int idEmp;
        private string nameEmp;
        private string phone;
        private string address;
        private string cmt;
        private string role;
        private string status;
        private string username;
        private string gender;
        private string shi;
        private double? salary;
        private string image;
        private DateTime dob;

        public int IdEmp { get => idEmp; set => idEmp = value; }
        public string NameEmp { get => nameEmp; set => nameEmp = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string Cmt { get => cmt; set => cmt = value; }
        public string Role { get => role; set => role = value; }
        public string Status { get => status; set => status = value; }
        public string Username { get => username; set => username = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Shi { get => shi; set => shi = value; }
        public double? Salary { get => salary; set => salary = value; }
        public string Image { get => image; set => image = value; }
        public DateTime Dob { get => dob; set => dob = value; }

        public EmployeeDTO(int idEmp, string nameEmp, string phone, string address, string cmt, string role, string status, string username, string gender, string shi, double? salary, string image, DateTime dob)
        {
            this.idEmp = idEmp;
            this.nameEmp = nameEmp;
            this.phone = phone;
            this.address = address;
            this.cmt = cmt;
            this.role = role;
            this.status = status;
            this.username = username;
            this.gender = gender;
            this.shi = shi;
            this.salary = salary;
            this.image = image;
            this.dob = dob;
        }

        public EmployeeDTO()
        {
        }
    }
}
