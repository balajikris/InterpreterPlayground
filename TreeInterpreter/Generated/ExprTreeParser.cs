//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 3.4.1.9004
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// $ANTLR 3.4.1.9004 D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g 2017-10-05 11:52:56

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162
// Missing XML comment for publicly visible type or member 'Type_or_Member'
#pragma warning disable 1591
// CLS compliance checking will not be performed on 'type' because it is not visible from outside this assembly.
#pragma warning disable 3019


using System;


using System.Collections.Generic;
using Antlr.Runtime;
using Antlr.Runtime.Misc;


using Antlr.Runtime.Tree;
using RewriteRuleITokenStream = Antlr.Runtime.Tree.RewriteRuleTokenStream;

namespace Interpreter
{
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.4.1.9004")]
[System.CLSCompliant(false)]
public partial class ExprTreeParser : Antlr.Runtime.Parser
{
	internal static readonly string[] tokenNames = new string[] {
		"<invalid>", "<EOR>", "<DOWN>", "<UP>", "CALL", "FUNC", "ID", "INT", "NEWLINE", "WS", "'('", "')'", "'*'", "'+'", "'-'", "'='"
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

	public ExprTreeParser(ITokenStream input)
		: this(input, new RecognizerSharedState())
	{
	}
	public ExprTreeParser(ITokenStream input, RecognizerSharedState state)
		: base(input, state)
	{
		ITreeAdaptor treeAdaptor = default(ITreeAdaptor);
		CreateTreeAdaptor(ref treeAdaptor);
		TreeAdaptor = treeAdaptor ?? new CommonTreeAdaptor();
		OnCreated();
	}
	// Implement this function in your helper file to use a custom tree adaptor
	partial void CreateTreeAdaptor(ref ITreeAdaptor adaptor);

	private ITreeAdaptor adaptor;

	public ITreeAdaptor TreeAdaptor
	{
		get
		{
			return adaptor;
		}

		set
		{
			this.adaptor = value;
		}
	}

	public override string[] TokenNames { get { return ExprTreeParser.tokenNames; } }
	public override string GrammarFileName { get { return "D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g"; } }


	/** List of function definitions. Must point at the FUNC nodes. */
	public readonly List<CommonTree> FunctionDefinitions = new List<CommonTree>();


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	#region Rules
	partial void EnterRule_prog();
	partial void LeaveRule_prog();
	// $ANTLR start "prog"
	// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:26:1: prog : ( stat )* ;
	[GrammarRule("prog")]
	private AstParserRuleReturnScope<CommonTree, IToken> prog()
	{
		EnterRule_prog();
		EnterRule("prog", 1);
		TraceIn("prog", 1);
		AstParserRuleReturnScope<CommonTree, IToken> retval = new AstParserRuleReturnScope<CommonTree, IToken>();
		retval.Start = (IToken)input.LT(1);

		CommonTree root_0 = default(CommonTree);

		AstParserRuleReturnScope<CommonTree, IToken> stat1 = default(AstParserRuleReturnScope<CommonTree, IToken>);

		try { DebugEnterRule(GrammarFileName, "prog");
		DebugLocation(26, 1);
		try
		{
			// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:26:5: ( ( stat )* )
			DebugEnterAlt(1);
			// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:26:9: ( stat )*
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(26, 9);
			// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:26:9: ( stat )*
			try { DebugEnterSubRule(1);
			while (true)
			{
				int alt1=2;
				try { DebugEnterDecision(1, false);
				int LA1_1 = input.LA(1);

				if (((LA1_1>=ID && LA1_1<=NEWLINE)||LA1_1==10))
				{
					alt1 = 1;
				}


				} finally { DebugExitDecision(1); }
				switch ( alt1 )
				{
				case 1:
					DebugEnterAlt(1);
					// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:26:11: stat
					{
					DebugLocation(26, 11);
					PushFollow(Follow._stat_in_prog94);
					stat1=stat();
					PopFollow();

					adaptor.AddChild(root_0, stat1.Tree);

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

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (CommonTree)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("prog", 1);
			LeaveRule("prog", 1);
			LeaveRule_prog();
		}
		DebugLocation(27, 1);
		} finally { DebugExitRule(GrammarFileName, "prog"); }
		return retval;

	}
	// $ANTLR end "prog"

	partial void EnterRule_stat();
	partial void LeaveRule_stat();
	// $ANTLR start "stat"
	// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:29:1: stat : ( expr NEWLINE -> expr | ID '=' expr NEWLINE -> ^( '=' ID expr ) | func NEWLINE -> func | NEWLINE ->);
	[GrammarRule("stat")]
	private AstParserRuleReturnScope<CommonTree, IToken> stat()
	{
		EnterRule_stat();
		EnterRule("stat", 2);
		TraceIn("stat", 2);
		AstParserRuleReturnScope<CommonTree, IToken> retval = new AstParserRuleReturnScope<CommonTree, IToken>();
		retval.Start = (IToken)input.LT(1);

		CommonTree root_0 = default(CommonTree);

		IToken NEWLINE3 = default(IToken);
		IToken ID4 = default(IToken);
		IToken char_literal5 = default(IToken);
		IToken NEWLINE7 = default(IToken);
		IToken NEWLINE9 = default(IToken);
		IToken NEWLINE10 = default(IToken);
		AstParserRuleReturnScope<CommonTree, IToken> expr2 = default(AstParserRuleReturnScope<CommonTree, IToken>);
		AstParserRuleReturnScope<CommonTree, IToken> expr6 = default(AstParserRuleReturnScope<CommonTree, IToken>);
		AstParserRuleReturnScope<CommonTree, IToken> func8 = default(AstParserRuleReturnScope<CommonTree, IToken>);

		CommonTree NEWLINE3_tree = default(CommonTree);
		CommonTree ID4_tree = default(CommonTree);
		CommonTree char_literal5_tree = default(CommonTree);
		CommonTree NEWLINE7_tree = default(CommonTree);
		CommonTree NEWLINE9_tree = default(CommonTree);
		CommonTree NEWLINE10_tree = default(CommonTree);
		RewriteRuleITokenStream stream_NEWLINE=new RewriteRuleITokenStream(adaptor,"token NEWLINE");
		RewriteRuleITokenStream stream_ID=new RewriteRuleITokenStream(adaptor,"token ID");
		RewriteRuleITokenStream stream_15=new RewriteRuleITokenStream(adaptor,"token 15");
		RewriteRuleSubtreeStream stream_expr=new RewriteRuleSubtreeStream(adaptor,"rule expr");
		RewriteRuleSubtreeStream stream_func=new RewriteRuleSubtreeStream(adaptor,"rule func");
		try { DebugEnterRule(GrammarFileName, "stat");
		DebugLocation(29, 4);
		try
		{
			// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:29:5: ( expr NEWLINE -> expr | ID '=' expr NEWLINE -> ^( '=' ID expr ) | func NEWLINE -> func | NEWLINE ->)
			int alt2=4;
			try { DebugEnterDecision(2, false);
			switch (input.LA(1))
			{
			case INT:
			case 10:
				{
				alt2 = 1;
				}
				break;
			case ID:
				{
				switch (input.LA(2))
				{
				case 10:
					{
					switch (input.LA(3))
					{
					case INT:
						{
						int LA2_4 = input.LA(4);

						if (((LA2_4>=12 && LA2_4<=14)))
						{
							alt2 = 1;
						}
						else if ((LA2_4==11))
						{
							int LA2_5 = input.LA(5);

							if ((LA2_5==15))
							{
								alt2 = 3;
							}
							else if ((LA2_5==NEWLINE||(LA2_5>=12 && LA2_5<=14)))
							{
								alt2 = 1;
							}
							else
							{
								NoViableAltException nvae = new NoViableAltException("", 2, 8, input, 5);
								DebugRecognitionException(nvae);
								throw nvae;
							}
						}
						else
						{
							NoViableAltException nvae = new NoViableAltException("", 2, 6, input, 4);
							DebugRecognitionException(nvae);
							throw nvae;
						}
						}
						break;
					case ID:
						{
						int LA2_4 = input.LA(4);

						if ((LA2_4==10||(LA2_4>=12 && LA2_4<=14)))
						{
							alt2 = 1;
						}
						else if ((LA2_4==11))
						{
							int LA2_5 = input.LA(5);

							if ((LA2_5==15))
							{
								alt2 = 3;
							}
							else if ((LA2_5==NEWLINE||(LA2_5>=12 && LA2_5<=14)))
							{
								alt2 = 1;
							}
							else
							{
								NoViableAltException nvae = new NoViableAltException("", 2, 8, input, 5);
								DebugRecognitionException(nvae);
								throw nvae;
							}
						}
						else
						{
							NoViableAltException nvae = new NoViableAltException("", 2, 7, input, 4);
							DebugRecognitionException(nvae);
							throw nvae;
						}
						}
						break;
					case 10:
						{
						alt2 = 1;
						}
						break;
					default:
						{
							NoViableAltException nvae = new NoViableAltException("", 2, 4, input, 3);
							DebugRecognitionException(nvae);
							throw nvae;
						}
					}

					}
					break;
				case 15:
					{
					alt2 = 2;
					}
					break;
				case NEWLINE:
				case 12:
				case 13:
				case 14:
					{
					alt2 = 1;
					}
					break;
				default:
					{
						NoViableAltException nvae = new NoViableAltException("", 2, 2, input, 2);
						DebugRecognitionException(nvae);
						throw nvae;
					}
				}

				}
				break;
			case NEWLINE:
				{
				alt2 = 4;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 2, 0, input, 1);
					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(2); }
			switch (alt2)
			{
			case 1:
				DebugEnterAlt(1);
				// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:29:9: expr NEWLINE
				{
				DebugLocation(29, 9);
				PushFollow(Follow._expr_in_stat109);
				expr2=expr();
				PopFollow();

				stream_expr.Add(expr2.Tree);
				DebugLocation(29, 14);
				NEWLINE3=(IToken)Match(input,NEWLINE,Follow._NEWLINE_in_stat111);  
				stream_NEWLINE.Add(NEWLINE3);



				{
				// AST REWRITE
				// elements: expr
				// token labels: 
				// rule labels: retval
				// token list labels: 
				// rule list labels: 
				// wildcard labels: 
				retval.Tree = root_0;
				RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

				root_0 = (CommonTree)adaptor.Nil();
				// 29:29: -> expr
				{
					DebugLocation(29, 32);
					adaptor.AddChild(root_0, stream_expr.NextTree());

				}

				retval.Tree = root_0;
				}

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:30:9: ID '=' expr NEWLINE
				{
				DebugLocation(30, 9);
				ID4=(IToken)Match(input,ID,Follow._ID_in_stat132);  
				stream_ID.Add(ID4);

				DebugLocation(30, 12);
				char_literal5=(IToken)Match(input,15,Follow._15_in_stat134);  
				stream_15.Add(char_literal5);

				DebugLocation(30, 16);
				PushFollow(Follow._expr_in_stat136);
				expr6=expr();
				PopFollow();

				stream_expr.Add(expr6.Tree);
				DebugLocation(30, 21);
				NEWLINE7=(IToken)Match(input,NEWLINE,Follow._NEWLINE_in_stat138);  
				stream_NEWLINE.Add(NEWLINE7);



				{
				// AST REWRITE
				// elements: 15, ID, expr
				// token labels: 
				// rule labels: retval
				// token list labels: 
				// rule list labels: 
				// wildcard labels: 
				retval.Tree = root_0;
				RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

				root_0 = (CommonTree)adaptor.Nil();
				// 30:29: -> ^( '=' ID expr )
				{
					DebugLocation(30, 32);
					// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:30:32: ^( '=' ID expr )
					{
					CommonTree root_1 = (CommonTree)adaptor.Nil();
					DebugLocation(30, 34);
					root_1 = (CommonTree)adaptor.BecomeRoot(stream_15.NextNode(), root_1);

					DebugLocation(30, 38);
					adaptor.AddChild(root_1, stream_ID.NextNode());
					DebugLocation(30, 41);
					adaptor.AddChild(root_1, stream_expr.NextTree());

					adaptor.AddChild(root_0, root_1);
					}

				}

				retval.Tree = root_0;
				}

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:31:6: func NEWLINE
				{
				DebugLocation(31, 6);
				PushFollow(Follow._func_in_stat155);
				func8=func();
				PopFollow();

				stream_func.Add(func8.Tree);
				DebugLocation(31, 11);
				NEWLINE9=(IToken)Match(input,NEWLINE,Follow._NEWLINE_in_stat157);  
				stream_NEWLINE.Add(NEWLINE9);



				{
				// AST REWRITE
				// elements: func
				// token labels: 
				// rule labels: retval
				// token list labels: 
				// rule list labels: 
				// wildcard labels: 
				retval.Tree = root_0;
				RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

				root_0 = (CommonTree)adaptor.Nil();
				// 31:20: -> func
				{
					DebugLocation(31, 23);
					adaptor.AddChild(root_0, stream_func.NextTree());

				}

				retval.Tree = root_0;
				}

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:32:9: NEWLINE
				{
				DebugLocation(32, 9);
				NEWLINE10=(IToken)Match(input,NEWLINE,Follow._NEWLINE_in_stat172);  
				stream_NEWLINE.Add(NEWLINE10);



				{
				// AST REWRITE
				// elements: 
				// token labels: 
				// rule labels: retval
				// token list labels: 
				// rule list labels: 
				// wildcard labels: 
				retval.Tree = root_0;
				RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

				root_0 = (CommonTree)adaptor.Nil();
				// 32:29: ->
				{
					DebugLocation(33, 5);
					root_0 = null;
				}

				retval.Tree = root_0;
				}

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (CommonTree)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("stat", 2);
			LeaveRule("stat", 2);
			LeaveRule_stat();
		}
		DebugLocation(33, 4);
		} finally { DebugExitRule(GrammarFileName, "stat"); }
		return retval;

	}
	// $ANTLR end "stat"

	partial void EnterRule_func();
	partial void LeaveRule_func();
	// $ANTLR start "func"
	// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:35:1: func : ID '(' formalPar ')' '=' expr -> ^( FUNC ID formalPar expr ) ;
	[GrammarRule("func")]
	private AstParserRuleReturnScope<CommonTree, IToken> func()
	{
		EnterRule_func();
		EnterRule("func", 3);
		TraceIn("func", 3);
		AstParserRuleReturnScope<CommonTree, IToken> retval = new AstParserRuleReturnScope<CommonTree, IToken>();
		retval.Start = (IToken)input.LT(1);

		CommonTree root_0 = default(CommonTree);

		IToken ID11 = default(IToken);
		IToken char_literal12 = default(IToken);
		IToken char_literal14 = default(IToken);
		IToken char_literal15 = default(IToken);
		AstParserRuleReturnScope<CommonTree, IToken> formalPar13 = default(AstParserRuleReturnScope<CommonTree, IToken>);
		AstParserRuleReturnScope<CommonTree, IToken> expr16 = default(AstParserRuleReturnScope<CommonTree, IToken>);

		CommonTree ID11_tree = default(CommonTree);
		CommonTree char_literal12_tree = default(CommonTree);
		CommonTree char_literal14_tree = default(CommonTree);
		CommonTree char_literal15_tree = default(CommonTree);
		RewriteRuleITokenStream stream_ID=new RewriteRuleITokenStream(adaptor,"token ID");
		RewriteRuleITokenStream stream_10=new RewriteRuleITokenStream(adaptor,"token 10");
		RewriteRuleITokenStream stream_11=new RewriteRuleITokenStream(adaptor,"token 11");
		RewriteRuleITokenStream stream_15=new RewriteRuleITokenStream(adaptor,"token 15");
		RewriteRuleSubtreeStream stream_formalPar=new RewriteRuleSubtreeStream(adaptor,"rule formalPar");
		RewriteRuleSubtreeStream stream_expr=new RewriteRuleSubtreeStream(adaptor,"rule expr");
		try { DebugEnterRule(GrammarFileName, "func");
		DebugLocation(35, 1);
		try
		{
			// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:35:5: ( ID '(' formalPar ')' '=' expr -> ^( FUNC ID formalPar expr ) )
			DebugEnterAlt(1);
			// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:35:7: ID '(' formalPar ')' '=' expr
			{
			DebugLocation(35, 7);
			ID11=(IToken)Match(input,ID,Follow._ID_in_func199);  
			stream_ID.Add(ID11);

			DebugLocation(35, 10);
			char_literal12=(IToken)Match(input,10,Follow._10_in_func201);  
			stream_10.Add(char_literal12);

			DebugLocation(35, 14);
			PushFollow(Follow._formalPar_in_func203);
			formalPar13=formalPar();
			PopFollow();

			stream_formalPar.Add(formalPar13.Tree);
			DebugLocation(35, 24);
			char_literal14=(IToken)Match(input,11,Follow._11_in_func205);  
			stream_11.Add(char_literal14);

			DebugLocation(35, 28);
			char_literal15=(IToken)Match(input,15,Follow._15_in_func207);  
			stream_15.Add(char_literal15);

			DebugLocation(35, 32);
			PushFollow(Follow._expr_in_func209);
			expr16=expr();
			PopFollow();

			stream_expr.Add(expr16.Tree);


			{
			// AST REWRITE
			// elements: ID, formalPar, expr
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (CommonTree)adaptor.Nil();
			// 35:37: -> ^( FUNC ID formalPar expr )
			{
				DebugLocation(35, 40);
				// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:35:40: ^( FUNC ID formalPar expr )
				{
				CommonTree root_1 = (CommonTree)adaptor.Nil();
				DebugLocation(35, 42);
				root_1 = (CommonTree)adaptor.BecomeRoot((CommonTree)adaptor.Create(FUNC, "FUNC"), root_1);

				DebugLocation(35, 47);
				adaptor.AddChild(root_1, stream_ID.NextNode());
				DebugLocation(35, 50);
				adaptor.AddChild(root_1, stream_formalPar.NextTree());
				DebugLocation(35, 60);
				adaptor.AddChild(root_1, stream_expr.NextTree());

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}

			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (CommonTree)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("func", 3);
			LeaveRule("func", 3);
			LeaveRule_func();

					FunctionDefinitions.Add(retval.Tree);
				
		}
		DebugLocation(36, 1);
		} finally { DebugExitRule(GrammarFileName, "func"); }
		return retval;

	}
	// $ANTLR end "func"

	partial void EnterRule_formalPar();
	partial void LeaveRule_formalPar();
	// $ANTLR start "formalPar"
	// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:41:1: formalPar : ( ID | INT );
	[GrammarRule("formalPar")]
	private AstParserRuleReturnScope<CommonTree, IToken> formalPar()
	{
		EnterRule_formalPar();
		EnterRule("formalPar", 4);
		TraceIn("formalPar", 4);
		AstParserRuleReturnScope<CommonTree, IToken> retval = new AstParserRuleReturnScope<CommonTree, IToken>();
		retval.Start = (IToken)input.LT(1);

		CommonTree root_0 = default(CommonTree);

		IToken set17 = default(IToken);

		CommonTree set17_tree = default(CommonTree);
		try { DebugEnterRule(GrammarFileName, "formalPar");
		DebugLocation(41, 3);
		try
		{
			// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:41:10: ( ID | INT )
			DebugEnterAlt(1);
			// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(41, 10);

			set17=(IToken)input.LT(1);
			if ((input.LA(1)>=ID && input.LA(1)<=INT))
			{
				input.Consume();
				adaptor.AddChild(root_0, (CommonTree)adaptor.Create(set17));
				state.errorRecovery=false;
			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				throw mse;
			}


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (CommonTree)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("formalPar", 4);
			LeaveRule("formalPar", 4);
			LeaveRule_formalPar();
		}
		DebugLocation(43, 3);
		} finally { DebugExitRule(GrammarFileName, "formalPar"); }
		return retval;

	}
	// $ANTLR end "formalPar"

	partial void EnterRule_expr();
	partial void LeaveRule_expr();
	// $ANTLR start "expr"
	// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:45:1: expr : multExpr ( ( '+' ^| '-' ^) multExpr )* ;
	[GrammarRule("expr")]
	private AstParserRuleReturnScope<CommonTree, IToken> expr()
	{
		EnterRule_expr();
		EnterRule("expr", 5);
		TraceIn("expr", 5);
		AstParserRuleReturnScope<CommonTree, IToken> retval = new AstParserRuleReturnScope<CommonTree, IToken>();
		retval.Start = (IToken)input.LT(1);

		CommonTree root_0 = default(CommonTree);

		IToken char_literal19 = default(IToken);
		IToken char_literal20 = default(IToken);
		AstParserRuleReturnScope<CommonTree, IToken> multExpr18 = default(AstParserRuleReturnScope<CommonTree, IToken>);
		AstParserRuleReturnScope<CommonTree, IToken> multExpr21 = default(AstParserRuleReturnScope<CommonTree, IToken>);

		CommonTree char_literal19_tree = default(CommonTree);
		CommonTree char_literal20_tree = default(CommonTree);
		try { DebugEnterRule(GrammarFileName, "expr");
		DebugLocation(45, 4);
		try
		{
			// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:45:5: ( multExpr ( ( '+' ^| '-' ^) multExpr )* )
			DebugEnterAlt(1);
			// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:45:9: multExpr ( ( '+' ^| '-' ^) multExpr )*
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(45, 9);
			PushFollow(Follow._multExpr_in_expr255);
			multExpr18=multExpr();
			PopFollow();

			adaptor.AddChild(root_0, multExpr18.Tree);
			DebugLocation(45, 18);
			// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:45:18: ( ( '+' ^| '-' ^) multExpr )*
			try { DebugEnterSubRule(4);
			while (true)
			{
				int alt4=2;
				try { DebugEnterDecision(4, false);
				int LA4_1 = input.LA(1);

				if (((LA4_1>=13 && LA4_1<=14)))
				{
					alt4 = 1;
				}


				} finally { DebugExitDecision(4); }
				switch ( alt4 )
				{
				case 1:
					DebugEnterAlt(1);
					// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:45:19: ( '+' ^| '-' ^) multExpr
					{
					DebugLocation(45, 19);
					// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:45:19: ( '+' ^| '-' ^)
					int alt3=2;
					try { DebugEnterSubRule(3);
					try { DebugEnterDecision(3, false);
					int LA3_1 = input.LA(1);

					if ((LA3_1==13))
					{
						alt3 = 1;
					}
					else if ((LA3_1==14))
					{
						alt3 = 2;
					}
					else
					{
						NoViableAltException nvae = new NoViableAltException("", 3, 0, input, 1);
						DebugRecognitionException(nvae);
						throw nvae;
					}
					} finally { DebugExitDecision(3); }
					switch (alt3)
					{
					case 1:
						DebugEnterAlt(1);
						// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:45:20: '+' ^
						{
						DebugLocation(45, 23);
						char_literal19=(IToken)Match(input,13,Follow._13_in_expr259); 
						char_literal19_tree = (CommonTree)adaptor.Create(char_literal19);
						root_0 = (CommonTree)adaptor.BecomeRoot(char_literal19_tree, root_0);

						}
						break;
					case 2:
						DebugEnterAlt(2);
						// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:45:25: '-' ^
						{
						DebugLocation(45, 28);
						char_literal20=(IToken)Match(input,14,Follow._14_in_expr262); 
						char_literal20_tree = (CommonTree)adaptor.Create(char_literal20);
						root_0 = (CommonTree)adaptor.BecomeRoot(char_literal20_tree, root_0);

						}
						break;

					}
					} finally { DebugExitSubRule(3); }

					DebugLocation(45, 31);
					PushFollow(Follow._multExpr_in_expr266);
					multExpr21=multExpr();
					PopFollow();

					adaptor.AddChild(root_0, multExpr21.Tree);

					}
					break;

				default:
					goto loop4;
				}
			}

			loop4:
				;

			} finally { DebugExitSubRule(4); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (CommonTree)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("expr", 5);
			LeaveRule("expr", 5);
			LeaveRule_expr();
		}
		DebugLocation(46, 4);
		} finally { DebugExitRule(GrammarFileName, "expr"); }
		return retval;

	}
	// $ANTLR end "expr"

	partial void EnterRule_multExpr();
	partial void LeaveRule_multExpr();
	// $ANTLR start "multExpr"
	// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:48:1: multExpr : atom ( '*' ^ atom )* ;
	[GrammarRule("multExpr")]
	private AstParserRuleReturnScope<CommonTree, IToken> multExpr()
	{
		EnterRule_multExpr();
		EnterRule("multExpr", 6);
		TraceIn("multExpr", 6);
		AstParserRuleReturnScope<CommonTree, IToken> retval = new AstParserRuleReturnScope<CommonTree, IToken>();
		retval.Start = (IToken)input.LT(1);

		CommonTree root_0 = default(CommonTree);

		IToken char_literal23 = default(IToken);
		AstParserRuleReturnScope<CommonTree, IToken> atom22 = default(AstParserRuleReturnScope<CommonTree, IToken>);
		AstParserRuleReturnScope<CommonTree, IToken> atom24 = default(AstParserRuleReturnScope<CommonTree, IToken>);

		CommonTree char_literal23_tree = default(CommonTree);
		try { DebugEnterRule(GrammarFileName, "multExpr");
		DebugLocation(48, 4);
		try
		{
			// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:49:5: ( atom ( '*' ^ atom )* )
			DebugEnterAlt(1);
			// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:49:9: atom ( '*' ^ atom )*
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(49, 9);
			PushFollow(Follow._atom_in_multExpr288);
			atom22=atom();
			PopFollow();

			adaptor.AddChild(root_0, atom22.Tree);
			DebugLocation(49, 14);
			// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:49:14: ( '*' ^ atom )*
			try { DebugEnterSubRule(5);
			while (true)
			{
				int alt5=2;
				try { DebugEnterDecision(5, false);
				int LA5_1 = input.LA(1);

				if ((LA5_1==12))
				{
					alt5 = 1;
				}


				} finally { DebugExitDecision(5); }
				switch ( alt5 )
				{
				case 1:
					DebugEnterAlt(1);
					// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:49:15: '*' ^ atom
					{
					DebugLocation(49, 18);
					char_literal23=(IToken)Match(input,12,Follow._12_in_multExpr291); 
					char_literal23_tree = (CommonTree)adaptor.Create(char_literal23);
					root_0 = (CommonTree)adaptor.BecomeRoot(char_literal23_tree, root_0);
					DebugLocation(49, 20);
					PushFollow(Follow._atom_in_multExpr294);
					atom24=atom();
					PopFollow();

					adaptor.AddChild(root_0, atom24.Tree);

					}
					break;

				default:
					goto loop5;
				}
			}

			loop5:
				;

			} finally { DebugExitSubRule(5); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (CommonTree)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("multExpr", 6);
			LeaveRule("multExpr", 6);
			LeaveRule_multExpr();
		}
		DebugLocation(50, 4);
		} finally { DebugExitRule(GrammarFileName, "multExpr"); }
		return retval;

	}
	// $ANTLR end "multExpr"

	partial void EnterRule_atom();
	partial void LeaveRule_atom();
	// $ANTLR start "atom"
	// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:52:1: atom : ( INT | ID | '(' expr ')' -> expr | ID '(' expr ')' -> ^( CALL ID expr ) );
	[GrammarRule("atom")]
	private AstParserRuleReturnScope<CommonTree, IToken> atom()
	{
		EnterRule_atom();
		EnterRule("atom", 7);
		TraceIn("atom", 7);
		AstParserRuleReturnScope<CommonTree, IToken> retval = new AstParserRuleReturnScope<CommonTree, IToken>();
		retval.Start = (IToken)input.LT(1);

		CommonTree root_0 = default(CommonTree);

		IToken INT25 = default(IToken);
		IToken ID26 = default(IToken);
		IToken char_literal27 = default(IToken);
		IToken char_literal29 = default(IToken);
		IToken ID30 = default(IToken);
		IToken char_literal31 = default(IToken);
		IToken char_literal33 = default(IToken);
		AstParserRuleReturnScope<CommonTree, IToken> expr28 = default(AstParserRuleReturnScope<CommonTree, IToken>);
		AstParserRuleReturnScope<CommonTree, IToken> expr32 = default(AstParserRuleReturnScope<CommonTree, IToken>);

		CommonTree INT25_tree = default(CommonTree);
		CommonTree ID26_tree = default(CommonTree);
		CommonTree char_literal27_tree = default(CommonTree);
		CommonTree char_literal29_tree = default(CommonTree);
		CommonTree ID30_tree = default(CommonTree);
		CommonTree char_literal31_tree = default(CommonTree);
		CommonTree char_literal33_tree = default(CommonTree);
		RewriteRuleITokenStream stream_10=new RewriteRuleITokenStream(adaptor,"token 10");
		RewriteRuleITokenStream stream_11=new RewriteRuleITokenStream(adaptor,"token 11");
		RewriteRuleITokenStream stream_ID=new RewriteRuleITokenStream(adaptor,"token ID");
		RewriteRuleSubtreeStream stream_expr=new RewriteRuleSubtreeStream(adaptor,"rule expr");
		try { DebugEnterRule(GrammarFileName, "atom");
		DebugLocation(52, 4);
		try
		{
			// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:52:5: ( INT | ID | '(' expr ')' -> expr | ID '(' expr ')' -> ^( CALL ID expr ) )
			int alt6=4;
			try { DebugEnterDecision(6, false);
			switch (input.LA(1))
			{
			case INT:
				{
				alt6 = 1;
				}
				break;
			case ID:
				{
				int LA6_2 = input.LA(2);

				if ((LA6_2==10))
				{
					alt6 = 4;
				}
				else if ((LA6_2==NEWLINE||(LA6_2>=11 && LA6_2<=14)))
				{
					alt6 = 2;
				}
				else
				{
					NoViableAltException nvae = new NoViableAltException("", 6, 2, input, 2);
					DebugRecognitionException(nvae);
					throw nvae;
				}
				}
				break;
			case 10:
				{
				alt6 = 3;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 6, 0, input, 1);
					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(6); }
			switch (alt6)
			{
			case 1:
				DebugEnterAlt(1);
				// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:52:9: INT
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(52, 9);
				INT25=(IToken)Match(input,INT,Follow._INT_in_atom311); 
				INT25_tree = (CommonTree)adaptor.Create(INT25);
				adaptor.AddChild(root_0, INT25_tree);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:53:9: ID
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(53, 9);
				ID26=(IToken)Match(input,ID,Follow._ID_in_atom322); 
				ID26_tree = (CommonTree)adaptor.Create(ID26);
				adaptor.AddChild(root_0, ID26_tree);

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:54:9: '(' expr ')'
				{
				DebugLocation(54, 9);
				char_literal27=(IToken)Match(input,10,Follow._10_in_atom332);  
				stream_10.Add(char_literal27);

				DebugLocation(54, 13);
				PushFollow(Follow._expr_in_atom334);
				expr28=expr();
				PopFollow();

				stream_expr.Add(expr28.Tree);
				DebugLocation(54, 18);
				char_literal29=(IToken)Match(input,11,Follow._11_in_atom336);  
				stream_11.Add(char_literal29);



				{
				// AST REWRITE
				// elements: expr
				// token labels: 
				// rule labels: retval
				// token list labels: 
				// rule list labels: 
				// wildcard labels: 
				retval.Tree = root_0;
				RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

				root_0 = (CommonTree)adaptor.Nil();
				// 54:22: -> expr
				{
					DebugLocation(54, 25);
					adaptor.AddChild(root_0, stream_expr.NextTree());

				}

				retval.Tree = root_0;
				}

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:55:4: ID '(' expr ')'
				{
				DebugLocation(55, 4);
				ID30=(IToken)Match(input,ID,Follow._ID_in_atom345);  
				stream_ID.Add(ID30);

				DebugLocation(55, 7);
				char_literal31=(IToken)Match(input,10,Follow._10_in_atom347);  
				stream_10.Add(char_literal31);

				DebugLocation(55, 11);
				PushFollow(Follow._expr_in_atom349);
				expr32=expr();
				PopFollow();

				stream_expr.Add(expr32.Tree);
				DebugLocation(55, 16);
				char_literal33=(IToken)Match(input,11,Follow._11_in_atom351);  
				stream_11.Add(char_literal33);



				{
				// AST REWRITE
				// elements: ID, expr
				// token labels: 
				// rule labels: retval
				// token list labels: 
				// rule list labels: 
				// wildcard labels: 
				retval.Tree = root_0;
				RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

				root_0 = (CommonTree)adaptor.Nil();
				// 55:20: -> ^( CALL ID expr )
				{
					DebugLocation(55, 23);
					// D:\\repos\\playground\\TreeExperiments\\TreeInterpreter\\Grammar\\ExprTree.g:55:23: ^( CALL ID expr )
					{
					CommonTree root_1 = (CommonTree)adaptor.Nil();
					DebugLocation(55, 25);
					root_1 = (CommonTree)adaptor.BecomeRoot((CommonTree)adaptor.Create(CALL, "CALL"), root_1);

					DebugLocation(55, 30);
					adaptor.AddChild(root_1, stream_ID.NextNode());
					DebugLocation(55, 33);
					adaptor.AddChild(root_1, stream_expr.NextTree());

					adaptor.AddChild(root_0, root_1);
					}

				}

				retval.Tree = root_0;
				}

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (CommonTree)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("atom", 7);
			LeaveRule("atom", 7);
			LeaveRule_atom();
		}
		DebugLocation(56, 4);
		} finally { DebugExitRule(GrammarFileName, "atom"); }
		return retval;

	}
	// $ANTLR end "atom"
	#endregion Rules


	#region Follow sets
	private static class Follow
	{
		public static readonly BitSet _stat_in_prog94 = new BitSet(new ulong[]{0x5C2UL});
		public static readonly BitSet _expr_in_stat109 = new BitSet(new ulong[]{0x100UL});
		public static readonly BitSet _NEWLINE_in_stat111 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _ID_in_stat132 = new BitSet(new ulong[]{0x8000UL});
		public static readonly BitSet _15_in_stat134 = new BitSet(new ulong[]{0x4C0UL});
		public static readonly BitSet _expr_in_stat136 = new BitSet(new ulong[]{0x100UL});
		public static readonly BitSet _NEWLINE_in_stat138 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _func_in_stat155 = new BitSet(new ulong[]{0x100UL});
		public static readonly BitSet _NEWLINE_in_stat157 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _NEWLINE_in_stat172 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _ID_in_func199 = new BitSet(new ulong[]{0x400UL});
		public static readonly BitSet _10_in_func201 = new BitSet(new ulong[]{0xC0UL});
		public static readonly BitSet _formalPar_in_func203 = new BitSet(new ulong[]{0x800UL});
		public static readonly BitSet _11_in_func205 = new BitSet(new ulong[]{0x8000UL});
		public static readonly BitSet _15_in_func207 = new BitSet(new ulong[]{0x4C0UL});
		public static readonly BitSet _expr_in_func209 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _multExpr_in_expr255 = new BitSet(new ulong[]{0x6002UL});
		public static readonly BitSet _13_in_expr259 = new BitSet(new ulong[]{0x4C0UL});
		public static readonly BitSet _14_in_expr262 = new BitSet(new ulong[]{0x4C0UL});
		public static readonly BitSet _multExpr_in_expr266 = new BitSet(new ulong[]{0x6002UL});
		public static readonly BitSet _atom_in_multExpr288 = new BitSet(new ulong[]{0x1002UL});
		public static readonly BitSet _12_in_multExpr291 = new BitSet(new ulong[]{0x4C0UL});
		public static readonly BitSet _atom_in_multExpr294 = new BitSet(new ulong[]{0x1002UL});
		public static readonly BitSet _INT_in_atom311 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _ID_in_atom322 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _10_in_atom332 = new BitSet(new ulong[]{0x4C0UL});
		public static readonly BitSet _expr_in_atom334 = new BitSet(new ulong[]{0x800UL});
		public static readonly BitSet _11_in_atom336 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _ID_in_atom345 = new BitSet(new ulong[]{0x400UL});
		public static readonly BitSet _10_in_atom347 = new BitSet(new ulong[]{0x4C0UL});
		public static readonly BitSet _expr_in_atom349 = new BitSet(new ulong[]{0x800UL});
		public static readonly BitSet _11_in_atom351 = new BitSet(new ulong[]{0x2UL});
	}
	#endregion Follow sets
}

} // namespace Interpreter