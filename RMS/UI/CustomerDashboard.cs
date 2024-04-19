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
    public partial class CustomerDashboard : Form
    {
        Customer customer;
        private string orderType = "offline";
        public CustomerDashboard(Customer customer)
        {
            this.customer = customer;
            InitializeComponent();
            showPanel(PopularItemsMain);
            InitializePopularItems();
            InitializeAllItems();
            InitializeInbox();
            InitializeCustomerPersonalInfo(customer);
        }

        private void InitializePopularItems()
        {
            // Load all the popular items
            List<Item> popularItems = ObjectHandler.GetItemDL().LoadItems();
            PopularItemsFlowPanel.Controls.Clear();
            foreach (Item item in popularItems)
            {
                PopularItemsFlowPanel.Controls.Add(new FoodItem(item, customer));
            }

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

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            showPanel(PopularItemsMain);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CustomerMainUpperPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
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

        private void CustomerPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void CustomerMainUpperPanel_Paint_4(object sender, PaintEventArgs e)
        {

        }

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {
            showPanel(PopularItemsMain);
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
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


        public static void Example(Guna.Charts.WinForms.GunaChart gunaChartCustomerPurchases)
        {
            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            //Chart configuration
            gunaChartCustomerPurchases.YAxes.GridLines.Display = false;

            //Create a new dataset 
            var dataset = new Guna.Charts.WinForms.GunaBarDataset();
            var r = new Random();
            for (int i = 0; i < days.Length; i++)
            {
                //random number
                int num = r.Next(10, 30);

                dataset.DataPoints.Add(days[i], num);
            }
            dataset.CornerRadius = 20;
            dataset.Label = "Purchases";
            dataset.FillColors.Add(Color.FromArgb(255, 0, 0, 0));

            //Add a new dataset to a chart.Datasets
            gunaChartCustomerPurchases.Datasets.Add(dataset);

            //An update was made to re-render the chart
            gunaChartCustomerPurchases.Update();
        }

        private void gunaChart1_Load(object sender, EventArgs e)
        {
            Example(CustomerPurchasesChart);
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            showPanel(PersonalInfoPanel);
        }

        private void personalInfo1_Load(object sender, EventArgs e)
        {

        }

        private void showPanel(Panel panel)
        {
            CustomerPanel.Visible = true;
            CustomerSidePanel.Visible = true;

            PopularItemsMain.Visible = false;
            AllItemMain.Visible = false;
            CartMain.Visible = false;
            AllPurchasesMain.Visible = false;
            PersonalInfoPanel.Visible = false;
            InboxMainPanel.Visible = false;

            panel.Visible = true;
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

        private void InboxMainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void messagesFlowPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text;
            string username = "admin";

            MessageBox.Show(username);

            User reciever = ObjectHandler.GetUserDL().GetUserByUsername(username);

            Inbox inbox = new Inbox(customer.getUserID(), reciever.getUserID(), message, DateTime.Now);

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

        private void PopularItemsFlowPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Cart cart = ObjectHandler.GetCartDL().LoadCartByCustomerID(customer.getUserID());
            List<CartItems> cartItems = ObjectHandler.GetCartDL().LoadCartItems(cart.GetCartID());

            double tip = Convert.ToDouble(txtTip.Text);
            string paymentMethod = ComboPaymentMethod.Text;

            double total = 0;
            foreach (CartItems cartItem in cartItems)
            {
                total += cartItem.GetCartItemPrice();
            }

            if (orderType == "offline")
            {
                Order order = new Order(customer.getUserID(), DateTime.Now, total, "offline", "", paymentMethod, tip, 0, "pending");
                if(ObjectHandler.GetOrderDL().AddOrder(order))
                {
                    if(AddCustomerItems(customer.getUserID()))
                    {
                        MessageBox.Show("Order placed successfully.");
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
            else
            {
                double deliveryCharges = Convert.ToDouble(LabeldeliveryChargesAmount.Text);
                string address = txtAddress.Text;

                Order order = new Order(customer.getUserID(), DateTime.Now, total, "online", address, paymentMethod, tip, deliveryCharges, "pending");
                if(ObjectHandler.GetOrderDL().AddOrder(order))
                {
                    if (AddCustomerItems(customer.getUserID()))
                    {
                        MessageBox.Show("Thanks for ordering...\nYour Order is in Pending...");
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

        private bool AddCustomerItems(int customerID)
        {
            Order order = ObjectHandler.GetOrderDL().GetCustomerOrder(customerID);
            Cart cart = ObjectHandler.GetCartDL().LoadCartByCustomerID(customer.getUserID());
            List<CartItems> cartItems = ObjectHandler.GetCartDL().LoadCartItems(cart.GetCartID());

            if (ObjectHandler.GetOrderDL().AddOrderDetails(order, cartItems))
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
                // WHEN ONLINE ORDER IS SELECTED
                orderType = "Online";
                LabeldeliveryChargesAmount.Text = "10";
                LabelAddress.ForeColor = Color.Black;
                LabelDeliveryCharges.ForeColor = Color.Black;
                LabeldeliveryChargesAmount.ForeColor = Color.Black;
                txtAddress.ReadOnly = false;
                txtAddress.HoverState.BorderColor = Color.DodgerBlue;
                txtAddress.FocusedState.BorderColor = Color.DodgerBlue;
            }
            else
            {
                // WHEN OFFLINE ORDER IS SELECTED
                orderType = "Offline";
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
    }
}
