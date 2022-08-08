using System;
using System.Collections.Generic;

#nullable disable

namespace Coffee_Management_Software.Models
{
    public partial class BillDetail
    {
        public int IdBill { get; set; }
        public int IdFood { get; set; }
        public int? Quality { get; set; }

        public virtual Bill IdBillNavigation { get; set; }
        public virtual Food IdFoodNavigation { get; set; }
    }
}
