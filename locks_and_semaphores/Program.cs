namespace locks_and_semaphores
{
    public class Program
    {
        private static Semaphore? semaphore;

        static void Main()
        {
            Console.WriteLine("----------Without Semaphore----------");

            StartThreadsWithoutSemaphore();

            Thread.Sleep(5000);

            Console.WriteLine();

            Console.WriteLine("----------With Semaphore----------");

            StartThreadsWithSemaphore();
        }

        private static void StartThreadsWithSemaphore()
        {
            // The first parameter is the initial number of threads starting.
            // The second parameter is the maximum number of threads in execution.
            semaphore = new Semaphore(2, 5);

            for (int i = 0; i < 10; i++)
            {
                var thread = new Thread(new ParameterizedThreadStart(FakeThreadExecutionWithSemaphore));
                thread.Start(i);
            }

            Thread.Sleep(500);
        }

        private static void StartThreadsWithoutSemaphore()
        {
            for (int i = 0; i < 10; i++)
            {
                var thread = new Thread(new ParameterizedThreadStart(FakeThreadExecution));
                thread.Start(i);
            }
        }

        private static void FakeThreadExecutionWithSemaphore(object? number)
        {
            Console.WriteLine($"Thread {number} waiting...");
            semaphore?.WaitOne();
            FakeThreadExecution(number);
            semaphore?.Release();
        }

        private static void FakeThreadExecution(object? number)
        {
            Console.WriteLine($"Thread {number} starting...");
            Thread.Sleep(3000);
            Console.WriteLine($"Thread {number} Finishing...");
        }
    }
}