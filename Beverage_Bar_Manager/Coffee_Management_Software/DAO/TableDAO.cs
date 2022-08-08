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
    class TableDAO
    {
        private static TableDAO instance = null;
        private static readonly object instanceLock = new object();
        private TableDAO() { }
        public static TableDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TableDAO();
                    }
                    return instance;
                }
            }
        }
        public List<TableDTO> GetAllTable(int page, int recordNum)
        {
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                var tables = (from t in db.TableOrs
                              select new TableDTO
                              {
                                  IdTable = t.Id,
                                  NameTable = t.Name,
                                  Status = t.Status,
                              }).Skip((page - 1) * recordNum).Take(recordNum).ToList();
                return tables;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TableOr GetTableInfoById(int id)
        {
            TableOr table;
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                table = db.TableOrs.Where(t => t.Id == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return table;
        }

        public void InsertTable(TableOr table)
        {
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                db.TableOrs.Add(table);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateTable(TableOr table)
        {
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                db.Entry<TableOr>(table).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteTable(TableOr table)
        {
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                var tab = db.TableOrs.SingleOrDefault(t => t.Id == table.Id);
                db.TableOrs.Remove(tab);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int CountTotalRecordTable()
        {
            int count = 0;
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                count = db.TableOrs.Count();              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return count;
        }
        public List<TableOr> GetAllTableToSale()
        {
            List<TableOr> tables;
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                tables = db.TableOrs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tables;
        }
        public bool CheckTableExist(int id)
        {
            bool flag = false;
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                int count = db.Bills.Where(b => b.IdTable.Equals(id)).Count();
                if(count <= 0)
                {
                    flag = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return flag;
        }
    }
}
