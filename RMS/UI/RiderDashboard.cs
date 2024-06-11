using Guna.Charts.WinForms;
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
using System.Threading;
using System.Diagnostics.Contracts;

namespace RMS.UI
{
    public partial class RiderDashboard : Form
    {
        private Order acceptedOrder;
        private User rider;
        private int selectedOrderID = 0;
        public RiderDashboard(User rider)
        {
            this.rider = rider;
            InitializeComponent();
            InitializeUpperBar(rider);
            InitializeActiveOrders();
            InitializeDeliveryStatus();
            InitializeInbox();
            InitializePersonalInfo(rider);
        }

        private void InitializeUpperBar(User rider)
        {
            UpperBarUsername.Text = rider.getUsername();
            UpperBarPicBox.Image = ObjectHandler.GetUserDL().GetUserImageByUserID(rider.getUserID());
        }

        private void InitializeActiveOrders()
        {
            ComboOrderID.Items.Clear();
            List<Order> orders = ObjectHandler.GetOrderDL().LoadOrders();

            foreach (Order order in orders)
            {
                ComboOrderID.Items.Add(order.GetOrderID());
            }

            LoadAllOrdersDataGridView(AllOrdersDataGridView);
        }

        private void InitializeDeliveryStatus()
        {
            txtOrderID.Clear();
            txtOrderItems.Clear();
            txtRecievablePayment.Clear();

            // Load The accepted order
            acceptedOrder = ObjectHandler.GetOrderDL().LoadAcceptedOrderByRiderID(rider.getUserID());

            
            if (acceptedOrder == null)
            {
                //If there is no accepted order
                txtOrderID.Text = "N/A";
                txtOrderItems.Text = "N/A";
                return;
            }
            else
            {
                //If there is an accepted order

                selectedOrderID = acceptedOrder.GetOrderID();

                Order order = ObjectHandler.GetOrderDL().LoadOrderByOrderID(selectedOrderID);
                List<OrderDetails> orderItems = ObjectHandler.GetOrderDL().GetOrderDetails(selectedOrderID);

                txtOrderID.Text = order.GetOrderID().ToString();
                foreach (OrderDetails orderItem in orderItems)
                {
                    Item item = ObjectHandler.GetItemDL().LoadItemByItemID(orderItem.GetItemID());
                    if (orderItems.IndexOf(orderItem) == orderItems.Count - 1)
                    {
                        txtOrderItems.Text += item.getItemName();
                    }
                    else
                    {
                        txtOrderItems.Text += item.getItemName() + ", ";
                    }
                }
                txtRecievablePayment.Text = order.GetTotalAmount().ToString();
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
            UsernamesCombo.SelectedIndex = 0;

            // Load all the messages
            List<Inbox> messages = ObjectHandler.GetInboxDL().LoadMessagesByUserID(rider);
            messagesFlowPanel.Controls.Clear();
            foreach (Inbox message in messages)
            {
                messagesFlowPanel.Controls.Add(new Message(message));
            }
        }

        private void InitializePersonalInfo(User tempRider)
        {
            Employee rider = ObjectHandler.GetUserDL().GetEmployeeByEmployeeID(tempRider.getUserID());
            personalInfoRider.NameTextPersonalInfo = rider.getUsername();
            personalInfoRider.PassTextPersonalInfo = rider.getUserHashPassword();
            personalInfoRider.EmailTextPersonalInfo = rider.getUserEmail();
            personalInfoRider.ContactTextPersonalInfo = rider.getUserPhone().ToString();
            personalInfoRider.SinceTextPersonalInfo = rider.getUserRegistrationDate().ToString();
            personalInfoRider.RoleTextPersonalInfo = rider.getRole();
            personalInfoRider.SalaryTextPersonalInfo = rider.GetSalary().ToString();
        }

        private void showPanel(Panel panel)
        {
            RiderPanelMain.Visible = true;
            RiderSideBarMainPanel.Visible = true;

            OrderHistoryMain.Visible = false;
            OrdersMain.Visible = false;
            DeliveryStatusMain.Visible = false;
            EarningTrackerMain.Visible = false;
            PersonalInfoMain.Visible = false;
            InboxMainPanel.Visible = false;

            panel.Visible = true;
        }

        private void LoadAllOrdersDataGridView(DataGridView dataGridView)
        {
            List<Order> orders = ObjectHandler.GetOrderDL().LoadOrders();

            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("OrderID", "Order ID");          //columns names
            dataGridView.Columns.Add("OrderType", "Order Type");
            dataGridView.Columns.Add("OrderStatus", "Order Status");
            dataGridView.Columns.Add("OrderDate", "Order Date");
            dataGridView.Columns.Add("OrderAddress", "Order Address");
            dataGridView.Columns.Add("OrderTip", "Order Tip");
            dataGridView.Columns.Add("OrderTotalAmount", "Order Total Amount");

            dataGridView.Rows.Clear();
            foreach (Order order in orders)
            {
                dataGridView.Rows.Add(order.GetOrderID(), order.GetOrderType(), order.GetOrderStatus(), order.GetOrderDate(), order.GetAddress(), order.GetTip(), order.GetTotalAmount());
            }
        }

        private void LabelOrders_Click(object sender, EventArgs e)
        {

        }

        public void Example(GunaChart chart)
        {
            List<Order> orders = ObjectHandler.GetOrderDL().LoadRiderOrdersByRiderID(rider.getUserID());
            //Create a new dataset 
            var dataset = new GunaBubbleDataset();

            for (int i = 0; i < orders.Count; i++)
            {
                //random number
                int radius = 10;
                int x = i + 1;
                int y = Convert.ToInt32(orders[i].GetTotalAmount());

                dataset.DataPoints.Add(radius, x, y);
            }

            dataset.Label = "Orders In a Week";
            dataset.FillColors.Add(Color.FromArgb(255, 192, 192, 192));
            dataset.BorderColors.Add(Color.FromArgb(255, 0, 0, 0));
            dataset.BorderWidth = 1/2;

            //Add a new dataset to a chart.Datasets
            chart.Datasets.Add(dataset);

            //An update was made to re-render the chart
            chart.Update();
        }


        private void OrderHistoryChart_Load(object sender, EventArgs e)
        {
            Example(OrderHistoryChart);
        }

        private void OrderHistoryMain_Paint(object sender, PaintEventArgs e)
        {

        }

        public void Tip(GunaChart chart)
        {
            List<Order> orders = ObjectHandler.GetOrderDL().LoadRiderOrdersByRiderID(rider.getUserID());
            //Chart configuration
            chart.Title.Text = "Tip In a Week";
            chart.Legend.Position = LegendPosition.Right;
            chart.XAxes.Display = false;
            chart.YAxes.Display = false;

            //Create a new dataset 
            var datasetMonday = new GunaDoughnutDataset();
            var datasetTuesday = new GunaDoughnutDataset();
            var datasetWednesday = new GunaDoughnutDataset();
            var datasetThursday = new GunaDoughnutDataset();
            var datasetFriday = new GunaDoughnutDataset();
            var datasetSaturday = new GunaDoughnutDataset();
            var datasetSunday = new GunaDoughnutDataset();

            foreach(Order order in orders)
            {
                if (order.GetOrderDate().DayOfWeek == DayOfWeek.Monday)
                {
                    datasetMonday.DataPoints.Add("Monday", Convert.ToInt32(order.GetTip()));
                }
                else if (order.GetOrderDate().DayOfWeek == DayOfWeek.Tuesday)
                {
                    datasetTuesday.DataPoints.Add("Tuesday", Convert.ToInt32(order.GetTip()));
                }
                else if (order.GetOrderDate().DayOfWeek == DayOfWeek.Wednesday)
                {
                    datasetWednesday.DataPoints.Add("Wednesday", Convert.ToInt32(order.GetTip()));
                }
                else if (order.GetOrderDate().DayOfWeek == DayOfWeek.Thursday)
                {
                    datasetThursday.DataPoints.Add("Thursday", Convert.ToInt32(order.GetTip()));
                }
                else if (order.GetOrderDate().DayOfWeek == DayOfWeek.Friday)
                {
                    datasetFriday.DataPoints.Add("Friday", Convert.ToInt32(order.GetTip()));
                }
                else if (order.GetOrderDate().DayOfWeek == DayOfWeek.Saturday)
                {
                    datasetSaturday.DataPoints.Add("Saturday", Convert.ToInt32(order.GetTip()));
                }
                else if (order.GetOrderDate().DayOfWeek == DayOfWeek.Sunday)
                {
                    datasetSunday.DataPoints.Add("Sunday", Convert.ToInt32(order.GetTip()));
                }
            }

            datasetMonday.Label = "Monday";
            datasetMonday.FillColors.Add(Color.FromArgb(69, 179, 224));
            datasetTuesday.Label = "Tuesday";
            datasetTuesday.FillColors.Add(Color.FromArgb(80, 187, 229));
            datasetWednesday.Label = "Wednesday";
            datasetWednesday.FillColors.Add(Color.FromArgb(120, 199, 233));
            datasetThursday.Label = "Thursday";
            datasetThursday.FillColors.Add(Color.FromArgb(135, 206, 235));
            datasetFriday.Label = "Friday";
            datasetFriday.FillColors.Add(Color.FromArgb(201, 233, 246));
            datasetSaturday.Label = "Saturday";
            datasetSaturday.FillColors.Add(Color.FromArgb(214, 237, 247));
            datasetSunday.Label = "Sunday";
            datasetSunday.FillColors.Add(Color.FromArgb(220, 240, 249));

            //Add a new dataset to a chart.Datasets
            chart.Datasets.Add(datasetMonday);
            chart.Datasets.Add(datasetTuesday);
            chart.Datasets.Add(datasetWednesday);
            chart.Datasets.Add(datasetThursday);
            chart.Datasets.Add(datasetFriday);
            chart.Datasets.Add(datasetSaturday);
            chart.Datasets.Add(datasetSunday);

            //An update was made to re-render the chart
            chart.Update();
        }


        private void gunaChart1_Load(object sender, EventArgs e)
        {
            Tip(gunaChart1);
        }

        public void Earning(GunaChart chart)
        {
            Employee userRider = ObjectHandler.GetUserDL().GetEmployeeByEmployeeID(rider.getUserID());

            DateTime userRegDate = userRider.getUserRegistrationDate();
            int userRegMonth = userRegDate.Month;
            int userRegYear = userRegDate.Year;

            // Get the current month and year
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;

            // Initialize an array to store earnings for each month
            int[] earningsByMonth = new int[12];

            // Calculate earnings for each month from the registration month to the current month
            for (int month = 1; month <= 12; month++)
            {
                // Check if the month is before the registration month or in the future
                if ((currentYear < userRegYear || (currentYear == userRegYear && month < userRegMonth)) ||
                    (currentYear == userRegYear && month > currentMonth))
                {
                    // If so, set earnings to 0
                    earningsByMonth[month - 1] = 0;
                }
                else
                {
                    // Otherwise, calculate earnings (assuming you have a method for this)
                    earningsByMonth[month - 1] = CalculateEarningsForMonth(userRider, month, currentYear);
                }
            }

            // Chart configuration 
            chart.YAxes.GridLines.Display = false;

            // Create a new dataset 
            var dataset = new GunaLineDataset();
            dataset.PointRadius = 10;
            dataset.PointStyle = PointStyle.Circle;
            dataset.Label = "Earnings";

            // Add earnings data to the dataset
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            for (int i = 0; i < 12; i++)
            {
                dataset.DataPoints.Add(months[i], earningsByMonth[i]);
            }

            // Add a new dataset to the chart's datasets
            chart.Datasets.Add(dataset);

            // An update was made to re-render the chart
            chart.Update();
        }

        private int CalculateEarningsForMonth(Employee rider, int month, int year)
        {
            //Return salary of rider + the tip he got from the orders
            List<Order> orders = ObjectHandler.GetOrderDL().LoadRiderOrdersByRiderID(rider.getUserID());
            double tip = 0;
            foreach (Order order in orders)
            {
                if (order.GetOrderDate().Month == month && order.GetOrderDate().Year == year)
                {
                    tip += order.GetTip();
                }
            }
            //Return the total earnings
            return Convert.ToInt32(rider.GetSalary() + tip);
        }


        private void gunaChart2_Load(object sender, EventArgs e)
        {
            Earning(EarningDuringWholeYearChart);
        }

        private void AddressLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (selectedOrderID == 0)
            {
                return;
            }
                string url = acceptedOrder.GetAddressInConcatenatedForm();
                System.Diagnostics.Process.Start(url);
                AddressLabel.LinkVisited = true;
        }

        private void RiderDashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnActiveOrders_Click(object sender, EventArgs e)
        {
            InitializeActiveOrders();
            showPanel(OrdersMain);
        }

        private void btnOrderHistory_Click(object sender, EventArgs e)
        {
            OrderHistoryChart_Load(sender, e);
            showPanel(OrderHistoryMain);
        }

        private void btnDeliveryStatus_Click(object sender, EventArgs e)
        {
            InitializeDeliveryStatus();
            showPanel(DeliveryStatusMain);
        }

        private void btnEarningTracker_Click(object sender, EventArgs e)
        {
            showPanel(EarningTrackerMain);
        }

        private void btnPersonalInfo_Click(object sender, EventArgs e)
        {
            InitializePersonalInfo(rider);
            showPanel(PersonalInfoMain);
        }

        private void btnInbox_Click(object sender, EventArgs e)
        {
            InitializeInbox();
            showPanel(InboxMainPanel);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
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

            Inbox inbox = new Inbox(rider.getUserID(), reciever.getUserID(), message, DateTime.Now);

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

        private void btnAcceptOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ComboOrderID.Text))
            { 
                //if order is not selected 
                MessageBox.Show("Please select an order to accept.");
                return;
            }

            if (selectedOrderID != 0)
            {
                MessageBox.Show("You have already accepted an order.");
                return;
            }

            string status = ObjectHandler.GetOrderDL().GetOrderStatus(Convert.ToInt32(ComboOrderID.Text));
            string orderType = ObjectHandler.GetOrderDL().GetOrderType(Convert.ToInt32(ComboOrderID.Text));

            if (status == "pending" && orderType == "online")
            {
                selectedOrderID = Convert.ToInt32(ComboOrderID.Text);
                if (ObjectHandler.GetOrderDL().AcceptOrder(selectedOrderID, rider.getUserID()))
                {
                    acceptedOrder = ObjectHandler.GetOrderDL().LoadAcceptedOrderByRiderID(rider.getUserID());
                    Order order = ObjectHandler.GetOrderDL().LoadOrderByOrderID(selectedOrderID);
                    UpdateRiderTip(order.GetTip());
                    //order accepted
                    MessageBox.Show("Order Accepted Successfully.");

                }
                else
                {
                    //somthing is wrong
                    MessageBox.Show("Failed to accept order.");
                }
            }
            else
            {
                MessageBox.Show("Order has already been accepted Or It is not availaible for deliverey...");   //if order is already accepted by anoother rider
            }
        }

        private void btnRejectOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ComboOrderID.Text))
            {
                MessageBox.Show("Please select an order to reject.");
                return;
            }

            if (Convert.ToDouble(ComboOrderID.Text) == selectedOrderID)
            {
                int selectedOrderToReject = Convert.ToInt32(ComboOrderID.Text);
                if (ObjectHandler.GetOrderDL().RejectOrder(selectedOrderToReject))
                {
                    Order order = ObjectHandler.GetOrderDL().LoadOrderByOrderID(selectedOrderToReject);
                    UpdateRiderTip(order.GetTip() * -1);
                    selectedOrderID = 0;
                    MessageBox.Show("Order Rejected Successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to reject order.");
                }
            }
            else
            {
                MessageBox.Show("There is no such accepted order to reject");
            }
        }

        private bool UpdateRiderTip(double tipToBeAdded)
        {
            Employee tempRider = ObjectHandler.GetUserDL().GetEmployeeByEmployeeID(rider.getUserID());
            double tip = ObjectHandler.GetUserDL().GetStoredUserTipByUserID(rider.getUserID());

            MessageBox.Show("Tip: " + tip);

            double updatedTip = tip + tipToBeAdded;

            MessageBox.Show("Updated Tip: " + updatedTip);

            Employee UpdatedRider = new Employee(tempRider.getUserID(), tempRider.getUsername(), tempRider.getUserHashPassword(), tempRider.getRole(), tempRider.getUserEmail(), tempRider.getUserPhone(), tempRider.getUserRegistrationDate(), tempRider.GetSalary() , updatedTip);
            

            if (ObjectHandler.GetUserDL().UpdateUser(UpdatedRider))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string status = ComboOrderStatus.Text.ToLower();
            if(ObjectHandler.GetOrderDL().UpdateOrderStatus(selectedOrderID, status))
            {
                MessageBox.Show("Order status updated successfully.");
            }
            else
            {
                MessageBox.Show("Failed to update order status.");
            }
        }
    }
}
