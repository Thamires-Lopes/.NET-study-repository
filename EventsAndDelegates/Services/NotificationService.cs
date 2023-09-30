using EventsAndDelegates.Entities;

namespace EventsAndDelegates.Services
{
    public class NotificationService
    {
        public static void SendNotification()
        {
            var notification = CreateNotification();

            Console.WriteLine("Sending notification");
            OnNotificationConfirmedGeneral(notification);
            MockNotificationReceived(notification);
        }

        private static void MockNotificationReceived(Notification notification)
        {
            Thread.Sleep(5000);

            notification.OnNotificationReceived();
        }

        private static void OnNotificationConfirmedGeneral(Notification notification)
        {
            if (notification.IdTypeEmail == 1)
            {
                notification.NotificationConfirmed += NotificationConfirmed;
            }
            else
            {
                notification.NotificationConfirmed += NotificationConfirmed2;
            }
        }

        private static Notification CreateNotification()
        {
            Console.WriteLine("Creating notification");
            var convertWithSucess = false;

            var value = 0;

            while (!convertWithSucess)
            {
                Console.WriteLine("Digit type of notification: ");

                var keyChar = Console.ReadKey().KeyChar.ToString();

                Console.WriteLine();

                convertWithSucess = int.TryParse(keyChar, out value);

                if (!convertWithSucess)
                {
                    Console.WriteLine("Please insert a valid type!");
                }

            }

            return new Notification { Message = "Notification test", IdTypeEmail = value };
        }

        private static void NotificationConfirmed(object? sender, EventArgs e)
        {
            Console.WriteLine("Notification type 1 received");
            Environment.Exit(0);
        }

        private static void NotificationConfirmed2(object? sender, EventArgs e)
        {
            Console.WriteLine("Notification type 2 received");
            Environment.Exit(0);
        }
    }
}
