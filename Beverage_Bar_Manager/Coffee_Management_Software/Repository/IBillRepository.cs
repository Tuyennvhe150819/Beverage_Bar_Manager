using Coffee_Management_Software.DTO;
using Coffee_Management_Software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Management_Software.Repository
{
    interface IBillRepository
    {
        void InsertBillAndBillDetail(List<FoodInBillDTO> bills,bool flagPay, int empID, TableOr table);
        Bill GetBillByIdTable(int idTable);
        List<BillDetail> GetBillDetailsByIdBill(int idB);
        void UpdateBillStatus(Bill bill);
        void InsertBillDetailById(List<FoodInBillDTO> bills, int billID);
        void DeleteBillDetailByIdBill(int idBill);
        Bill GetBillById(int id);
        List<BillDTO> GetBillShow();

    }
}
