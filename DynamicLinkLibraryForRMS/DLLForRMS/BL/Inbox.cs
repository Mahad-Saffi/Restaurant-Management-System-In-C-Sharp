using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLLForRMS.BL
{
    public class Inbox
    {
        private int messageID;
        private int senderID;
        private int receiverID;
        private string message;
        private DateTime sentDateTime;

        public Inbox(int senderID, int receiverID, string message, DateTime sentDateTime)
        {
            this.senderID = senderID;
            this.receiverID = receiverID;
            this.message = message;
            this.sentDateTime = sentDateTime;
        }

        public Inbox(int messageID, int senderID, int receiverID, string message, DateTime sentDateTime)
        {
            this.messageID = messageID;
            this.senderID = senderID;
            this.receiverID = receiverID;
            this.message = message;
            this.sentDateTime = sentDateTime;
        }

        public int getMessageID()
        {
            return messageID;
        }

        public int getSenderID()
        {
            return senderID;
        }

        public int getReceiverID()
        {
            return receiverID;
        }

        public string getMessage()
        {
            return message;
        }

        public DateTime getSentDateTime()
        {
            return sentDateTime;
        }
    }
}
