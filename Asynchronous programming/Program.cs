namespace Asynchronous_programming
{
    internal class Program
    {
        static async Task  Main(string[] args)
        {
            Task<int> result = LongTask();
            Task<int> result1 = LongTask1();




            ShortTask();

            var valu = await result;
            var value = await result1;

            Displayvalue(valu);
            Console.WriteLine(value);
            Console.ReadKey();
            
        }

        static async Task<int> LongTask()
        {
            Console.WriteLine("my task started");
            await Task.Delay(4000);
            Console.WriteLine("My long task completed");
            return 19;
        }
        static async Task<int> LongTask1()
        {
            Console.WriteLine("my task1 started");
            await Task.Delay(4000);
            Console.WriteLine("My long task1 completed");
            return 10;
        }

        static void ShortTask()
        {
            Console.WriteLine("my short task started");
            Console.WriteLine("My short task compelted");

        }

        static void Displayvalue(int a)
        {
            Console.WriteLine(a);
        }
    }
}