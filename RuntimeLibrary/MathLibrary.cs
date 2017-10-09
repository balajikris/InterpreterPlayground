using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Interpreter;

namespace RuntimeLibrary
{
    [Export(typeof(IScalarFunctionProvider))]
    [ExportMetadata("Name", nameof(MathExt.Negate))]
    class NegateProvider : IScalarFunctionProvider
    {
        public Expression Operation(Expression[] operands)
        {
            return Expression.Call(typeof(MathExt), nameof(MathExt.Negate), null, operands);
        }
    }

    public class MathExt
    {
        public static long Negate(long operand)
        {
            return operand.CompareTo(0) < 0
                ? operand
                : -operand;
        }
    }
}
