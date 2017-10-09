tree grammar TreeEval;

options {
    tokenVocab=ExprTree;
    ASTLabelType=CommonTree;
}

@namespace {Interpreter} 

@header {
using System;
using System.Numerics;
using System.Reflection;
}

@members {
	/** Points to functions tracked by tree builder */
	private List<CommonTree> functionDefinitions;
	
	/** Remember local variables. Currently, this is only the function parameter. */
    private Dictionary<string, BigInteger> localMemory = new Dictionary<string, BigInteger>();
	
	/** Remember global variables set by =. */
    private Dictionary<string, BigInteger> globalMemory = new Dictionary<string, BigInteger>();
	 
	/** Set up an evaluator with a node stream; and a set of function definition ASTs. */
    public TreeEval(CommonTreeNodeStream nodes, List<CommonTree> functionDefinitions)
		: base(nodes)
	{
        this.functionDefinitions = functionDefinitions;
		LoadRuntimeFunctions(); //BALAJIK
    }

	/// <summary>
    /// Set up a local evaluator for a nested function call.
    /// </summary>
    /// <param name="function">tree of function's definition</param>
    /// <param name="functionDefinitions">set of all function definitions</param>
    /// <param name="globalMemory">global memory scope</param>
    /// <param name="paramValue">value of function's parameter to be added to local memory</param>
	private TreeEval(CommonTree function,
                List<CommonTree> functionDefinitions,
                Dictionary<string, BigInteger> globalMemory,
                BigInteger paramValue)
			: this(new CommonTreeNodeStream(function.GetChild(2)), functionDefinitions)
    {
        // Expected tree for function: ^(FUNC ID ( INT | ID ) expr)
        this.globalMemory = globalMemory;
        localMemory.Add(function.GetChild(1).Text, paramValue);
	}

	/** Find matching function definition for a function name and parameter
     *  value. The first definition is returned where (a) the name matches
     *  and (b) the formal parameter agrees if it is defined as constant.
     */
    private CommonTree FindFunction(String name, BigInteger paramValue) 
	{
        foreach(CommonTree f in functionDefinitions) 
		{
            // Expected tree for f: ^(FUNC ID (ID | INT) expr)
            if (f.GetChild(0).Text == name) 
			{
                // Check whether parameter matches
              	CommonTree formalPar = (CommonTree) f.GetChild(1);
                if (formalPar.Token.Type == INT 
					&& !(BigInteger.Parse(formalPar.Token.Text).Equals(paramValue))) 
				{
                        // Constant in formalPar list does not match actual value -> no match.
                        continue;
                }
                // Parameter (value for INT formal arg) as well as fct name agrees!
                return f;
            }
        }
        return null;
    }

	private MethodInfo FindRuntimeFunction(string name, Type paramType)
	{
		// TODO: use table from TreeEval.Runtime to lookup.
		// HACK: We use bigintegers here, but system.math supports only predefined types, work with long, forget about overflow cases.
		var methodSignature = new Signature(name, typeof(long)); // using long instead of paramType
		MethodInfo methodInfo = null;
		if(!runtimeFunctions.TryGetValue(methodSignature, out methodInfo))
		{
			return null;
		}

		return methodInfo;
	}

	/** Get value of name up call stack. */
    public BigInteger GetValue(string name) 
	{
        BigInteger value;
        
		if (localMemory.TryGetValue(name, out value)) 
		{
            return value;
        }
        
        if (globalMemory.TryGetValue(name, out value)) 
		{
            return value;
        }

        // not found in local memory or global memory
        Console.WriteLine("undefined variable " + name);
        return BigInteger.Zero;
    }
}

prog:   stat*
	;

stat:   expr
        {Console.WriteLine($expr.value);}
    |   ^('=' ID expr)
        {globalMemory.Add($ID.text, $expr.value);}
	|   ^(FUNC .+)
		// ignore FUNCs - we added them to functionDefinitions already in parser.
    ;

expr returns [BigInteger value]
    :   ^('+' a=expr b=expr)  {$value = BigInteger.Add($a.value, $b.value);}
    |   ^('-' a=expr b=expr)  {$value = BigInteger.Subtract($a.value, $b.value);}   
    |   ^('*' a=expr b=expr)  {$value = BigInteger.Multiply($a.value, $b.value);}
	|   ^('/' a=expr b=expr)  {$value = BigInteger.Divide($a.value, $b.value);}
	|   ^('%' a=expr b=expr)  {$value = BigInteger.Remainder($a.value, $b.value);}
    |   ID					  {$value = GetValue($ID.text);}
    |   INT                   {$value = BigInteger.Parse($INT.text);}
	|	call				  {$value = $call.value;}
    ;

call returns [BigInteger value]
	:	^(CALL ID expr)
		{
			BigInteger p = $expr.value;
			CommonTree funcRoot = FindFunction($ID.text, p);
			if (funcRoot == null)
			{
				// could be a runtime function --- BALAJIK
				var methodInfo = FindRuntimeFunction($ID.text, p.GetType());
				if(methodInfo == null)
				{
					Console.WriteLine("Function " + $ID.text + " with matching args not found");
				}
				else
				{
					// HACK: Use long instead of biginteger
					var temp = (long)methodInfo.Invoke(methodInfo.DeclaringType, new object[] { long.Parse(p.ToString()) });
					$value = new BigInteger(temp);
				}
			}
			else
			{
				// Here we set up the local evaluator to run over the
				// function definition with the parameter value.
				// This re-reads a sub-AST of our input AST!
				TreeEval e = new TreeEval(funcRoot, functionDefinitions, globalMemory, p);
				$value = e.expr();
			}
		}
	;