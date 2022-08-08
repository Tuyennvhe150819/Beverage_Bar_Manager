using Coffee_Management_Software.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Management_Software.DAO
{
    class AttendanceDAO
    {
        private static AttendanceDAO instance = null;
        private static readonly object instanceLock = new object();
        private AttendanceDAO() { }
        public static AttendanceDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AttendanceDAO();
                    }
                    return instance;
                }
            }
        }

        public void InserAttendance(Attendance attendance)
        {
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                db.Attendances.Add(attendance);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void UpdateAttendance (Attendance attendance)
        {
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                db.Entry<Attendance>(attendance).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Attendance GetAttendance(int idEmp)
        {
            Attendance attendance = new Attendance();
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                attendance = db.Attendances.Where(a => a.IdEmployee.Equals(idEmp)
                && a.Attendance2Nd.Equals(false)
                && a.AttendanceDate.Value.Date == DateTime.Now.Date
                && a.AttendanceDate.Value.Month == DateTime.Now.Month
                && a.AttendanceDate.Value.Year == DateTime.Now.Year).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return attendance;
        }

        public int CountAttendByIdEmpAndMonht(int idEmp)
        {
            int count = 0;
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                count = db.Attendances.Where(a => a.IdEmployee.Equals(idEmp)
                && a.Attendance1St.Equals(true)
                && a.Attendance2Nd.Equals(true)
                && a.AttendanceDate.Value.Month == DateTime.Now.Month).Count(); ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return count;
        }

        public Shift GetShiftByID(int idShift)
        {
            Shift shift;
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                shift = db.Shifts.Where(s => s.Id.Equals(idShift)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return shift;
        }
        public List<Shift> GetShiftInfo()
        {
            List<Shift> shifts;
            try
            {
                using Management_PRN211 db = new Management_PRN211();
                shifts = db.Shifts.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return shifts;
        }
    }
}
