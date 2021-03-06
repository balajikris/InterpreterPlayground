//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 3.4.1.9004
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// $ANTLR 3.4.1.9004 D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g 2017-10-05 11:52:58

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162
// Missing XML comment for publicly visible type or member 'Type_or_Member'
#pragma warning disable 1591
// CLS compliance checking will not be performed on 'type' because it is not visible from outside this assembly.
#pragma warning disable 3019


using System;
using System.Numerics;


using System.Collections.Generic;
using Antlr.Runtime;
using Antlr.Runtime.Misc;
using Antlr.Runtime.Tree;
using RewriteRuleITokenStream = Antlr.Runtime.Tree.RewriteRuleTokenStream;
using System.Reflection;
using System.Linq.Expressions;

namespace Interpreter
{
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.4.1.9004")]
[System.CLSCompliant(false)]
public partial class TreeEval : Antlr.Runtime.Tree.TreeParser
{
	internal static readonly string[] tokenNames = new string[] {
		"<invalid>", "<EOR>", "<DOWN>", "<UP>", "CALL", "FUNC", "ID", "INT", "NEWLINE", "WS", "'('", "')'", "'*'", "'+'", "'-'", "'='", "'%'", "'/'"
	};
	public const int EOF=-1;
	public const int CALL=4;
	public const int FUNC=5;
	public const int ID=6;
	public const int INT=7;
	public const int NEWLINE=8;
	public const int WS=9;
	public const int T__10=10;
	public const int T__11=11;
	public const int T__12=12;
	public const int T__13=13;
	public const int T__14=14;
	public const int T__15=15;
	public const int T__16=16;
	public const int T__17=17;

	public TreeEval(ITreeNodeStream input)
		: this(input, new RecognizerSharedState())
	{
	}
	public TreeEval(ITreeNodeStream input, RecognizerSharedState state)
		: base(input, state)
	{
		OnCreated();
	}

	public override string[] TokenNames { get { return TreeEval.tokenNames; } }
	public override string GrammarFileName { get { return "D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g"; } }


		/** Points to functions tracked by tree builder */
		private List<CommonTree> functionDefinitions;
		
		/** Remember local variables. Currently, this is only the function parameter. */
	    private Dictionary<string, BigInteger> localMemory = new Dictionary<string, BigInteger>();
		
		/** Remember global variables set by =. */
	    private Dictionary<string, BigInteger> globalMemory = new Dictionary<string, BigInteger>();
		 
		/** Set up an evaluator with a node stream; and a set of function definition ASTs. */
	    public TreeEval(CommonTreeNodeStream nodes, List<CommonTree> functionDefinitions, IRuntimeLibrary runtimeLibrary)
			: base(nodes)
		{
	        this.functionDefinitions = functionDefinitions;
            //LoadRuntimeFunctions(); //BALAJIK
            this.runtimeLibrary = runtimeLibrary;
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
	                BigInteger paramValue,
                    IRuntimeLibrary runtimeLibrary)
				: this(new CommonTreeNodeStream(function.GetChild(2)), functionDefinitions, runtimeLibrary)
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

        private Expression FindRuntimeFunction(string functionName, Expression[] operands)
        {
            var provider = this.runtimeLibrary.GetProvider(functionName);

            var containingType = provider is IScalarFunctionMetadataProvider
                ? Type.GetType(((IScalarFunctionMetadataProvider)provider).TypeName)
                : provider.GetType();

            // todo: generics.
            return provider.MemberKind == MemberKind.Static
                ? Expression.Call(containingType, functionName, typeArguments: null, arguments: operands)
                : Expression.Call(Expression.New(containingType), functionName, typeArguments: null, arguments: operands);
        }

		private MethodInfo FindRuntimeFunction(string name, Type paramType)
		{
			// TODO: use table from TreeEval.Runtime to lookup.
			var methodSignature = new Signature(name, typeof(long));
			MethodInfo methodInfo = null;
            if (!runtimeFunctions.TryGetValue(methodSignature, out methodInfo))
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


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	#region Rules
	partial void EnterRule_prog();
	partial void LeaveRule_prog();
	// $ANTLR start "prog"
	// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:111:1: prog : ( stat )* ;
	[GrammarRule("prog")]
	private void prog()
	{
		EnterRule_prog();
		EnterRule("prog", 1);
		TraceIn("prog", 1);
		try { DebugEnterRule(GrammarFileName, "prog");
		DebugLocation(111, 1);
		try
		{
			// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:111:5: ( ( stat )* )
			DebugEnterAlt(1);
			// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:111:9: ( stat )*
			{
			DebugLocation(111, 9);
			// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:111:9: ( stat )*
			try { DebugEnterSubRule(1);
			while (true)
			{
				int alt1=2;
				try { DebugEnterDecision(1, false);
				int LA1_1 = input.LA(1);

				if (((LA1_1>=CALL && LA1_1<=INT)||(LA1_1>=12 && LA1_1<=17)))
				{
					alt1 = 1;
				}


				} finally { DebugExitDecision(1); }
				switch ( alt1 )
				{
				case 1:
					DebugEnterAlt(1);
					// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:111:9: stat
					{
					DebugLocation(111, 9);
					PushFollow(Follow._stat_in_prog55);
					stat();
					PopFollow();


					}
					break;

				default:
					goto loop1;
				}
			}

			loop1:
				;

			} finally { DebugExitSubRule(1); }


			}

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("prog", 1);
			LeaveRule("prog", 1);
			LeaveRule_prog();
		}
		DebugLocation(112, 1);
		} finally { DebugExitRule(GrammarFileName, "prog"); }
		return;

	}
	// $ANTLR end "prog"

	partial void EnterRule_stat();
	partial void LeaveRule_stat();
	// $ANTLR start "stat"
	// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:114:1: stat : ( expr | ^( '=' ID expr ) | ^( FUNC ( . )+ ) );
	[GrammarRule("stat")]
	private void stat()
	{
		EnterRule_stat();
		EnterRule("stat", 2);
		TraceIn("stat", 2);
		CommonTree ID2 = default(CommonTree);
		BigInteger expr1 = default(BigInteger);
		BigInteger expr3 = default(BigInteger);

		try { DebugEnterRule(GrammarFileName, "stat");
		DebugLocation(114, 4);
		try
		{
			// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:114:5: ( expr | ^( '=' ID expr ) | ^( FUNC ( . )+ ) )
			int alt3=3;
			try { DebugEnterDecision(3, false);
			switch (input.LA(1))
			{
			case CALL:
			case ID:
			case INT:
			case 12:
			case 13:
			case 14:
			case 16:
			case 17:
				{
				alt3 = 1;
				}
				break;
			case 15:
				{
				alt3 = 2;
				}
				break;
			case FUNC:
				{
				alt3 = 3;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 3, 0, input, 1);
					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(3); }
			switch (alt3)
			{
			case 1:
				DebugEnterAlt(1);
				// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:114:9: expr
				{
				DebugLocation(114, 9);
				PushFollow(Follow._expr_in_stat67);
				expr1=expr();
				PopFollow();

				DebugLocation(115, 9);
				Console.WriteLine(expr1);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:116:9: ^( '=' ID expr )
				{
				DebugLocation(116, 9);
				DebugLocation(116, 11);
				Match(input,15,Follow._15_in_stat88); 

				Match(input, TokenTypes.Down, null); 
				DebugLocation(116, 15);
				ID2=(CommonTree)Match(input,ID,Follow._ID_in_stat90); 
				DebugLocation(116, 18);
				PushFollow(Follow._expr_in_stat92);
				expr3=expr();
				PopFollow();


				Match(input, TokenTypes.Up, null); 

				DebugLocation(117, 9);
				globalMemory.Add((ID2!=null?ID2.Text:null), expr3);

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:118:6: ^( FUNC ( . )+ )
				{
				DebugLocation(118, 6);
				DebugLocation(118, 8);
				Match(input,FUNC,Follow._FUNC_in_stat111); 

				Match(input, TokenTypes.Down, null); 
				DebugLocation(118, 13);
				// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:118:13: ( . )+
				int cnt2=0;
				try { DebugEnterSubRule(2);
				while (true)
				{
					int alt2=2;
					try { DebugEnterDecision(2, false);
					int LA2_1 = input.LA(1);

					if (((LA2_1>=CALL && LA2_1<=17)))
					{
						alt2 = 1;
					}
					else if ((LA2_1==UP))
					{
						alt2 = 2;
					}


					} finally { DebugExitDecision(2); }
					switch (alt2)
					{
					case 1:
						DebugEnterAlt(1);
						// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:118:13: .
						{
						DebugLocation(118, 13);
						MatchAny(input); 

						}
						break;

					default:
						if (cnt2 >= 1)
							goto loop2;

						EarlyExitException eee2 = new EarlyExitException( 2, input );
						DebugRecognitionException(eee2);
						throw eee2;
					}
					cnt2++;
				}
				loop2:
					;

				} finally { DebugExitSubRule(2); }


				Match(input, TokenTypes.Up, null); 


				}
				break;

			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("stat", 2);
			LeaveRule("stat", 2);
			LeaveRule_stat();
		}
		DebugLocation(120, 4);
		} finally { DebugExitRule(GrammarFileName, "stat"); }
		return;

	}
	// $ANTLR end "stat"

	partial void EnterRule_expr();
	partial void LeaveRule_expr();
	// $ANTLR start "expr"
	// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:122:1: expr returns [BigInteger value] : ( ^( '+' a= expr b= expr ) | ^( '-' a= expr b= expr ) | ^( '*' a= expr b= expr ) | ^( '/' a= expr b= expr ) | ^( '%' a= expr b= expr ) | ID | INT | call );
	[GrammarRule("expr")]
	private BigInteger expr()
	{
		EnterRule_expr();
		EnterRule("expr", 3);
		TraceIn("expr", 3);
		BigInteger value = default(BigInteger);


		CommonTree ID4 = default(CommonTree);
		CommonTree INT5 = default(CommonTree);
		BigInteger a = default(BigInteger);
		BigInteger b = default(BigInteger);
		BigInteger call6 = default(BigInteger);

		try { DebugEnterRule(GrammarFileName, "expr");
		DebugLocation(122, 4);
		try
		{
			// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:123:5: ( ^( '+' a= expr b= expr ) | ^( '-' a= expr b= expr ) | ^( '*' a= expr b= expr ) | ^( '/' a= expr b= expr ) | ^( '%' a= expr b= expr ) | ID | INT | call )
			int alt4=8;
			try { DebugEnterDecision(4, false);
			switch (input.LA(1))
			{
			case 13:
				{
				alt4 = 1;
				}
				break;
			case 14:
				{
				alt4 = 2;
				}
				break;
			case 12:
				{
				alt4 = 3;
				}
				break;
			case 17:
				{
				alt4 = 4;
				}
				break;
			case 16:
				{
				alt4 = 5;
				}
				break;
			case ID:
				{
				alt4 = 6;
				}
				break;
			case INT:
				{
				alt4 = 7;
				}
				break;
			case CALL:
				{
				alt4 = 8;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 4, 0, input, 1);
					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(4); }
			switch (alt4)
			{
			case 1:
				DebugEnterAlt(1);
				// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:123:9: ^( '+' a= expr b= expr )
				{
				DebugLocation(123, 9);
				DebugLocation(123, 11);
				Match(input,13,Follow._13_in_expr142); 

				Match(input, TokenTypes.Down, null); 
				DebugLocation(123, 16);
				PushFollow(Follow._expr_in_expr146);
				a=expr();
				PopFollow();

				DebugLocation(123, 23);
				PushFollow(Follow._expr_in_expr150);
				b=expr();
				PopFollow();


				Match(input, TokenTypes.Up, null); 

				DebugLocation(123, 31);
				value = BigInteger.Add(a, b);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:124:9: ^( '-' a= expr b= expr )
				{
				DebugLocation(124, 9);
				DebugLocation(124, 11);
				Match(input,14,Follow._14_in_expr165); 

				Match(input, TokenTypes.Down, null); 
				DebugLocation(124, 16);
				PushFollow(Follow._expr_in_expr169);
				a=expr();
				PopFollow();

				DebugLocation(124, 23);
				PushFollow(Follow._expr_in_expr173);
				b=expr();
				PopFollow();


				Match(input, TokenTypes.Up, null); 

				DebugLocation(124, 31);
				value = BigInteger.Subtract(a, b);

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:125:9: ^( '*' a= expr b= expr )
				{
				DebugLocation(125, 9);
				DebugLocation(125, 11);
				Match(input,12,Follow._12_in_expr191); 

				Match(input, TokenTypes.Down, null); 
				DebugLocation(125, 16);
				PushFollow(Follow._expr_in_expr195);
				a=expr();
				PopFollow();

				DebugLocation(125, 23);
				PushFollow(Follow._expr_in_expr199);
				b=expr();
				PopFollow();


				Match(input, TokenTypes.Up, null); 

				DebugLocation(125, 31);
				value = BigInteger.Multiply(a, b);

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:126:6: ^( '/' a= expr b= expr )
				{
				DebugLocation(126, 6);
				DebugLocation(126, 8);
				Match(input,17,Follow._17_in_expr211); 

				Match(input, TokenTypes.Down, null); 
				DebugLocation(126, 13);
				PushFollow(Follow._expr_in_expr215);
				a=expr();
				PopFollow();

				DebugLocation(126, 20);
				PushFollow(Follow._expr_in_expr219);
				b=expr();
				PopFollow();


				Match(input, TokenTypes.Up, null); 

				DebugLocation(126, 28);
				value = BigInteger.Divide(a, b);

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:127:6: ^( '%' a= expr b= expr )
				{
				DebugLocation(127, 6);
				DebugLocation(127, 8);
				Match(input,16,Follow._16_in_expr231); 

				Match(input, TokenTypes.Down, null); 
				DebugLocation(127, 13);
				PushFollow(Follow._expr_in_expr235);
				a=expr();
				PopFollow();

				DebugLocation(127, 20);
				PushFollow(Follow._expr_in_expr239);
				b=expr();
				PopFollow();


				Match(input, TokenTypes.Up, null); 

				DebugLocation(127, 28);
				value = BigInteger.Remainder(a, b);

				}
				break;
			case 6:
				DebugEnterAlt(6);
				// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:128:9: ID
				{
				DebugLocation(128, 9);
				ID4=(CommonTree)Match(input,ID,Follow._ID_in_expr253); 
				DebugLocation(128, 18);
				value = GetValue((ID4!=null?ID4.Text:null));

				}
				break;
			case 7:
				DebugEnterAlt(7);
				// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:129:9: INT
				{
				DebugLocation(129, 9);
				INT5=(CommonTree)Match(input,INT,Follow._INT_in_expr271); 
				DebugLocation(129, 31);
				value = BigInteger.Parse((INT5!=null?INT5.Text:null));

				}
				break;
			case 8:
				DebugEnterAlt(8);
				// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:130:4: call
				{
				DebugLocation(130, 4);
				PushFollow(Follow._call_in_expr296);
				call6=call();
				PopFollow();

				DebugLocation(130, 14);
				value = call6;

				}
				break;

			}
		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("expr", 3);
			LeaveRule("expr", 3);
			LeaveRule_expr();
		}
		DebugLocation(131, 4);
		} finally { DebugExitRule(GrammarFileName, "expr"); }
		return value;

	}
	// $ANTLR end "expr"

	partial void EnterRule_call();
	partial void LeaveRule_call();
	// $ANTLR start "call"
	// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:133:1: call returns [BigInteger value] : ^( CALL ID expr ) ;
	[GrammarRule("call")]
	private BigInteger call()
	{
		EnterRule_call();
		EnterRule("call", 4);
		TraceIn("call", 4);
		BigInteger value = default(BigInteger);


		CommonTree ID8 = default(CommonTree);
		BigInteger expr7 = default(BigInteger);

		try { DebugEnterRule(GrammarFileName, "call");
		DebugLocation(133, 1);
		try
		{
			// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:134:2: ( ^( CALL ID expr ) )
			DebugEnterAlt(1);
			// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\TreeEval.g:134:4: ^( CALL ID expr )
			{
			DebugLocation(134, 4);
			DebugLocation(134, 6);
			Match(input,CALL,Follow._CALL_in_call322); 

			Match(input, TokenTypes.Down, null); 
			DebugLocation(134, 11);
			ID8=(CommonTree)Match(input,ID,Follow._ID_in_call324); 
			DebugLocation(134, 14);
			PushFollow(Follow._expr_in_call326);
			expr7=expr();
			PopFollow();


			Match(input, TokenTypes.Up, null); 

			DebugLocation(135, 3);

						BigInteger p = expr7;
						CommonTree funcRoot = FindFunction((ID8!=null?ID8.Text:null), p);
						if (funcRoot == null)
						{

                            var callExpression = FindRuntimeFunction(ID8.Text, 
                                new Expression[] { Expression.Constant(long.Parse(p.ToString()), typeof(long)) });
                            var lambda = Expression.Lambda<System.Func<long>>(callExpression).Compile();
                            value = lambda();
							// could be a runtime function --- BALAJIK
							//var methodInfo = FindRuntimeFunction((ID8!=null?ID8.Text:null), p.GetType());
							//if(methodInfo == null)
							//{
							//	Console.WriteLine("Function " + (ID8!=null?ID8.Text:null) + " with matching args not found");
							//}
							//else
							//{
       //                         var temp = (long)methodInfo.Invoke(methodInfo.DeclaringType, new object[] { long.Parse(p.ToString()) });
       //                         value = new BigInteger(temp);
							//}
						}
						else
						{
							// Here we set up the local evaluator to run over the
							// function definition with the parameter value.
							// This re-reads a sub-AST of our input AST!
							TreeEval e = new TreeEval(funcRoot, functionDefinitions, globalMemory, p, this.runtimeLibrary);
							value = e.expr();
						}
					

			}

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		}
		finally
		{
			TraceOut("call", 4);
			LeaveRule("call", 4);
			LeaveRule_call();
		}
		DebugLocation(160, 1);
		} finally { DebugExitRule(GrammarFileName, "call"); }
		return value;

	}
	// $ANTLR end "call"
	#endregion Rules


	#region Follow sets
	private static class Follow
	{
		public static readonly BitSet _stat_in_prog55 = new BitSet(new ulong[]{0x3F0F2UL});
		public static readonly BitSet _expr_in_stat67 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _15_in_stat88 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _ID_in_stat90 = new BitSet(new ulong[]{0x370D0UL});
		public static readonly BitSet _expr_in_stat92 = new BitSet(new ulong[]{0x8UL});
		public static readonly BitSet _FUNC_in_stat111 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _13_in_expr142 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _expr_in_expr146 = new BitSet(new ulong[]{0x370D0UL});
		public static readonly BitSet _expr_in_expr150 = new BitSet(new ulong[]{0x8UL});
		public static readonly BitSet _14_in_expr165 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _expr_in_expr169 = new BitSet(new ulong[]{0x370D0UL});
		public static readonly BitSet _expr_in_expr173 = new BitSet(new ulong[]{0x8UL});
		public static readonly BitSet _12_in_expr191 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _expr_in_expr195 = new BitSet(new ulong[]{0x370D0UL});
		public static readonly BitSet _expr_in_expr199 = new BitSet(new ulong[]{0x8UL});
		public static readonly BitSet _17_in_expr211 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _expr_in_expr215 = new BitSet(new ulong[]{0x370D0UL});
		public static readonly BitSet _expr_in_expr219 = new BitSet(new ulong[]{0x8UL});
		public static readonly BitSet _16_in_expr231 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _expr_in_expr235 = new BitSet(new ulong[]{0x370D0UL});
		public static readonly BitSet _expr_in_expr239 = new BitSet(new ulong[]{0x8UL});
		public static readonly BitSet _ID_in_expr253 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _INT_in_expr271 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _call_in_expr296 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _CALL_in_call322 = new BitSet(new ulong[]{0x4UL});
		public static readonly BitSet _ID_in_call324 = new BitSet(new ulong[]{0x370D0UL});
		public static readonly BitSet _expr_in_call326 = new BitSet(new ulong[]{0x8UL});
	}
	#endregion Follow sets
}

} // namespace Interpreter
