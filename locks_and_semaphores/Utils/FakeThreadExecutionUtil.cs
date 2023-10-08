namespace locks_and_semaphores.Utils
{
    public static class FakeThreadExecutionUtil
    {
        public static void FakeThreadExecution(object? number, string method)
        {
            Console.WriteLine($"Thread {number} using {method} starting...");
            Thread.Sleep(3000);
            Console.WriteLine($"Thread {number} using {method} Finishing...");
        }

        public static void FakeWaitingThreadExecution(object? number, string method)
        {
            Console.WriteLine($"Thread {number} using {method} waiting...");
        }
    }
}
