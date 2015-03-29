using MsmqCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MsmqReader
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageQueue messageQueue = new MessageQueue(".\\Private$\\Notifications");

            messageQueue.Formatter = new XmlMessageFormatter(new System.Type[]
                {
                    new Notification().GetType(),
                    new Object().GetType()
                });

            Notification notification = (Notification)messageQueue.Receive().Body;
            Console.WriteLine("Processing {0} ", notification);
        }
    }
}
