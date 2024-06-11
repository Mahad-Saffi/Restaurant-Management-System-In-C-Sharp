using DLLForRMS.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForRMS.DLInterfaces
{
    public interface ICart
    {
        bool AddCart(Cart cart);
        Cart LoadCartByCustomerID(int customerID);
        bool IsCartPresent(int customerID);
        bool AddItemToCart(int cartID, int itemID, double price);
        List<CartItems> LoadCartItems(int cartID);
        bool ClearCart(int cartID);






















    }
}
