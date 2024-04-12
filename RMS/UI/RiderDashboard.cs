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

namespace RMS.UI
{
    public partial class RiderDashboard : Form
    {
        private Order acceptedOrder;
        public RiderDashboard()
        {
            InitializeComponent();
        }

        private void LabelOrders_Click(object sender, EventArgs e)
        {

        }

        public static void Example(Guna.Charts.WinForms.GunaChart chart)
        {
            //Create a new dataset 
            var dataset = new Guna.Charts.WinForms.GunaBubbleDataset();
            var r = new Random();
            for (int i = 0; i < 7; i++)
            {
                //random number
                int radius = 10;
                int x = i + 1;
                int y = r.Next(1000, 10000);


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

        public static void Tip(Guna.Charts.WinForms.GunaChart chart)
        {

            //Chart configuration
            chart.Title.Text = "Tip In a Week";
            chart.Legend.Position = Guna.Charts.WinForms.LegendPosition.Right;
            chart.XAxes.Display = false;
            chart.YAxes.Display = false;

            //Create a new dataset 
            var datasetMonday = new Guna.Charts.WinForms.GunaDoughnutDataset();
            var datasetTuesday = new Guna.Charts.WinForms.GunaDoughnutDataset();
            var datasetWednesday = new Guna.Charts.WinForms.GunaDoughnutDataset();
            var datasetThursday = new Guna.Charts.WinForms.GunaDoughnutDataset();
            var datasetFriday = new Guna.Charts.WinForms.GunaDoughnutDataset();
            var datasetSaturday = new Guna.Charts.WinForms.GunaDoughnutDataset();
            var datasetSunday = new Guna.Charts.WinForms.GunaDoughnutDataset();
            var r = new Random();
            
            int num = r.Next(10, 100);

            datasetMonday.DataPoints.Add("Monday", num);
            datasetTuesday.DataPoints.Add("Tuesday", num);
            datasetWednesday.DataPoints.Add("Wednesday", num);
            datasetThursday.DataPoints.Add("Thursday", num);
            datasetFriday.DataPoints.Add("Friday", num);
            datasetSaturday.DataPoints.Add("Saturday", num);
            datasetSunday.DataPoints.Add("Sunday", num);


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

        public static void Earning(Guna.Charts.WinForms.GunaChart chart)
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "Septempber", "October", "November", "December" };

            //Chart configuration 
            chart.YAxes.GridLines.Display = false;

            //Create a new dataset 
            var dataset = new Guna.Charts.WinForms.GunaLineDataset();
            dataset.PointRadius = 10;
            dataset.PointStyle = PointStyle.Circle;
            dataset.Label = "Earnings";
            var r = new Random();
            for (int i = 0; i < months.Length; i++)
            {
                //random number
                int num = r.Next(10, 100);

                dataset.DataPoints.Add(months[i], num);
            }

            //Add a new dataset to a chart.Datasets
            chart.Datasets.Add(dataset);

            //An update was made to re-render the chart
            chart.Update();
        }


        private void gunaChart2_Load(object sender, EventArgs e)
        {
            Earning(EarningDuringWholeYearChart);
        }

        private void AddressLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = acceptedOrder.GetAddressInConcatenatedForm();
            System.Diagnostics.Process.Start(url);
            AddressLabel.LinkVisited = true;
        }
    }
}
