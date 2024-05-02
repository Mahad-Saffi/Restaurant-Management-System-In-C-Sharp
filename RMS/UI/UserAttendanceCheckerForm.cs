using DLLForRMS.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS.UI
{
    public partial class UserAttendanceCheckerForm : Form
    {
        public UserAttendanceCheckerForm(int employeeID)
        {
            InitializeComponent();
            LoadDataGridViewForAttendanceChecker(employeeID);
        }

        private void LoadDataGridViewForAttendanceChecker(int employeeID)
        {
            AttendanceCheckerDataGridView.Columns.Add("AttendanceID", "Attendance ID");
            AttendanceCheckerDataGridView.Columns.Add("EmployeeID", "Employee ID");
            AttendanceCheckerDataGridView.Columns.Add("Date", "Date");
            AttendanceCheckerDataGridView.Columns.Add("TimeIn", "Time In");
            AttendanceCheckerDataGridView.Columns.Add("TimeOut", "Time Out");

            AttendanceCheckerDataGridView.Rows.Clear();
            List<Attendance> attendance = ObjectHandler.GetAttendanceDL().LoadAttendanceByEmployeeID(employeeID);


            foreach (Attendance a in attendance)
            {
                AttendanceCheckerDataGridView.Rows.Add(a.GetAttendanceID(), a.GetUserID(), a.GetDate(), a.GetTimeIn(), a.GetTimeOut());
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
