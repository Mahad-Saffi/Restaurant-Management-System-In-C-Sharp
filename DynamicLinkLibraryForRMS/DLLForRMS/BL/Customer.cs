using DLLForRMS.DL;
using DLLForRMS.DLInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForRMS.BL
{
    public class Customer : User
    {
        private Cart cart;

        public Customer(int userID, string username, string userHashPassword, string role, string userEmail, long userPhone, DateTime registrationDate)
        : base(userID, username, userHashPassword, role, userEmail, userPhone, registrationDate)
        {
            this.cart = new Cart(userID);
        }

        public Customer(string username, string userHashPassword, string role, string userEmail, long userPhone, DateTime registrationDate, byte[] image)
            : base(username, userHashPassword, role, userEmail, userPhone, registrationDate)
        {
            this.username = username;
            this.userHashPassword = userHashPassword;
            this.role = role;
            this.userEmail = userEmail;
            this.userPhone = userPhone;
            this.userRegistrationDate = registrationDate;
            this.userPic = image;
            this.cart = new Cart(userID);
        }

        public Customer(User user)
        {
            this.userID = user.getUserID();
            this.username = user.getUsername();
            this.userHashPassword = user.getUserHashPassword();
            this.role = user.getRole();
            this.userEmail = user.getUserEmail();
            this.userPhone = user.getUserPhone();
            this.userRegistrationDate = user.getUserRegistrationDate();
            this.userPic = user.GetUserPicture();
            this.cart = new Cart(userID);
        }

        public Customer(User user, Cart cart)
        {
            this.userID = user.getUserID();
            this.username = user.getUsername();
            this.userHashPassword = user.getUserHashPassword();
            this.role = user.getRole();
            this.userEmail = user.getUserEmail();
            this.userPhone = user.getUserPhone();
            this.userRegistrationDate = user.getUserRegistrationDate();
            this.userPic = user.GetUserPicture();
            this.cart = cart;
        }

        public Customer()
        {
        }

        public Cart GetCart()
        {
            return cart;
        }
    }
}
