﻿namespace RMS.UI
{
    partial class Message
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MessagePanel = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.TxtMessage = new Guna.UI2.WinForms.Guna2TextBox();
            this.Username = new System.Windows.Forms.Label();
            this.MessageDateTime = new System.Windows.Forms.Label();
            this.Role = new System.Windows.Forms.Label();
            this.MessagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MessagePanel
            // 
            this.MessagePanel.BackColor = System.Drawing.Color.Transparent;
            this.MessagePanel.Controls.Add(this.Role);
            this.MessagePanel.Controls.Add(this.MessageDateTime);
            this.MessagePanel.Controls.Add(this.TxtMessage);
            this.MessagePanel.Controls.Add(this.Username);
            this.MessagePanel.FillColor = System.Drawing.Color.White;
            this.MessagePanel.Location = new System.Drawing.Point(133, 24);
            this.MessagePanel.Name = "MessagePanel";
            this.MessagePanel.ShadowColor = System.Drawing.Color.Black;
            this.MessagePanel.Size = new System.Drawing.Size(757, 144);
            this.MessagePanel.TabIndex = 0;
            // 
            // TxtMessage
            // 
            this.TxtMessage.AutoScroll = true;
            this.TxtMessage.BorderRadius = 20;
            this.TxtMessage.BorderThickness = 2;
            this.TxtMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtMessage.DefaultText = "The whole Text of the message goes here.";
            this.TxtMessage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtMessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtMessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtMessage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtMessage.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtMessage.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.TxtMessage.ForeColor = System.Drawing.Color.Black;
            this.TxtMessage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtMessage.Location = new System.Drawing.Point(24, 43);
            this.TxtMessage.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.TxtMessage.Multiline = true;
            this.TxtMessage.Name = "TxtMessage";
            this.TxtMessage.PasswordChar = '\0';
            this.TxtMessage.PlaceholderText = "";
            this.TxtMessage.ReadOnly = true;
            this.TxtMessage.SelectedText = "";
            this.TxtMessage.Size = new System.Drawing.Size(709, 88);
            this.TxtMessage.TabIndex = 1;
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Mongolian Baiti", 18F);
            this.Username.Location = new System.Drawing.Point(32, 13);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(109, 25);
            this.Username.TabIndex = 0;
            this.Username.Text = "Username";
            // 
            // MessageDateTime
            // 
            this.MessageDateTime.AutoSize = true;
            this.MessageDateTime.Font = new System.Drawing.Font("Mongolian Baiti", 14F);
            this.MessageDateTime.Location = new System.Drawing.Point(515, 15);
            this.MessageDateTime.Name = "MessageDateTime";
            this.MessageDateTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MessageDateTime.Size = new System.Drawing.Size(149, 20);
            this.MessageDateTime.TabIndex = 2;
            this.MessageDateTime.Text = "MessageDateTime";
            // 
            // Role
            // 
            this.Role.AutoSize = true;
            this.Role.Font = new System.Drawing.Font("Mongolian Baiti", 18F);
            this.Role.Location = new System.Drawing.Point(317, 13);
            this.Role.Name = "Role";
            this.Role.Size = new System.Drawing.Size(57, 25);
            this.Role.TabIndex = 3;
            this.Role.Text = "Role";
            // 
            // Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MessagePanel);
            this.Name = "Message";
            this.Size = new System.Drawing.Size(1089, 189);
            this.Load += new System.EventHandler(this.Message_Load);
            this.MessagePanel.ResumeLayout(false);
            this.MessagePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel MessagePanel;
        private Guna.UI2.WinForms.Guna2TextBox TxtMessage;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Label MessageDateTime;
        private System.Windows.Forms.Label Role;
    }
}
