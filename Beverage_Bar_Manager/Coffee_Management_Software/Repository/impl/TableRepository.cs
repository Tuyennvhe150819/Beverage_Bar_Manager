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
    class TableRepository : ITableRepository
    {
        public bool CheckTableExist(int id) => TableDAO.Instance.CheckTableExist(id);

        public int CountTotalRecordTable() => TableDAO.Instance.CountTotalRecordTable();

        public void DeleteTable(TableOr table) => TableDAO.Instance.DeleteTable(table);

        public List<TableDTO> GetAllTable(int page, int recordNum) => TableDAO.Instance.GetAllTable(page, recordNum);

        public List<TableOr> GetAllTableToSale() => TableDAO.Instance.GetAllTableToSale();

        public TableOr GetTableInfoById(int id) => TableDAO.Instance.GetTableInfoById(id);

        public void InsertTable(TableOr table) => TableDAO.Instance.InsertTable(table);

        public void UpdateTable(TableOr table) => TableDAO.Instance.UpdateTable(table);
    }
}
