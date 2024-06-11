using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLLForRMS;
using DLLForRMS.DLInterfaces;
using DLLForRMS.DL;
using DLLForRMS.Utilities;

namespace RMS
{
    public class ObjectHandler
    {

        //implementing the factory pattern
        private static IUser userDB = new UserDB();           //to Get Reference of all the 
        private static IItem itemDB = new ItemDB();
        private static ICart cartDB = new CartDB();
        private static IOrder orderDB = new OrderDB();
        private static IInbox inboxDB = new InboxDB();
        private static IAttendance attendanceDB = new AttendanceDB();
        private static IUtility utilityDB = new UtilityDB();
        private static IFeedback feedbackDB = new FeedbackDB();
        private static Validations validations = new Validations();


        public static IUser GetUserDL()        //to det instance of all the objjects
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

        public static IFeedback GetFeedbackDL()
        {
            return feedbackDB;
        }

        public static Validations GetValidations()
        {
            return validations;
        }
    }
}
