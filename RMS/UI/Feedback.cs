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

namespace RMS.UI
{
    public partial class Feedback : Form
    {
        private int feedbackRating = 0;     //by detault rating is 0 star
        Customer customer;
        public Feedback(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
        }

        private void btnStar1_Click(object sender, EventArgs e)
        {
            btnStar1.Image = Properties.Resources.star_Fill;
            btnStar2.Image = Properties.Resources.star;
            btnStar3.Image = Properties.Resources.star;
            btnStar4.Image = Properties.Resources.star;
            btnStar5.Image = Properties.Resources.star;
            feedbackRating = 1;
        }

        private void btnStar2_Click(object sender, EventArgs e)
        {
            btnStar1.Image = Properties.Resources.star_Fill;
            btnStar2.Image = Properties.Resources.star_Fill;
            btnStar3.Image = Properties.Resources.star;
            btnStar4.Image = Properties.Resources.star;
            btnStar5.Image = Properties.Resources.star;
            feedbackRating = 2;
        }

        private void btnStar3_Click(object sender, EventArgs e)
        {
            btnStar1.Image = Properties.Resources.star_Fill;
            btnStar2.Image = Properties.Resources.star_Fill;
            btnStar3.Image = Properties.Resources.star_Fill;
            btnStar4.Image = Properties.Resources.star;
            btnStar5.Image = Properties.Resources.star;
            feedbackRating = 3;
        }

        private void btnStar4_Click(object sender, EventArgs e)
        {
            btnStar1.Image = Properties.Resources.star_Fill;
            btnStar2.Image = Properties.Resources.star_Fill;
            btnStar3.Image = Properties.Resources.star_Fill;
            btnStar4.Image = Properties.Resources.star_Fill;
            btnStar5.Image = Properties.Resources.star;
            feedbackRating = 4;
        }

        private void btnStar5_Click(object sender, EventArgs e)
        {
            btnStar1.Image = Properties.Resources.star_Fill;
            btnStar2.Image = Properties.Resources.star_Fill;
            btnStar3.Image = Properties.Resources.star_Fill;
            btnStar4.Image = Properties.Resources.star_Fill;
            btnStar5.Image = Properties.Resources.star_Fill;
            feedbackRating = 5;
        }

        private void btnNotNow_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYesOfCourse_Click(object sender, EventArgs e)
        {
            if(ObjectHandler.GetFeedbackDL().AddFeedback(customer.getUserID(), feedbackRating))
            {
                MessageBox.Show("Thank you for your feedback!", "Feedback", MessageBoxButtons.OK, MessageBoxIcon.Information);     //if feedback is successfull
                this.Close();
            }
        }
    }
}
