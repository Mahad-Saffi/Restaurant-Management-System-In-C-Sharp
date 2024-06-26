﻿using DLLForRMS.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS.UI
{
    public partial class FoodItem : UserControl
    {
        Item item;  //item oject
        Customer customer;     //customer object
        public FoodItem(Item item, Customer customer)
        {
            InitializeComponent();
            ItemName.Text = item.getItemName();
            ItemPrice.Text = "$" + item.getItemPrice().ToString();
            ItemPicture.Image = Image.FromStream(new MemoryStream(item.getItemPicture()));
            this.item = item;
            this.customer = customer;
        }

        private void ItemPrice_Click(object sender, EventArgs e)
        {

        }

        private void ItemPicture_Click(object sender, EventArgs e)
        {

        }

        public string TxtItemName        
        {
            get { return ItemName.Text; }   //getter setters
            set { ItemName.Text = value; }
        }

        public double TxtItemPrice
        {
            get { return Convert.ToDouble(ItemPrice.Text); }        //getter setters
            set { ItemPrice.Text = value.ToString(); }
        }

        public Image ImageItemPicture
        {
            get { return ItemPicture.Image; }                      //getter setters
            set { ItemPicture.Image = value; }
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ItemName_Click(object sender, EventArgs e)
        {

        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            // Add the item to the cart
            Cart cart = ObjectHandler.GetCartDL().LoadCartByCustomerID(customer.getUserID());
            if(ObjectHandler.GetCartDL().AddItemToCart(cart.GetCartID(), item.getItemID(), item.getItemPrice()))
            {
                //to show that item added
                MessageBox.Show("Item added to cart successfully.");    
            }
            else       //if not added in cart
            {
                MessageBox.Show("Failed to add item to cart.");        
            }
        }
    }
}
