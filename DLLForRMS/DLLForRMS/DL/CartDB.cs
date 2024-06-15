using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DLLForRMS.BL;
using DLLForRMS.DLInterfaces;
using DLLForRMS.Utilities;

namespace DLLForRMS.DL
{
    public class CartDB : ICart
    {
        public bool AddCart(Cart cart)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "INSERT INTO Carts (UserID, CreatedDate) VALUES (@UserID, @CreatedDate)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserID", cart.GetCustomerID());
                    command.Parameters.AddWithValue("@CreatedDate", cart.GetCartCreatedDate());

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Cart LoadCartByCustomerID(int customerID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "SELECT * FROM Carts WHERE UserID = @UserID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserID", customerID);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int CartID = (reader.GetInt32(0));
                        int CustomerID = (reader.GetInt32(1));
                        DateTime createdDate = (reader.GetDateTime(2));

                        Cart cart = new Cart(CartID, CustomerID, createdDate);

                        return cart;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool IsCartPresent(int customerID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "SELECT * FROM Carts WHERE UserID = @UserID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserID", customerID);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddItemToCart(int cartID, int itemID, double price)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "INSERT INTO CartItems (CartID, ItemID, Price) VALUES (@CartID, @ItemID, @Price)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CartID", cartID);
                    command.Parameters.AddWithValue("@ItemID", itemID);
                    command.Parameters.AddWithValue("@Price", price);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<CartItems> LoadCartItems(int cartID)
        {
            try
            {
                List<CartItems> cartItems = new List<CartItems>();
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "SELECT * FROM CartItems WHERE CartID = @CartID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CartID", cartID);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int cartItemID = (reader.GetInt32(0));
                        int CartID = (reader.GetInt32(1));
                        int ItemID = (reader.GetInt32(2));
                        double Price = Convert.ToDouble(reader.GetValue(3));

                        CartItems cartItem = new CartItems(cartItemID, CartID, ItemID, Price);
                        cartItems.Add(cartItem);
                    }

                    return cartItems;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool ClearCartItems(int cartID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "DELETE FROM CartItems WHERE CartID = @CartID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CartID", cartID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ClearCart(int cartID)
        {
            try
            {
                if (!ClearCartItems(cartID))
                {
                    return false;
                }
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "DELETE FROM CartItems WHERE CartID = @CartID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CartID", cartID);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
