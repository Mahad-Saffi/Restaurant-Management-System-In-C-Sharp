using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DLLForRMS.Utilities
{
    public static class GetConnectionString
    {
        private static string connectionString = "Data Source=DESKTOP-0000000;Initial Catalog=RMSDatabase;Integrated Security=True;";
        private static string filePath = "D:\\CS 2023\\2nd Semester\\OOP\\Item.txt";

        public static string ConnectionString()
        {
            return connectionString;
        }

        public static void SetConnectionString(string newConnectionString)
        {
            connectionString = newConnectionString;
        }

        public static string FilePath()
        {
            return filePath;
        }
    }
}
