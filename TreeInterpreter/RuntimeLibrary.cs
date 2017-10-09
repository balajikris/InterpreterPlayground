using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public interface IProviderMetadata
    {
        string Name { get; }
    }

    public interface IScalarFunctionProvider
    {
        Expression Operation(Expression[] operands);
    }

    [Export(typeof(IScalarFunctionProvider))]
    [ExportMetadata("Name", nameof(Abs))]
    class Abs : IScalarFunctionProvider
    {
        public Expression Operation(Expression[] operands)
        {
            return Expression.Call(typeof(Math), nameof(Abs), null, operands);
        }
    }


    [Export(typeof(IScalarFunctionProvider))]
    [ExportMetadata("Name", nameof(ToInt64))]
    class ToInt64 : IScalarFunctionProvider
    {
        public Expression Operation(Expression[] operands)
        {
            return Expression.Call(typeof(Convert), nameof(ToInt64), null, operands);
        }
    }

    public interface IRuntimeLibrary
    {
        IScalarFunctionProvider GetProvider(string name);
    }

    [Export(typeof(IRuntimeLibrary))]
    public class RuntimeLibrary : IRuntimeLibrary
    {
        [ImportMany]
        private IEnumerable<Lazy<IScalarFunctionProvider, IProviderMetadata>> providers;

        public IScalarFunctionProvider GetProvider(string name)
        {
            return providers.Single(provider => provider.Metadata.Name.Equals(name)).Value;
        }
    }
}
