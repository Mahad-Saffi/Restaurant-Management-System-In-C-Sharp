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
        public ManagerDashboard()
        {
            InitializeComponent();
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
    }
}
