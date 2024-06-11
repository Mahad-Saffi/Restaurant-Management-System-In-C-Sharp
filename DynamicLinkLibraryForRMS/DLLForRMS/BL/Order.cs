using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForRMS.BL
{
    public class Order
    {
        private int orderID;
        private int userID;
        private DateTime orderDate;
        private double totalAmount;
        private string orderType;
        private string address;
        private string paymentMethod;
        private double tip;
        private double delieveryCharge;
        private int rider;
        private string status;
        private List<OrderDetails> orderDetails;

        public Order(int userID, DateTime orderDate, double totalAmount, string orderType, string address, string paymentMethod, double tip, double delieveryCharge, string status)
        {
            this.userID = userID;
            this.orderDate = orderDate;
            this.totalAmount = totalAmount;
            this.orderType = orderType;
            this.address = address;
            this.paymentMethod = paymentMethod;
            this.tip = tip;
            this.delieveryCharge = delieveryCharge;
            this.status = status;
            this.orderDetails = new List<OrderDetails>();
        }

        public Order(int orderID, int userID, DateTime orderDate, double totalAmount, string orderType, string address, string paymentMethod, double tip, double delieveryCharge, string status)
        {
            this.orderID = orderID;
            this.userID = userID;
            this.orderDate = orderDate;
            this.totalAmount = totalAmount;
            this.orderType = orderType;
            this.address = address;
            this.paymentMethod = paymentMethod;
            this.tip = tip;
            this.delieveryCharge = delieveryCharge;
            this.status = status;
            this.orderDetails = new List<OrderDetails>();
        }

        public Order(int orderID, int userID, DateTime orderDate, double totalAmount, string orderType, string address, string paymentMethod, double tip, double delieveryCharge, int rider, string status)
        {
            this.orderID = orderID;
            this.userID = userID;
            this.orderDate = orderDate;
            this.totalAmount = totalAmount;
            this.orderType = orderType;
            this.address = address;
            this.paymentMethod = paymentMethod;
            this.tip = tip;
            this.delieveryCharge = delieveryCharge;
            this.rider = rider;
            this.status = status;
            this.orderDetails = new List<OrderDetails>();
        }

        public void AddOrderDetails(OrderDetails orderDetails)
        {
            this.orderDetails.Add(orderDetails);
        }

        public List<OrderDetails> GetOrderDetails()
        {
            return orderDetails;
        }

        public int GetUserID()
        {
            return userID;
        }

        public int GetOrderID()
        {
            return orderID;
        }

        public DateTime GetOrderDate()
        {
            return orderDate;
        }

        public double GetTotalAmount()
        {
            return totalAmount;
        }

        public string GetOrderType()
        {
            return orderType;
        }

        public string GetPaymentMethod()
        {
            return paymentMethod;
        }

        public double GetTip()
        {
            return tip;
        }

        public double GetDeliveryCharge()
        {
            return delieveryCharge;
        }

        public string GetOrderAddress()
        {
            return address;
        }

        public string GetOrderStatus()
        {
            return status;
        }

        public int GetRider()
        {
            return rider;
        }

        public string GetAddress()
        {
            return address;
        }

        public string GetAddressInConcatenatedForm()
        {
            string addressInConcatenatedForm = "";

            for (int i = 0; i < address.Length; i++)
            {
                if (address[i] == ' ')
                {
                    addressInConcatenatedForm += "+";
                }
                else
                {
                    addressInConcatenatedForm += address[i];
                }
            }

            return $"www.google.com/maps/place/{addressInConcatenatedForm}";
        }
    }
}
