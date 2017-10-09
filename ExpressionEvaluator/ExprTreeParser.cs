//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 3.4.1.9004
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// $ANTLR 3.4.1.9004 D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g 2017-10-02 17:10:20

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

namespace  ExpressionEvaluator 
{
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.4.1.9004")]
[System.CLSCompliant(false)]
public partial class ExprTreeParser : Antlr.Runtime.Parser
{
	internal static readonly string[] tokenNames = new string[] {
		"<invalid>", "<EOR>", "<DOWN>", "<UP>", "ID", "INT", "NEWLINE", "WS", "'('", "')'", "'*'", "'+'", "'-'", "'='"
	};
	public const int EOF=-1;
	public const int ID=4;
	public const int INT=5;
	public const int NEWLINE=6;
	public const int WS=7;
	public const int T__8=8;
	public const int T__9=9;
	public const int T__10=10;
	public const int T__11=11;
	public const int T__12=12;
	public const int T__13=13;

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
	public override string GrammarFileName { get { return "D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g"; } }


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	#region Rules
	partial void EnterRule_prog();
	partial void LeaveRule_prog();
	// $ANTLR start "prog"
	// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:14:1: prog : ( stat )+ ;
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
		DebugLocation(14, 66);
		try
		{
			// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:14:5: ( ( stat )+ )
			DebugEnterAlt(1);
			// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:14:9: ( stat )+
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(14, 9);
			// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:14:9: ( stat )+
			int cnt1=0;
			try { DebugEnterSubRule(1);
			while (true)
			{
				int alt1=2;
				try { DebugEnterDecision(1, false);
				int LA1_1 = input.LA(1);

				if (((LA1_1>=ID && LA1_1<=NEWLINE)||LA1_1==8))
				{
					alt1 = 1;
				}


				} finally { DebugExitDecision(1); }
				switch (alt1)
				{
				case 1:
					DebugEnterAlt(1);
					// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:14:11: stat
					{
					DebugLocation(14, 11);
					PushFollow(Follow._stat_in_prog68);
					stat1=stat();
					PopFollow();

					adaptor.AddChild(root_0, stat1.Tree);
					DebugLocation(14, 16);
					Console.WriteLine((stat1!=null?((CommonTree)stat1.Tree):default(CommonTree)).ToStringTree());

					}
					break;

				default:
					if (cnt1 >= 1)
						goto loop1;

					EarlyExitException eee1 = new EarlyExitException( 1, input );
					DebugRecognitionException(eee1);
					throw eee1;
				}
				cnt1++;
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
		DebugLocation(14, 66);
		} finally { DebugExitRule(GrammarFileName, "prog"); }
		return retval;

	}
	// $ANTLR end "prog"

	partial void EnterRule_stat();
	partial void LeaveRule_stat();
	// $ANTLR start "stat"
	// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:16:1: stat : ( expr NEWLINE -> expr | ID '=' expr NEWLINE -> ^( '=' ID expr ) | NEWLINE ->);
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
		IToken NEWLINE8 = default(IToken);
		AstParserRuleReturnScope<CommonTree, IToken> expr2 = default(AstParserRuleReturnScope<CommonTree, IToken>);
		AstParserRuleReturnScope<CommonTree, IToken> expr6 = default(AstParserRuleReturnScope<CommonTree, IToken>);

		CommonTree NEWLINE3_tree = default(CommonTree);
		CommonTree ID4_tree = default(CommonTree);
		CommonTree char_literal5_tree = default(CommonTree);
		CommonTree NEWLINE7_tree = default(CommonTree);
		CommonTree NEWLINE8_tree = default(CommonTree);
		RewriteRuleITokenStream stream_NEWLINE=new RewriteRuleITokenStream(adaptor,"token NEWLINE");
		RewriteRuleITokenStream stream_ID=new RewriteRuleITokenStream(adaptor,"token ID");
		RewriteRuleITokenStream stream_13=new RewriteRuleITokenStream(adaptor,"token 13");
		RewriteRuleSubtreeStream stream_expr=new RewriteRuleSubtreeStream(adaptor,"rule expr");
		try { DebugEnterRule(GrammarFileName, "stat");
		DebugLocation(16, 4);
		try
		{
			// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:16:5: ( expr NEWLINE -> expr | ID '=' expr NEWLINE -> ^( '=' ID expr ) | NEWLINE ->)
			int alt2=3;
			try { DebugEnterDecision(2, false);
			switch (input.LA(1))
			{
			case INT:
			case 8:
				{
				alt2 = 1;
				}
				break;
			case ID:
				{
				int LA2_2 = input.LA(2);

				if ((LA2_2==13))
				{
					alt2 = 2;
				}
				else if ((LA2_2==NEWLINE||(LA2_2>=10 && LA2_2<=12)))
				{
					alt2 = 1;
				}
				else
				{
					NoViableAltException nvae = new NoViableAltException("", 2, 2, input, 2);
					DebugRecognitionException(nvae);
					throw nvae;
				}
				}
				break;
			case NEWLINE:
				{
				alt2 = 3;
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
				// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:16:9: expr NEWLINE
				{
				DebugLocation(16, 9);
				PushFollow(Follow._expr_in_stat83);
				expr2=expr();
				PopFollow();

				stream_expr.Add(expr2.Tree);
				DebugLocation(16, 14);
				NEWLINE3=(IToken)Match(input,NEWLINE,Follow._NEWLINE_in_stat85);  
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
				// 16:29: -> expr
				{
					DebugLocation(16, 32);
					adaptor.AddChild(root_0, stream_expr.NextTree());

				}

				retval.Tree = root_0;
				}

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:17:9: ID '=' expr NEWLINE
				{
				DebugLocation(17, 9);
				ID4=(IToken)Match(input,ID,Follow._ID_in_stat106);  
				stream_ID.Add(ID4);

				DebugLocation(17, 12);
				char_literal5=(IToken)Match(input,13,Follow._13_in_stat108);  
				stream_13.Add(char_literal5);

				DebugLocation(17, 16);
				PushFollow(Follow._expr_in_stat110);
				expr6=expr();
				PopFollow();

				stream_expr.Add(expr6.Tree);
				DebugLocation(17, 21);
				NEWLINE7=(IToken)Match(input,NEWLINE,Follow._NEWLINE_in_stat112);  
				stream_NEWLINE.Add(NEWLINE7);



				{
				// AST REWRITE
				// elements: 13, ID, expr
				// token labels: 
				// rule labels: retval
				// token list labels: 
				// rule list labels: 
				// wildcard labels: 
				retval.Tree = root_0;
				RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

				root_0 = (CommonTree)adaptor.Nil();
				// 17:29: -> ^( '=' ID expr )
				{
					DebugLocation(17, 32);
					// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:17:32: ^( '=' ID expr )
					{
					CommonTree root_1 = (CommonTree)adaptor.Nil();
					DebugLocation(17, 34);
					root_1 = (CommonTree)adaptor.BecomeRoot(stream_13.NextNode(), root_1);

					DebugLocation(17, 38);
					adaptor.AddChild(root_1, stream_ID.NextNode());
					DebugLocation(17, 41);
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
				// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:18:9: NEWLINE
				{
				DebugLocation(18, 9);
				NEWLINE8=(IToken)Match(input,NEWLINE,Follow._NEWLINE_in_stat132);  
				stream_NEWLINE.Add(NEWLINE8);



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
				// 18:29: ->
				{
					DebugLocation(19, 5);
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
		DebugLocation(19, 4);
		} finally { DebugExitRule(GrammarFileName, "stat"); }
		return retval;

	}
	// $ANTLR end "stat"

	partial void EnterRule_expr();
	partial void LeaveRule_expr();
	// $ANTLR start "expr"
	// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:21:1: expr : multExpr ( ( '+' ^| '-' ^) multExpr )* ;
	[GrammarRule("expr")]
	private AstParserRuleReturnScope<CommonTree, IToken> expr()
	{
		EnterRule_expr();
		EnterRule("expr", 3);
		TraceIn("expr", 3);
		AstParserRuleReturnScope<CommonTree, IToken> retval = new AstParserRuleReturnScope<CommonTree, IToken>();
		retval.Start = (IToken)input.LT(1);

		CommonTree root_0 = default(CommonTree);

		IToken char_literal10 = default(IToken);
		IToken char_literal11 = default(IToken);
		AstParserRuleReturnScope<CommonTree, IToken> multExpr9 = default(AstParserRuleReturnScope<CommonTree, IToken>);
		AstParserRuleReturnScope<CommonTree, IToken> multExpr12 = default(AstParserRuleReturnScope<CommonTree, IToken>);

		CommonTree char_literal10_tree = default(CommonTree);
		CommonTree char_literal11_tree = default(CommonTree);
		try { DebugEnterRule(GrammarFileName, "expr");
		DebugLocation(21, 4);
		try
		{
			// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:21:5: ( multExpr ( ( '+' ^| '-' ^) multExpr )* )
			DebugEnterAlt(1);
			// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:21:9: multExpr ( ( '+' ^| '-' ^) multExpr )*
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(21, 9);
			PushFollow(Follow._multExpr_in_expr160);
			multExpr9=multExpr();
			PopFollow();

			adaptor.AddChild(root_0, multExpr9.Tree);
			DebugLocation(21, 18);
			// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:21:18: ( ( '+' ^| '-' ^) multExpr )*
			try { DebugEnterSubRule(4);
			while (true)
			{
				int alt4=2;
				try { DebugEnterDecision(4, false);
				int LA4_1 = input.LA(1);

				if (((LA4_1>=11 && LA4_1<=12)))
				{
					alt4 = 1;
				}


				} finally { DebugExitDecision(4); }
				switch ( alt4 )
				{
				case 1:
					DebugEnterAlt(1);
					// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:21:19: ( '+' ^| '-' ^) multExpr
					{
					DebugLocation(21, 19);
					// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:21:19: ( '+' ^| '-' ^)
					int alt3=2;
					try { DebugEnterSubRule(3);
					try { DebugEnterDecision(3, false);
					int LA3_1 = input.LA(1);

					if ((LA3_1==11))
					{
						alt3 = 1;
					}
					else if ((LA3_1==12))
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
						// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:21:20: '+' ^
						{
						DebugLocation(21, 23);
						char_literal10=(IToken)Match(input,11,Follow._11_in_expr164); 
						char_literal10_tree = (CommonTree)adaptor.Create(char_literal10);
						root_0 = (CommonTree)adaptor.BecomeRoot(char_literal10_tree, root_0);

						}
						break;
					case 2:
						DebugEnterAlt(2);
						// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:21:25: '-' ^
						{
						DebugLocation(21, 28);
						char_literal11=(IToken)Match(input,12,Follow._12_in_expr167); 
						char_literal11_tree = (CommonTree)adaptor.Create(char_literal11);
						root_0 = (CommonTree)adaptor.BecomeRoot(char_literal11_tree, root_0);

						}
						break;

					}
					} finally { DebugExitSubRule(3); }

					DebugLocation(21, 31);
					PushFollow(Follow._multExpr_in_expr171);
					multExpr12=multExpr();
					PopFollow();

					adaptor.AddChild(root_0, multExpr12.Tree);

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
			TraceOut("expr", 3);
			LeaveRule("expr", 3);
			LeaveRule_expr();
		}
		DebugLocation(22, 4);
		} finally { DebugExitRule(GrammarFileName, "expr"); }
		return retval;

	}
	// $ANTLR end "expr"

	partial void EnterRule_multExpr();
	partial void LeaveRule_multExpr();
	// $ANTLR start "multExpr"
	// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:24:1: multExpr : atom ( '*' ^ atom )* ;
	[GrammarRule("multExpr")]
	private AstParserRuleReturnScope<CommonTree, IToken> multExpr()
	{
		EnterRule_multExpr();
		EnterRule("multExpr", 4);
		TraceIn("multExpr", 4);
		AstParserRuleReturnScope<CommonTree, IToken> retval = new AstParserRuleReturnScope<CommonTree, IToken>();
		retval.Start = (IToken)input.LT(1);

		CommonTree root_0 = default(CommonTree);

		IToken char_literal14 = default(IToken);
		AstParserRuleReturnScope<CommonTree, IToken> atom13 = default(AstParserRuleReturnScope<CommonTree, IToken>);
		AstParserRuleReturnScope<CommonTree, IToken> atom15 = default(AstParserRuleReturnScope<CommonTree, IToken>);

		CommonTree char_literal14_tree = default(CommonTree);
		try { DebugEnterRule(GrammarFileName, "multExpr");
		DebugLocation(24, 4);
		try
		{
			// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:25:5: ( atom ( '*' ^ atom )* )
			DebugEnterAlt(1);
			// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:25:9: atom ( '*' ^ atom )*
			{
			root_0 = (CommonTree)adaptor.Nil();

			DebugLocation(25, 9);
			PushFollow(Follow._atom_in_multExpr193);
			atom13=atom();
			PopFollow();

			adaptor.AddChild(root_0, atom13.Tree);
			DebugLocation(25, 14);
			// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:25:14: ( '*' ^ atom )*
			try { DebugEnterSubRule(5);
			while (true)
			{
				int alt5=2;
				try { DebugEnterDecision(5, false);
				int LA5_1 = input.LA(1);

				if ((LA5_1==10))
				{
					alt5 = 1;
				}


				} finally { DebugExitDecision(5); }
				switch ( alt5 )
				{
				case 1:
					DebugEnterAlt(1);
					// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:25:15: '*' ^ atom
					{
					DebugLocation(25, 18);
					char_literal14=(IToken)Match(input,10,Follow._10_in_multExpr196); 
					char_literal14_tree = (CommonTree)adaptor.Create(char_literal14);
					root_0 = (CommonTree)adaptor.BecomeRoot(char_literal14_tree, root_0);
					DebugLocation(25, 20);
					PushFollow(Follow._atom_in_multExpr199);
					atom15=atom();
					PopFollow();

					adaptor.AddChild(root_0, atom15.Tree);

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
			TraceOut("multExpr", 4);
			LeaveRule("multExpr", 4);
			LeaveRule_multExpr();
		}
		DebugLocation(26, 4);
		} finally { DebugExitRule(GrammarFileName, "multExpr"); }
		return retval;

	}
	// $ANTLR end "multExpr"

	partial void EnterRule_atom();
	partial void LeaveRule_atom();
	// $ANTLR start "atom"
	// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:28:1: atom : ( INT | ID | '(' ! expr ')' !);
	[GrammarRule("atom")]
	private AstParserRuleReturnScope<CommonTree, IToken> atom()
	{
		EnterRule_atom();
		EnterRule("atom", 5);
		TraceIn("atom", 5);
		AstParserRuleReturnScope<CommonTree, IToken> retval = new AstParserRuleReturnScope<CommonTree, IToken>();
		retval.Start = (IToken)input.LT(1);

		CommonTree root_0 = default(CommonTree);

		IToken INT16 = default(IToken);
		IToken ID17 = default(IToken);
		IToken char_literal18 = default(IToken);
		IToken char_literal20 = default(IToken);
		AstParserRuleReturnScope<CommonTree, IToken> expr19 = default(AstParserRuleReturnScope<CommonTree, IToken>);

		CommonTree INT16_tree = default(CommonTree);
		CommonTree ID17_tree = default(CommonTree);
		CommonTree char_literal18_tree = default(CommonTree);
		CommonTree char_literal20_tree = default(CommonTree);
		try { DebugEnterRule(GrammarFileName, "atom");
		DebugLocation(28, 4);
		try
		{
			// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:28:5: ( INT | ID | '(' ! expr ')' !)
			int alt6=3;
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
				alt6 = 2;
				}
				break;
			case 8:
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
				// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:28:9: INT
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(28, 9);
				INT16=(IToken)Match(input,INT,Follow._INT_in_atom216); 
				INT16_tree = (CommonTree)adaptor.Create(INT16);
				adaptor.AddChild(root_0, INT16_tree);

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:29:9: ID
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(29, 9);
				ID17=(IToken)Match(input,ID,Follow._ID_in_atom227); 
				ID17_tree = (CommonTree)adaptor.Create(ID17);
				adaptor.AddChild(root_0, ID17_tree);

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// D:\\repos\\playground\\TreeExperiments\\ExpressionEvaluator\\ExprTree.g:30:9: '(' ! expr ')' !
				{
				root_0 = (CommonTree)adaptor.Nil();

				DebugLocation(30, 12);
				char_literal18=(IToken)Match(input,8,Follow._8_in_atom237); 
				DebugLocation(30, 14);
				PushFollow(Follow._expr_in_atom240);
				expr19=expr();
				PopFollow();

				adaptor.AddChild(root_0, expr19.Tree);
				DebugLocation(30, 22);
				char_literal20=(IToken)Match(input,9,Follow._9_in_atom242); 

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
			TraceOut("atom", 5);
			LeaveRule("atom", 5);
			LeaveRule_atom();
		}
		DebugLocation(31, 4);
		} finally { DebugExitRule(GrammarFileName, "atom"); }
		return retval;

	}
	// $ANTLR end "atom"
	#endregion Rules


	#region Follow sets
	private static class Follow
	{
		public static readonly BitSet _stat_in_prog68 = new BitSet(new ulong[]{0x172UL});
		public static readonly BitSet _expr_in_stat83 = new BitSet(new ulong[]{0x40UL});
		public static readonly BitSet _NEWLINE_in_stat85 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _ID_in_stat106 = new BitSet(new ulong[]{0x2000UL});
		public static readonly BitSet _13_in_stat108 = new BitSet(new ulong[]{0x130UL});
		public static readonly BitSet _expr_in_stat110 = new BitSet(new ulong[]{0x40UL});
		public static readonly BitSet _NEWLINE_in_stat112 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _NEWLINE_in_stat132 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _multExpr_in_expr160 = new BitSet(new ulong[]{0x1802UL});
		public static readonly BitSet _11_in_expr164 = new BitSet(new ulong[]{0x130UL});
		public static readonly BitSet _12_in_expr167 = new BitSet(new ulong[]{0x130UL});
		public static readonly BitSet _multExpr_in_expr171 = new BitSet(new ulong[]{0x1802UL});
		public static readonly BitSet _atom_in_multExpr193 = new BitSet(new ulong[]{0x402UL});
		public static readonly BitSet _10_in_multExpr196 = new BitSet(new ulong[]{0x130UL});
		public static readonly BitSet _atom_in_multExpr199 = new BitSet(new ulong[]{0x402UL});
		public static readonly BitSet _INT_in_atom216 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _ID_in_atom227 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _8_in_atom237 = new BitSet(new ulong[]{0x130UL});
		public static readonly BitSet _expr_in_atom240 = new BitSet(new ulong[]{0x200UL});
		public static readonly BitSet _9_in_atom242 = new BitSet(new ulong[]{0x2UL});
	}
	#endregion Follow sets
}

} // namespace  ExpressionEvaluator 
