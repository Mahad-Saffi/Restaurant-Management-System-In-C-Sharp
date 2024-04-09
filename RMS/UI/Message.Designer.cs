namespace RMS.UI
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
            this.MessagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MessagePanel
            // 
            this.MessagePanel.BackColor = System.Drawing.Color.Transparent;
            this.MessagePanel.Controls.Add(this.TxtMessage);
            this.MessagePanel.Controls.Add(this.Username);
            this.MessagePanel.FillColor = System.Drawing.Color.White;
            this.MessagePanel.Location = new System.Drawing.Point(133, 22);
            this.MessagePanel.Name = "MessagePanel";
            this.MessagePanel.ShadowColor = System.Drawing.Color.Black;
            this.MessagePanel.Size = new System.Drawing.Size(744, 144);
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
            this.TxtMessage.Location = new System.Drawing.Point(138, 43);
            this.TxtMessage.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.TxtMessage.Multiline = true;
            this.TxtMessage.Name = "TxtMessage";
            this.TxtMessage.PasswordChar = '\0';
            this.TxtMessage.PlaceholderText = "";
            this.TxtMessage.ReadOnly = true;
            this.TxtMessage.SelectedText = "";
            this.TxtMessage.Size = new System.Drawing.Size(590, 88);
            this.TxtMessage.TabIndex = 1;
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Mongolian Baiti", 20F);
            this.Username.Location = new System.Drawing.Point(19, 17);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(123, 29);
            this.Username.TabIndex = 0;
            this.Username.Text = "Username";
            // 
            // Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MessagePanel);
            this.Name = "Message";
            this.Size = new System.Drawing.Size(1089, 189);
            this.MessagePanel.ResumeLayout(false);
            this.MessagePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel MessagePanel;
        private Guna.UI2.WinForms.Guna2TextBox TxtMessage;
        private System.Windows.Forms.Label Username;
    }
}
