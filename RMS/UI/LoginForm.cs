using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RMS;
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
        UserDB userDB = new UserDB();

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
            username = txtUsername.Text.ToLower();
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
                if (!ObjectHandler.GetUserDL().VerifyPassword(password, storedPassword))
                {
                    MessageBox.Show("Invalid Password...");
                    return;
                }

                ProceedWithValidUser(username);
            }
        }

        private void ProceedWithValidUser(string username)
        {
            User user = ObjectHandler.GetUserDL().GetUserByUsername(username);
            if (user == null)
            {
                MessageBox.Show("User not found.");
                return;
            }

            this.Hide();  // Hide the login form in preparation for showing the appropriate dashboard

            switch (user.getRole().ToLower())
            {
                case "customer":
                    Customer customer = new Customer(user);
                    ShowCustomerDashboard(customer);
                    break;
                case "admin":
                    Admin admin = new Admin(user);
                    ShowAdminDashboard(admin);
                    break;
                case "manager":
                    Employee manager = new Employee(user);
                    ShowManagerDashboard(manager);
                    break;
                case "rider":
                    Employee rider = new Employee(user);
                    ShowRiderDashboard(rider);
                    break;
                default:
                    MessageBox.Show("Role not recognized.");
                    this.Show();  // Re-show the login form
                    break;
            }
        }

        private void ShowCustomerDashboard(Customer customer)
        {
            if (!ObjectHandler.GetCartDL().IsCartPresent(customer.getUserID()))
            {
                ObjectHandler.GetCartDL().AddCart(new Cart(customer.getUserID()));
            }
            var customerWithCart = new Customer(customer, customer.GetCart());
            var customerDashboard = new CustomerDashboard(customer);
            customerDashboard.Show();
        }

        private void ShowAdminDashboard(Admin admin)
        {
            var adminDashboard = new AdminDashboard(admin);
            adminDashboard.Show();
        }

        private void ShowManagerDashboard(Employee manager)
        {
            var managerDashboard = new ManagerDashboard(manager);
            managerDashboard.Show();
        }

        private void ShowRiderDashboard(Employee rider)
        {
            var riderDashboard = new RiderDashboard(rider);
            riderDashboard.Show();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
