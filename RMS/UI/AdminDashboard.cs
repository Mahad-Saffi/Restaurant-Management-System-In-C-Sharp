using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLLForRMS.BL;
using DLLForRMS.DL;

namespace RMS.UI
{
    public partial class AdminDashboard : Form
    {
        string username;
        string password;
        string email;
        long phone;
        string role;
        double salary;

        public AdminDashboard(User admin)
        {
            InitializeComponent();
            InitializePersonalInfo(admin);
        }

        private void InitializePersonalInfo(User admin)
        {
            personalInfoAdmin.NameTextPersonalInfo = admin.getUsername();
            personalInfoAdmin.PassTextPersonalInfo = admin.getUserHashPassword();
            personalInfoAdmin.EmailTextPersonalInfo = admin.getUserEmail();
            personalInfoAdmin.ContactTextPersonalInfo = admin.getUserPhone().ToString();
            personalInfoAdmin.SinceTextPersonalInfo = admin.getUserRegistrationDate().ToString();
            personalInfoAdmin.RoleTextPersonalInfo = admin.getRole();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void messagesFlowPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private void InboxMainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rMSDatabaseDataSet.Items' table. You can move, or remove it, as needed.
            this.itemsTableAdapter.Fill(this.rMSDatabaseDataSet.Items);
            messagesFlowPanel.Controls.Clear();
            messagesFlowPanel.Controls.Add(new Message());
            messagesFlowPanel.Controls.Add(new Message());
            messagesFlowPanel.Controls.Add(new Message());
            messagesFlowPanel.Controls.Add(new Message());
            messagesFlowPanel.Controls.Add(new Message());
            messagesFlowPanel.Controls.Add(new Message());
        }

        private void showPanel (Panel panel)
        {
            AdminSideBarMainPanel.Visible = true;
            AdminPanelMain.Visible = true;

            UserDetailsMainPanel.Visible = false;
            ItemDetailsMainPanel.Visible = false;
            FinancialDataMainPanel.Visible = false;
            AnalyticsMainPanel.Visible = false;
            InboxMainPanel.Visible = false;
            FeedbackMainPanel.Visible = false;
            AttendanceMainPanel.Visible = false;
            personalInfoAdmin.Visible = false;

            panel.Visible = true;
        }

        private void personalInfo1_Load(object sender, EventArgs e)
        {
            personalInfoAdmin.NameTextPersonalInfo = "Admin";
            personalInfoAdmin.PassTextPersonalInfo = "admin";
            personalInfoAdmin.EmailTextPersonalInfo = "admin@gmail.com";
            personalInfoAdmin.ContactTextPersonalInfo = "1234567890";
            personalInfoAdmin.SinceTextPersonalInfo = "2021";
            personalInfoAdmin.RoleTextPersonalInfo = "Admin";
            personalInfoAdmin.PersonalInfoPicBox = Properties.Resources.eye;
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            
        }

        private void UserDetailsMainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            string itemName = txtItemName.Text;
            string itemPrice = txtItemPrice.Text;
            string itemCost = txtCostOfPurchase.Text;
            var item = new Item(itemName, Convert.ToDouble(itemPrice), Convert.ToDouble(itemCost));

            if (ObjectHandler.GetItemDL().AddItem(item))
            {
                MessageBox.Show("Item added successfully.");
            }
            else
            {
                MessageBox.Show("Failed to add item.");
            }
        }

        private void btnAddItemPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                byte[] imageBytes = System.IO.File.ReadAllBytes(dialog.FileName);
                string query = "INSERT INTO Items (Picture) VALUES (@image) Where ItemID = @itemID";
                ObjectHandler.GetUtilityDL().SaveImage(imageBytes, query, 1, "item");
            }
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            string itemID = ItemIDCombo.Text;
            string itemName = txtItemName.Text;
            string itemPrice = txtItemPrice.Text;
            string itemCost = txtCostOfPurchase.Text;
            var item = new Item(Convert.ToInt32(itemID), itemName, Convert.ToDouble(itemPrice), Convert.ToDouble(itemCost));

            if (ObjectHandler.GetItemDL().UpdateItem(item))
            {
                MessageBox.Show("Item updated successfully.");
            }
            else
            {
                MessageBox.Show("Failed to update item.");
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            string itemID = ItemIDCombo.Text;

            if (ObjectHandler.GetItemDL().DeleteItem(Convert.ToInt32(itemID)))
            {
                MessageBox.Show("Item deleted successfully.");
            }
            else
            {
                MessageBox.Show("Failed to delete item.");
            }
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            username = txtUsername.Text.ToLower();
            password = ObjectHandler.GetUserDL().HashPassword(txtUserPassword.Text);
            email = txtEmail.Text;
            phone = Convert.ToInt64(txtContact.Text);
            role = comboRole.Text.ToLower();
            salary = Convert.ToDouble(txtSalary.Text);

            if (role.ToLower() == "admin")
            {
                User admin = new Admin(username, password, role, email, phone, DateTime.Now);
                ObjectHandler.GetUserDL().AddUserData(admin);
            }
            else if (role.ToLower() == "manager" || role.ToLower() == "rider")
            {
                User employee = new Employee(username, password, role, email, phone, DateTime.Now, salary);
                ObjectHandler.GetUserDL().AddUserData(employee);
            }
            else if (role.ToLower() == "customer")
            {
                User customer = new Customer(username, password, role, email, phone, DateTime.Now);
                ObjectHandler.GetUserDL().AddUserData(customer);
            }
        }

        private void btnItemDetails_Click(object sender, EventArgs e)
        {
            showPanel(ItemDetailsMainPanel);
        }

        private void btnUserDetails_Click(object sender, EventArgs e)
        {
            showPanel(UserDetailsMainPanel);
        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            showPanel(AnalyticsMainPanel);
        }

        private void btnFinancialData_Click(object sender, EventArgs e)
        {
            showPanel(FinancialDataMainPanel);
        }

        private void btnInbox_Click(object sender, EventArgs e)
        {
            showPanel(InboxMainPanel);
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            showPanel(FeedbackMainPanel);
        }

        private void btnCheckAttendance_Click(object sender, EventArgs e)
        {
            showPanel(AttendanceMainPanel);
        }

        private void btnPersonalInfo_Click(object sender, EventArgs e)
        {
            showPanel(UserDetailsMainPanel);
            personalInfoAdmin.Visible = true;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
