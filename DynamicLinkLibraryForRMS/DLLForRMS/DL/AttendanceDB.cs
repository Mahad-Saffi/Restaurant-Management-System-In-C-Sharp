using DLLForRMS.BL;
using DLLForRMS.DLInterfaces;
using DLLForRMS.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForRMS.DL
{
    public class AttendanceDB : IAttendance
    {
        public bool UserAndDatePresentIntable(int userID, DateTime date)
        {
            string connectionStr = GetConnectionString.ConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Attendance WHERE UserID = @UserID AND Date = @Date", connection);
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@Date", date);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public bool MarkAttendance(Attendance attendance)
        {
            string connectionStr = GetConnectionString.ConnectionString();
            SqlConnection connection = new SqlConnection(connectionStr);

            connection.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Attendance (UserID, Date, TimeIn, TimeOut) VALUES (@UserID, @Date, @TimeIn, @TimeOut)", connection);
                cmd.Parameters.AddWithValue("@UserID", attendance.GetUserID());
                cmd.Parameters.AddWithValue("@Date", attendance.GetDate());
                cmd.Parameters.AddWithValue("@TimeIn", attendance.GetTimeIn());
                cmd.Parameters.AddWithValue("@TimeOut", attendance.GetTimeOut());

                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                connection.Close();
                return false;
            }
        }

        public bool UpdateAttendance(int userID, DateTime date, DateTime timeIn, DateTime timeOut)
        {
            string connectionStr = GetConnectionString.ConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Attendance SET TimeIn = @TimeIn, TimeOut = @TimeOut WHERE UserID = @UserID AND Date = @Date", connection);
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@TimeIn", timeIn);
                    cmd.Parameters.AddWithValue("@TimeOut", timeOut);

                    cmd.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    return false;
                }
            }
        }

        public List<Attendance> LoadAttendanceByEmployeeID(int employeeID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();
                    List<Attendance> attendances = new List<Attendance>();
                    try
                    {
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Attendance WHERE UserID = @UserID", connection);
                        cmd.Parameters.AddWithValue("@UserID", employeeID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int attendanceID = reader.GetInt32(0);
                                int userID = reader.GetInt32(1);
                                string date = reader.GetString(2);
                                TimeSpan timeIn = reader.GetTimeSpan(3);
                                TimeSpan timeOut = reader.GetTimeSpan(4);

                                // Convert date string to DateTime
                                DateTime dateTime = DateTime.Parse(date);

                                // Combine date and time to create DateTime objects for timeIn and timeOut
                                DateTime timeInDateTime = dateTime.Date + timeIn;
                                DateTime timeOutDateTime = dateTime.Date + timeOut;

                                Attendance attendance = new Attendance(attendanceID, userID, date, timeInDateTime, timeOutDateTime);
                                attendances.Add(attendance);
                            }
                        }
                        connection.Close();
                        return attendances;
                    }
                    catch (Exception ex)
                    {
                        List<Attendance> nullList = new List<Attendance>();
                        nullList.Add(new Attendance(0, 0, ex.ToString(), DateTime.Now, DateTime.Now));
                        return nullList;
                    }
                }
            }
            catch (Exception ex)
            {

                List<Attendance> nullList = new List<Attendance>();
                nullList.Add(new Attendance(0, 0, ex.ToString(), DateTime.Now, DateTime.Now));
                return nullList;
            }
        }
    }
}
