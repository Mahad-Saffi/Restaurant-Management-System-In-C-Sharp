using DLLForRMS.DLInterfaces;
using DLLForRMS.Utilities;
using DLLForRMS.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForRMS.DL
{
    public class FeedbackDB : IFeedback
    {
        public bool AddFeedback(int customerID, int rating)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "INSERT INTO Feedback (CustomerID, Rating) VALUES (@customerID, @rating)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@customerID", customerID);
                        command.Parameters.AddWithValue("@rating", rating);

                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<int> LoadAllFeedbacks()
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();
                List<int> feedbacks = new List<int>();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "SELECT * FROM Feedback";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int rating = reader.GetInt32(2);
                                feedbacks.Add(rating);
                            }
                        }
                    }
                }

                return feedbacks;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
