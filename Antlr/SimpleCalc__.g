lexer grammar SimpleCalc;
options {
  language=CSharp3;

}

@namespace { BalajiK.ParserTest }

DIV : '/' ;
MINUS : '-' ;
MULT : '*' ;
PLUS : '+' ;

// $ANTLR src "D:\repos\playground\TreeExperiments\Antlr\SimpleCalc.g" 32
NUMBER  : (DIGIT)+ ;// $ANTLR src "D:\repos\playground\TreeExperiments\Antlr\SimpleCalc.g" 34
WHITESPACE : ( '\t' | ' ' | '\r' | '\n'| '\u000C' )+    { $channel = Hidden; } ;// $ANTLR src "D:\repos\playground\TreeExperiments\Antlr\SimpleCalc.g" 36
fragment DIGIT  : '0'..'9' ;