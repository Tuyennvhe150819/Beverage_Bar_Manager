using System;
using System.Collections.Generic;

#nullable disable

namespace Coffee_Management_Software.Models
{
    public partial class Attendance
    {
        public int Id { get; set; }
        public int? IdEmployee { get; set; }
        public bool? Attendance1St { get; set; }
        public bool? Attendance2Nd { get; set; }
        public DateTime? AttendanceDate { get; set; }
        //public int? IdShift { get; set; }

        public virtual Employee IdEmployeeNavigation { get; set; }
        //public virtual Shift IdShiftNavigation { get; set; }
    }
}
