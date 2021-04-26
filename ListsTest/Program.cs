
using BenchmarkDotNet.Running;

namespace ListsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<TestMethods>();
        }

        
    }
}
