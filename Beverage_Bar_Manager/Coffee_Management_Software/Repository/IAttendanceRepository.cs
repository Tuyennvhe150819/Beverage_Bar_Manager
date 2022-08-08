using Coffee_Management_Software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Management_Software.Repository
{
    interface IAttendanceRepository
    {
        void InserAttendance(Attendance attendance);
        void UpdateAttendance(Attendance attendance);
        Attendance GetAttendance(int idEmp);
        int CountAttendByIdEmpAndMonht(int idEmp);
        Shift GetShiftByID(int idShift);
        List<Shift> GetShiftInfo();
    }
}
