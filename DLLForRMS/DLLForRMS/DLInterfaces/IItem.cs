using DLLForRMS.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForRMS.DLInterfaces
{
    public interface IItem
    {
        List<Item> LoadItems();
        Item LoadLastItem();
        Item LoadItemByItemID(int itemID);
        bool AddItem(Item item);
        bool UpdateItem(Item item);
        bool DeleteItem(int itemID);
        List<int> LoadItemsID();
        double GetTotalCostOfPurchases();
    }
}
