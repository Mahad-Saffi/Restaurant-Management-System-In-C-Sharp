﻿using DLLForRMS.BL;
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
            get { return TxtNamePersonalInfo.Text; }       //getters and setters
            set { TxtNamePersonalInfo.Text = value; }
        }

        public string PassTextPersonalInfo
        {
            get { return TxtPassPersonalInfo.Text; }
            set { TxtPassPersonalInfo.PlaceholderText = value; }       //getters and setters
        }

        public string EmailTextPersonalInfo
        {
            get { return TxtEmailPersonalInfo.Text; }         //getters and setters
            set { TxtEmailPersonalInfo.Text = value; }
        }

        public string ContactTextPersonalInfo
        {
            get { return TxtContactPersonalInfo.Text; }           //getters and setters
            set { TxtContactPersonalInfo.Text = value; }
        }

        public string SinceTextPersonalInfo
        {
            get { return TxtSincePersonalInfo.Text; }            //getters and setters
            set { TxtSincePersonalInfo.Text = value; }
        }

        public string RoleTextPersonalInfo
        {  
            get { return TxtRolePersonalInfo.Text; }                 //getters and setters
            set { TxtRolePersonalInfo.Text = value; }
        }

        public string SalaryTextPersonalInfo
        {
            get { return TxtSalaryPersonalInfo.Text; }                    //getters and setters
            set { TxtSalaryPersonalInfo.Text = value; }
        }

        public Image PersonalInfoPicBox
        {
            get { return PersonalInfoPic.Image; }                 //getters and setters
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

        private void btnPersonalInfoSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(PassTextPersonalInfo) || string.IsNullOrEmpty(EmailTextPersonalInfo) || string.IsNullOrEmpty(ContactTextPersonalInfo))
            {
                MessageBox.Show("Please Fill Password, Email and Contact Fields...");
                return;
            }
            else
            {
                string username = NameTextPersonalInfo; ;
                string password = PassTextPersonalInfo;
                string email = EmailTextPersonalInfo;
                long phone = Convert.ToInt64(ContactTextPersonalInfo);
                if (ObjectHandler.GetUserDL().UpdateUser(username, password, email, phone))
                {
                    MessageBox.Show("Personal Info Updated Successfully...");          //info changed
                }
                else
                {
                    MessageBox.Show("Failed to update personal info...");         //somthing is wrong
                }
            }
        }
    }
}
