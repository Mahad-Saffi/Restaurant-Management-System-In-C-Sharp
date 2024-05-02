using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLLForRMS.BL;
using DLLForRMS.DL;
using Guna.Charts.WinForms;

namespace RMS.UI
{
    public partial class ManagerDashboard : Form
    {
        User manager;
        public ManagerDashboard(User manager)
        {
            this.manager = manager;
            InitializeComponent();
            InitializeUpperBar(manager);

            InitializeInventory();
            InitializeOrders();
            InitializeCustomerDetails();
            InitializeAnalytics();
            InitializeFinancialTransactions();
            InitializeInbox();
            InitializePersonalInfo(manager);
        }

        private void InitializeUpperBar(User manager)
        {
            UpperBarUsername.Text = manager.getUsername();
            UpperBarPicBox.Image = ObjectHandler.GetUserDL().GetUserImageByUserID(manager.getUserID());
        }

        private void InitializeInventory()
        {
            ItemIDCombo.Items.Clear();
            // Load all Item IDs for Combo Box
            List<int> itemIDs = ObjectHandler.GetItemDL().LoadItemsID();
            if (itemIDs == null)
            {
                return;
            }

            foreach (int itemID in itemIDs)
            {
                ItemIDCombo.Items.Add(itemID);
            }

            // Load all the items for data grid view
            List<Item> items = ObjectHandler.GetItemDL().LoadItems();

            ManagerInventoryGridView.Columns.Clear();
            ManagerInventoryGridView.Columns.Add("ItemID", "Item ID");
            ManagerInventoryGridView.Columns.Add("ItemName", "Item Name");
            ManagerInventoryGridView.Columns.Add("ItemPrice", "Item Price");
            ManagerInventoryGridView.Columns.Add("CostOfPurchase", "Cost Of Purchase");

            ManagerInventoryGridView.Rows.Clear();
            foreach (Item item in items)
            {
                ManagerInventoryGridView.Rows.Add(item.getItemID(), item.getItemName(), item.getItemPrice(), item.getCostOfPurchase());
            }
        }

        private void InitializeOrders()
        {
            AmountTotalOrders.Text = "";
            AmountItemsSold.Text = "";
            AmountMostOrdersInDay.Text = "";
            nameBestItem.Text = "";

            double totalOrders = ObjectHandler.GetOrderDL().LoadOrders().Count;
            double itemsSold = ObjectHandler.GetOrderDL().GetTotalItemsSoldThisMonth();
            double mostOrdersInDay = ObjectHandler.GetOrderDL().GetMostOrdersInDay();
            string bestItem = ObjectHandler.GetOrderDL().GetBestItemThisMonth();

            AmountTotalOrders.Text = totalOrders.ToString();
            AmountItemsSold.Text = itemsSold.ToString();
            AmountMostOrdersInDay.Text = mostOrdersInDay.ToString();
            nameBestItem.Text = bestItem;

            List<Order> orders = ObjectHandler.GetOrderDL().LoadOrders();

            OrdersDataGridView.Columns.Clear();
            OrdersDataGridView.Columns.Add("CustomerID", "Customer ID");
            OrdersDataGridView.Columns.Add("OrderDate", "Order Date");
            OrdersDataGridView.Columns.Add("OrderType", "Order Type");
            OrdersDataGridView.Columns.Add("OrderStatus", "Order Status");
            OrdersDataGridView.Columns.Add("PaymentMethod", "Payment Method");
            OrdersDataGridView.Columns.Add("OrderAddress", "Order Address");

            OrdersDataGridView.Rows.Clear();
            foreach (Order order in orders)
            {
                OrdersDataGridView.Rows.Add(order.GetUserID(), order.GetOrderDate(), order.GetOrderType(), order.GetOrderStatus(), order.GetPaymentMethod(), order.GetOrderAddress());
            }
        }

        private void InitializeCustomerDetails()
        {
            CustomerIDCombo.Items.Clear();
            // Load all Customer IDs for Combo Box
            List<int> customerIDs = ObjectHandler.GetUserDL().LoadAllCustomerID();
            foreach (int customerID in customerIDs)
            {
                CustomerIDCombo.Items.Add(customerID);
            }

            // Load all the customers for data grid view
            List<User> users = ObjectHandler.GetUserDL().LoadAllUsers();

            CustomerDataGridView.Columns.Clear();
            CustomerDataGridView.Columns.Add("CustomerID", "Customer ID");
            CustomerDataGridView.Columns.Add("Username", "Username");
            CustomerDataGridView.Columns.Add("Email", "Email");
            CustomerDataGridView.Columns.Add("Phone", "Phone");
            CustomerDataGridView.Columns.Add("RegistrationDate", "Registration Date");

            CustomerDataGridView.Rows.Clear();
            foreach (User user in users)
            {
                if (user.getRole() == "customer")
                {
                    CustomerDataGridView.Rows.Add(user.getUserID(), user.getUsername(), user.getUserEmail(), user.getUserPhone(), user.getUserRegistrationDate());
                }
            }
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
                    txtTopItemsThisMonth.Text += item;
                }
                else
                    txtTopItemsThisMonth.Text += item + ", ";
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
            UsernamesCombo.SelectedIndex = -1;

            // Load all the messages
            List<Inbox> messages = ObjectHandler.GetInboxDL().LoadMessagesByUserID(manager);
            if (messages == null)
            {
                return;
            }
            messagesFlowPanel.Controls.Clear();
            foreach (Inbox message in messages)
            {
                messagesFlowPanel.Controls.Add(new Message(message));
            }
        }


        private void InitializePersonalInfo(User tempManager)
        {
            Employee manager = ObjectHandler.GetUserDL().GetEmployeeByEmployeeID(tempManager.getUserID());
            personalInfoManager.NameTextPersonalInfo = manager.getUsername();
            personalInfoManager.PassTextPersonalInfo = manager.getUserHashPassword();
            personalInfoManager.EmailTextPersonalInfo = manager.getUserEmail();
            personalInfoManager.ContactTextPersonalInfo = manager.getUserPhone().ToString();
            personalInfoManager.SinceTextPersonalInfo = manager.getUserRegistrationDate().ToString();
            personalInfoManager.RoleTextPersonalInfo = manager.getRole();
            personalInfoManager.SalaryTextPersonalInfo = manager.GetSalary().ToString();
        }

        private void showPanel(Panel panel)
        {
            ManagerMainPanel.Visible = true;
            ManagerSideBarMainPanel.Visible = true;

            InventoryPanelMain.Visible = false;
            OrderPanelMain.Visible = false;
            FinancialdataPanelMain.Visible = false;
            AnalyticsPanelMain.Visible = false;
            CustomerDetailsMainPanel.Visible = false;
            PersonalInfoMain.Visible = false;
            InboxMainPanel.Visible = false;

            panel.Visible = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            showPanel(InventoryPanelMain);
            InitializeInventory();
        }



        private void ManagerDashboard_Load(object sender, EventArgs e)
        {
            showPanel(InventoryPanelMain);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            showPanel(OrderPanelMain);
        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            showPanel(AnalyticsPanelMain);
        }

        private void btnFinancialData_Click(object sender, EventArgs e)
        {
            showPanel(FinancialdataPanelMain);
        }

        private void btnCustomerDetails_Click(object sender, EventArgs e)
        {
            showPanel(CustomerDetailsMainPanel);
            InitializeCustomerDetails();
        }

        private void btnPersonalInfoManager_Click(object sender, EventArgs e)
        {
            InitializePersonalInfo(manager);
            showPanel(PersonalInfoMain);
        }

        private void btnInboxManager_Click(object sender, EventArgs e)
        {
            showPanel(InboxMainPanel);
            InitializeInbox();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void personalInfoManager_Load(object sender, EventArgs e)
        {

        }

        private void InboxMainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text;
            string username = UsernamesCombo.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please select a Valid Reciever to send a message.");
                return;
            }
            else if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Please fill the message field.");
                return;
            }

            User reciever = ObjectHandler.GetUserDL().GetUserByUsername(username);

            Inbox inbox = new Inbox(manager.getUserID(), reciever.getUserID(), message, DateTime.Now);

            if (ObjectHandler.GetInboxDL().SendMessage(inbox))
            {
                txtMessage.Clear();
                MessageBox.Show("Message sent successfully.");
            }
            else
            {
                MessageBox.Show("Failed to send message.");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
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
                InitializeInventory();
            }
            else
            {
                MessageBox.Show("Failed to add item.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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
            byte[] imageBytes = ItemPictureBox.Image != null ? ObjectHandler.GetUtilityDL().ImageToByteArray(ItemPictureBox.Image) : null;

            if (imageBytes == null)
            {
                imageBytes = ObjectHandler.GetUtilityDL().ImageToByteArray(Properties.Resources.dish);
            }

            var item = new Item(Convert.ToInt32(itemID), itemName, Convert.ToDouble(itemPrice), Convert.ToDouble(itemCost), imageBytes);

            if (ObjectHandler.GetItemDL().UpdateItem(item))
            {
                MessageBox.Show("Item updated successfully.");
                InitializeInventory();
            }
            else
            {
                MessageBox.Show("Failed to update item.");
            }
        }

        private void InventoryPanelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ItemIDCombo.Text))
            {
                MessageBox.Show("Please select an item to delete.");
                return;
            }
            int itemID = Convert.ToInt32(ItemIDCombo.Text);

            if (ObjectHandler.GetItemDL().DeleteItem(itemID))
            {
                MessageBox.Show("Item deleted successfully.");
                ItemIDCombo.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Failed to delete item.");
            }
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ItemPictureBox.Image = new Bitmap(dialog.FileName);
                ItemPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
            if (ObjectHandler.GetValidations().ValidateInteger(ItemIDCombo.Text))
            {
                string query = "UPDATE Items SET Picture = @image WHERE ItemID = @ID";
                if (ObjectHandler.GetUtilityDL().SaveImage(ObjectHandler.GetUtilityDL().ImageToByteArray(ItemPictureBox.Image), query, Convert.ToInt32(ItemIDCombo.Text), "item"))
                {
                    MessageBox.Show("Item Image Updated successfully...");
                }
                else
                {
                    MessageBox.Show("Failed to update item image...");
                }
            }
        }

        private void CustomerIDCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CustomerIDCombo.Text))
            {
                MessageBox.Show("Please select a customer to delete.");
                return;
            }

            if (!ObjectHandler.GetValidations().ValidateInteger(CustomerIDCombo.Text))
            {
                MessageBox.Show("Please enter a valid customer ID.");
                return;
            }

            int customerID = Convert.ToInt32(CustomerIDCombo.Text);

            if (ObjectHandler.GetUserDL().DeleteUser(customerID))
            {
                MessageBox.Show("Customer deleted successfully.");
                CustomerIDCombo.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Failed to delete customer.");
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CustomerIDCombo.Text))
            {
                MessageBox.Show("Please select a Reciever to send a message.");
                return;
            }
            else if (string.IsNullOrEmpty(txtMessage.Text))
            {
                MessageBox.Show("Please fill the message field.");
                return;
            }

            int reciever = Convert.ToInt32(CustomerIDCombo.Text);
            string message = txtMessage.Text;

            Inbox inbox = new Inbox(manager.getUserID(), reciever, message, DateTime.Now);

            if (ObjectHandler.GetInboxDL().SendMessage(inbox))
            {
                MessageBox.Show("Message sent successfully.");
                txtMessage.Clear();
                CustomerIDCombo.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Failed to send message.");
            }
        }

        private void OrderPanelMain_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
