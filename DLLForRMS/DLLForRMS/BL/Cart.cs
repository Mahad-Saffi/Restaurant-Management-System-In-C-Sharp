using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForRMS.BL
{
    public class Cart
    {
        private int cartID = 0;
        private int customerID;
        private DateTime dateCreated;
        private List<CartItems> cartItems;

        public Cart(int customerID)
        {
            this.customerID = customerID;
            this.dateCreated = DateTime.Now;
            this.cartItems = new List<CartItems>();
        }

        public Cart(int cartID, DateTime dateCreated)
        {
            this.cartID = cartID;
            this.dateCreated = dateCreated;
            this.cartItems = new List<CartItems>();
        }

        public Cart(int cartID, int customerID, DateTime dateCreated)
        {
            this.cartID = cartID;
            this.customerID = customerID;
            this.dateCreated = dateCreated;
        }

        public void AddCartItems(CartItems cartItem)
        {
            cartItems.Add(cartItem);
        }

        public List<CartItems> GetCartItems()
        {
            return cartItems;
        }

        public int GetCartID()
        {
            return cartID;
        }

        public int GetCustomerID()
        {
            return customerID;
        }

        public int GetCartCreatedDate()
        {
            return dateCreated.Day;
        }
    }
}
