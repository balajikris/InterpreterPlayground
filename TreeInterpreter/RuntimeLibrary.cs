using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public enum MemberKind
    {
        Static,
        Instance
    }

    public interface IProviderMetadata
    {
        string FunctionName { get; }
    }

    public interface IScalarFunctionProvider
    {
        //string MemberName { get; }
        MemberKind MemberKind { get; }
    }

    public interface IScalarFunctionMetadataProvider
    {
        /// <summary>
        /// Fully qualified name of the containing type of the scalar function
        /// </summary>
        string TypeName { get; }
    }

    [Export(typeof(IScalarFunctionProvider))]
    [ExportMetadata("FunctionName", nameof(Math.Abs))]
    class AbsProvider : IScalarFunctionProvider, IScalarFunctionMetadataProvider
    {
        public string TypeName => typeof(Math).FullName;
        public MemberKind MemberKind => MemberKind.Static;
    }


    [Export(typeof(IScalarFunctionProvider))]
    [ExportMetadata("FunctionName", nameof(Convert.ToInt64))]
    class ToInt64Provider : IScalarFunctionProvider, IScalarFunctionMetadataProvider
    {
        public string TypeName => typeof(Convert).FullName;
        public MemberKind MemberKind => MemberKind.Static;
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
            return providers.Single(provider => provider.Metadata.FunctionName.Equals(name)).Value;
        }
    }
}
