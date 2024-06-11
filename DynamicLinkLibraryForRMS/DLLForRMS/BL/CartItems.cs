using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForRMS.BL
{
    public class CartItems
    {
        private int cartItemID;
        private int cartID;
        private int itemID;
        private double price;

        public CartItems(int cartID, int itemID, double price)
        {
            this.cartID = cartID;
            this.itemID = itemID;
            this.price = price;
        }

        public CartItems(int cartItemID, int cartID, int itemID, double price)
        {
            this.cartItemID = cartItemID;
            this.cartID = cartID;
            this.itemID = itemID;
            this.price = price;
        }

        public int GetItemID()
        {
            return itemID;
        }

        public double GetCartItemPrice()
        {
            return price;
        }

        public int GetCartID()
        {
            return cartID;
        }


    }
}
