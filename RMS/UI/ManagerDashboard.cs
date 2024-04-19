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

namespace RMS.UI
{
    public partial class ManagerDashboard : Form
    {
        User manager;
        public ManagerDashboard(User manager)
        {
            this.manager = manager;
            InitializeComponent();
            InitializeInventory();
            InitializeCustomerDetails();
            InitializeAnalytics();
            InitializeFinancialTransactions();
            InitializeInbox();
        }

        private void InitializeInventory()
        {
            // Load all Item IDs for Combo Box
            List<int> itemIDs = ObjectHandler.GetItemDL().LoadItemsID();
            foreach (int itemID in itemIDs)
            {
                ItemIDCombo.Items.Add(itemID);
            }
        }

        private void InitializeCustomerDetails()
        {
            // Load all Customer IDs for Combo Box
            List<int> customerIDs = ObjectHandler.GetUserDL().LoadAllCustomerID();
            foreach (int customerID in customerIDs)
            {
                CustomerIDCombo.Items.Add(customerID);
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
            // Load all Usernames for Combo Box
            List<string> usernames = ObjectHandler.GetUserDL().LoadAllUsernames();
            foreach (string username in usernames)
            {
                UsernamesCombo.Items.Add(username);
            }
            UsernamesCombo.SelectedIndex = 0;

            // Load all the messages
            List<Inbox> messages = ObjectHandler.GetInboxDL().LoadMessagesByUserID(manager);
            messagesFlowPanel.Controls.Clear();
            foreach (Inbox message in messages)
            {
                messagesFlowPanel.Controls.Add(new Message(message));
            }
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
        }

        private void btnPersonalInfoManager_Click(object sender, EventArgs e)
        {
            showPanel(PersonalInfoMain);
        }

        private void btnInboxManager_Click(object sender, EventArgs e)
        {
            showPanel(InboxMainPanel);
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

            MessageBox.Show(username);

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
            string itemName = txtItemName.Text;
            string itemPrice = txtItemPrice.Text;
            string itemCost = txtCostOfPurchase.Text;
            byte[] itemImage = ItemPictureBox.Image != null ? ObjectHandler.GetUtilityDL().ImageToByteArray(ItemPictureBox.Image) : null;

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string itemID = ItemIDCombo.Text;
            string itemName = txtItemName.Text;
            string itemPrice = txtItemPrice.Text;
            string itemCost = txtCostOfPurchase.Text;
            byte[] itemImage = ItemPictureBox.Image != null ? ObjectHandler.GetUtilityDL().ImageToByteArray(ItemPictureBox.Image) : null;
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

        private void InventoryPanelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int itemID = Convert.ToInt32(ItemIDCombo.Text);

            if (ObjectHandler.GetItemDL().DeleteItem(itemID))
            {
                MessageBox.Show("Item deleted successfully.");
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
        }

        private void CustomerIDCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(CustomerIDCombo.Text);

            if (ObjectHandler.GetUserDL().DeleteUser(customerID))
            {
                MessageBox.Show("Customer deleted successfully.");
            }
            else
            {
                MessageBox.Show("Failed to delete customer.");
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            int reciever = Convert.ToInt32(CustomerIDCombo.Text);
            string message = txtMessage.Text;

            Inbox inbox = new Inbox(manager.getUserID(), reciever, message, DateTime.Now);

            if (ObjectHandler.GetInboxDL().SendMessage(inbox))
            {
                MessageBox.Show("Message sent successfully.");
            }
            else
            {
                MessageBox.Show("Failed to send message.");
            }
        }

        private void OrderPanelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
