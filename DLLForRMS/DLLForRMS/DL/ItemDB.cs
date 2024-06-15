using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLLForRMS.BL;
using DLLForRMS.DLInterfaces;
using DLLForRMS.Utilities;
using System.Data.SqlClient;
using System.Drawing;

namespace DLLForRMS.DL
{
    public class ItemDB : IItem
    {
        public List<Item> LoadItems()
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    try
                    {
                        List<Item> items = new List<Item>();

                        SqlCommand cmd = new SqlCommand("SELECT * FROM Items", connection);
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int itemID = Convert.ToInt32(reader["ItemID"]);
                                string itemName = reader["Name"].ToString();
                                double itemPrice = Convert.ToDouble(reader["Price"]);
                                double itemCost = Convert.ToDouble(reader["CostOfPurchase"]);
                                byte[] picture = (byte[])reader["Picture"];

                                Item item = new Item(itemID, itemName, itemPrice, itemCost, picture);
                                items.Add(item);
                            }
                            reader.Close();
                        }
                        connection.Close();
                        return items;
                    }
                    catch (Exception ex)
                    {
                        connection.Close();
                        return null;
                    }
                }
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
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    try
                    {
                        Item item = null;

                        SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM Items ORDER BY ItemID DESC", connection);
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int itemID = Convert.ToInt32(reader["ItemID"]);
                                string itemName = reader["Name"].ToString();
                                double itemPrice = Convert.ToDouble(reader["Price"]);
                                double itemCost = Convert.ToDouble(reader["CostOfPurchase"]);

                                item = new Item(itemID, itemName, itemPrice, itemCost);
                            }
                            reader.Close();
                        }
                        connection.Close();
                        return item;
                    }
                    catch (Exception ex)
                    {
                        connection.Close();
                        return null;
                    }
                }
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
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    try
                    {
                        Item item = null;

                        SqlCommand cmd = new SqlCommand("SELECT * FROM Items WHERE ItemID = @ItemID", connection);
                        cmd.Parameters.AddWithValue("@ItemID", itemID);
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string itemName = reader["Name"].ToString();
                                double itemPrice = Convert.ToDouble(reader["Price"]);
                                double itemCost = Convert.ToDouble(reader["CostOfPurchase"]);

                                item = new Item(itemID, itemName, itemPrice, itemCost);
                            }
                            reader.Close();
                        }
                        connection.Close();
                        return item;
                    }
                    catch (Exception ex)
                    {
                        connection.Close();
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<int> LoadItemsID()
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    try
                    {
                        List<int> itemsID = new List<int>();

                        SqlCommand cmd = new SqlCommand("SELECT ItemID FROM Items", connection);
                        connection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int itemID = Convert.ToInt32(reader["ItemID"]);
                                itemsID.Add(itemID);
                            }
                            reader.Close();
                        }
                        connection.Close();
                        return itemsID;
                    }
                    catch (Exception ex)
                    {
                        connection.Close();
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddItem(Item item)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    try
                    {
                        connection.Open();
                        string query = "Insert into Items (Name, Price, CostOfPurchase) values (@ItemName, @ItemPrice, @CostOfPurchase)";
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@ItemName", item.getItemName());
                        cmd.Parameters.AddWithValue("@ItemPrice", item.getItemPrice());
                        cmd.Parameters.AddWithValue("@CostOfPurchase", item.getCostOfPurchase());

                        int result = cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Handle exception
                        return false;
                    }
                }
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
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE Items SET Name = @ItemName, Price = @ItemPrice, CostOfPurchase = @CostOfPurchase WHERE ItemID = @ItemID", connection);
                        cmd.Parameters.AddWithValue("@ItemID", item.getItemID());
                        cmd.Parameters.AddWithValue("@ItemName", item.getItemName());
                        cmd.Parameters.AddWithValue("@ItemPrice", item.getItemPrice());
                        cmd.Parameters.AddWithValue("@CostOfPurchase", item.getCostOfPurchase());

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Log or handle the exception
                        return false;
                    }
                }
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
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand("DELETE FROM Items WHERE ItemID = @ItemID", connection);
                        cmd.Parameters.AddWithValue("@ItemID", itemID);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Log or handle the exception
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public double GetTotalCostOfPurchases()
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();
                    try
                    {
                        double totalCost = 0;

                        SqlCommand cmd = new SqlCommand("SELECT SUM(CostOfPurchase) FROM Items", connection);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                totalCost = Convert.ToDouble(reader[0]);
                            }
                        }
                        connection.Close();
                        return totalCost;
                    }
                    catch (Exception ex)
                    {
                        connection.Close();
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
