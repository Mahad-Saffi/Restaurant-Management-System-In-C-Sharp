using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
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
        User admin;
        private DateTime timeIn = DateTime.Now;
        private DateTime timeOut = DateTime.Now;

        public AdminDashboard(User admin)
        {
            this.admin = admin;
            InitializeComponent();
            InitializeItemDetails();
            InitializeUserDetails();
            InitializeAnalytics();
            InitializeFinancialTransactions();
            InitializeInbox();
            InitializeAttendance();
            InitializePersonalInfo(admin);
        }

        private void InitializeItemDetails()
        {
            // Load all the Item IDs for Combo Box
            List<int> items = ObjectHandler.GetItemDL().LoadItemsID();
            foreach(int item in items)
            {
                ItemIDCombo.Items.Add(item);
            }
        }

        private void InitializeUserDetails()
        {
            // Load all the User IDs for Combo Box
            List<int> users = ObjectHandler.GetUserDL().LoadUsersID();
            foreach (int user in users)
            {
                UsersIDCombo.Items.Add(user);
            }

            // Fill the two lower text boxes
            txtTotalUsers.Text = ObjectHandler.GetUserDL().GetTotalUsers().ToString();
            txtRepeatingCustomers.Text = ObjectHandler.GetUserDL().GetRepeatingCustomers().ToString();
        }

        private void InitializeAnalytics()
        {
            double paymentsRecieved = ObjectHandler.GetOrderDL().GetTotalAmountOfSalesThisMonth();
            double expenditures = ObjectHandler.GetItemDL().GetTotalCostOfPurchases();
            List<string> topItems = ObjectHandler.GetOrderDL().GetTopItemsThisMonth();

            AmountPaymentsReceved.Text = "$" + paymentsRecieved;
            AmountExpenditures.Text = "$" + expenditures;

            foreach (string item in topItems)
            {
                if (item == topItems.Last())
                {
                    txtTopItemsMonth.Text += item;
                }
                else
                    txtTopItemsMonth.Text += item + ", ";
            }
        }

        private void InitializeFinancialTransactions()
        {
            double totalTransactionsThisMonth = ObjectHandler.GetOrderDL().GetTotalAmountOfSalesThisMonth() + ObjectHandler.GetItemDL().GetTotalCostOfPurchases();
            double totalTransactionsThisYear = ObjectHandler.GetOrderDL().GetTotalAmountOfSalesThisYear() + ObjectHandler.GetItemDL().GetTotalCostOfPurchases();

            TransactionsMonthlyAmount.Text = "$" + totalTransactionsThisMonth;
            TransactionsYearlyAmount.Text = "$" + totalTransactionsThisYear;

            double totalRevenueThisMonth = ObjectHandler.GetOrderDL().GetTotalAmountOfSalesThisMonth();
            double totalRevenueThisYear = ObjectHandler.GetOrderDL().GetTotalAmountOfSalesThisYear();

            RevenueMonthlyAmount.Text = "$" + totalRevenueThisMonth;
            RevenueYearlyAmount.Text = "$" + totalRevenueThisYear;

            double monthlyIncome = totalRevenueThisMonth - ObjectHandler.GetItemDL().GetTotalCostOfPurchases();
            double yearlyIncome = totalRevenueThisYear - ObjectHandler.GetItemDL().GetTotalCostOfPurchases();

            MonthlyIncomeAmount.Text = "$" + (monthlyIncome);
            YearlyIncomeAmount.Text = "$" + (yearlyIncome);

            if (monthlyIncome > (yearlyIncome / 12))
            {
                ProfitOrLossThisMonth.Text = "Profit";
                ProfitOrLossThisYear.Text = "Loss";
            }
            else
            {
                ProfitOrLossThisMonth.Text = "Loss";
                ProfitOrLossThisYear.Text = "Profit";
            }
        }

        private void InitializeInbox()
        {
            // Load all Usernames for Combo Box
            List<string> usernames = ObjectHandler.GetUserDL().LoadAllUsernames();
            foreach (string username in usernames)
            {
                UsernamesCombo.Items.Add(username);
            }

            // Load all the messages
            List<Inbox> messages = ObjectHandler.GetInboxDL().LoadMessagesByUserID(admin);
            messagesFlowPanel.Controls.Clear();
            foreach (Inbox message in messages)
            {
                messagesFlowPanel.Controls.Add(new Message(message));
            }
        }

        private void InitializeAttendance()
        {
            //Load All employee ID's for Combo Box
            List<int> employeeID = ObjectHandler.GetUserDL().GetAllEmployeeID();
            foreach (int id in employeeID)
            {
                EmployeeIDCombo.Items.Add(id);
            }
        }

        private void InitializePersonalInfo(User admin)
        {
            personalInfoAdmin.NameTextPersonalInfo = admin.getUsername();
            personalInfoAdmin.PassTextPersonalInfo = admin.getUserHashPassword();
            personalInfoAdmin.EmailTextPersonalInfo = admin.getUserEmail();
            personalInfoAdmin.ContactTextPersonalInfo = admin.getUserPhone().ToString();
            personalInfoAdmin.SinceTextPersonalInfo = admin.getUserRegistrationDate().ToString();
            personalInfoAdmin.RoleTextPersonalInfo = admin.getRole();
            personalInfoAdmin.SalaryTextPersonalInfo = "N/A";
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
            PersonalInfoPanel.Visible = false;

            panel.Visible = true;
        }

        private void personalInfo1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                UserPicturebox.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void UserDetailsMainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            string itemName = txtItemName.Text;
            string itemPrice = txtItemPrice.Text;
            string itemCost = txtCostOfPurchase.Text;
            byte[] itemImage = ItemPicturebox.Image != null ? ObjectHandler.GetUtilityDL().ImageToByteArray(ItemPicturebox.Image) : null;

            var item = new Item(itemName, Convert.ToDouble(itemPrice), Convert.ToDouble(itemCost), itemImage);

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
                ItemPicturebox.Image = Image.FromFile(dialog.FileName);
                ItemPicturebox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            string itemID = ItemIDCombo.Text;
            string itemName = txtItemName.Text;
            string itemPrice = txtItemPrice.Text;
            string itemCost = txtCostOfPurchase.Text;
            byte[] itemImage = ItemPicturebox.Image != null ? ObjectHandler.GetUtilityDL().ImageToByteArray(ItemPicturebox.Image) : null;
            var item = new Item(Convert.ToInt32(itemID), itemName, Convert.ToDouble(itemPrice), Convert.ToDouble(itemCost), itemImage);

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
            string username = txtUsername.Text.ToLower();
            string password = ObjectHandler.GetUserDL().HashPassword(txtUserPassword.Text);
            string email = txtEmail.Text;
            long phone = Convert.ToInt64(txtContact.Text);
            string role = comboRole.Text.ToLower();
            double salary = Convert.ToDouble(txtSalary.Text);
            byte[] userPicture = UserPicturebox.Image != null ? ObjectHandler.GetUtilityDL().ImageToByteArray(UserPicturebox.Image) : null;

            if (userPicture != null)
            {
                string base64String = Convert.ToBase64String(userPicture);
                MessageBox.Show(base64String);
            }
            else
            {
                MessageBox.Show("No picture loaded.");
            }


            if (role.ToLower() == "admin")
            {
                Admin adminTobeAdded = new Admin(username, password, role, email, phone, DateTime.Now, userPicture);
                if (ObjectHandler.GetUserDL().AddUserData(adminTobeAdded))
                {
                    MessageBox.Show("Admin added successfully.");
                }
                else
                {
                    MessageBox.Show("Username already present...\nPlease try a different username...");
                }
            }
            else if (role.ToLower() == "manager" || role.ToLower() == "rider")
            {
                Employee employee = new Employee(username, password, role, email, phone, DateTime.Now, salary, userPicture);
                ObjectHandler.GetUserDL().AddUserData(employee);
            }
            else if (role.ToLower() == "customer")
            {
                Customer customer = new Customer(username, password, role, email, phone, DateTime.Now, userPicture);
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
            showPanel(PersonalInfoPanel);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void ItemIDCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text;
            string username = UsernamesCombo.Text;

            MessageBox.Show(username);

            User reciever = ObjectHandler.GetUserDL().GetUserByUsername(username);

            Inbox inbox = new Inbox(admin.getUserID(), reciever.getUserID(), message, DateTime.Now);

            if(ObjectHandler.GetInboxDL().SendMessage(inbox))
            {
                txtMessage.Clear();
                ReloadInbox();
                MessageBox.Show("Message sent successfully.");
            }
            else
            {
                MessageBox.Show("Failed to send message.");
            }
        }

        private void ReloadInbox()
        {
            messagesFlowPanel.Controls.Clear();
            List<Inbox> messages = ObjectHandler.GetInboxDL().LoadMessagesByUserID(admin);
            foreach (Inbox message in messages)
            {
                messagesFlowPanel.Controls.Add(new Message(message));
            }
        }

        private void AttendanceMainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            timeIn = DateTime.Now;
            MessageBox.Show("Time In marked successfully.\nDon't Forget To Click On Save To Save It...");
        }

        private void MarkAttenManuallyCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (MarkAttenManuallyCheckbox.Checked)
            {
                LabelMarkTimeIn.Visible = true;
                LabelMarkTimeOut.Visible = true;
                DateTimePickerTimeIn.Visible = true;
                DateTimePickerTimeOut.Visible = true;
            }
            else
            {
                LabelMarkTimeIn.Visible = false;
                LabelMarkTimeOut.Visible = false;
                DateTimePickerTimeIn.Visible = false;
                DateTimePickerTimeOut.Visible = false;
            }
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            timeOut = DateTime.Now;
            MessageBox.Show("Time Out marked successfully.\nDon't Forget To Click On Save To Save It...");
        }

        private void AttendanceGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(UsersIDCombo.Text);

            if (ObjectHandler.GetUserDL().DeleteUser(userID))
            {
                MessageBox.Show("User deleted Successfully!");
            }
            else
            {
                MessageBox.Show("Failed to delete the user!");
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(UsersIDCombo.Text);
            string username = txtUsername.Text;
            string password = ObjectHandler.GetUserDL().HashPassword(txtUserPassword.Text);
            string email = txtEmail.Text;
            long phone = Convert.ToInt64(txtContact.Text);
            string role = comboRole.Text.ToLower();
            double salary = Convert.ToDouble(txtSalary.Text);
            byte[] userPicture = UserPicturebox.Image != null ? ObjectHandler.GetUtilityDL().ImageToByteArray(UserPicturebox.Image) : null;

            if (role.ToLower() == "admin")
            {
                Admin adminTobeAdded = new Admin(userID, username, password, role, email, phone, DateTime.Now, userPicture);
                ObjectHandler.GetUserDL().UpdateUser(adminTobeAdded);
            }
            else if (role.ToLower() == "manager" || role.ToLower() == "rider")
            {
                Employee employee = new Employee(userID, username, password, role, email, phone, DateTime.Now, salary, userPicture);
                ObjectHandler.GetUserDL().UpdateUser(employee);
            }
            else if (role.ToLower() == "customer")
            {
                Customer customer = new Customer(userID, username, password, role, email, phone, DateTime.Now, userPicture);
                ObjectHandler.GetUserDL().UpdateUser(customer);
            }
        }

        private void ItemDetailsMainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FinancialDataMainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AnalyticsMainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnSaveAttendance_Click(object sender, EventArgs e)
        {
            DateTime date = timeIn.Date;
            if (ObjectHandler.GetAttendanceDL().UserAndDatePresentIntable(int.Parse(EmployeeIDCombo.Text), date))
            {
                //If Manual Marking is checked
                if (MarkAttenManuallyCheckbox.Checked)
                {
                    timeIn = DateTimePickerTimeIn.Value;
                    timeOut = DateTimePickerTimeOut.Value;
                }


                if(ObjectHandler.GetAttendanceDL().UpdateAttendance(int.Parse(EmployeeIDCombo.Text), date, timeIn, timeOut))
                {
                    MessageBox.Show("Attendance marked successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to mark attendance.");
                }
            }
            else
            {
                Attendance attendance = new Attendance(int.Parse(EmployeeIDCombo.Text), date.Date.ToString(), timeIn, timeOut);
                if (ObjectHandler.GetAttendanceDL().MarkAttendance(attendance))
                {
                    MessageBox.Show("Attendance marked successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to mark attendance.");
                }
            }
        }

        private void DateTimePickerTimeIn_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DateTimePickerTimeOut_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
