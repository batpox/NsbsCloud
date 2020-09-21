using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoilStore
{
    public class EpMessage
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="eventName"></param>
        /// <param name="eventParameters"></param>
        public EpMessage(string messageType, string eventName, string eventParameters)
        {
            EntryType = messageType;
            EventName = eventName;
            EventParameters = eventParameters;
        }

        public EpMessage(string messageType, string info1, string info2, string info3)
        {
            EntryType = messageType;
            Info1 = info1;
            Info2 = info2;
            Info3 = info3;
        }

        public string EntryType;
        public DateTime InsertionTimeUtc;

        public string EventName;
        public string EventParameters;

        public string Info1;
        public string Info2;
        public string Info3;
    }
}
