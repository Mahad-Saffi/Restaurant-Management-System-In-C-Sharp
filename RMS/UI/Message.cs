using DLLForRMS.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS.UI
{
    public partial class Message : UserControl
    {
        public Message(Inbox inbox)
        {
            InitializeComponent();
            User user = ObjectHandler.GetUserDL().GetUserByUserID(inbox.getSenderID());
            TextUsername = user.getUsername();
            TextRole = user.getRole().ToUpper();
            TextMessage = inbox.getMessage();
            TextDateTime = inbox.getSentDateTime().ToString();
        }

        private void Message_Load(object sender, EventArgs e)
        {

        }

        public string TextUsername
        {
            get { return Username.Text; }
            set { Username.Text = value; }
        }

        public string TextRole
        {
            get { return Role.Text; }
            set { Role.Text = value; }
        }

        public string TextDateTime
        {
            get { return MessageDateTime.Text; }
            set { MessageDateTime.Text = value; }
        }

        public string TextMessage
        {
            get { return TxtMessage.Text; }
            set { TxtMessage.Text = value; }
        }

        
    }
}
