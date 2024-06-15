using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DLLForRMS.Utilities
{
    public class Validations
    {
        public bool ValidateString(string input)
        {
            if (string.IsNullOrEmpty(input) || !input.All(Char.IsLetter))
            {
                return false;
            }
            return true;
        }

        public bool ValidateDouble(string input)
        {
            if (string.IsNullOrEmpty(input) || !input.All(Char.IsDigit))
            {
                return false;
            }
            else if (Convert.ToDouble(input) < 0)
            {
                return false;
            }
            return true;
        }

        public bool ValidateInteger(string input)
        {
            if (string.IsNullOrEmpty(input) || !input.All(Char.IsDigit))
            {
                return false;
            }
            return true;
        }

        public bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            else if (!email.Contains("@") || !email.Contains("."))
            {
                return false;
            }
            else
            {
                try
                {
                    // Attempt to create a MailAddress instance with the given email
                    MailAddress mailAddress = new MailAddress(email);
                    return true; // If successful, email is considered valid
                }
                catch (FormatException)
                {
                    // If FormatException is thrown, the email is not in a valid format
                    return false;
                }
            }
        }

        public string ValidateContactNumber(string phoneStr)
        {
            if (phoneStr.Contains("+") || phoneStr.Contains("-") || phoneStr.Contains(" "))
            {
                phoneStr = phoneStr.Replace("+", "");
                phoneStr = phoneStr.Replace("-", "");
                phoneStr = phoneStr.Replace(" ", "");
            }
            else if (string.IsNullOrEmpty(phoneStr))
            {
                return "false";
            }
            else if (!phoneStr.All(Char.IsDigit) || phoneStr.Length > 12 || phoneStr.Length < 10)
            {
                return "false";
            }
            return phoneStr;
        }
    }
}
