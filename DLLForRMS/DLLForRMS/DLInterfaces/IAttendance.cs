using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLLForRMS.BL;

namespace DLLForRMS.DLInterfaces
{
    public interface IAttendance
    {
        List<Attendance> LoadAttendanceByEmployeeID(int enployeeID);
        bool UserAndDatePresentIntable(int userID, DateTime date);
        bool MarkAttendance(Attendance attendance);
        bool UpdateAttendance(int userID, DateTime date, DateTime timeIn, DateTime timeOut);
    }
}
