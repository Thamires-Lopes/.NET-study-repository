using locks_and_semaphores.Utils;

namespace locks_and_semaphores.Services
{
    public static class SemaphoreSlimExampleService
    {
        private static SemaphoreSlim? _semaphoreSlim;

        public static void Run()
        {
            Thread.Sleep(10000);

            Console.WriteLine();

            Console.WriteLine("----------With SemaphoreSlim----------");

            StartThreadsWithSemaphoreSlim();
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
            FakeThreadExecutionUtil.FakeWaitingThreadExecution(number, "Semaphore Slim");
            _semaphoreSlim?.Wait();
            FakeThreadExecutionUtil.FakeThreadExecution(number, "Semaphore Slim");
            _semaphoreSlim?.Release();
        }
    }
}
