using DLLForRMS.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForRMS.DLInterfaces
{
    public interface IFeedback
    {
        bool AddFeedback(int customerID, int rating);
        List<int> LoadAllFeedbacks();
    }
}
