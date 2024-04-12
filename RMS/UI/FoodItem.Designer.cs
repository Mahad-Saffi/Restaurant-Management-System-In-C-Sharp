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
            this.ItemPicture = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.LabelItemPrice = new System.Windows.Forms.Label();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.AddToCart = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.ItemName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ItemPicture)).BeginInit();
            this.guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddToCart)).BeginInit();
            this.SuspendLayout();
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
            // 
            // LabelItemPrice
            // 
            this.LabelItemPrice.AutoSize = true;
            this.LabelItemPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelItemPrice.Location = new System.Drawing.Point(24, 176);
            this.LabelItemPrice.Name = "LabelItemPrice";
            this.LabelItemPrice.Size = new System.Drawing.Size(53, 24);
            this.LabelItemPrice.TabIndex = 1;
            this.LabelItemPrice.Text = "Price";
            this.LabelItemPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelItemPrice.Click += new System.EventHandler(this.ItemPrice_Click);
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.ItemName);
            this.guna2ShadowPanel1.Controls.Add(this.AddToCart);
            this.guna2ShadowPanel1.Controls.Add(this.LabelItemPrice);
            this.guna2ShadowPanel1.Controls.Add(this.ItemPicture);
            this.guna2ShadowPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(202, 212);
            this.guna2ShadowPanel1.TabIndex = 0;
            // 
            // AddToCart
            // 
            this.AddToCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddToCart.Image = ((System.Drawing.Image)(resources.GetObject("AddToCart.Image")));
            this.AddToCart.ImageRotate = 0F;
            this.AddToCart.Location = new System.Drawing.Point(140, 151);
            this.AddToCart.Name = "AddToCart";
            this.AddToCart.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.AddToCart.Size = new System.Drawing.Size(42, 44);
            this.AddToCart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AddToCart.TabIndex = 2;
            this.AddToCart.TabStop = false;
            this.AddToCart.UseTransparentBackground = true;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 10;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // ItemName
            // 
            this.ItemName.AutoSize = true;
            this.ItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.ItemName.Location = new System.Drawing.Point(22, 143);
            this.ItemName.Name = "ItemName";
            this.ItemName.Size = new System.Drawing.Size(71, 26);
            this.ItemName.TabIndex = 3;
            this.ItemName.Text = "Name";
            this.ItemName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FoodItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Name = "FoodItem";
            this.Size = new System.Drawing.Size(202, 212);
            ((System.ComponentModel.ISupportInitialize)(this.ItemPicture)).EndInit();
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddToCart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CirclePictureBox ItemPicture;
        private System.Windows.Forms.Label LabelItemPrice;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox AddToCart;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label ItemName;
    }
}
