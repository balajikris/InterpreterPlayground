using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace TreeExperiments
{
    public class Globals
    {
        public int X;
        public int Y;
    }

    public class RoslynTrees
    {
        public static void Simple(int x1, int y1)
        {
            // build syntax tree for expr
            var beforeParse = DateTime.Now;
            var lambdaExpression = BuildSyntaxTree2();
            var timeToParse = DateTime.Now - beforeParse;

            // TODO: is there a way to pass a syntax tree instead of string?
            // compile
            var text = lambdaExpression.ToString(); // exclude from time measurements.
            var beforeCompile = DateTime.Now;
            var script = CSharpScript.Create<Func<int, int, int>>(text /*, globalsType: typeof(Globals)*/);
            var runner = script.CreateDelegate(CancellationToken.None);
            var timeToCompile = DateTime.Now - beforeCompile;

            // execute
            var beforeExecute = DateTime.Now;
            var func = runner().Result;
            var result = func(x1, y1);
            var timeToExecute = DateTime.Now - beforeExecute;

            Console.WriteLine($"the roslyn tree was evaluated and it returned: {result}");
            Console.WriteLine("Printing Time elapsed info:");
            Console.WriteLine($"Parsing: {timeToParse}, compile: {timeToCompile}, execute: {timeToExecute}");
            Console.WriteLine($"total time: {timeToParse.Add(timeToCompile).Add(timeToExecute).TotalMilliseconds} ms");
        }

        private static ParenthesizedLambdaExpressionSyntax BuildSyntaxTree2()
        {
            SyntaxToken identifierX = Identifier("x");
            SyntaxToken identifierY = Identifier("y");

            ParameterSyntax p1 = Parameter(identifierX);
            ParameterSyntax p2 = Parameter(identifierY);

            ExpressionSyntax addExpr = BinaryExpression(SyntaxKind.AddExpression, 
                IdentifierName(identifierX), IdentifierName(identifierY));

            ParenthesizedLambdaExpressionSyntax lambdaExpression = 
                ParenthesizedLambdaExpression(addExpr)
                    .WithParameterList(ParameterList(SeparatedList(new[] {p1, p2})));

            return lambdaExpression;
        }

        private static ParenthesizedLambdaExpressionSyntax BuildSyntaxTree1()
        {
            return ParenthesizedLambdaExpression(
                BinaryExpression(
                    SyntaxKind.AddExpression,
                    IdentifierName("x"),
                    IdentifierName(
                        Identifier(
                            TriviaList(),
                            "y",
                            TriviaList(
                                Trivia(
                                    SkippedTokensTrivia()
                                        .WithTokens(
                                            TokenList(
                                                Token(SyntaxKind.SemicolonToken)))))))))
                .WithParameterList(
                    ParameterList(
                        SeparatedList<ParameterSyntax>(
                            new SyntaxNodeOrToken[]
                            {
                                Parameter(
                                    Identifier("x")),
                                Token(SyntaxKind.CommaToken),
                                Parameter(
                                    Identifier("y"))
                            })))
                .NormalizeWhitespace();
        }


        // since the expression in the script is a Func, it is not evaluated when we invoke the delegate created by compiling hte script
        // we can finally invoke the result with the appropriate args. Note that if the expression has variables, they need to be bound
        // by the globals object.. below method shows that, but it uses run() instead of createDelegate()..
        // but since dgrep would only have lambda like queries, it should be this scenario i guess?
        // need to understand the apis a bit more here.
        // var diagnostics = script.Compile(CancellationToken.None)
        // Debug.Assert(diagnostics.IsDefaultOrEmpty);
        // var result = (await script.RunAsync(args)).ReturnValue;
        // var args = new Globals { X = x1, Y = y1 };
        // var del = runner(args).Result;
    }
}
