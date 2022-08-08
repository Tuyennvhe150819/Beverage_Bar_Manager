using System;
using System.Collections.Generic;

#nullable disable

namespace Coffee_Management_Software.Models
{
    public partial class Shift
    {
        public Shift()
        {
            //Attendances = new HashSet<Attendance>();
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? Time { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }

        //public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
