using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr.Runtime;
[assembly: CLSCompliant(true)]

namespace BalajiK.ParserTest
{
    partial class SimpleCalcParser
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                args = new string[] { "100+23" };
            }

            SimpleCalcLexer lex = new SimpleCalcLexer(new ANTLRStringStream(args[0]));
            CommonTokenStream tokens = new CommonTokenStream(lex);

            SimpleCalcParser parser = new SimpleCalcParser(tokens);

            try
            {
                parser.expr();
            }
            catch (RecognitionException e)
            {
                Console.Error.WriteLine(e.StackTrace);
            }
        }
    }
}
