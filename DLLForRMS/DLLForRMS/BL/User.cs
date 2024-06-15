using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Drawing;
using System.IO;

namespace DLLForRMS.BL
{
    public class User
    {
        protected int userID = 0;
        protected string username;
        protected string userHashPassword;
        protected string role;
        protected string userEmail;
        protected long userPhone;
        protected DateTime userRegistrationDate;
        protected byte[] userPic;

        public User()
        {
            
        }

        public User(string username, string userHashPassword, string role, string userEmail, long userPhone, DateTime registrationDate)
        {
            this.username = username;
            this.userHashPassword = userHashPassword;
            this.role = role;
            this.userEmail = userEmail;
            this.userPhone = userPhone;
            this.userRegistrationDate = registrationDate;
        }

        public User(string username, string userHashPassword, string role, string userEmail, long userPhone, DateTime registrationDate, byte[] userPic)
        {
            this.username = username;
            this.userHashPassword = userHashPassword;
            this.role = role;
            this.userEmail = userEmail;
            this.userPhone = userPhone;
            this.userRegistrationDate = registrationDate;
            this.userPic = userPic;
        }

        public User(int UserID, string username, string userHashPassword, string role, string userEmail, long userPhone, DateTime registrationDate)
        {
            this.userID = UserID;
            this.username = username;
            this.userHashPassword = userHashPassword;
            this.role = role;
            this.userEmail = userEmail;
            this.userPhone = userPhone;
            this.userRegistrationDate = registrationDate;
        }

        public string getUsername()
        {
            return username;
        }

        public string getUserHashPassword()
        {
            return userHashPassword;
        }

        public string getRole()
        {
            return role;
        }

        public string getUserEmail()
        {
            return userEmail;
        }

        public long getUserPhone()
        {
            return userPhone;
        }

        public DateTime getUserRegistrationDate()
        {
            return userRegistrationDate;
        }

        public int getUserID()
        {
            return userID;
        }

        public byte[] GetUserPicture()
        {
            return userPic;
        }

        public void setUserID(int userID)
        {
            this.userID = userID;
        }

        public void setUsername(string username)
        {
            this.username = username;
        }

        public void setUserHashPassword(string userHashPassword)
        {
            this.userHashPassword = userHashPassword;
        }

        public void setRole(string role)
        {
            this.role = role;
        }

        public void setUserEmail(string userEmail)
        {
            this.userEmail = userEmail;
        }

        public void setUserPhone(long userPhone)
        {
            this.userPhone = userPhone;
        }

        public void setUserRegistrationDate(DateTime userRegistrationDate)
        {
            this.userRegistrationDate = userRegistrationDate;
        }


    }
}
