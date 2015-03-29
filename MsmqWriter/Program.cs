using MsmqCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MsmqWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            Notification notification;
            notification.NotificationType = "MsmqWriter";
            notification.Payload = "Written by MsmqWriter on " + DateTime.Now.ToString();

            Message message = new Message();
            message.Body = notification;

            using (MessageQueue messageQueue = new MessageQueue(".\\Private$\\Notifications"))
            {
                messageQueue.Send(message);
                messageQueue.Close();
            }
        }
    }
}
