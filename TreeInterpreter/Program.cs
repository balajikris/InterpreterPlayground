using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr.Runtime.Tree;
using System.Numerics;
using Antlr.Runtime;
using System.IO;

[assembly: CLSCompliant(true)]

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                args = new string[] { @"../../input.txt" };
            }
            var input = new ANTLRFileStream(Path.GetFullPath(args[0]));
            var lexer = new ExprTreeLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new ExprTreeParser(tokens);

            var tree = parser.Parse().Tree;
            var nodes = new CommonTreeNodeStream(tree);
            var evaluator = new TreeEval(nodes, parser.FunctionDefinitions);

            evaluator.Do();
        }
    }
}
