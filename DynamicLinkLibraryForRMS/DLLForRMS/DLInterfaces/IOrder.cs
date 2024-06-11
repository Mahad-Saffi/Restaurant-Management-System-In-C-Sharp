using DLLForRMS.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForRMS.DLInterfaces
{
    public interface IOrder
    {
        List<Order> GetCustomerAllOrders(int userID);
        bool AddOrder(Order order);
        bool AddOrderDetails(Order order);
        Order GetCustomerOrder(int customerID);
        List<OrderDetails> GetOrderDetails(int orderID);
        int GetCustomerPurchases(int userID);
        int GetCustomerPurchasesThisWeek(int userID);
        double GetTotalAmountOfPurchasesOfCustomer(int userID);
        double GetTotalAmountOfSalesThisMonth();
        double GetTotalAmountOfSalesThisYear();
        List<string> GetTopItemsThisMonth();
        int GetTotalItemsSoldThisMonth();
        int GetMostOrdersInDay();
        string GetBestItemThisMonth();
        List<Order> LoadOrders();
        List<Order> LoadRiderOrdersByRiderID(int riderID);
        Order LoadOrderByOrderID(int orderID);
        string GetOrderStatus(int orderID);
        string GetOrderType(int orderID);
        bool UpdateOrderStatus(int orderID, string status);
        bool AcceptOrder(int orderID, int RiderID);
        bool RejectOrder(int orderID);
        Order LoadAcceptedOrderByRiderID(int riderID);
    }
}
