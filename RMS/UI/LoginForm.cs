using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabelSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var signUp = new SignUp();
            signUp.Show();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void txtPassword_IconRightClick(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                txtPassword.IconRight = Properties.Resources.hidden;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.IconRight = Properties.Resources.eye;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // To Use Password Hidder
            txtPassword.UseSystemPasswordChar = true;
            // To focus cursor on the username field
            txtUsername.Focus();

            // Subscribe to the KeyDown event of the username TextBox
            txtUsername.KeyDown += TxtUsername_KeyDown;
        }

        private void TxtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the Enter key is pressed and focus is on the username field
            if (e.KeyCode == Keys.Enter && txtUsername.Focused)
            {
                // Code to handle Enter key press on the username field
                txtPassword.Focus();
            }

            txtPassword.KeyDown += TxtPassword_KeyDown;
        }

        // To Login On Enter Key Press
        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the Enter key is pressed and focus is on the password field
            if (e.KeyCode == Keys.Enter && txtPassword.Focused)
            {
                // Code to handle Enter key press on the password field
                btnLogin.PerformClick();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            var customer = new CustomerDashboard();
            customer.Show();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
