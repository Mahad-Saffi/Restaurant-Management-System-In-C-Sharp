using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLLForRMS;
using DLLForRMS.BL;

namespace RMS.UI
{
    public partial class SignUp : Form
    {
        private string username;
        private string password;
        private string email;
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
            password = ObjectHandler.GetUserDL().HashPassword(txtPassword.Text);
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            email = txtEmail.Text;
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            string phoneStr = txtContact.Text;
            phone = long.Parse(phoneStr);
        }

        private void btnSignUp_Click_1(object sender, EventArgs e)
        {
            if (username == null || password == null || email == null || phone == 0)
            {
                MessageBox.Show("Please fill all the fields");
            }
            else
            {
                User user = new User(username, password, "Customer", email, phone, DateTime.Now);
                if (ObjectHandler.GetUserDL().AddUserData(user))
                {
                    MessageBox.Show("Sign Up Successful");
                }
                else
                {
                    MessageBox.Show("Sign Up Failed");
                }

                this.Hide();
                var loginForm = new LoginForm();
                loginForm.Show();
            }
        }
    }
}
