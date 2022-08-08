using System;
using System.Collections.Generic;

#nullable disable

namespace Coffee_Management_Software.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Accounts = new HashSet<Account>();
            Attendances = new HashSet<Attendance>();
            Bills = new HashSet<Bill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime? Dob { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? DateJoin { get; set; }
        public string Gender { get; set; }
        public string Cmt { get; set; }
        public int? IdShift { get; set; }

        public virtual Shift IdShiftNavigation { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
