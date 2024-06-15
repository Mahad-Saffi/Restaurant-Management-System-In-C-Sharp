using DLLForRMS.DLInterfaces;
using DLLForRMS.Utilities;
using DLLForRMS.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForRMS.DL
{
    public class OrderDB : IOrder
    {
        public List<Order> GetCustomerAllOrders(int userID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "SELECT * FROM Orders WHERE CustomerID = @userID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@userID", userID);

                    SqlDataReader reader = command.ExecuteReader();

                    List<Order> orders = new List<Order>();

                    while (reader.Read())
                    {
                        int orderID = (int)reader["OrderID"];
                        int UserID = (int)reader["CustomerID"];
                        DateTime Date_Time = (DateTime)reader["Date_Time"];
                        double TotalAmount = Convert.ToDouble(reader["TotalAmount"]);
                        string PaymentMethod = (string)reader["PaymentMethod"];
                        double Tip = Convert.ToDouble(reader["Tip"]);
                        double DeliveryCharge = Convert.ToDouble(reader["DeliveryCharges"]);
                        string DeliveryAddress = (string)reader["Address"];
                        string Status = (string)reader["Status"];
                        string OrderType = (string)reader["OrderType"];
                        int RiderID = reader["RiderID"] == DBNull.Value ? -1 : (int)reader["RiderID"];


                        Order order = new Order(orderID, UserID, Date_Time, TotalAmount, OrderType, DeliveryAddress, PaymentMethod, Tip, DeliveryCharge, RiderID, Status);

                        orders.Add(order);
                    }

                    return orders;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddOrder(Order order)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "INSERT INTO Orders (CustomerID, Date_Time, TotalAmount, OrderType, Address, PaymentMethod, Tip, DeliveryCharges, Status) VALUES (@UserID, @Date_Time, @TotalAmount, @OrderType, @DeliveryAddress, @PaymentMethod, @Tip, @DeliveryCharge, @Status)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserID", order.GetUserID());
                    command.Parameters.AddWithValue("@Date_Time", order.GetOrderDate());
                    command.Parameters.AddWithValue("@TotalAmount", order.GetTotalAmount());
                    command.Parameters.AddWithValue("@OrderType", order.GetOrderType());
                    command.Parameters.AddWithValue("@DeliveryAddress", order.GetOrderAddress());
                    command.Parameters.AddWithValue("@PaymentMethod", order.GetPaymentMethod());
                    command.Parameters.AddWithValue("@Tip", order.GetTip());
                    command.Parameters.AddWithValue("@DeliveryCharge", order.GetDeliveryCharge());
                    command.Parameters.AddWithValue("@Status", order.GetOrderStatus());

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

        public bool AddOrderDetails(Order order)
        {
            string connectionStr = GetConnectionString.ConnectionString();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "INSERT INTO OrderDetails (OrderID, ItemID, Price) VALUES (@OrderID, @ItemID, @Price)";

                    List<OrderDetails> orderDetails = order.GetOrderDetails();
                    foreach (var item in orderDetails)
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@OrderID", item.GetOrderID());
                            command.Parameters.AddWithValue("@ItemID", item.GetItemID());
                            command.Parameters.AddWithValue("@Price", item.GetOrderItemPrice());

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected <= 0)
                            {
                                return false;
                            }
                        }
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Order GetCustomerOrder(int customerID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "SELECT * FROM Orders WHERE CustomerID = @customerID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@customerID", customerID);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int orderID = (int)reader["OrderID"];
                        int UserID = (int)reader["CustomerID"];
                        DateTime Date_Time = (DateTime)reader["Date_Time"];
                        double TotalAmount = Convert.ToDouble(reader["TotalAmount"]);
                        string PaymentMethod = (string)reader["PaymentMethod"];
                        double Tip = Convert.ToDouble(reader["Tip"]);
                        double DeliveryCharge = Convert.ToDouble(reader["DeliveryCharges"]);
                        string DeliveryAddress = (string)reader["Address"];
                        string Status = (string)reader["Status"];
                        string OrderType = (string)reader["OrderType"];
                        int RiderID = reader["RiderID"] == DBNull.Value ? -1 : (int)reader["RiderID"];

                        Order order = new Order(orderID, UserID, Date_Time, TotalAmount, OrderType, DeliveryAddress, PaymentMethod, Tip, DeliveryCharge, RiderID, Status);

                        return order;
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

        public List<OrderDetails> GetOrderDetails(int orderID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "SELECT * FROM OrderDetails WHERE OrderID = @orderID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@orderID", orderID);

                    SqlDataReader reader = command.ExecuteReader();

                    List<OrderDetails> orderDetails = new List<OrderDetails>();

                    while (reader.Read())
                    {
                        int OrderID = (int)reader["OrderID"];
                        int ItemID = (int)reader["ItemID"];
                        double Price = Convert.ToDouble(reader["Price"]);

                        OrderDetails orderDetail = new OrderDetails(ItemID, OrderID, Price);

                        orderDetails.Add(orderDetail);
                    }

                    return orderDetails;
                }
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public int GetCustomerPurchases(int userID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Orders WHERE CustomerID = @userID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@userID", userID);

                    int count = (int)command.ExecuteScalar();

                    return count;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetCustomerPurchasesThisWeek(int userID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Orders WHERE CustomerID = @userID AND Date_Time BETWEEN DATEADD(day, -7, GETDATE()) AND GETDATE()";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@userID", userID);

                    object result = command.ExecuteScalar();

                    if (result == DBNull.Value)
                    {
                        return 0;
                    }
                    else
                    {
                        int count = Convert.ToInt32(result);
                        return count;
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public double GetTotalAmountOfPurchasesOfCustomer(int userID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "SELECT SUM(TotalAmount) FROM Orders WHERE CustomerID = @userID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@userID", userID);

                    object result = command.ExecuteScalar();

                    if (result == DBNull.Value)
                    {
                        return 0;
                    }
                    else
                    {
                        double totalAmount = Convert.ToDouble(result);
                        return totalAmount;
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public double GetTotalAmountOfSalesThisMonth()
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "SELECT SUM(TotalAmount) FROM Orders WHERE Date_Time BETWEEN DATEADD(month, DATEDIFF(month, 0, GETDATE()), 0) AND GETDATE()";
                    SqlCommand command = new SqlCommand(query, connection);

                    double totalAmount = Convert.ToDouble(command.ExecuteScalar());

                    return totalAmount;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public double GetTotalAmountOfSalesThisYear()
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "SELECT SUM(TotalAmount) FROM Orders WHERE Date_Time BETWEEN DATEADD(year, DATEDIFF(year, 0, GETDATE()), 0) AND GETDATE()";
                    SqlCommand command = new SqlCommand(query, connection);

                    double totalAmount = Convert.ToDouble(command.ExecuteScalar());

                    return totalAmount;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public List<string> GetTopItemsThisMonth()
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "SELECT TOP 5 i.Name FROM OrderDetails od INNER JOIN Items i ON od.ItemID = i.ItemID WHERE od.OrderID IN (SELECT OrderID FROM Orders WHERE Date_Time BETWEEN DATEADD(month, DATEDIFF(month, 0, GETDATE()), 0) AND GETDATE()) GROUP BY i.Name ORDER BY SUM(od.Price) DESC";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    List<string> topItems = new List<string>();

                    while (reader.Read())
                    {
                        string itemName = reader["Name"].ToString();
                        topItems.Add(itemName);
                    }

                    return topItems;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int GetTotalItemsSoldThisMonth()
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM OrderDetails WHERE OrderID IN (SELECT OrderID FROM Orders WHERE Date_Time BETWEEN DATEADD(month, DATEDIFF(month, 0, GETDATE()), 0) AND GETDATE())";
                    SqlCommand command = new SqlCommand(query, connection);

                    int count = (int)command.ExecuteScalar();

                    return count;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetMostOrdersInDay()
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "SELECT TOP 1 COUNT(*) FROM Orders GROUP BY Date_Time ORDER BY COUNT(*) DESC";
                    SqlCommand command = new SqlCommand(query, connection);

                    int count = (int)command.ExecuteScalar();

                    return count;
                }
            }
            catch
            {
                return 0;
            }
        }

        public string GetBestItemThisMonth()
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "SELECT i.Name FROM OrderDetails od INNER JOIN Items i ON od.ItemID = i.ItemID WHERE od.OrderID IN (SELECT OrderID FROM Orders WHERE Date_Time BETWEEN DATEADD(month, DATEDIFF(month, 0, GETDATE()), 0) AND GETDATE()) GROUP BY i.Name ORDER BY SUM(od.Price) DESC";
                    SqlCommand command = new SqlCommand(query, connection);

                    string itemName = (string)command.ExecuteScalar();

                    return itemName;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public List<Order> LoadOrders()
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "SELECT * FROM Orders";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    List<Order> orders = new List<Order>();

                    while (reader.Read())
                    {
                        int orderID = (int)reader["OrderID"];
                        int UserID = (int)reader["CustomerID"];
                        DateTime Date_Time = (DateTime)reader["Date_Time"];
                        double TotalAmount = Convert.ToDouble(reader["TotalAmount"]);
                        string PaymentMethod = (string)reader["PaymentMethod"];
                        double Tip = Convert.ToDouble(reader["Tip"]);
                        double DeliveryCharge = Convert.ToDouble(reader["DeliveryCharges"]);
                        string DeliveryAddress = (string)reader["Address"];
                        string Status = (string)reader["Status"];
                        string OrderType = (string)reader["OrderType"];

                        Order order = new Order(orderID, UserID, Date_Time, TotalAmount, OrderType, DeliveryAddress, PaymentMethod, Tip, DeliveryCharge, Status);

                        orders.Add(order);
                    }

                    return orders;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Order> LoadRiderOrdersByRiderID(int riderID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "SELECT * FROM Orders WHERE RiderID = @riderID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@riderID", riderID);

                    SqlDataReader reader = command.ExecuteReader();

                    List<Order> orders = new List<Order>();

                    while (reader.Read())
                    {
                        int OrderID = (int)reader["OrderID"];
                        int UserID = (int)reader["CustomerID"];
                        DateTime Date_Time = (DateTime)reader["Date_Time"];
                        double TotalAmount = Convert.ToDouble(reader["TotalAmount"]);
                        string PaymentMethod = (string)reader["PaymentMethod"];
                        double Tip = Convert.ToDouble(reader["Tip"]);
                        double DeliveryCharge = Convert.ToDouble(reader["DeliveryCharges"]);
                        string DeliveryAddress = (string)reader["Address"];
                        string Status = (string)reader["Status"];
                        string OrderType = (string)reader["OrderType"];
                        int RiderID = (int)reader["RiderID"];

                        Order order = new Order(OrderID, UserID, Date_Time, TotalAmount, OrderType, DeliveryAddress, PaymentMethod, Tip, DeliveryCharge, RiderID, Status);

                        orders.Add(order);
                    }

                    return orders;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Order LoadOrderByOrderID(int orderID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "SELECT * FROM Orders WHERE OrderID = @orderID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@orderID", orderID);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int OrderID = (int)reader["OrderID"];
                        int UserID = (int)reader["CustomerID"];
                        DateTime Date_Time = (DateTime)reader["Date_Time"];
                        double TotalAmount = Convert.ToDouble(reader["TotalAmount"]);
                        string PaymentMethod = (string)reader["PaymentMethod"];
                        double Tip = Convert.ToDouble(reader["Tip"]);
                        double DeliveryCharge = Convert.ToDouble(reader["DeliveryCharges"]);
                        string DeliveryAddress = (string)reader["Address"];
                        string Status = (string)reader["Status"];
                        string OrderType = (string)reader["OrderType"];
                        int RiderID = reader["RiderID"] == DBNull.Value ? -1 : (int)reader["RiderID"];

                        Order order = new Order(OrderID, UserID, Date_Time, TotalAmount, OrderType, DeliveryAddress, PaymentMethod, Tip, DeliveryCharge, RiderID, Status);

                        return order;
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

        public string GetOrderStatus(int orderID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "SELECT Status FROM Orders WHERE OrderID = @orderID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@orderID", orderID);

                    string status = (string)command.ExecuteScalar();

                    return status;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public string GetOrderType(int orderID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "SELECT OrderType FROM Orders WHERE OrderID = @orderID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@orderID", orderID);

                    string orderType = (string)command.ExecuteScalar();

                    return orderType;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public bool UpdateOrderStatus(int orderID, string status)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "UPDATE Orders SET Status = @status WHERE OrderID = @orderID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@orderID", orderID);
                    command.Parameters.AddWithValue("@status", status);

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

        public bool AcceptOrder(int orderID, int RiderID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "UPDATE Orders SET Status = 'accepted', RiderID = @RiderID WHERE OrderID = @orderID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@orderID", orderID);
                    command.Parameters.AddWithValue("@RiderID", RiderID);

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

        public bool RejectOrder(int orderID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "UPDATE Orders SET Status = 'pending', RiderID = -1 WHERE OrderID = @orderID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@orderID", orderID);

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

        public Order LoadAcceptedOrderByRiderID(int riderID)
        {
            try
            {
                string connectionStr = GetConnectionString.ConnectionString();

                using (SqlConnection connection = new SqlConnection(connectionStr))
                {
                    connection.Open();

                    string query = "SELECT * FROM Orders WHERE RiderID = @riderID AND Status IN ('accepted', 'en-route', 'picked')";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@riderID", riderID);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int OrderID = (int)reader["OrderID"];
                        int UserID = (int)reader["CustomerID"];
                        DateTime Date_Time = (DateTime)reader["Date_Time"];
                        double TotalAmount = Convert.ToDouble(reader["TotalAmount"]);
                        string PaymentMethod = (string)reader["PaymentMethod"];
                        double Tip = Convert.ToDouble(reader["Tip"]);
                        double DeliveryCharge = Convert.ToDouble(reader["DeliveryCharges"]);
                        string DeliveryAddress = (string)reader["Address"];
                        string Status = (string)reader["Status"];
                        string OrderType = (string)reader["OrderType"];
                        int RiderID = (int)reader["RiderID"];

                        Order order = new Order(OrderID, UserID, Date_Time, TotalAmount, OrderType, DeliveryAddress, PaymentMethod, Tip, DeliveryCharge, RiderID, Status);

                        return order;
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
    }
}
