using Coffee_Management_Software.DAO;
using Coffee_Management_Software.DTO;
using Coffee_Management_Software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Management_Software.Repository.impl
{
    class BillRepository : IBillRepository
    {
        public void DeleteBillDetailByIdBill(int idBill) => BillDAO.Instance.DeleteBillDetailByIdBill(idBill);

        public Bill GetBillById(int id) => BillDAO.Instance.GetBillById(id);

        public Bill GetBillByIdTable(int idTable) => BillDAO.Instance.GetBillByIdTable(idTable);

        public List<BillDetail> GetBillDetailsByIdBill(int idB) => BillDAO.Instance.GetBillDetailsByIdBill(idB);

        public List<BillDTO> GetBillShow() => BillDAO.Instance.GetBillShow();

        public void InsertBillAndBillDetail(List<FoodInBillDTO> bills,bool flagPay, int empID, TableOr table) 
            => BillDAO.Instance.InsertBillAndBillDetail(bills,flagPay, empID, table);

        public void InsertBillDetailById(List<FoodInBillDTO> bills, int billID) => BillDAO.Instance.InsertBillDetailById(bills,billID);

        public void UpdateBillStatus(Bill bill) => BillDAO.Instance.UpdateBillStatus(bill);
    }
}
