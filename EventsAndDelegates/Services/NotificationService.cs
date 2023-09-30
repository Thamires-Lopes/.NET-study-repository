using EventsAndDelegates.Entities;
using EventsAndDelegates.Enums;

namespace EventsAndDelegates.Services
{
    public class NotificationService
    {
        public static void SendNotification(TypeOfNotificationSending typeOfNotificationSending)
        {
            var notification = CreateNotification();

            Console.WriteLine("Sending notification");
            OnNotificationConfirmedGeneral(notification, typeOfNotificationSending);
            MockNotificationReceived(notification, typeOfNotificationSending);
        }

        private static void MockNotificationReceived(Notification notification, TypeOfNotificationSending typeOfNotificationSending)
        {
            Thread.Sleep(5000);

            switch (typeOfNotificationSending)
            {
                case TypeOfNotificationSending.WithoutArgs:
                    notification.OnNotificationReceived();
                    break;
                case TypeOfNotificationSending.WithArgs:
                    var eventArgs = new NotificationReceivedEventArgs { TimeNotificationReceived = DateTime.Now };
                    notification.OnNotificationReceivedWithArgs(eventArgs);
                    break;
                case TypeOfNotificationSending.WithDeclaredDelegate:
                    var eventArgsDelegate = new NotificationReceivedEventArgs { TimeNotificationReceived = DateTime.Now };
                    notification.OnNotificationReceivedWithDelegate(eventArgsDelegate);
                    break;
                default:
                    break;
            }
        }

        private static void OnNotificationConfirmedGeneral(Notification notification, TypeOfNotificationSending typeOfNotification)
        {
            switch (typeOfNotification)
            {
                case TypeOfNotificationSending.WithoutArgs:
                    OnNotificationConfirmedWithoutArgs(notification);
                    break;
                case TypeOfNotificationSending.WithArgs:
                    OnNotificationConfirmedWithArgs(notification);
                    break;
                case TypeOfNotificationSending.WithDeclaredDelegate:
                    OnNotificationConfirmedWithDeclaredDelegate(notification);
                    break;
                default:
                    break;
            }
        }

        private static void OnNotificationConfirmedWithoutArgs(Notification notification)
        {
            if (notification.IdTypeNotification == (int)TypeOfNotification.FirstExample)
            {
                notification.NotificationConfirmed += NotificationConfirmed;
            }
            else
            {
                notification.NotificationConfirmed += NotificationConfirmed2;
            }
        }

        private static void OnNotificationConfirmedWithArgs(Notification notification)
        {
            if (notification.IdTypeNotification == (int)TypeOfNotification.FirstExample)
            {
                notification.NotificationConfirmedWithArgs += NotificationConfirmedWithArgs;
            }
            else
            {
                notification.NotificationConfirmedWithArgs += NotificationConfirmedWithArgs2;
            }
        }

        private static void OnNotificationConfirmedWithDeclaredDelegate(Notification notification)
        {
            if (notification.IdTypeNotification == (int)TypeOfNotification.FirstExample)
            {
                notification.NotificationConfirmedDelegate += NotificationConfirmedWithDelegate;
            }
            else
            {
                notification.NotificationConfirmedDelegate += NotificationConfirmedWithDelegate2;
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

            return new Notification { Message = "Notification test", IdTypeNotification = value };
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

        private static void NotificationConfirmedWithArgs(object? sender, NotificationReceivedEventArgs eventArgs)
        {
            Console.WriteLine($"Notification type 1 received in {eventArgs.TimeNotificationReceived}");
            Environment.Exit(0);
        }

        private static void NotificationConfirmedWithArgs2(object? sender, NotificationReceivedEventArgs eventArgs)
        {
            Console.WriteLine($"Notification type 2 received in {eventArgs.TimeNotificationReceived}");
            Environment.Exit(0);
        }

        private static void NotificationConfirmedWithDelegate(object? sender, NotificationReceivedEventArgs eventArgs)
        {
            Console.WriteLine($"Notification with delegate type 1 received in {eventArgs.TimeNotificationReceived}");
            Environment.Exit(0);
        }

        private static void NotificationConfirmedWithDelegate2(object? sender, NotificationReceivedEventArgs eventArgs)
        {
            Console.WriteLine($"Notification with delegate type 2 received in {eventArgs.TimeNotificationReceived}");
            Environment.Exit(0);
        }
    }
}
