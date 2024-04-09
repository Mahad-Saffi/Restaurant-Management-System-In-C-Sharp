using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS.UI
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
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

            messagesFlowPanel.Controls.Clear();
            messagesFlowPanel.Controls.Add(new Message());
            messagesFlowPanel.Controls.Add(new Message());
            messagesFlowPanel.Controls.Add(new Message());
            messagesFlowPanel.Controls.Add(new Message());
            messagesFlowPanel.Controls.Add(new Message());
            messagesFlowPanel.Controls.Add(new Message());
        }

        private void personalInfo1_Load(object sender, EventArgs e)
        {
            personalInfo1.NameTextPersonalInfo = "Admin";
            personalInfo1.PassTextPersonalInfo = "admin";
            personalInfo1.EmailTextPersonalInfo = "admin@gmail.com";
            personalInfo1.ContactTextPersonalInfo = "1234567890";
            personalInfo1.SinceTextPersonalInfo = "2021";
            personalInfo1.RoleTextPersonalInfo = "Admin";
            personalInfo1.SalaryTextPersonalInfo = "Null";
        }
    }
}
