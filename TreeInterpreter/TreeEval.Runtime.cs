using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    public partial class TreeEval
    {
        private IRuntimeLibrary runtimeLibrary;

        // some abstract sym table structure to store and look up runtime funcs.
        // signature (name + arglist) could be key, a symbol could be value.
        // structure of symbol - simply a lambda that takes args and knows how to compute result.
        // if findfunction returns null, search findRuntimeFunction and just execute the lambda and store the result in $value.
        // TODO: try using MethodCallExpression to represent this instead of delegate
        private Dictionary<Signature, MethodInfo> runtimeFunctions = new Dictionary<Signature, MethodInfo>();

        private void LoadRuntimeFunctions()
        {
            LoadMathLibrary();
        }

        private void LoadMathLibrary()
        {
            var type = typeof(Math);
            var allMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Static);
            const string MethodName = "Abs";
            var absMethodInfo = allMethods.Where((x) => x.Name == MethodName);
            foreach (var item in absMethodInfo)
            {
                // TODO: there will be list of parameters, not just one. keeping this simple for Abs.
                var methodSignature = new Signature(MethodName, item.GetParameters().First().ParameterType);
                if(!runtimeFunctions.ContainsKey(methodSignature))
                {
                    runtimeFunctions.Add(methodSignature, item);
                }
            }
        }
    }

    class DelegateInfo
    {
        public Type Type { get; set; }
        public MethodInfo MethodInfo { get; set; }
    }

    class Signature : IEquatable<Signature>
    {
        private string methodName;
        private Type arg1Type;

        public Signature(string methodName, Type parameterType)
        {
            this.methodName = methodName;
            this.arg1Type = parameterType;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj);    
        }

        public override int GetHashCode()
        {
            return this.methodName.GetHashCode() ^ this.arg1Type.GetHashCode();
        }
        
        public bool Equals(Signature other)
        {
            return this.methodName == other.methodName && this.arg1Type.Equals(other.arg1Type);
        }
    }
}
