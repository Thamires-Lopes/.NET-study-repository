using EventsAndDelegates.Enums;
using EventsAndDelegates.Services;

namespace EventsAndDelegates
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Create Notifications without args.");
            Console.WriteLine("2 - Create Notifications with args.");
            Console.WriteLine("3 - Create Notifications with args and declared delegate.");

            while (true)
            {
                var key = Console.ReadKey().KeyChar.ToString();
                var converted = int.TryParse(key, out var type);
                Console.WriteLine();

                if (converted)
                {
                    switch (type)
                    {
                        case (int)TypeOfNotificationSending.WithoutArgs:
                            NotificationService.SendNotification(TypeOfNotificationSending.WithoutArgs);
                            break;
                        case (int)TypeOfNotificationSending.WithArgs:
                            NotificationService.SendNotification(TypeOfNotificationSending.WithArgs);
                            break;
                        case (int)TypeOfNotificationSending.WithDeclaredDelegate:
                            NotificationService.SendNotification(TypeOfNotificationSending.WithDeclaredDelegate);
                            break;
                        default:
                            PrintWarningMessage();
                            break;
                    }
                }
                else { PrintWarningMessage(); };
            }
        }

        private static void PrintWarningMessage()
        {
            Console.WriteLine("Choose a valid option.");
        }
    }
}