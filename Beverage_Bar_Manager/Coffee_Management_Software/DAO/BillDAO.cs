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
    class BillDAO
    {
        private static BillDAO instance = null;
        private static readonly object instanceLock = new object();
        private BillDAO() { }
        public static BillDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BillDAO();
                    }
                    return instance;
                }
            }
        }

        public void InsertBillAndBillDetail(List<FoodInBillDTO> bills, bool flagPay, int empID,TableOr table)
        {
            
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                Bill bill = new Bill();
                bill.IdEmployee = empID;
                if (flagPay)
                {
                    bill.IdTable = table.Id;
                    bill.DateCheckIn = bill.DateCheckOut = DateTime.Now;
                    bill.Status = true;
                    
                } 
                else
                {
                    bill.IdTable = table.Id;
                    table.Status = "Có người";
                    db.Entry<TableOr>(table).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    bill.DateCheckIn = DateTime.Now;
                    bill.Status = false;
                }
                db.Bills.Add(bill);
                db.SaveChanges();
                int billID = int.Parse(db.Bills
                        .OrderByDescending(b => b.Id)
                        .Select(b => b.Id)
                        .First().ToString());
                foreach (var item in bills)
                {
                    BillDetail detail = new BillDetail();
                    detail.IdBill = billID;
                    detail.IdFood = item.ProductID;
                    detail.Quality = item.Quality;
                    db.BillDetails.Add(detail);
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertBillDetailById(List<FoodInBillDTO> bills, int billID)
        {         
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                foreach (var item in bills)
                {
                    BillDetail detail = new BillDetail();
                    detail.IdBill = billID;
                    detail.IdFood = item.ProductID;
                    detail.Quality = item.Quality;
                    db.BillDetails.Add(detail);
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Bill GetBillByIdTable(int idTable)
        {
            Bill bill = new Bill();
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                bill = db.Bills.Where(b => b.IdTable.Equals(idTable) && b.Status.Equals(false)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bill;
        }

        public Bill GetBillById(int id)
        {
            Bill bill = new Bill();
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                bill = db.Bills.Where(b => b.Id.Equals(id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bill;
        }

        public List<BillDetail> GetBillDetailsByIdBill(int idB)
        {
            List<BillDetail> billDetails = new List<BillDetail>();
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                billDetails = db.BillDetails.Where(b => b.IdBill.Equals(idB)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return billDetails;
        }

        public void DeleteBillDetailByIdBill(int idBill)
        {
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                db.BillDetails.RemoveRange(db.BillDetails.Where(b => b.IdBill.Equals(idBill)));
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateBillStatus(Bill bill)
        {
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                db.Entry<Bill>(bill).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
        public List<BillDTO> GetBillShow()
        {
            List<BillDTO> bills = new List<BillDTO>();
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                var bils = (from b in db.Bills
                             join bd in db.BillDetails
                             on b.Id equals bd.IdBill
                             join e in db.Employees
                             on b.IdEmployee equals e.Id
                             join f in db.Foods
                             on bd.IdFood equals f.Id
                             where b.Status == true
                             select new
                             {
                                 idBill = b.Id,
                                 revenue = bd.Quality * f.Price,
                                 dateOfPay = b.DateCheckOut,
                                 nameEmp = e.Name
                             }).ToList();
                var bi = (from b in bils
                          group b by (b.idBill, b.nameEmp, b.dateOfPay)
                          into g
                          select new
                          {
                              Id = g.Key.idBill,
                              Re = g.Sum(item => item.revenue),
                              DatePay = g.Key.dateOfPay,
                              Name = g.Key.nameEmp
                          }).ToList();
                for(int i =0; i < bi.Count; i++)
                {                   
                    int id = bi[i].Id;
                    double re = (double)bi[i].Re;
                    DateTime date = (DateTime)bi[i].DatePay;
                    string name = bi[i].Name;
                    BillDTO bill = new BillDTO(id,re,date,name);
                    bills.Add(bill);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bills;
        }
    }
}
