using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForRMS.BL
{
    public class Item
    {
        private int itemID;
        private string itemName;
        private double itemPrice;
        private double costOfPurchase;
        private byte[] itemPicture;

        public Item(string itemName, double itemPrice, double costOfPurchase)
        {
            this.itemName = itemName;
            this.itemPrice = itemPrice;
            this.costOfPurchase = costOfPurchase;
        }

        public Item(string itemName, double itemPrice, double costOfPurchase, byte[] itemPicture)
        {
            this.itemName = itemName;
            this.itemPrice = itemPrice;
            this.costOfPurchase = costOfPurchase;
            this.itemPicture = itemPicture;
        }

        public Item(int itemID, string itemName, double itemPrice, double costOfPurchase)
        {
            this.itemID = itemID;
            this.itemName = itemName;
            this.itemPrice = itemPrice;
            this.costOfPurchase = costOfPurchase;
        }

        public Item(int itemID, string itemName, double itemPrice, double costOfPurchase, byte[] itemPicture)
        {
            this.itemID = itemID;
            this.itemName = itemName;
            this.itemPrice = itemPrice;
            this.costOfPurchase = costOfPurchase;
            this.itemPicture = itemPicture;
        }

        public int getItemID()
        {
            return itemID;
        }

        public string getItemName()
        {
            return itemName;
        }

        public double getItemPrice()
        {
            return itemPrice;
        }

        public double getCostOfPurchase()
        {
            return costOfPurchase;
        }

        public byte[] getItemPicture()
        {
            return itemPicture;
        }

        public void setItemID(int itemID)
        {
            this.itemID = itemID;
        }

        public void setItemName(string itemName)
        {
            this.itemName = itemName;
        }

        public void setItemPrice(double itemPrice)
        {
            this.itemPrice = itemPrice;
        }

        public void setCostOfPurchase(double costOfPurchase)
        {
            this.costOfPurchase = costOfPurchase;
        }

        public void setItemPicture(byte[] itemPicture)
        {
            this.itemPicture = itemPicture;
        }


    }
}
