using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Management_Software.DTO
{
    class FoodDTO
    {

        private int idFood;
        private string nameFood;
        private string nameCate;
        private double? price;
        private string description;
        private string status;
        private string size;
        private int idCate;

        public FoodDTO()
        {
        }

        public FoodDTO(int idFood, string nameFood, string nameCate, double? price, string description, string status, string size, int idCate)
        {
            this.idFood = idFood;
            this.nameFood = nameFood;
            this.nameCate = nameCate;
            this.price = price;
            this.description = description;
            this.status = status;
            this.size = size;
            this.idCate = idCate;
        }

        public int IdFood { get => idFood; set => idFood = value; }
        public string NameFood { get => nameFood; set => nameFood = value; }
        public string NameCate { get => nameCate; set => nameCate = value; }
        public double? Price { get => price; set => price = value; }
        public string Description { get => description; set => description = value; }
        public string Status { get => status; set => status = value; }
        public string Size { get => size; set => size = value; }
        public int IdCate { get => idCate; set => idCate = value; }
    }
}
