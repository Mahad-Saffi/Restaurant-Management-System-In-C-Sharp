using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForRMS.BL
{
    public class OrderDetails
    {
        private int itemID;
        private int orderID;
        private double price;

        public OrderDetails(int itemID, int orderID, double price)
        {
            this.itemID = itemID;
            this.orderID = orderID;
            this.price = price;
        }

        public int GetItemID()
        {
            return itemID;
        }

        public int GetOrderID()
        {
            return orderID;
        }

        public double GetOrderItemPrice()
        {
            return price;
        }
    }
}
