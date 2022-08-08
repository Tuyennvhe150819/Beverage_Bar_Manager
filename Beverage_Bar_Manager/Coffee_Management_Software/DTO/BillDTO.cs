using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Management_Software.DTO
{
    class BillDTO
    {
        private int idBill;
        private double revenue;
        private DateTime dateOfPay;
        private string nameEmp;

        public int IdBill { get => idBill; set => idBill = value; }
        public double Revenue { get => revenue; set => revenue = value; }
        public DateTime DateOfPay { get => dateOfPay; set => dateOfPay = value; }
        public string NameEmp { get => nameEmp; set => nameEmp = value; }

        public BillDTO(int idBill, double revenue, DateTime dateOfPay, string nameEmp)
        {
            this.IdBill = idBill;
            this.Revenue = revenue;
            this.DateOfPay = dateOfPay;
            this.NameEmp = nameEmp;
        }

        public BillDTO()
        {
        }
    }
}
