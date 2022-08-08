using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Management_Software.DTO
{
    class CategoryDTO
    {
        private int idCate;
        private string nameCate;
        private string desCate;
        private string statusCate;

        public int IdCate { get => idCate; set => idCate = value; }
        public string NameCate { get => nameCate; set => nameCate = value; }
        public string DesCate { get => desCate; set => desCate = value; }
        public string StatusCate { get => statusCate; set => statusCate = value; }

        public CategoryDTO(int idCate, string nameCate, string desCate, string statusCate)
        {
            this.idCate = idCate;
            this.nameCate = nameCate;
            this.desCate = desCate;
            this.statusCate = statusCate;
        }

        public CategoryDTO()
        {
        }
    }
}
