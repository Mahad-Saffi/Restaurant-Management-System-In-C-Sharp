using DLLForRMS.DLInterfaces;
using DLLForRMS.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace DLLForRMS.DL
{
    public class UtilityDB : IUtility
    {
        public bool SaveImage(byte[] image, string type, int ID, string table)
        {
            try
            {
                string connectionString = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "";

                    if (type == "item")
                    {
                        query = "UPDATE Items SET Picture = @image WHERE ItemID = @ID";
                    }
                    else if (type == "user")
                    {
                        query = "UPDATE Users SET Picture = @image WHERE UserID = @ID";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@image", image));
                        if (table.ToLower() == "item")
                        {
                            command.Parameters.Add(new SqlParameter("@ID", ID));
                        }
                        else if (table.ToLower() == "user")
                        {
                            command.Parameters.Add(new SqlParameter("@ID", ID));
                        }

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public byte[] ImageToByteArray(Image image)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Save the image to the MemoryStream, specifying the format to use
                    image.Save(ms, ImageFormat.Png);

                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                return new byte[3];
            }
        }
    }
}
