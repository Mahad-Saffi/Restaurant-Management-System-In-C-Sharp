using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using DLLForRMS.BL;
using DLLForRMS.DLInterfaces;
using DLLForRMS.Utilities;

namespace DLLForRMS.DL
{
    public class ItemFH : IItem
    {
        //This Class is used to handle the Item class with file handling

        public List<Item> LoadItems()
        {
            try
            {
                string filePath = GetConnectionString.FilePath();
                List<Item> items = new List<Item>();
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    Item item = new Item(int.Parse(parts[0]), parts[1], double.Parse(parts[2]), double.Parse(parts[3]));
                    items.Add(item);
                }
                return items;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Item LoadLastItem()
        {
            try
            {
                string filePath = GetConnectionString.FilePath();
                string[] lines = File.ReadAllLines(filePath);
                string lastLine = lines[lines.Length - 1];
                string[] parts = lastLine.Split(',');
                Item item = new Item(int.Parse(parts[0]), parts[1], double.Parse(parts[2]), double.Parse(parts[3]));
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Item LoadItemByItemID(int itemID)
        {
            try
            {
                string filePath = GetConnectionString.FilePath();
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (int.Parse(parts[0]) == itemID)
                    {
                        Item item = new Item(int.Parse(parts[0]), parts[1], double.Parse(parts[2]), double.Parse(parts[3]));
                        return item;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddItem(Item item)
        {
            string filePath = GetConnectionString.FilePath();
            try
            {
                List<Item> items = LoadItems();
                int nextID = 1;

                if (items != null && items.Count > 0)
                {
                    nextID = items.Max(i => i.getItemID()) + 1;
                }

                item.setItemID(nextID);

                string line = nextID + "," + item.getItemName() + "," + item.getItemPrice() + "," + item.getCostOfPurchase();
                File.AppendAllText(filePath, line + Environment.NewLine);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool UpdateItem(Item item)
        {
            try
            {
                string filePath = GetConnectionString.FilePath();
                string[] lines = File.ReadAllLines(filePath);
                string output = "";
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (int.Parse(parts[0]) == item.getItemID())
                    {
                        output += item.getItemID() + "," + item.getItemName() + "," + item.getItemPrice() + "," + item.getCostOfPurchase() + Environment.NewLine;
                    }
                    else
                    {
                        output += line + Environment.NewLine;
                    }
                }
                File.WriteAllText(filePath, output);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteItem(int itemID)
        {
            try
            {
                string filePath = GetConnectionString.FilePath();
                string[] lines = File.ReadAllLines(filePath);
                string output = "";
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (int.Parse(parts[0]) != itemID)
                    {
                        output += line + Environment.NewLine;
                    }
                }
                File.WriteAllText(filePath, output);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<int> LoadItemsID()
        {
            try
            {
                string filePath = GetConnectionString.FilePath();
                List<int> itemIDs = new List<int>();
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    itemIDs.Add(int.Parse(parts[0]));
                }
                return itemIDs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public double GetTotalCostOfPurchases()
        {
            try
            {
                string filePath = GetConnectionString.FilePath();
                double totalCost = 0;
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    totalCost += double.Parse(parts[3]);
                }
                return totalCost;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
