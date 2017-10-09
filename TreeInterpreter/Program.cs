using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr.Runtime.Tree;
using System.Numerics;
using Antlr.Runtime;
using System.IO;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;

[assembly: CLSCompliant(true)]

namespace Interpreter
{
    class Program
    {
        private CompositionContainer container;

        [Import(typeof(IRuntimeLibrary))]
        public IRuntimeLibrary runtimeLibrary;
         
        private Program()
        {
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();
            //Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog(".\\Extensions"));

            //Create the CompositionContainer with the parts in the catalog
            container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {
                this.container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }

        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                args = new string[] { @"../../input.txt" };
            }

            Program p = new Program(); // composition is performed in the ctor.

            var input = new ANTLRFileStream(Path.GetFullPath(args[0]));
            var lexer = new ExprTreeLexer(input);
            var tokens = new CommonTokenStream(lexer);
            var parser = new ExprTreeParser(tokens);

            var tree = parser.Parse().Tree;
            var nodes = new CommonTreeNodeStream(tree);
            var evaluator = new TreeEval(nodes, parser.FunctionDefinitions, p.runtimeLibrary);

            evaluator.Do();
        }
    }
}
