lexer grammar ExprTree;
options {
  language=CSharp3;

}

@namespace { ExpressionEvaluator }

T__8 : '(' ;
T__9 : ')' ;
T__10 : '*' ;
T__11 : '+' ;
T__12 : '-' ;
T__13 : '=' ;

// $ANTLR src "D:\repos\playground\TreeExperiments\ExpressionEvaluator\ExprTree.g" 33
ID  :   ('a'..'z'|'A'..'Z')+ ;// $ANTLR src "D:\repos\playground\TreeExperiments\ExpressionEvaluator\ExprTree.g" 34
INT :   '0'..'9'+ ;// $ANTLR src "D:\repos\playground\TreeExperiments\ExpressionEvaluator\ExprTree.g" 35
NEWLINE:'\r'? '\n' ;// $ANTLR src "D:\repos\playground\TreeExperiments\ExpressionEvaluator\ExprTree.g" 36
WS  :   (' '|'\t')+ {Skip();} ;