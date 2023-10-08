using locks_and_semaphores.Services;

namespace locks_and_semaphores
{
    public class Program
    {
        static void Main()
        {
            SimpleExampleService.Run();

            SemaphoreExampleService.Run();

            SemaphoreSlimExampleService.Run();

            var lockService = new LockExampleService();
            lockService.Run();
        }
    }
}