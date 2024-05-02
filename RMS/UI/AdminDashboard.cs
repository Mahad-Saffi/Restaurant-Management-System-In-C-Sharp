using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DLLForRMS.BL;
using DLLForRMS.DL;
using Guna.Charts.WinForms;

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
            InitializeUpperBar(admin);
            InitializeItemDetails();
            InitializeUserDetails();
            InitializeAnalytics();
            InitializeFinancialTransactions();
            InitializeInbox();
            InitializeFeedback();
            InitializeAttendance();
            InitializePersonalInfo(admin);
        }

        private void InitializeUpperBar(User admin)
        {
            UpperBarUsername.Text = admin.getUsername();
            UpperBarPicBox.Image = ObjectHandler.GetUserDL().GetUserImageByUserID(admin.getUserID());
        }

        private void InitializeItemDetails()
        {
            ItemIDCombo.Items.Clear();
            // Load all the Item IDs for Combo Box
            if (ObjectHandler.GetItemDL().LoadItemsID() == null)
            {
                return;
            }
            else
            {
                List<int> items = ObjectHandler.GetItemDL().LoadItemsID();
                foreach (int item in items)
                {
                    ItemIDCombo.Items.Add(item);
                }
            }

            // Fill the data grid view
            LoadItemDetailsToGridView(ItemDataGridView);

        }

        private void InitializeUserDetails()
        {
            UsersIDCombo.Items.Clear();
            // Load all the User IDs for Combo Box
            List<int> users = ObjectHandler.GetUserDL().LoadUsersID();
            foreach (int user in users)
            {
                UsersIDCombo.Items.Add(user);
            }

            // Fill the two lower text boxes
            txtTotalUsers.Text = ObjectHandler.GetUserDL().GetTotalUsers().ToString();
            txtRepeatingCustomers.Text = ObjectHandler.GetUserDL().GetRepeatingCustomers().ToString();

            //fill the data grid view
            LoadUserDataGridView(UsersDataGridView);
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
            UsernamesCombo.Items.Clear();
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

        private void InitializeFeedback()
        {
            txtTotalFeedbacks.Clear();
            txtPositiveFeedbbacks.Clear();
            txtNegativeFeedbacks.Clear();

            // Load all the feedbacks
            List<int> feedbacks = ObjectHandler.GetFeedbackDL().LoadAllFeedbacks();
            int positiveFeedbacks = 0;
            int negativeFeedbacks = 0;
            int totalFeedbacks = feedbacks.Count;

            foreach (int feedback in feedbacks)
            {
                if (feedback >= 3)
                {
                    positiveFeedbacks++;
                }
                else
                {
                    negativeFeedbacks++;
                }
            }

            txtTotalFeedbacks.Text = totalFeedbacks.ToString();
            txtPositiveFeedbbacks.Text = positiveFeedbacks.ToString();
            txtNegativeFeedbacks.Text = negativeFeedbacks.ToString();
        }

        private void InitializeAttendance()
        {
            EmployeeIDCombo.Items.Clear();
            //Load All employee ID's for Combo Box
            List<int> employeeID = ObjectHandler.GetUserDL().GetAllEmployeeID();
            foreach (int id in employeeID)
            {
                EmployeeIDCombo.Items.Add(id);
            }

            //Fill the data grid view
            LoadAttendanceDataGridView(AttendanceDataGridView);
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

        private void LoadItemDetailsToGridView(DataGridView dataGridView)
        {
            List<Item> allItems = ObjectHandler.GetItemDL().LoadItems();

            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("ItemID", "Item ID");
            dataGridView.Columns.Add("ItemName", "Item Name");
            dataGridView.Columns.Add("ItemPrice", "Item Price");
            dataGridView.Columns.Add("ItemCost", "Item Cost");

            dataGridView.Rows.Clear();
            foreach (Item item in allItems)
            {
                dataGridView.Rows.Add(item.getItemID(), item.getItemName(), item.getItemPrice(), item.getCostOfPurchase());
            }
        }

        private void LoadUserDataGridView(DataGridView dataGridView)
        {
            List<User> allUsers = ObjectHandler.GetUserDL().LoadAllUsers();

            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("UserID", "User ID");
            dataGridView.Columns.Add("Username", "Username");
            dataGridView.Columns.Add("Role", "Role");
            dataGridView.Columns.Add("Email", "Email");
            dataGridView.Columns.Add("Phone", "Phone");
            dataGridView.Columns.Add("RegistrationDate", "Registration Date");
            dataGridView.Columns.Add("Salary", "Salary");

            dataGridView.Rows.Clear();
            foreach (User user in allUsers)
            {
                if (user.getRole() == "manager" || user.getRole() == "rider")
                {
                    Employee employee = ObjectHandler.GetUserDL().GetEmployeeByEmployeeID(user.getUserID());
                    dataGridView.Rows.Add(employee.getUserID(), employee.getUsername(), employee.getRole(), employee.getUserEmail(), employee.getUserPhone(), employee.getUserRegistrationDate(), employee.GetSalary());
                }
                else
                {
                    dataGridView.Rows.Add(user.getUserID(), user.getUsername(), user.getRole(), user.getUserEmail(), user.getUserPhone(), user.getUserRegistrationDate(), 0);
                }
            }
        }

        private void LoadAttendanceDataGridView(DataGridView dataGridView)
        {
            List<User> users = ObjectHandler.GetUserDL().LoadAllUsers();

            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("UserID", "User ID");
            dataGridView.Columns.Add("Username", "Username");
            dataGridView.Columns.Add("Role", "Role");
            dataGridView.Columns.Add("Email", "Email");
            dataGridView.Columns.Add("Phone", "Phone");
            dataGridView.Columns.Add("RegistrationDate", "Registration Date");
            dataGridView.Columns.Add("Salary", "Salary");

            dataGridView.Rows.Clear();
            foreach (User user in users)
            {
                if (user.getRole() == "manager" || user.getRole() == "rider")
                {
                    Employee employee = ObjectHandler.GetUserDL().GetEmployeeByEmployeeID(user.getUserID());
                    dataGridView.Rows.Add(employee.getUserID(), employee.getUsername(), employee.getRole(), employee.getUserEmail(), employee.getUserPhone(), employee.getUserRegistrationDate(), employee.GetSalary());
                }
            }
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
            // TODO: This line of code loads data into the 'rMSDatabaseDataSet.Items' table. You can move, or remove it, as needed.
        }

        private void showPanel(Panel panel)
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
                UserPicturebox.SizeMode = PictureBoxSizeMode.Zoom;
            }

            if (ObjectHandler.GetValidations().ValidateInteger(UsersIDCombo.Text))
            {
                string query = "UPDATE Users SET Picture = @image WHERE UserID = @ID";
                if (ObjectHandler.GetUtilityDL().SaveImage(ObjectHandler.GetUtilityDL().ImageToByteArray(UserPicturebox.Image), query, Convert.ToInt32(UsersIDCombo.Text), "user"))
                {
                    MessageBox.Show("User Image Updated successfully...");
                }
                else
                {
                    MessageBox.Show("Failed to update user image...");
                }
            }
        }

        private void UserDetailsMainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (!ObjectHandler.GetValidations().ValidateDouble(txtItemPrice.Text) || !ObjectHandler.GetValidations().ValidateDouble(txtCostOfPurchase.Text))
            {
                MessageBox.Show("Please enter valid inputs...");
                txtItemPrice.Clear();
                txtCostOfPurchase.Clear();
                return;
            }

            string itemName = txtItemName.Text;
            string itemPrice = txtItemPrice.Text;
            string itemCost = txtCostOfPurchase.Text;

            var item = new Item(itemName, Convert.ToDouble(itemPrice), Convert.ToDouble(itemCost));

            if (ObjectHandler.GetItemDL().AddItem(item))
            {
                Item tempItem = ObjectHandler.GetItemDL().LoadLastItem();
                string query = "UPDATE Items SET Picture = @image WHERE ItemID = @ID";
                if (ObjectHandler.GetUtilityDL().SaveImage(ObjectHandler.GetUtilityDL().ImageToByteArray(Properties.Resources.dish), query, tempItem.getItemID(), "item"))
                {
                    MessageBox.Show("Item added successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to add item image.");
                }
                InitializeItemDetails();
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
            if (ObjectHandler.GetValidations().ValidateInteger(ItemIDCombo.Text))
            {
                string query = "UPDATE Items SET Picture = @image WHERE ItemID = @ID";
                if (ObjectHandler.GetUtilityDL().SaveImage(ObjectHandler.GetUtilityDL().ImageToByteArray(ItemPicturebox.Image), query, Convert.ToInt32(ItemIDCombo.Text), "item"))
                {
                    MessageBox.Show("Item Image Updated successfully...");
                }
                else
                {
                    MessageBox.Show("Failed to update item image...");
                }
            }
        }

        private void btnUpdateItem_Click(object sender, EventArgs e)
        {
            if (!ObjectHandler.GetValidations().ValidateDouble(txtItemPrice.Text) || !ObjectHandler.GetValidations().ValidateDouble(txtCostOfPurchase.Text) || !ObjectHandler.GetValidations().ValidateInteger(ItemIDCombo.Text))
            {
                MessageBox.Show("Please enter valid inputs...");
                txtItemPrice.Clear();
                txtCostOfPurchase.Clear();
                ItemIDCombo.Text = "";
                return;
            }

            string itemID = ItemIDCombo.Text;
            string itemName = txtItemName.Text;
            string itemPrice = txtItemPrice.Text;
            string itemCost = txtCostOfPurchase.Text;
            byte[] imageBytes = ItemPicturebox.Image != null ? ObjectHandler.GetUtilityDL().ImageToByteArray(ItemPicturebox.Image) : null;

            if (imageBytes == null)
            {
                imageBytes = ObjectHandler.GetUtilityDL().ImageToByteArray(Properties.Resources.dish);
            }

            var item = new Item(Convert.ToInt32(itemID), itemName, Convert.ToDouble(itemPrice), Convert.ToDouble(itemCost), imageBytes);

            if (ObjectHandler.GetItemDL().UpdateItem(item))
            {
                MessageBox.Show("Item updated successfully.");
                InitializeItemDetails();
            }
            else
            {
                MessageBox.Show("Failed to update item.");
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (!ObjectHandler.GetValidations().ValidateInteger(ItemIDCombo.Text))
            {
                MessageBox.Show("Please enter valid inputs...");
                ItemIDCombo.Text = "";
                return;
            }

            string itemID = ItemIDCombo.Text;

            if (ObjectHandler.GetItemDL().DeleteItem(Convert.ToInt32(itemID)))
            {
                MessageBox.Show("Item deleted successfully.");
                InitializeItemDetails();
            }
            else
            {
                MessageBox.Show("Failed to delete item.");
            }
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            //Validations
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtUserPassword.Text) || string.IsNullOrEmpty(comboRole.Text))
            {
                MessageBox.Show("Please fill all the fields.");
                return;
            }
            else if (!ObjectHandler.GetValidations().ValidateString(comboRole.Text))
            {
                MessageBox.Show("Invalid Role.");
                comboRole.Text = "";
                return;
            }
            else if (ObjectHandler.GetValidations().ValidateContactNumber(txtContact.Text) == "false")
            {
                MessageBox.Show("Invalid Phone Number.");
                txtContact.Clear();
                return;
            }
            else if (!ObjectHandler.GetValidations().ValidateEmail(txtEmail.Text))
            {
                MessageBox.Show("Invalid Email.");
                txtEmail.Clear();
                return;
            }
            else if (!ObjectHandler.GetValidations().ValidateDouble(txtSalary.Text))
            {
                MessageBox.Show("Invalid Salary.");
                txtSalary.Clear();
                return;
            }

            string username = txtUsername.Text.ToLower();
            string password = ObjectHandler.GetUserDL().HashPassword(txtUserPassword.Text);
            string email = txtEmail.Text;
            long phone = Convert.ToInt64(ObjectHandler.GetValidations().ValidateContactNumber(txtContact.Text));
            string role = comboRole.Text.ToLower();
            double salary = Convert.ToDouble(txtSalary.Text);
            byte[] userPicture = UserPicturebox.Image != null ? ObjectHandler.GetUtilityDL().ImageToByteArray(UserPicturebox.Image) : null;


            if (role.ToLower() == "admin")
            {
                Admin adminTobeAdded = new Admin(username, password, role, email, phone, DateTime.Now, userPicture);
                if (ObjectHandler.GetUserDL().AddUserData(adminTobeAdded))
                {
                    User tempUser = ObjectHandler.GetUserDL().GetUserByUsername(username);
                    string query = "UPDATE Users SET Picture = @image WHERE UserID = @ID";
                    if (ObjectHandler.GetUtilityDL().SaveImage(ObjectHandler.GetUtilityDL().ImageToByteArray(Properties.Resources.user), query, tempUser.getUserID(), "user"))
                    {
                        MessageBox.Show("Admin added successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to Add user image");
                    }
                    InitializeUserDetails();
                }
                else
                {
                    MessageBox.Show("Username already present...\nPlease try a different username...");
                }
            }
            else if (role.ToLower() == "manager" || role.ToLower() == "rider")
            {
                Employee employee = new Employee(username, password, role, email, phone, DateTime.Now, salary, userPicture);
                if(ObjectHandler.GetUserDL().AddUserData(employee))
                {
                    User tempUser = ObjectHandler.GetUserDL().GetUserByUsername(username);
                    string query = "UPDATE Users SET Picture = @image WHERE UserID = @ID";
                    if (ObjectHandler.GetUtilityDL().SaveImage(ObjectHandler.GetUtilityDL().ImageToByteArray(Properties.Resources.user), query, tempUser.getUserID(), "user"))
                    {
                        MessageBox.Show("Employee added successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to Add user image");
                    }
                    InitializeUserDetails();
                }
                else
                {
                    MessageBox.Show("Username already present...\nPlease try a different username...");
                }
            }
            else if (role.ToLower() == "customer")
            {
                Customer customer = new Customer(username, password, role, email, phone, DateTime.Now, userPicture);
                if(ObjectHandler.GetUserDL().AddUserData(customer))
                {
                    User tempUser = ObjectHandler.GetUserDL().GetUserByUsername(username);
                    string query = "UPDATE Users SET Picture = @image WHERE UserID = @ID";
                    if (ObjectHandler.GetUtilityDL().SaveImage(ObjectHandler.GetUtilityDL().ImageToByteArray(Properties.Resources.user), query, tempUser.getUserID(), "user"))
                    {
                        MessageBox.Show("Customer added successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to Add user image");
                    }
                    InitializeUserDetails();
                }
                else
                {
                    MessageBox.Show("Username already present...\nPlease try a different username...");
                }
            }
        }

        private void btnItemDetails_Click(object sender, EventArgs e)
        {
            InitializeItemDetails();
            showPanel(ItemDetailsMainPanel);
        }

        private void btnUserDetails_Click(object sender, EventArgs e)
        {
            InitializeUserDetails();
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
            InitializeInbox();
            showPanel(InboxMainPanel);
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            showPanel(FeedbackMainPanel);
        }

        private void btnCheckAttendance_Click(object sender, EventArgs e)
        {
            InitializeAttendance();
            showPanel(AttendanceMainPanel);
        }

        private void btnPersonalInfo_Click(object sender, EventArgs e)
        {
            InitializePersonalInfo(admin);
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
            //Validations
            if (string.IsNullOrEmpty(txtMessage.Text))
            {
                MessageBox.Show("Please enter a message.");
                return;
            }
            else if (ObjectHandler.GetValidations().ValidateString(UsernamesCombo.Text))
            {
                MessageBox.Show("Invalid Username.");
                UsernamesCombo.Text = "";
                return;
            }

            string message = txtMessage.Text;
            string username = UsernamesCombo.Text;

            User reciever = ObjectHandler.GetUserDL().GetUserByUsername(username);
            Inbox inbox = new Inbox(admin.getUserID(), reciever.getUserID(), message, DateTime.Now);

            if (ObjectHandler.GetInboxDL().SendMessage(inbox))
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
            if (!ObjectHandler.GetValidations().ValidateInteger(UsersIDCombo.Text))
            {
                MessageBox.Show("Please enter a valid User ID.");
                UsersIDCombo.Text = "";
                return;
            }
            int userID = Convert.ToInt32(UsersIDCombo.Text);

            if (ObjectHandler.GetUserDL().DeleteUser(userID))
            {
                MessageBox.Show("User deleted Successfully!");
            }
            else
            {
                MessageBox.Show("Failed to delete the user!");
                InitializeUserDetails();
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (!ObjectHandler.GetValidations().ValidateInteger(UsersIDCombo.Text))
            {
                MessageBox.Show("Please enter a valid User ID.");
                UsersIDCombo.Text = "";
                return;
            }
            else if (!ObjectHandler.GetValidations().ValidateEmail(txtEmail.Text))
            {
                MessageBox.Show("Invalid Email Address.");
                txtEmail.Clear();
                return;
            }
            else if (ObjectHandler.GetValidations().ValidateContactNumber(txtContact.Text) == "false")
            {
                MessageBox.Show("Invalid Phone Number.");
                txtContact.Clear();
                return;
            }
            else if (!ObjectHandler.GetValidations().ValidateDouble(txtSalary.Text))
            {
                MessageBox.Show("Invalid Salary.");
                txtSalary.Clear();
                return;
            }
            else if (!ObjectHandler.GetValidations().ValidateString(comboRole.Text))
            {
                MessageBox.Show("Invalid Role.");
                comboRole.Text = "";
                return;
            }



            int userID = Convert.ToInt32(UsersIDCombo.Text);
            string username = txtUsername.Text;
            string password = ObjectHandler.GetUserDL().HashPassword(txtUserPassword.Text);
            string email = txtEmail.Text;
            long phone = Convert.ToInt64(ObjectHandler.GetValidations().ValidateContactNumber(txtContact.Text));
            string role = comboRole.Text.ToLower();
            double salary = Convert.ToDouble(txtSalary.Text);

            if (role.ToLower() == "admin")
            {
                Admin adminTobeAdded = new Admin(userID, username, password, role, email, phone, DateTime.Now);
                if(ObjectHandler.GetUserDL().UpdateUser(adminTobeAdded))
                {
                    MessageBox.Show("Admin updated successfully.");
                    InitializeUserDetails();
                }
                else
                {
                    MessageBox.Show("Failed to update admin.");
                }
            }
            else if (role.ToLower() == "manager" || role.ToLower() == "rider")
            {
                Employee employee = new Employee(userID, username, password, role, email, phone, DateTime.Now, salary);
                if(ObjectHandler.GetUserDL().UpdateUser(employee))
                {
                    MessageBox.Show("Employee updated successfully.");
                    InitializeUserDetails();
                }
                else
                {
                    MessageBox.Show("Failed to update employee.");
                }
            }
            else if (role.ToLower() == "customer")
            {
                Customer customer = new Customer(userID, username, password, role, email, phone, DateTime.Now);
                if(ObjectHandler.GetUserDL().UpdateUser(customer))
                {
                    MessageBox.Show("Customer updated successfully.");
                    InitializeUserDetails();
                }
                else
                {
                    MessageBox.Show("Failed to update customer.");
                }
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
            DateTime date = DateTime.Now.Date;
            if (!ObjectHandler.GetValidations().ValidateInteger(EmployeeIDCombo.Text))
            {
                MessageBox.Show("Please enter a valid Employee ID.");
                EmployeeIDCombo.Text = "";
                return;
            }


            if (ObjectHandler.GetAttendanceDL().UserAndDatePresentIntable(int.Parse(EmployeeIDCombo.Text), date))
            {
                //If Manual Marking is checked
                if (MarkAttenManuallyCheckbox.Checked)
                {
                    timeIn = DateTimePickerTimeIn.Value;
                    timeOut = DateTimePickerTimeOut.Value;
                }


                if (ObjectHandler.GetAttendanceDL().UpdateAttendance(int.Parse(EmployeeIDCombo.Text), date, timeIn, timeOut))
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

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            //Validation
            if (!ObjectHandler.GetValidations().ValidateInteger(EmployeeIDCombo.Text))
            {
                MessageBox.Show("Please enter a valid Employee ID.");
                EmployeeIDCombo.Text = "";
                return;
            }
            int selectedEmployeeID = Convert.ToInt32(EmployeeIDCombo.Text);

            var EmployeeAttendanceCheckerForm = new UserAttendanceCheckerForm(selectedEmployeeID);
            EmployeeAttendanceCheckerForm.Show();
        }

        
        private void TotalOrdersThisMonthChart_Load(object sender, EventArgs e)
        {

            //Create a new dataset 
            var dataset = new GunaScatterDataset();
            dataset.PointStyle = PointStyle.Rect;
            dataset.Label = "Total Orders This Month";
            var r = new Random();
            for (int i = 0; i < 30; i++)
            {
                //random number
                int x = i;
                int y = r.Next(10, 100);

                dataset.DataPoints.Add(x, y);
            }

            //Add a new dataset to a chart.Datasets
            TotalOrdersThisMonthChart.Datasets.Add(dataset);

            //An update was made to re-render the chart
            TotalOrdersThisMonthChart.Update();

        }

        private void TypeOfOrdersChart_Load(object sender, EventArgs e)
        {

            List<Order> orders = ObjectHandler.GetOrderDL().LoadOrders();
            int cash = 0;
            int jazzCash = 0;
            int easyPaisa = 0;
            int card = 0;

            foreach (Order order in orders)
            {
                if (order.GetPaymentMethod() == "Cash")
                {
                    cash++;
                }
                else if (order.GetPaymentMethod() == "JazzCash")
                {
                    jazzCash++;
                }
                else if (order.GetPaymentMethod() == "EasyPaisa")
                {
                    easyPaisa++;
                }
                else if (order.GetPaymentMethod() == "Card")
                {
                    card++;
                }
            }

            string[] paymentMethods = { "Cash", "JazzCash", "EasyPaisa", "Card" };

            //Chart configuration  
            TypeOfOrdersChart.Legend.Position = LegendPosition.Right;
            TypeOfOrdersChart.XAxes.Display = false;
            TypeOfOrdersChart.YAxes.Display = false;

            //Create a new dataset 
            var dataset = new GunaPieDataset();
            dataset.Label = "Payment Methods";
            dataset.DataPoints.Add(paymentMethods[0], cash);
            dataset.DataPoints.Add(paymentMethods[1], jazzCash);
            dataset.DataPoints.Add(paymentMethods[2], easyPaisa);
            dataset.DataPoints.Add(paymentMethods[3], card);

            //Add a new dataset to a chart.Datasets
            TypeOfOrdersChart.Datasets.Add(dataset);

            //An update was made to re-render the chart
            TypeOfOrdersChart.Update();

        }

        private void SalesAndPurchasesChart_Load(object sender, EventArgs e)
        {

            int orders = ObjectHandler.GetOrderDL().GetTotalItemsSoldThisMonth();
            List<Item> items = ObjectHandler.GetItemDL().LoadItems();
            string[] type = { "Sales", "Purchases" };

            //Chart configuration 
            SalesAndPurchasesChart.YAxes.GridLines.Display = false;

            //Create a new dataset 
            var dataset = new GunaSteppedAreaDataset();
            dataset.Label = "Sales and Purchases";

            dataset.DataPoints.Add(type[0], orders);
            dataset.DataPoints.Add(type[1], items.Count);

            dataset.PointRadius = 5;
            dataset.PointFillColors = ChartUtils.Colors(type.Length, Color.OrangeRed);
            dataset.PointBorderColors = dataset.PointFillColors;

            //Add a new dataset to a chart.Datasets
            SalesAndPurchasesChart.Datasets.Add(dataset);

            //An update was made to re-render the chart
            SalesAndPurchasesChart.Update();

        }

        private void FeedbackChart_Load(object sender, EventArgs e)
        {

            List<int> feedbacks = ObjectHandler.GetFeedbackDL().LoadAllFeedbacks();
            string[] ratings = { "1 Star", "2 Star", "3 Star", "4 Star", "5 Star" };

            int star1 = 0;
            int star2 = 0;
            int star3 = 0;
            int star4 = 0;
            int star5 = 0;
            foreach (int feedback in feedbacks)
            {
                if (feedback == 1)
                {
                    star1++;
                }
                else if (feedback == 2)
                {
                    star2++;
                }
                else if (feedback == 3)
                {
                    star3++;
                }
                else if (feedback == 4)
                {
                    star4++;
                }
                else if (feedback == 5)
                {
                    star5++;
                }
            }

            //Chart configuration 
            FeedbackChart.YAxes.GridLines.Display = false;

            //Create a new dataset 
            var dataset = new GunaHorizontalBarDataset();
            dataset.Label = "Feedbacks";

            dataset.DataPoints.Add(ratings[0], star1);
            dataset.DataPoints.Add(ratings[1], star2);
            dataset.DataPoints.Add(ratings[2], star3);
            dataset.DataPoints.Add(ratings[3], star4);
            dataset.DataPoints.Add(ratings[4], star5);

            //Add a new dataset to a chart.Datasets
            FeedbackChart.Datasets.Add(dataset);

            //An update was made to re-render the chart
            FeedbackChart.Update();

        }
    }
}
