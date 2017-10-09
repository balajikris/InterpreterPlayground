using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr.Runtime;
using System.IO;
using Antlr.Runtime.Tree;

[assembly: CLSCompliant(true)]

namespace ExpressionEvaluator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = new ANTLRReaderStream(Console.In);
            var lexer = new ExprTreeLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new ExprTreeParser(tokens);

            var tree = parser.Parse().Tree;
            var nodes = new CommonTreeNodeStream(tree);

            var evaluator = new TreeEval(nodes);
            evaluator.Do();
        }
    }
}
