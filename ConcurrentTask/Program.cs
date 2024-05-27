namespace ConcurrentTask
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
            Console.WriteLine("Concurrent Async Task Execution!");
            
            //Three Task returing genrating n unique string
            Task<List<string>> Task1 = AsyncTask.T1(4, "T1");
            Task<List<string>> Task2 = AsyncTask.T2(3, "T2");
            Task<List<string>> Task3 = AsyncTask.T3(6, "T3");


            try
            {
                //Concurrent execution of all 3 tasks and their result
                await Task.WhenAll(Task1, Task2, Task3);

                //Combine result of these tasks in one list
                List<string> stringList1 = Task1.Result;
                stringList1.AddRange(Task2.Result);
                stringList1.AddRange(Task3.Result);

                //Output all result with separator |
                Console.WriteLine(string.Join('|', stringList1));


                //In case any exception it will get also printed
                //using concurrentbag for thread safe execution
                foreach (var item in AsyncTask.conBag)
                {
                    Console.WriteLine("Exception: " + item.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            
            //catch (AggregateException ae)
            //{
            //    ae.Flatten().Handle(e =>
            //    {
            //            Console.WriteLine(e.Message);
            //            return true;
            //    });
            //}
        }


    }
}