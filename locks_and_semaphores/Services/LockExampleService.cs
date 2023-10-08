using locks_and_semaphores.Utils;

namespace locks_and_semaphores.Services
{
    public class LockExampleService
    {
        private readonly object _objectLock = new();

        public void Run()
        {
            Thread.Sleep(10000);

            Console.WriteLine();

            Console.WriteLine("----------With Lock----------");

            StartThreadsWithLock();
        }

        private void StartThreadsWithLock()
        {
            for (int i = 0; i < 10; i++)
            {
                var thread = new Thread(new ParameterizedThreadStart(FakeThreadExecutionWithLock));
                thread.Start(i);
            }

            Thread.Sleep(500);
        }

        // The lock instruction is always checking if another thread is running the piece of code inside it.
        // So, it is preventing that the same piece of code is running in parallel.
        private void FakeThreadExecutionWithLock(object? number)
        {
            FakeThreadExecutionUtil.FakeWaitingThreadExecution(number, "lock");
            lock (_objectLock)
            {
                FakeThreadExecutionUtil.FakeThreadExecution(number, "lock");
            }
        }
       
    }
}
