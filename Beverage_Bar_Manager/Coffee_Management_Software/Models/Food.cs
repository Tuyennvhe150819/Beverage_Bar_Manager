using System;
using System.Collections.Generic;

#nullable disable

namespace Coffee_Management_Software.Models
{
    public partial class Food
    {
        public Food()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? IdCatagory { get; set; }
        public decimal? Price { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public bool? Status { get; set; }

        public virtual FoodCategory IdCatagoryNavigation { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
