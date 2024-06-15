using DLLForRMS.DLInterfaces;
using DLLForRMS.Utilities;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DLLForRMS.BL;
using System.Data;
using System.Runtime.Remoting;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;

namespace DLLForRMS.DL
{
    public class UserDB : IUser
    {


        public string HashPassword(string password)
        {
            // Generate a random salt
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Turn the combined salt+hash into a string for storage
            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            return savedPasswordHash;
        }

        public bool VerifyPassword(string enteredPassword, string storedPasswordBase64)
        {
            byte[] hashBytes = Convert.FromBase64String(storedPasswordBase64);

            // Gets the salt from the hash bytes
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            using (var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 10000))
            {
                byte[] enteredHash = pbkdf2.GetBytes(20);

                // Compares the computed hash with the stored hash
                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != enteredHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }


        public string RetrieveStoredPassword(string enteredUsername)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();
                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();

                string query = "SELECT PasswordHash FROM Users WHERE Username = @username";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", enteredUsername);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        byte[] passwordHashBytes = (byte[])reader["PasswordHash"];
                        connection.Close();

                        return Convert.ToBase64String(passwordHashBytes);
                    }
                    else
                    {
                        connection.Close();
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public User GetUserByUsername(string username)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();
                SqlConnection connection = new SqlConnection(connectionStr);

                connection.Open();
                string query = "SELECT * FROM Users WHERE Username = @username";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int userID = reader.GetInt32(0);
                        byte[] passwordHashBytes = (byte[])reader["PasswordHash"];
                        string userHashPassword = Convert.ToBase64String(passwordHashBytes);
                        long userPhone = reader.GetInt64(3);
                        string userEmail = reader.GetString(4);
                        string role = reader.GetString(5);
                        DateTime userRegistrationDate = reader.GetDateTime(6);

                        connection.Close();

                        return new User(userID, username, userHashPassword, role, userEmail, userPhone, userRegistrationDate);
                    }
                    else
                    {
                        connection.Close();
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Image GetUserImageByUserID(int userID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();
                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();

                string query = "SELECT Picture FROM Users WHERE UserID = @userID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userID", userID);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        byte[] imageBytes = (byte[])reader["Picture"];
                        Image userImage = Image.FromStream(new MemoryStream(imageBytes));
                        connection.Close();

                        return userImage;
                    }
                    else
                    {
                        connection.Close();
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public User GetUserByUserID(int userID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();
                    string query = "SELECT * FROM Users WHERE UserID = @userID";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@userID", userID);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string username = reader.GetString(1);
                            byte[] passwordHashBytes = (byte[])reader["PasswordHash"];
                            string userHashPassword = Convert.ToBase64String(passwordHashBytes);
                            long userPhone = reader.GetInt64(3);
                            string userEmail = reader.GetString(4);
                            string role = reader.GetString(5);
                            DateTime userRegistrationDate = reader.GetDateTime(6);

                            connection.Close();

                            return new User(userID, username, userHashPassword, role, userEmail, userPhone, userRegistrationDate);
                        }
                        else
                        {
                            connection.Close();
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Employee GetEmployeeByEmployeeID(int employeeID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();
                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();

                string query = "SELECT * FROM Users WHERE UserID = @employeeID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@employeeID", employeeID);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string username = reader.GetString(1);
                        byte[] passwordHashBytes = (byte[])reader["PasswordHash"];
                        string userHashPassword = Convert.ToBase64String(passwordHashBytes);
                        long userPhone = reader.GetInt64(3);
                        string userEmail = reader.GetString(4);
                        string role = reader.GetString(5);
                        DateTime userRegistrationDate = reader.GetDateTime(6);
                        double salary = Convert.ToDouble(reader.GetValue(8));
                        double tip = Convert.ToDouble(reader.GetValue(9));

                        connection.Close();

                        return new Employee(employeeID, username, userHashPassword, role, userEmail, userPhone, userRegistrationDate, salary, tip);
                    }
                    else
                    {
                        connection.Close();
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<int> LoadUsersID()
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();
                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();

                List<int> usersID = new List<int>();

                string query = "SELECT UserID FROM Users";
                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int userID = reader.GetInt32(0);
                        usersID.Add(userID);
                    }
                }
                connection.Close();
                return usersID;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<int> LoadAllCustomerID()
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    List<int> customerID = new List<int>();

                    string query = "SELECT UserID FROM Users WHERE Role = 'customer'";
                    var command = new SqlCommand(query, connection);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int userID = reader.GetInt32(0);
                            customerID.Add(userID);
                        }
                    }
                    connection.Close();
                    return customerID;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<int> GetAllEmployeeID()
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    List<int> employeeID = new List<int>();

                    string query = "SELECT UserID FROM Users WHERE Role = 'manager' OR Role = 'rider'";
                    var command = new SqlCommand(query, connection);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int userID = reader.GetInt32(0);
                            employeeID.Add(userID);
                        }
                    }
                    connection.Close();
                    return employeeID;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<string> LoadAllUsernames()
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();
                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();

                List<string> usernames = new List<string>();

                string query = "SELECT Username FROM Users";
                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string username = reader.GetString(0);
                        usernames.Add(username);
                    }
                }
                connection.Close();
                return usernames;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool IsUsernameAvailable(string username)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();
                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();

                string query = "SELECT COUNT(1) FROM Users WHERE Username = @username";
                var command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@username", username);

                int count = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

                return count == 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddUserData(User user)
        {
            try
            {
                if (!IsUsernameAvailable(user.getUsername()))
                {
                    return false;
                }

                string connectionStr = GetConnectionString.ConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    // Get the byte array of the hash directly
                    byte[] passwordHashBytes = Convert.FromBase64String(user.getUserHashPassword());

                    string query = "INSERT INTO Users (Username, PasswordHash, Phone, Email, Role, Since, Salary) VALUES (@username, @passwordHash, @phone, @email, @role, @registrationDate, @salary)";

                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", user.getUsername());
                    command.Parameters.Add("@passwordHash", SqlDbType.VarBinary).Value = passwordHashBytes;
                    command.Parameters.AddWithValue("@phone", user.getUserPhone());
                    command.Parameters.AddWithValue("@email", user.getUserEmail());
                    command.Parameters.AddWithValue("@role", user.getRole().ToLower());
                    command.Parameters.AddWithValue("@registrationDate", user.getUserRegistrationDate());

                    // Set salary to 0 if user is not an employee
                    double salary = (user is Employee) ? ((Employee)user).GetSalary() : 0;
                    command.Parameters.AddWithValue("@salary", salary);

                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int GetTotalUsers()
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();
                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();

                string query = "SELECT COUNT(1) FROM Users";
                var command = new SqlCommand(query, connection);

                int count = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

                return count;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<User> LoadAllUsers()
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();
                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();

                List<User> users = new List<User>();

                string query = "SELECT * FROM Users";
                var command = new SqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int userID = reader.GetInt32(0);
                        string username = reader.GetString(1);
                        byte[] passwordHashBytes = (byte[])reader["PasswordHash"];
                        string userHashPassword = Convert.ToBase64String(passwordHashBytes);
                        long userPhone = reader.GetInt64(3);
                        string userEmail = reader.GetString(4);
                        string role = reader.GetString(5);
                        DateTime userRegistrationDate = reader.GetDateTime(6);

                        User user = new User(userID, username, userHashPassword, role, userEmail, userPhone, userRegistrationDate);
                        users.Add(user);
                    }
                }
                connection.Close();
                return users;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                if (!IsUsernameAvailable(user.getUsername()))
                {
                    return false;
                }

                string connectionStr = GetConnectionString.ConnectionString();
                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();

                byte[] passwordHashBytes = Convert.FromBase64String(user.getUserHashPassword());

                string query = "UPDATE Users SET Username = @username, PasswordHash = @passwordHash, Phone = @phone, Email = @email, Role = @role";

                // Add salary update for employees
                if (user is Employee)
                {
                    query += ", Salary = @salary, TipEarned = @tip";
                }

                query += " WHERE UserID = @userID";

                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", user.getUsername());
                command.Parameters.Add("@passwordHash", SqlDbType.VarBinary).Value = passwordHashBytes;
                command.Parameters.AddWithValue("@phone", user.getUserPhone());
                command.Parameters.AddWithValue("@email", user.getUserEmail());
                command.Parameters.AddWithValue("@role", user.getRole().ToLower());

                // Set salary parameter if user is an employee
                if (user is Employee)
                {
                    command.Parameters.AddWithValue("@salary", ((Employee)user).GetSalary());
                    command.Parameters.AddWithValue("@tip", ((Employee)user).GetTip());
                }

                command.Parameters.AddWithValue("@userID", user.getUserID());

                int result = command.ExecuteNonQuery();
                connection.Close();

                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public bool UpdateUser(string username, string password, string email, long contact)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();
                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();

                byte[] passwordHashBytes = Convert.FromBase64String(HashPassword(password));

                string query = "UPDATE Users SET PasswordHash = @passwordHash, Phone = @phone, Email = @email WHERE Username = @username";

                var command = new SqlCommand(query, connection);
                command.Parameters.Add("@passwordHash", SqlDbType.VarBinary).Value = passwordHashBytes;
                command.Parameters.AddWithValue("@phone", contact);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@username", username);

                int result = command.ExecuteNonQuery();
                connection.Close();

                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteUser(int userID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();
                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();

                DeleteUserInbox(userID);

                string query = "DELETE FROM Users WHERE UserID = @UserID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userID", userID);

                int result = command.ExecuteNonQuery();
                connection.Close();

                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool DeleteUserInbox(int userID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();
                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();

                string query = "DELETE FROM Inbox WHERE ReceiverID = @UserID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userID", userID);

                int result = command.ExecuteNonQuery();
                connection.Close();

                return result > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int GetRepeatingCustomers()
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();
                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();

                string query = "SELECT COUNT(1) FROM (SELECT CustomerID FROM Orders GROUP BY CustomerID HAVING COUNT(CustomerID) > 1) AS RepeatingUsers";
                var command = new SqlCommand(query, connection);

                int count = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

                return count;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public double GetStoredUserTipByUserID(int riderID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();
                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();

                string query = "SELECT TipEarned FROM Users WHERE UserID = @userID";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@userID", riderID);

                double tip = Convert.ToDouble(command.ExecuteScalar());
                connection.Close();

                return tip;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
