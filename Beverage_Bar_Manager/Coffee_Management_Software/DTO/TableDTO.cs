using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Management_Software.DTO
{
    class TableDTO
    {
        private int idTable;
        private string nameTable;
        private string status;

        public int IdTable { get => idTable; set => idTable = value; }
        public string NameTable { get => nameTable; set => nameTable = value; }
        public string Status { get => status; set => status = value; }

        public TableDTO(int idTable, string nameTable, string status)
        {
            this.idTable = idTable;
            this.nameTable = nameTable;
            this.status = status;
        }

        public TableDTO()
        {
        }
    }
}
