using Coffee_Management_Software.DTO;
using Coffee_Management_Software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Management_Software.Repository
{
    interface ITableRepository
    {
        List<TableDTO> GetAllTable(int page, int recordNum);
        List<TableOr> GetAllTableToSale();
        TableOr GetTableInfoById(int id);
        void InsertTable(TableOr table);
        void UpdateTable(TableOr table);
        void DeleteTable(TableOr table);
        int CountTotalRecordTable();
        bool CheckTableExist(int id);
    }
}
