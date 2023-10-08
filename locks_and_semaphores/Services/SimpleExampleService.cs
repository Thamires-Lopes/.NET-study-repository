namespace locks_and_semaphores.Services
{
    public static class SimpleExampleService
    {
        // Just an example of running threads without controlling them.
        public static void Run()
        {
            Console.WriteLine("----------Without Semaphore----------");

            StartThreadsWithoutSemaphore();
        }

        private static void StartThreadsWithoutSemaphore()
        {
            for (int i = 0; i < 10; i++)
            {
                var thread = new Thread(new ParameterizedThreadStart(FakeThreadExecution));
                thread.Start(i);
            }
        }

        private static void FakeThreadExecution(object? number)
        {
            Console.WriteLine($"Thread {number} starting...");
            Thread.Sleep(3000);
            Console.WriteLine($"Thread {number} Finishing...");
        }
    }
}
