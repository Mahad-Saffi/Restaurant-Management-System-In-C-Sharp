using DLLForRMS.DLInterfaces;
using DLLForRMS.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLLForRMS.Utilities;
using System.Data.SqlClient;

namespace DLLForRMS.DL
{
    public class InboxDB : IInbox
    {

        public List<Inbox> LoadMessagesByUserID(User user)
        {
            string connectionStr = GetConnectionString.ConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                try
                {
                    List<Inbox> messages = new List<Inbox>();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Inbox WHERE ReceiverID = @ReceiverID", connection);
                    cmd.Parameters.AddWithValue("@ReceiverID", user.getUserID());
                    connection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int messageID = Convert.ToInt32(reader["MessageID"]);
                            int senderID = Convert.ToInt32(reader["SenderID"]);
                            int receiverID = Convert.ToInt32(reader["ReceiverID"]);
                            string message = reader["MessageText"].ToString();
                            DateTime sentDateTime = Convert.ToDateTime(reader["SentDateTime"]);

                            Inbox inbox = new Inbox(messageID, senderID, receiverID, message, sentDateTime);
                            messages.Add(inbox);
                        }
                        reader.Close();
                    }
                    connection.Close();
                    return messages;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public bool SendMessage(Inbox inbox)
        {
            string connectionStr = GetConnectionString.ConnectionString();

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Inbox (SenderID, ReceiverID, MessageText, SentDateTime) VALUES (@SenderID, @ReceiverID, @MessageText, @SentDateTime)", connection);
                    cmd.Parameters.AddWithValue("@SenderID", inbox.getSenderID());
                    cmd.Parameters.AddWithValue("@ReceiverID", inbox.getReceiverID());
                    cmd.Parameters.AddWithValue("@MessageText", inbox.getMessage());
                    cmd.Parameters.AddWithValue("@SentDateTime", inbox.getSentDateTime());

                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    return false;
                }
            }
        }
    }
}
