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
    public partial class PersonalInfo : UserControl
    {
        public PersonalInfo()
        {
            InitializeComponent();
        }

        private void PersonalInfoLabel_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PersonalInfoPic_Click(object sender, EventArgs e)
        {

        }

        private void TxtNamePersonalInfo_TextChanged(object sender, EventArgs e)
        {

        }

        public string NameTextPersonalInfo
        {
            get { return TxtNamePersonalInfo.Text; }
            set { TxtNamePersonalInfo.Text = value; }
        }

        public string PassTextPersonalInfo
        {
            get { return TxtPassPersonalInfo.Text; }
            set { TxtPassPersonalInfo.Text = value; }
        }

        public string EmailTextPersonalInfo
        {
            get { return TxtEmailPersonalInfo.Text; }
            set { TxtEmailPersonalInfo.Text = value; }
        }

        public string ContactTextPersonalInfo
        {
            get { return TxtContactPersonalInfo.Text; }
            set { TxtContactPersonalInfo.Text = value; }
        }

        public string SinceTextPersonalInfo
        {
            get { return TxtSincePersonalInfo.Text; }
            set { TxtSincePersonalInfo.Text = value; }
        }

        public string RoleTextPersonalInfo
        {
            get { return TxtRolePersonalInfo.Text; }
            set { TxtRolePersonalInfo.Text = value; }
        }

        public string SalaryTextPersonalInfo
        {
            get { return TxtSalaryPersonalInfo.Text; }
            set { TxtSalaryPersonalInfo.Text = value; }
        }

        public Image PersonalInfoPicBox
        {
            get { return PersonalInfoPic.Image; }
            set { PersonalInfoPic.Image = value; }
        }

        private void btnAddPicPersonalInfo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            ofd.FilterIndex = 1;
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PersonalInfoPic.Image = Image.FromFile(ofd.FileName);
            }
        }
    }
}
