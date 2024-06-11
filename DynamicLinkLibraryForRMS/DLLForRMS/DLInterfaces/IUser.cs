using DLLForRMS.BL;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DLLForRMS.DLInterfaces
{
    public interface IUser
    {
        string HashPassword(string password);
        bool VerifyPassword(string enteredPassword, string storedPassword);
        string RetrieveStoredPassword(string enteredUsername);
        bool AddUserData(User user);
        bool UpdateUser(User user);
        bool UpdateUser(string username, string password, string email, long contact);
        bool DeleteUser(int userID);
        User GetUserByUsername(string username);
        Image GetUserImageByUserID(int userID);
        Employee GetEmployeeByEmployeeID(int employeeID);
        User GetUserByUserID(int userID);
        int GetTotalUsers();
        List<User> LoadAllUsers();
        int GetRepeatingCustomers();
        List<int> LoadUsersID();
        List<int> LoadAllCustomerID();
        List<int> GetAllEmployeeID();
        List<String> LoadAllUsernames();
        double GetStoredUserTipByUserID(int riderID);
    }
}
