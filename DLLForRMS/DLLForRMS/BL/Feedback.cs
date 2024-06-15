using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForRMS.BL
{
    public class Feedback
    {
        int customerID;
        int rating;

        public Feedback(int customerID, int rating)
        {
            this.customerID = customerID;
            this.rating = rating;
        }
    }
}
