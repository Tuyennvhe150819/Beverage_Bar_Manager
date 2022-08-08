using System;
using System.Collections.Generic;

#nullable disable

namespace Coffee_Management_Software.Models
{
    public partial class TableOr
    {
        public TableOr()
        {
            Bills = new HashSet<Bill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public TableOr(int id, string name, string status)
        {
            Id = id;
            Name = name;
            Status = status;
        }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
