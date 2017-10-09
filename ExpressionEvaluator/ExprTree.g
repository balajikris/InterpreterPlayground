grammar ExprTree;
options {
    language=CSharp3;
    output=AST;
    ASTLabelType=CommonTree; // type of $stat.tree ref etc...
}

@lexer::namespace { ExpressionEvaluator } 
@parser::namespace { ExpressionEvaluator }
@header {
using System;
}

prog:   ( stat {Console.WriteLine($stat.tree.ToStringTree());} )+ ;

stat:   expr NEWLINE        -> expr
    |   ID '=' expr NEWLINE -> ^('=' ID expr)
    |   NEWLINE             ->
    ;

expr:   multExpr (('+'^|'-'^) multExpr)*
    ; 

multExpr
    :   atom ('*'^ atom)*
    ; 

atom:   INT 
    |   ID
    |   '('! expr ')'!
    ;

ID  :   ('a'..'z'|'A'..'Z')+ ;
INT :   '0'..'9'+ ;
NEWLINE:'\r'? '\n' ;
WS  :   (' '|'\t')+ {Skip();} ;