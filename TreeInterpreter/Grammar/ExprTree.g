grammar ExprTree;

// ANTLR3 requires the following ordering - options, tokens, @header, @members, rules.
options {
    language=CSharp3;
    output=AST;
    ASTLabelType=CommonTree;
}

tokens {
    FUNC;
    CALL;
}

@lexer::namespace {Interpreter} 
@parser::namespace {Interpreter}
@header {
using System;
}

@members {
/** List of function definitions. Must point at the FUNC nodes. */
public readonly List<CommonTree> FunctionDefinitions = new List<CommonTree>();
}

prog:   ( stat )* 
	;

stat:   expr NEWLINE        -> expr
    |   ID '=' expr NEWLINE -> ^('=' ID expr)
	|   func NEWLINE		-> func
    |   NEWLINE             -> 
    ;

func: ID '(' formalPar ')' '=' expr -> ^(FUNC ID formalPar expr)
	;
	finally {
		FunctionDefinitions.Add($func.tree);
	}

formalPar: ID
		 | INT
		 ;

expr:   multExpr (('+'^|'-'^) multExpr)*
    ; 

multExpr
    :   atom ('*'^ atom)*
    ; 

atom:   INT 
    |   ID
    |   '(' expr ')' -> expr
	|	ID '(' expr ')' -> ^(CALL ID expr)
    ;

ID  :   ('a'..'z'|'A'..'Z')+ ;
INT :   '0'..'9'+ ;
NEWLINE:'\r'? '\n' ;
WS  :   (' '|'\t')+ {Skip();} ;
