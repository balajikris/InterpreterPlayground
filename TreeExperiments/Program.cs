using System;

namespace TreeExperiments
{
    class Program
    {
        private const int X1 = 5;
        private const int Y1 = 4;

        static void Main(string[] args)
        {
            TestInLoop(ExpressionTrees.Simple);
            TestInLoop(RoslynTrees.Simple);
            Console.ReadKey();
        }

        private static void TestInLoop(Action<int, int> executor)
        {
            var count = 0;
            while (count < 10)
            {
                executor(X1, Y1);
                count++;
                Console.WriteLine("------------------------------------------");
            }
        }
    }
}
