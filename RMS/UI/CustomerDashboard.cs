using DLLForRMS.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLLForRMS.DL;

namespace RMS.UI
{
    public partial class CustomerDashboard :Form  
    {
        Customer customer;
        private string orderType = "Offline";    //by default

        private void InitializePopularItems()
        {
            
            List<Item> popularItems = ObjectHandler.GetItemDL().LoadItems();     // Load all the popular items
            PopularItemsFlowPanel.Controls.Clear();
            foreach (Item item in popularItems)
            {
                PopularItemsFlowPanel.Controls.Add(new FoodItem(item, customer));
            }
            LoadCart(PopularItemsDataGridView);                   // Load all the items for cart

        }


        private void LoadCart(DataGridView dataGridViewOfCart)
        {
            Cart cart = ObjectHandler.GetCartDL().LoadCartByCustomerID(customer.getUserID());
            List<CartItems> cartItems = ObjectHandler.GetCartDL().LoadCartItems(cart.GetCartID());    //cart items list

            dataGridViewOfCart.Columns.Clear();
            dataGridViewOfCart.Columns.Add("ItemID", "Item ID");
            dataGridViewOfCart.Columns.Add("ItemName", "Item Name");
            dataGridViewOfCart.Columns.Add("ItemPrice", "Item Price");

            CustomerCartDataGridView.Rows.Clear();
            foreach (CartItems cartItem in cartItems)
            {
                Item item = ObjectHandler.GetItemDL().LoadItemByItemID(cartItem.GetItemID());
                dataGridViewOfCart.Rows.Add(cartItem.GetItemID(), item.getItemName(), cartItem.GetCartItemPrice());    //fill the grid view 
            }

            // Calculate total amount of cart
            double total = 0;
            foreach (CartItems cartItem in cartItems)
            {
                total += cartItem.GetCartItemPrice();
            }
            AmountLabelCart.Text =total.ToString();
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }
        private void InitializeInbox()
        {
            // Load all the messages
            List<Inbox> messages = ObjectHandler.GetInboxDL().LoadMessagesByUserID(customer);
            messagesFlowPanel.Controls.Clear();
            foreach (Inbox message in messages)
            {
                messagesFlowPanel.Controls.Add(new Message(message));
            }
        }


        private void guna2Button4_Click(object sender,EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }
        public CustomerDashboard(Customer customer)
        {
            this.customer = customer;
            InitializeComponent();
            InitializeUpperBar(customer);
            showPanel(PopularItemsMain);

            //Initialization of the customer dashboard
            InitializePopularItems();
            InitializeAllItems();
            InitializePurchases();
            InitializeCart();
            InitializeInbox();
            InitializeCustomerPersonalInfo(customer);
        }

        private void InitializeCustomerPersonalInfo(Customer customer)
        {
            // Set customer details
            personalInfo1.NameTextPersonalInfo = customer.getUsername();
            personalInfo1.PassTextPersonalInfo = customer.getUserHashPassword();
            personalInfo1.EmailTextPersonalInfo = customer.getUserEmail();
            personalInfo1.ContactTextPersonalInfo = customer.getUserPhone().ToString();
            personalInfo1.SinceTextPersonalInfo = customer.getUserRegistrationDate().ToString();
            personalInfo1.RoleTextPersonalInfo = customer.getRole();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            LoadCart(PopularItemsDataGridView);        //load the chart
            showPanel(PopularItemsMain);      //show item in the panel
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CustomerMainUpperPanel_Paint(object sender,PaintEventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender,EventArgs e)
        {
            LoadCart(AllItemsdataGridView);
            showPanel(AllItemMain);
        }

        private void CustomerMainUpperPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void AllItemsUpperPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CustomerMainUpperPanel_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void CustomerMainUpperPanel_Paint_3(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Cart_Click(object sender, EventArgs e)
        {

        }

        private void CustomerPanel_Paint(object sender,  PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void InitializeCart()
        {

            LoadCart(CustomerCartDataGridView);
        }

        private void CustomerMainUpperPanel_Paint_4(object sender ,PaintEventArgs e)
        {

        }

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
            showPanel(PopularItemsMain);
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            LoadCart(CustomerCartDataGridView);
            showPanel(CartMain);
        }

        private void CartPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OnlineOrderSwitch_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Address_Click(object sender, EventArgs e)
        {

        }

        private void DeliveryCharges_Click(object sender, EventArgs e)
        {

        }

        private void PurchasesLabel_Click(object sender, EventArgs e)
        {

        }

        private void AllPurchasesMain_Paint(object sender, PaintEventArgs e)
        {

        }
        private void showPanel(Panel panel)
        {
            CustomerPanel.Visible = true;              //panel properties
            CustomerSidePanel.Visible = true;

            PopularItemsMain.Visible = false;
            AllItemMain.Visible = false;
            CartMain.Visible = false;
            AllPurchasesMain.Visible = false;
            PersonalInfoPanel.Visible = false;
            InboxMainPanel.Visible = false;

            panel.Visible = true;
        }


        public void Example(Guna.Charts.WinForms.GunaChart gunaChartCustomerPurchases)
        {
            // Fetch the orders for the customer
            List<Order> customerOrders = ObjectHandler.GetOrderDL().GetCustomerAllOrders(customer.getUserID());

            // Initialize an array to store the count of purchases for each day
            int[] purchasesByDay = new int[7];

            // Iterate through each order to count purchases per day
            foreach (Order order in customerOrders)
            {
                // Get the day of the week for the order date
                DayOfWeek dayOfWeek = order.GetOrderDate().DayOfWeek;

                // Increment the count of purchases for the corresponding day
                purchasesByDay[(int)dayOfWeek]++;
            }

            // Clear existing datasets to avoid duplication
            gunaChartCustomerPurchases.Datasets.Clear();

            // Create a new dataset
            var dataset = new Guna.Charts.WinForms.GunaBarDataset
            {
                CornerRadius = 20,
                Label = "Purchases",
            };

            // Define colors for the dataset
            dataset.FillColors.Add(Color.FromArgb(255, 0, 0, 0));

            // Days of the week for labeling
            string[] days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

            // Add purchase data to the dataset
            for (int i = 0; i < days.Length; i++)
            {
                dataset.DataPoints.Add(days[i], purchasesByDay[i]);
            }

            // Add dataset to the chart
            gunaChartCustomerPurchases.Datasets.Add(dataset);

            // Update the chart to reflect changes
            gunaChartCustomerPurchases.Update();
        }


        private void gunaChart1_Load(object sender, EventArgs e)
        {
            Example(CustomerPurchasesChart);
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            InitializeCustomerPersonalInfo(customer);
            showPanel(PersonalInfoPanel);
        }

        private void personalInfo1_Load(object sender, EventArgs e)
        {

        }
        private void InitializeUpperBar(Customer customer)
        {
            UpperBarUsername.Text = customer.getUsername();
            UpperBarPicBox.Image = ObjectHandler.GetUserDL().GetUserImageByUserID(customer.getUserID());
        }



        private void guna2Button4_Click_2(object sender, EventArgs e)
        {
            showPanel(AllPurchasesMain);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnInboxCustomer_Click(object sender, EventArgs e)
        {
            showPanel(InboxMainPanel);
        }
        private void InitializeAllItems()
        {
            // Load all the items
            List<Item> allItems = ObjectHandler.GetItemDL().LoadItems();
            AllitemFlowPanel.Controls.Clear();
            foreach (Item item in allItems)
            {
                AllitemFlowPanel.Controls.Add(new FoodItem(item, customer));
            }

            // Load all the items for cart
            LoadCart(AllItemsdataGridView);
        }

        private void InboxMainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InitializePurchases()
        {
            CustomerTotalPurchases.Text = ObjectHandler.GetOrderDL().GetCustomerPurchases(customer.getUserID()).ToString();
            CustomerPurchasesThisWeek.Text = ObjectHandler.GetOrderDL().GetCustomerPurchasesThisWeek(customer.getUserID()).ToString();
            CustomerTotalAmountOfPurchases.Text = "$" + ObjectHandler.GetOrderDL().GetTotalAmountOfPurchasesOfCustomer(customer.getUserID()).ToString();
        }

        private void messagesFlowPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
           
            string message = txtMessage.Text;         //To Save the message
            string username = "admin";         //by default

            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Please enter message.");         //if message box is empty and user try to send it
                return;
            }

            User reciever = ObjectHandler.GetUserDL().GetUserByUsername(username);

            Inbox inbox = new Inbox(customer.getUserID(), reciever.getUserID(), message, DateTime.Now); 

            if (ObjectHandler.GetInboxDL().SendMessage(inbox))
            {
                txtMessage.Clear();        
                MessageBox.Show("Message sent successfully.");        //message sent 
            }
            else
            {
                MessageBox.Show("Failed to send message.");        //some problem in message sendig
            }
        }

        private void PopularItemsFlowPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            // cart
            Cart cart = ObjectHandler.GetCartDL().LoadCartByCustomerID(customer.getUserID());
            List<CartItems> cartItems = ObjectHandler.GetCartDL().LoadCartItems(cart.GetCartID());

            double tip = 0; //tip intilize to zero
            string Strtip = txtTip.Text;
            string paymentMethod = ComboPaymentMethod.Text;

            if (string.IsNullOrEmpty(Strtip))
            {
                tip = 0;        //if tip is empty then it is zero
            }
            else
            {
                tip = Convert.ToDouble(Strtip);
            }

            if (string.IsNullOrEmpty(paymentMethod))
            {
                MessageBox.Show("Please select payment method.");
                return;
            }

            double total = 0;
            foreach (CartItems cartItem in cartItems)
            {
                total += cartItem.GetCartItemPrice();        //total price
            }

            if (orderType == "Offline")
            {

                Order order = new Order(customer.getUserID(), DateTime.Now, total, "offline", "", paymentMethod, tip, 0, "delivered");
                if(ObjectHandler.GetOrderDL().AddOrder(order))
                {
                    List<Order> customerOrders = ObjectHandler.GetOrderDL().GetCustomerAllOrders(customer.getUserID());
                    order = customerOrders.Last();

                    // Add order details to list in order class
                    foreach (var item in cartItems)
                    {
                        int orderID = order.GetOrderID();
                        int itemID = item.GetItemID();
                        double price = item.GetCartItemPrice();

                        OrderDetails orderDetails = new OrderDetails(itemID, orderID, price);

                        order.AddOrderDetails(orderDetails);
                    }

                    if (AddCustomerItems(order))
                    {
                        new Feedback(customer).Show();
                        MessageBox.Show("Order placed successfully.");
                        LoadCart(CustomerCartDataGridView);

                        ObjectHandler.GetCartDL().ClearCart(cart.GetCartID());
                    }
                    else
                    {
                        MessageBox.Show("Failed to place order.");
                    }
                }
                else
                {
                    MessageBox.Show("Failed to place order.");
                }
            }
            else   //if order is online
            {
                double deliveryCharges = Convert.ToDouble(LabeldeliveryChargesAmount.Text);
                string address = txtAddress.Text;

                if (string.IsNullOrEmpty(address))
                {
                    MessageBox.Show("Please enter address.");
                    return;
                }

                Order order = new Order(customer.getUserID(), DateTime.Now, total, "online", address, paymentMethod, tip, deliveryCharges, "pending");

                if(ObjectHandler.GetOrderDL().AddOrder(order))
                {

                    List<Order> customerOrders = ObjectHandler.GetOrderDL().GetCustomerAllOrders(customer.getUserID());
                    order = customerOrders.Last();


                    // Add order details to list in order class
                    foreach (var item in cartItems)
                    {
                        int orderID = order.GetOrderID();
                        int itemID = item.GetItemID();
                        double price = item.GetCartItemPrice();
                        OrderDetails orderDetails = new OrderDetails(itemID, orderID, price);

                        order.AddOrderDetails(orderDetails);
                    }


                    if (AddCustomerItems(order))
                    {
                        new Feedback(customer).Show();
                        MessageBox.Show("Thanks for ordering...\nYour Order is in Pending...");
                        LoadCart(CustomerCartDataGridView);
                    }
                    else
                    {
                        MessageBox.Show("Failed to place order.");
                    }
                }
                else
                {
                    MessageBox.Show("Failed to place order.");
                }
            }
        }

        private bool AddCustomerItems(Order order)
        {


            if(ObjectHandler.GetOrderDL().AddOrderDetails(order))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void OnlineOrderSwitch_CheckedChanged_1(object sender, EventArgs e)
        {

            if(OnlineOrderSwitch.Checked == true)
            {
               
                orderType = "Online";               // WHEN ONLINE ORDER IS SELECTED
                LabeldeliveryChargesAmount.Text = "20";

                LabelAddress.ForeColor = Color.Black;
                LabelDeliveryCharges.ForeColor = Color.Black;
                LabeldeliveryChargesAmount.ForeColor = Color.Black;
                txtAddress.ReadOnly = false;
                txtAddress.HoverState.BorderColor = Color.DodgerBlue;
                txtAddress.FocusedState.BorderColor = Color.DodgerBlue;

            }
            else if (OnlineOrderSwitch.Checked == false)
            {
               
                orderType = "Offline";            // WHEN OFFLINE ORDER IS SELECTED
                LabeldeliveryChargesAmount.Text = "Amount";

                LabelAddress.ForeColor = Color.Gray;
                LabelDeliveryCharges.ForeColor = Color.Gray;
                LabeldeliveryChargesAmount.ForeColor = Color.Gray;
                txtAddress.ReadOnly = true;
                txtAddress.HoverState.BorderColor = Color.Transparent;
                txtAddress.FocusedState.BorderColor = Color.Transparent;

            }
        }

        private void CustomerSideSubPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            Cart cart = ObjectHandler.GetCartDL().LoadCartByCustomerID(customer.getUserID());       //cart data from data base


            if (ObjectHandler.GetCartDL().ClearCart(cart.GetCartID()))
            {
                MessageBox.Show("Cart cleared successfully.");         //cleared the cart or empty cart
            }
            else
            { 
                MessageBox.Show("Failed to clear cart.");         //some problem in the clearing cart
            }
        }
    }
}
