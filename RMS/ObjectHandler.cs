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
        private static ICart cartDB = new CartDB();
        private static IOrder orderDB = new OrderDB();
        private static IInbox inboxDB = new InboxDB();
        private static IAttendance attendanceDB = new AttendanceDB();
        private static IUtility utilityDB = new UtilityDB();

        public static IUser GetUserDL()
        {
            return userDB;
        }

        public static IItem GetItemDL()
        {
            return itemDB;
        }

        public static ICart GetCartDL()
        {
            return cartDB;
        }

        public static IOrder GetOrderDL()
        {
            return orderDB;
        }

        public static IUtility GetUtilityDL()
        {
            return utilityDB;
        }

        public static IInbox GetInboxDL()
        {
            return inboxDB;
        }

        public static IAttendance GetAttendanceDL()
        {
            return attendanceDB;
        }
    }
}
