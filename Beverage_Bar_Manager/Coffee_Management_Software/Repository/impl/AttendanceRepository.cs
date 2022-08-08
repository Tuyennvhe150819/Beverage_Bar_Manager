using Coffee_Management_Software.DAO;
using Coffee_Management_Software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Management_Software.Repository.impl
{
    class AttendanceRepository : IAttendanceRepository
    {
        public int CountAttendByIdEmpAndMonht(int idEmp) => AttendanceDAO.Instance.CountAttendByIdEmpAndMonht(idEmp);

        public Attendance GetAttendance(int idEmp) => AttendanceDAO.Instance.GetAttendance(idEmp);

        public void InserAttendance(Models.Attendance attendance) => AttendanceDAO.Instance.InserAttendance(attendance);

        public Shift GetShiftByID(int idShift) => AttendanceDAO.Instance.GetShiftByID(idShift);

        public void UpdateAttendance(Models.Attendance attendance) => AttendanceDAO.Instance.UpdateAttendance(attendance);

        public List<Shift> GetShiftInfo() => AttendanceDAO.Instance.GetShiftInfo(); 
    }
}
