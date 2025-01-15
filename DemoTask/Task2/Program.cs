namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Wait for all tasks to complete
            Task[] tasks = new Task[5];
            string taskData = "Hello";
            for (int i = 0; i < 5; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    Console.WriteLine($"Task={Task.CurrentId}, obj={taskData}, " +
                        $"ThreadId={Thread.CurrentThread.ManagedThreadId}");
                    Thread.Sleep(1000);
                });
            }
            try
            {
                Task.WaitAll(tasks);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("One or more exceptions occured: ");
                foreach(var e in ex.Flatten().InnerExceptions)
                    Console.WriteLine("   {0}",e.Message);
            }
            Console.WriteLine("Status of completed tasks:");
            foreach (var task in tasks)
            {
                Console.WriteLine("   Task #{0}: {1}", task.Id, task.Status);
            }
            Console.Read();
        }
    }
}
