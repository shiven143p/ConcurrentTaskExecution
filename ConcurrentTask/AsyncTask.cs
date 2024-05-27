using System.Collections.Concurrent;


namespace ConcurrentTask
{
    public static class AsyncTask
    {
        public static ConcurrentBag<string> conBag = new();

        public static async Task<List<string>> T1(int n, string taskname)
        {
            Console.WriteLine($"Task Execution {taskname}");
            List<string> stringList = new();
            try
            {
                //throw new Exception("Test Exception: T1");
                await Task.Delay(1000 * n);
                stringList = await StringGenerator(n, taskname);
            }
            catch (Exception ex)
            {
                conBag.Add(taskname + ":" + ex.Message);
            }
            return stringList;

        }

        public static async Task<List<string>> T2(int n, string taskname)
        {
            Console.WriteLine($"Task Execution {taskname}");
            List<string> stringList = new();
            try
            {
                await Task.Delay(1000 * n);
                stringList = await StringGenerator(n, taskname);
            }
            catch (Exception ex)
            {
                conBag.Add(taskname + ":" + ex.Message);
            }
            return stringList;
        }
        public static async Task<List<string>> T3(int n, string taskname)
        {
            Console.WriteLine($"Task Execution {taskname}");
            List<string> stringList = new();
            try
            {
                await Task.Delay(1000 * n);
                stringList = await StringGenerator(n, taskname);
            }
            catch (Exception ex)
            {
                conBag.Add(taskname + ":" + ex.Message);
            }
            return stringList;
        }

        public static async Task<List<string>> StringGenerator(int n, string taskname)
        {
            Console.WriteLine($"StringGenerator: Task Execution {taskname}");
            List<string> stringList = new() { taskname };
            object lockCounter = new();
            try
            {
                lock (lockCounter)
                {
                    for (int i = 1; i <= n; i++)
                    {
                        stringList.Add(Guid.NewGuid().ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                conBag.Add(taskname + ":" + ex.Message);
            }
            return await Task.FromResult(stringList);
        }
    }
}
