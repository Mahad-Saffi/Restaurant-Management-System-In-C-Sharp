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
        public CustomerDashboard(Customer customer)
        {
            InitializeComponent();
            SetCustomerDetails(customer);
        }

        private void SetCustomerDetails(Customer customer)
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
            
            PopularItemsFlowPanel.Controls.Add(new FoodItem());
            PopularItemsFlowPanel.Controls.Add(new FoodItem());
            PopularItemsFlowPanel.Controls.Add(new FoodItem());
            PopularItemsFlowPanel.Controls.Add(new FoodItem());
            PopularItemsFlowPanel.Controls.Add(new FoodItem());
            AllitemFlowPanel.Controls.Add(new FoodItem());
            AllitemFlowPanel.Controls.Add(new FoodItem());
            AllitemFlowPanel.Controls.Add(new FoodItem());
            AllitemFlowPanel.Controls.Add(new FoodItem());
            AllitemFlowPanel.Controls.Add(new FoodItem());
            AllitemFlowPanel.Controls.Add(new FoodItem());
            AllitemFlowPanel.Controls.Add(new FoodItem());
            AllitemFlowPanel.Controls.Add(new FoodItem());
            AllitemFlowPanel.Controls.Add(new FoodItem());
            AllitemFlowPanel.Controls.Add(new FoodItem());
            messagesFlowPanel.Controls.Clear();
            messagesFlowPanel.Controls.Add(new Message());
            messagesFlowPanel.Controls.Add(new Message());
            messagesFlowPanel.Controls.Add(new Message());
            messagesFlowPanel.Controls.Add(new Message());

        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            showPanel(CartPanel);
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
            Example(gunaChartCustomerPurchases);
        }

        private void guna2Button5_Click_1(object sender, EventArgs e)
        {
            showPanel(CustomerPanel);
            showPanel(CustomerSidePanel);
            personalInfo1.Visible = true;
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
            CartPanel.Visible = false;
            AllPurchasesMain.Visible = false;
            personalInfo1.Visible = false;
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
    }
}
