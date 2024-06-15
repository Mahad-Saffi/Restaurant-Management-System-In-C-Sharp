using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForRMS.BL
{
    public class Employee : User
    {
        private double salary = 0;
        private double tip = 0;

        public Employee(int userID, string username, string userHashPassword, string role, string userEmail, long userPhone, DateTime registrationDate, double salary, double tip)
            : base(userID, username, userHashPassword, role, userEmail, userPhone, registrationDate)
        {
            this.salary = salary;
            this.tip = tip;
        }

        public Employee(string username, string userHashPassword, string role, string userEmail, long userPhone, DateTime registrationDate, double salary, byte[] image)
        {
            this.username = username;
            this.userHashPassword = userHashPassword;
            this.role = role;
            this.userEmail = userEmail;
            this.userPhone = userPhone;
            this.userRegistrationDate = registrationDate;
            this.salary = salary;
            this.userPic = image;
        }

        public Employee(int userID, string username, string userHashPassword, string role, string userEmail, long userPhone, DateTime registrationDate, double salary)
            : base(userID, username, userHashPassword, role, userEmail, userPhone, registrationDate)
        {
            this.salary = salary;
        }

        public Employee(User employee)
        {
            this.userID = employee.getUserID();
            this.username = employee.getUsername();
            this.userHashPassword = employee.getUserHashPassword();
            this.role = employee.getRole();
            this.userEmail = employee.getUserEmail();
            this.userPhone = employee.getUserPhone();
            this.userRegistrationDate = employee.getUserRegistrationDate();
        }

        public Employee()
        {
        }

        public double GetSalary()
        {
            return salary;
        }

        public double GetTip()
        {
            return tip;
        }

    }
}
