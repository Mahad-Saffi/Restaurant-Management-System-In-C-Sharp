namespace RMS.UI
{
    partial class Feedback
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Feedback));
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.FeedbackMainLabel = new System.Windows.Forms.Label();
            this.btnNotNow = new Guna.UI2.WinForms.Guna2Button();
            this.btnYesOfCourse = new Guna.UI2.WinForms.Guna2Button();
            this.btnStar1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnStar2 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnStar3 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnStar4 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.btnStar5 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 50;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // FeedbackMainLabel
            // 
            this.FeedbackMainLabel.AutoSize = true;
            this.FeedbackMainLabel.Font = new System.Drawing.Font("Mongolian Baiti", 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FeedbackMainLabel.Location = new System.Drawing.Point(82, 45);
            this.FeedbackMainLabel.Name = "FeedbackMainLabel";
            this.FeedbackMainLabel.Size = new System.Drawing.Size(391, 29);
            this.FeedbackMainLabel.TabIndex = 0;
            this.FeedbackMainLabel.Text = "Do You Want To Give Feedback?";
            // 
            // btnNotNow
            // 
            this.btnNotNow.BorderRadius = 20;
            this.btnNotNow.BorderThickness = 2;
            this.btnNotNow.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNotNow.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNotNow.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNotNow.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNotNow.FillColor = System.Drawing.Color.Transparent;
            this.btnNotNow.Font = new System.Drawing.Font("Segoe Print", 14F);
            this.btnNotNow.ForeColor = System.Drawing.Color.Black;
            this.btnNotNow.Location = new System.Drawing.Point(44, 204);
            this.btnNotNow.Name = "btnNotNow";
            this.btnNotNow.Size = new System.Drawing.Size(127, 42);
            this.btnNotNow.TabIndex = 1;
            this.btnNotNow.Text = "Not Now!";
            this.btnNotNow.Click += new System.EventHandler(this.btnNotNow_Click);
            // 
            // btnYesOfCourse
            // 
            this.btnYesOfCourse.BorderRadius = 20;
            this.btnYesOfCourse.BorderThickness = 2;
            this.btnYesOfCourse.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnYesOfCourse.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnYesOfCourse.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnYesOfCourse.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnYesOfCourse.FillColor = System.Drawing.Color.Transparent;
            this.btnYesOfCourse.Font = new System.Drawing.Font("Segoe Print", 14F);
            this.btnYesOfCourse.ForeColor = System.Drawing.Color.Black;
            this.btnYesOfCourse.Location = new System.Drawing.Point(339, 204);
            this.btnYesOfCourse.Name = "btnYesOfCourse";
            this.btnYesOfCourse.Size = new System.Drawing.Size(174, 42);
            this.btnYesOfCourse.TabIndex = 2;
            this.btnYesOfCourse.Text = "Yes, Ofcourse!";
            this.btnYesOfCourse.Click += new System.EventHandler(this.btnYesOfCourse_Click);
            // 
            // btnStar1
            // 
            this.btnStar1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStar1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStar1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStar1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStar1.FillColor = System.Drawing.Color.Transparent;
            this.btnStar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnStar1.ForeColor = System.Drawing.Color.White;
            this.btnStar1.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            this.btnStar1.Image = global::RMS.Properties.Resources.star;
            this.btnStar1.ImageSize = new System.Drawing.Size(50, 50);
            this.btnStar1.Location = new System.Drawing.Point(78, 110);
            this.btnStar1.Name = "btnStar1";
            this.btnStar1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnStar1.Size = new System.Drawing.Size(73, 62);
            this.btnStar1.TabIndex = 3;
            this.btnStar1.Click += new System.EventHandler(this.btnStar1_Click);
            // 
            // btnStar2
            // 
            this.btnStar2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStar2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStar2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStar2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStar2.FillColor = System.Drawing.Color.Transparent;
            this.btnStar2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnStar2.ForeColor = System.Drawing.Color.White;
            this.btnStar2.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            this.btnStar2.Image = global::RMS.Properties.Resources.star;
            this.btnStar2.ImageSize = new System.Drawing.Size(50, 50);
            this.btnStar2.Location = new System.Drawing.Point(157, 110);
            this.btnStar2.Name = "btnStar2";
            this.btnStar2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnStar2.Size = new System.Drawing.Size(73, 62);
            this.btnStar2.TabIndex = 4;
            this.btnStar2.Click += new System.EventHandler(this.btnStar2_Click);
            // 
            // btnStar3
            // 
            this.btnStar3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStar3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStar3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStar3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStar3.FillColor = System.Drawing.Color.Transparent;
            this.btnStar3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnStar3.ForeColor = System.Drawing.Color.White;
            this.btnStar3.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.btnStar3.Image = global::RMS.Properties.Resources.star;
            this.btnStar3.ImageSize = new System.Drawing.Size(50, 50);
            this.btnStar3.Location = new System.Drawing.Point(236, 110);
            this.btnStar3.Name = "btnStar3";
            this.btnStar3.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnStar3.Size = new System.Drawing.Size(73, 62);
            this.btnStar3.TabIndex = 5;
            this.btnStar3.Click += new System.EventHandler(this.btnStar3_Click);
            // 
            // btnStar4
            // 
            this.btnStar4.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStar4.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStar4.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStar4.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStar4.FillColor = System.Drawing.Color.Transparent;
            this.btnStar4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnStar4.ForeColor = System.Drawing.Color.White;
            this.btnStar4.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.btnStar4.Image = global::RMS.Properties.Resources.star;
            this.btnStar4.ImageSize = new System.Drawing.Size(50, 50);
            this.btnStar4.Location = new System.Drawing.Point(315, 110);
            this.btnStar4.Name = "btnStar4";
            this.btnStar4.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnStar4.Size = new System.Drawing.Size(73, 62);
            this.btnStar4.TabIndex = 6;
            this.btnStar4.Click += new System.EventHandler(this.btnStar4_Click);
            // 
            // btnStar5
            // 
            this.btnStar5.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnStar5.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnStar5.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnStar5.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnStar5.FillColor = System.Drawing.Color.Transparent;
            this.btnStar5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnStar5.ForeColor = System.Drawing.Color.White;
            this.btnStar5.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnStar5.Image = global::RMS.Properties.Resources.star;
            this.btnStar5.ImageSize = new System.Drawing.Size(50, 50);
            this.btnStar5.Location = new System.Drawing.Point(394, 110);
            this.btnStar5.Name = "btnStar5";
            this.btnStar5.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnStar5.Size = new System.Drawing.Size(73, 62);
            this.btnStar5.TabIndex = 7;
            this.btnStar5.Click += new System.EventHandler(this.btnStar5_Click);
            // 
            // Feedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 277);
            this.Controls.Add(this.btnStar5);
            this.Controls.Add(this.btnStar4);
            this.Controls.Add(this.btnStar3);
            this.Controls.Add(this.btnStar2);
            this.Controls.Add(this.btnStar1);
            this.Controls.Add(this.btnYesOfCourse);
            this.Controls.Add(this.btnNotNow);
            this.Controls.Add(this.FeedbackMainLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Feedback";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Feedback";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Button btnNotNow;
        private System.Windows.Forms.Label FeedbackMainLabel;
        private Guna.UI2.WinForms.Guna2Button btnYesOfCourse;
        private Guna.UI2.WinForms.Guna2CircleButton btnStar1;
        private Guna.UI2.WinForms.Guna2CircleButton btnStar5;
        private Guna.UI2.WinForms.Guna2CircleButton btnStar4;
        private Guna.UI2.WinForms.Guna2CircleButton btnStar3;
        private Guna.UI2.WinForms.Guna2CircleButton btnStar2;
    }
}