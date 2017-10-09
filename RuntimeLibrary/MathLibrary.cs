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
    //[Export(typeof(IScalarFunctionProvider))]
    //[ExportMetadata("FunctionName", nameof(MathExt.Negate))]
    //class NegateProvider : IScalarFunctionProvider
    //{
    //    public string ContainingTypeName => nameof(MathExt);
    //    public MemberKind MemberKind => MemberKind.Static;
    //}

    //public class MathExt
    //{
    //    public static long Negate(long operand)
    //    {
    //        return operand.CompareTo(0) < 0
    //            ? operand
    //            : -operand;
    //    }
    //}

    [Export(typeof(IScalarFunctionProvider))]
    [ExportMetadata("FunctionName", nameof(Negate))]
    public class NegateProvider : IScalarFunctionProvider
    {
        public MemberKind MemberKind => MemberKind.Static;

        public static long Negate(long operand)
        {
            return operand.CompareTo(0) < 0
                ? operand
                : -operand;
        }
    }

}
