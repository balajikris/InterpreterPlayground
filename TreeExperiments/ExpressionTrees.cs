using System;
using System.Linq.Expressions;
// ReSharper disable SuggestVarOrType_SimpleTypes
// ReSharper disable SuggestVarOrType_Elsewhere

namespace TreeExperiments
{
    public class ExpressionTrees
    {
        public static void Simple(int x1, int y1)
        {
            // expr is a simple expression lambda, takes x and y, returns the sum.
            Expression<Func<int, int, int>> expression = (x, y) => x + y;

            // manually building it
            var beforeParse = DateTime.Now;
            var constructedExpression = BuildExpressionTree();
            var timeToParse = DateTime.Now - beforeParse;

            // compile
            var beforeCompile = DateTime.Now;
            Func<int, int, int> compiledExpression = constructedExpression.Compile();
            var timeToCompile = DateTime.Now - beforeCompile;

            // execute
            var beforeExecute = DateTime.Now;
            var result = compiledExpression(x1, y1);
            var timeToExecute = DateTime.Now - beforeExecute;

            Console.WriteLine($"the expression tree was evaluated and it returned: {result}");
            Console.WriteLine("Printing Time elapsed info:");
            Console.WriteLine($"Parsing: {timeToParse}, compile: {timeToCompile}, execute: {timeToExecute}");
            Console.WriteLine($"total time: {timeToParse.Add(timeToCompile).Add(timeToExecute).TotalMilliseconds} ms");

        }

        private static Expression<Func<int, int, int>> BuildExpressionTree()
        {
            ParameterExpression p1 = Expression.Parameter(typeof (int), "x");
            ParameterExpression p2 = Expression.Parameter(typeof (int), "y");
            BinaryExpression f = Expression.Add(p1, p2);
            Expression<Func<int, int, int>> constructedExpression = Expression.Lambda<Func<int, int, int>>(f, p1, p2);
            return constructedExpression;
        }
    }
}