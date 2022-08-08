using System;
using System.Collections.Generic;

#nullable disable

namespace Coffee_Management_Software.Models
{
    public partial class Bill
    {
        public Bill()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        public int Id { get; set; }
        public int? IdEmployee { get; set; }
        public DateTime? DateCheckIn { get; set; }
        public DateTime? DateCheckOut { get; set; }
        public int? IdTable { get; set; }
        public bool? Status { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        public virtual TableOr IdTableNavigation { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
