namespace RMS.UI
{
    partial class FoodItem
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FoodItem));
            this.ItemPrice = new System.Windows.Forms.Label();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.ItemName = new System.Windows.Forms.Label();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.btnAddToCart = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.ItemPicture = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddToCart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemPrice
            // 
            this.ItemPrice.AutoSize = true;
            this.ItemPrice.Font = new System.Drawing.Font("Mongolian Baiti", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemPrice.Location = new System.Drawing.Point(22, 176);
            this.ItemPrice.Name = "ItemPrice";
            this.ItemPrice.Size = new System.Drawing.Size(64, 20);
            this.ItemPrice.TabIndex = 1;
            this.ItemPrice.Text = "$00.00";
            this.ItemPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ItemPrice.Click += new System.EventHandler(this.ItemPrice_Click);
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.ItemName);
            this.guna2ShadowPanel1.Controls.Add(this.btnAddToCart);
            this.guna2ShadowPanel1.Controls.Add(this.ItemPrice);
            this.guna2ShadowPanel1.Controls.Add(this.ItemPicture);
            this.guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(202, 212);
            this.guna2ShadowPanel1.TabIndex = 0;
            this.guna2ShadowPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2ShadowPanel1_Paint);
            // 
            // ItemName
            // 
            this.ItemName.Font = new System.Drawing.Font("Mongolian Baiti", 16F);
            this.ItemName.Location = new System.Drawing.Point(22, 143);
            this.ItemName.Name = "ItemName";
            this.ItemName.Size = new System.Drawing.Size(71, 26);
            this.ItemName.TabIndex = 3;
            this.ItemName.Text = "Name";
            this.ItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ItemName.Click += new System.EventHandler(this.ItemName_Click);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 10;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddToCart.Image = ((System.Drawing.Image)(resources.GetObject("btnAddToCart.Image")));
            this.btnAddToCart.ImageRotate = 0F;
            this.btnAddToCart.Location = new System.Drawing.Point(140, 151);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnAddToCart.Size = new System.Drawing.Size(42, 44);
            this.btnAddToCart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAddToCart.TabIndex = 2;
            this.btnAddToCart.TabStop = false;
            this.btnAddToCart.UseTransparentBackground = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // ItemPicture
            // 
            this.ItemPicture.FillColor = System.Drawing.Color.Transparent;
            this.ItemPicture.Image = ((System.Drawing.Image)(resources.GetObject("ItemPicture.Image")));
            this.ItemPicture.ImageRotate = 0F;
            this.ItemPicture.Location = new System.Drawing.Point(14, 7);
            this.ItemPicture.Name = "ItemPicture";
            this.ItemPicture.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.ItemPicture.Size = new System.Drawing.Size(172, 133);
            this.ItemPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ItemPicture.TabIndex = 0;
            this.ItemPicture.TabStop = false;
            this.ItemPicture.UseTransparentBackground = true;
            this.ItemPicture.Click += new System.EventHandler(this.ItemPicture_Click);
            // 
            // FoodItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Name = "FoodItem";
            this.Size = new System.Drawing.Size(202, 212);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddToCart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox ItemPicture;
        private System.Windows.Forms.Label ItemPrice;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox btnAddToCart;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label ItemName;
    }
}
