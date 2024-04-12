using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLLForRMS;
using DLLForRMS.DLInterfaces;
using DLLForRMS.DL;

namespace RMS
{
    public class ObjectHandler
    {
        private static IUser userDB = new UserDB();
        private static IItem itemDB = new ItemDB();
        private static IOrder orderDB = new OrderDB();
        private static IUtility utilityDB = new UtilityDB();

        public static IUser GetUserDL()
        {
            return userDB;
        }

        public static IItem GetItemDL()
        {
            return itemDB;
        }

        public static IOrder GetOrderDL()
        {
            return orderDB;
        }

        public static IUtility GetUtilityDL()
        {
            return utilityDB;
        }
    }
}
