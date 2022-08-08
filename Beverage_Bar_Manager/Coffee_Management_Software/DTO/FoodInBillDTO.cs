using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Management_Software.DTO
{
    public class FoodInBillDTO
    {
        private int productID;
        private string productName;
        private double price;
        private string size;
        private int quality;
        private double cost;

        public int ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public double Price { get => price; set => price = value; }
        public string Size { get => size; set => size = value; }
        public int Quality { get => quality; set => quality = value; }
        public double Cost { get => cost; set => cost = value; }

        public FoodInBillDTO(int productID, string productName, double price, string size, int quality, double cost)
        {
            this.productID = productID;
            this.productName = productName;
            this.price = price;
            this.size = size;
            this.quality = quality;
            this.cost = cost;
        }

        public FoodInBillDTO()
        {
        }
    }
}
