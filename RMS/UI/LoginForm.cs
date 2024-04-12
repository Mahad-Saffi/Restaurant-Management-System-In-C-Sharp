﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLLForRMS.DL;
using DLLForRMS.BL;
using DLLForRMS.DLInterfaces;

namespace RMS.UI
{
    public partial class LoginForm : Form
    {
        private string username;
        private string password;
        private string storedPassword;
        DLLForRMS.DL.UserDB userDB = new DLLForRMS.DL.UserDB();

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
            // To work as a password hider
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
            username = txtUsername.Text;
            password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill all the fields");
            }
            else
            {
                // To get the stored password from the database By the given username in textbox
                storedPassword = ObjectHandler.GetUserDL().RetrieveStoredPassword(username);

                if (storedPassword == null)
                {
                    MessageBox.Show("Username not found.");
                    return;
                }

                //If the password entered by the user matches the stored password
                if (ObjectHandler.GetUserDL().VerifyPassword(password, storedPassword))
                {
                    User user = ObjectHandler.GetUserDL().GetUserByUsername(username);
                    Customer customer = new Customer(user);

                    if (user != null && user.getRole() == "Customer")
                    {
                        this.Hide();
                        var customerDashboard = new CustomerDashboard(customer);
                        customerDashboard.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid password.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid password.");
                }
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
