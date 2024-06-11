using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForRMS.BL
{
    public class Attendance
    {
        private int attendanceID;
        private int userID;
        private string date;
        private DateTime timeIn;
        private DateTime timeOut;


        public Attendance(int userID, string date, DateTime timeIn, DateTime timeOut)
        {
            this.userID = userID;
            this.date = date;
            this.timeIn = timeIn;
            this.timeOut = timeOut;
        }

        public Attendance(int attendanceID, int userID, string date, DateTime timeIn, DateTime timeOut)
        {
            this.attendanceID = attendanceID;
            this.userID = userID;
            this.date = date;
            this.timeIn = timeIn;
            this.timeOut = timeOut;
        }

        public void SetTimeIn(DateTime time)
        {
            this.timeIn = time;
        }

        public void SetTimeOut(DateTime time)
        {
            this.timeOut = time;
        }

        public int GetAttendanceID()
        {
            return attendanceID;
        }

        public int GetUserID()
        {
            return userID;
        }

        public string GetDate()
        {
            return date;
        }

        public DateTime GetTimeIn()
        {
            return timeIn;
        }

        public DateTime GetTimeOut()
        {
            return timeOut;
        }


    }
}
