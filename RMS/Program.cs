using RMS.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DLLForRMS.BL;
using DLLForRMS.Utilities;

namespace RMS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ///Integration of Admin Account Code Goes Here
            
            Application.Run(new LoginForm());
        }
    }
}
