using locks_and_semaphores.Utils;
using System.Threading;

namespace locks_and_semaphores.Services
{
    public static class SemaphoreExampleService
    {
        private static Semaphore? _semaphore;

        public static void Run()
        {
            Thread.Sleep(10000);

            Console.WriteLine();

            Console.WriteLine("----------With Semaphore----------");

            StartThreadsWithSemaphore();
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

        private static void FakeThreadExecutionWithSemaphore(object? number)
        {
            FakeThreadExecutionUtil.FakeWaitingThreadExecution(number, "Semaphore");
            _semaphore?.WaitOne();
            FakeThreadExecutionUtil.FakeThreadExecution(number, "Semaphore");
            _semaphore?.Release();
        }
    }
}
