namespace locks_and_semaphores
{
    public class Program
    {
        private static Semaphore? _semaphore;
        private static SemaphoreSlim? _semaphoreSlim;

        static void Main()
        {
            Console.WriteLine("----------Without Semaphore----------");

            StartThreadsWithoutSemaphore();

            Thread.Sleep(5000);

            Console.WriteLine();

            Console.WriteLine("----------With Semaphore----------");

            StartThreadsWithSemaphore();

            Thread.Sleep(5000);

            Console.WriteLine();

            Console.WriteLine("----------With SemaphoreSlim----------");

            StartThreadsWithSemaphoreSlim();
        }

        private static void StartThreadsWithSemaphore()
        {
            // The first parameter is the initial number of threads starting.
            // The second parameter is the maximum number of threads in execution.
            _semaphore = new Semaphore(2, 5);

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


        // SemaphoresSlim is just another way to do the same thing that Semaphore already do. But it is lighter.
        private static void StartThreadsWithSemaphoreSlim()
        {
            // The first parameter is the initial number of threads starting.
            // The second parameter is the maximum number of threads in execution.
            _semaphoreSlim = new SemaphoreSlim(2, 5);

            for (int i = 0; i < 10; i++)
            {
                var thread = new Thread(new ParameterizedThreadStart(FakeThreadExecutionWithSemaphoreSlim));
                thread.Start(i);
            }

            Thread.Sleep(500);
        }

        private static void FakeThreadExecutionWithSemaphoreSlim(object? number)
        {
            Console.WriteLine($"Thread {number} waiting...");
            _semaphoreSlim?.Wait();
            FakeThreadExecution(number);
            _semaphoreSlim?.Release();
        }

        private static void FakeThreadExecutionWithSemaphore(object? number)
        {
            Console.WriteLine($"Thread {number} waiting...");
            _semaphore?.WaitOne();
            FakeThreadExecution(number);
            _semaphore?.Release();
        }

        private static void FakeThreadExecution(object? number)
        {
            Console.WriteLine($"Thread {number} starting...");
            Thread.Sleep(3000);
            Console.WriteLine($"Thread {number} Finishing...");
        }
    }
}