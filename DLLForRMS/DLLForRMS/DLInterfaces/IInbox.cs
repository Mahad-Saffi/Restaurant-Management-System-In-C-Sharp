using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLLForRMS.BL;

namespace DLLForRMS.DLInterfaces
{
    public interface IInbox
    {
        List<Inbox> LoadMessagesByUserID(User user);
        bool SendMessage(Inbox inbox);
    }
}
