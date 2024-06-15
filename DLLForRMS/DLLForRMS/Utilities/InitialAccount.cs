using DLLForRMS.BL;
using DLLForRMS.DL;
using DLLForRMS.DLInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DLLForRMS.Utilities
{
    public static class InitialAccount
    {

        /*This Function is used to Add Admin and should be deleted after the Admin is added*/
        public static bool AddAdmin(string username, string password, string email, long phoneNumber)
        {
            Validations validations = new Validations();
            if (validations.ValidateContactNumber(phoneNumber.ToString()) == "false")
            {
                return false;
            }

            IUser user = new UserDB();
            DateTime registrationDate = DateTime.Now;
            Admin admin = new Admin(username.ToLower(), user.HashPassword(password), "admin", email, phoneNumber, registrationDate);
            if (user.AddUserData(admin))
            {
                return true;
            }
            return false;
        }
    }
}
