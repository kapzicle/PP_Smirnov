using System;

namespace MaterialTrackingSystem
{
    public class Notification
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"\nУведомление: {message}");
        }
    }
}