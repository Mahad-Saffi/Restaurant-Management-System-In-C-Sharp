using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLLForRMS;
using DLLForRMS.BL;

namespace RMS.UI
{
    public partial class SignUp : Form
    {
        private string username;     //all the things need for signup
        private string password;
        private string email;
        private string phoneStr;
        private long phone;

        public SignUp()
        {
            InitializeComponent();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var loginForm = new LoginForm();
            loginForm.Show();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            username = txtUserName.Text.ToLower();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            password = ObjectHandler.GetUserDL().HashPassword(txtPassword.Text);       //encrypting the password
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            email = txtEmail.Text;
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            phoneStr = txtContact.Text;
        }

        private void btnSignUp_Click_1(object sender, EventArgs e)
        {
            // Validations
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneStr))
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }
            else if (ObjectHandler.GetValidations().ValidateContactNumber(phoneStr) == "false")
            {
                txtContact.Clear();
                MessageBox.Show("Invalid Phone Number");
                return;
            }
            else if (ObjectHandler.GetValidations().ValidateContactNumber(phoneStr) != "false")
            {
                phone = Convert.ToInt64(ObjectHandler.GetValidations().ValidateContactNumber(phoneStr));
            }
            else if (!ObjectHandler.GetValidations().ValidateEmail(email))
            {
                txtEmail.Clear();
                MessageBox.Show("Invalid Email Address");
                return;
            }

            byte[] imageBytes = ObjectHandler.GetUtilityDL().ImageToByteArray(Properties.Resources.user);
            User user = new User(username, password, "Customer", email, phone, DateTime.Now, imageBytes);
            if (ObjectHandler.GetUserDL().AddUserData(user))
            {
                User tempUser = ObjectHandler.GetUserDL().GetUserByUsername(username);
                string query = "UPDATE Users SET Picture = @image WHERE UserID = @ID";       //update picture
                if (ObjectHandler.GetUtilityDL().SaveImage(ObjectHandler.GetUtilityDL().ImageToByteArray(Properties.Resources.user), query, tempUser.getUserID(), "user"))
                {
                    MessageBox.Show("Sign Up Successfully...");
                }
                else
                {
                    MessageBox.Show("Some error occurs...");
                }
            }
            else
            {
                MessageBox.Show("Username already present...\nPlease try a different username...");   // becaude username is unique
            }

            this.Hide();
            var loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
