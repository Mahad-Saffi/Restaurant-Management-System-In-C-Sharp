using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForRMS.BL
{
    public class Admin : User
    {
        public Admin(int userID, string username, string userHashPassword, string role, string userEmail, long userPhone, DateTime registrationDate)
            : base(userID, username, userHashPassword, role, userEmail, userPhone, registrationDate)
        {

        }

        public Admin(string username, string userHashPassword, string role, string userEmail, long userPhone, DateTime registrationDate)
            : base(username, userHashPassword, role, userEmail, userPhone, registrationDate)
        {

        }

        public Admin(string username, string userHashPassword, string role, string userEmail, long userPhone, DateTime registrationDate, byte[] image)
            : base(username, userHashPassword, role, userEmail, userPhone, registrationDate)
        {
            this.userPic = image;
        }

        public Admin(User user)
        {
            this.userID = user.getUserID();
            this.username = user.getUsername();
            this.userHashPassword = user.getUserHashPassword();
            this.role = user.getRole();
            this.userEmail = user.getUserEmail();
            this.userPhone = user.getUserPhone();
            this.userRegistrationDate = user.getUserRegistrationDate();
            this.userPic = user.GetUserPicture();
        }

    }
}
