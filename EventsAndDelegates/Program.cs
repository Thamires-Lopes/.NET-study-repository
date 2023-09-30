using EventsAndDelegates.Services;

namespace EventsAndDelegates
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Choose option:");
            Console.WriteLine("1 - Create Notifications");

            while (true)
            {
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.KeyChar)
                {
                    case '1':
                        NotificationService.SendNotification();
                        break;
                    default:
                        Console.WriteLine("Choose an option.");
                        break;
                }
            }
        }
    }
}