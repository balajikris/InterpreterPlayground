tree grammar TreeEval;

options {
    tokenVocab=ExprTree;
    ASTLabelType=CommonTree;
}

@namespace { ExpressionEvaluator } 

@header {
using System;
}

@members {
/** Map variable name to Integer object holding value */
Dictionary<string, int> memory = new Dictionary<string, int>();
}

prog:   stat+ ;

stat:   expr
        {Console.WriteLine($expr.value);}
    |   ^('=' ID expr)
        {memory.Add($ID.text, $expr.value);}
    ;

expr returns [int value]
    :   ^('+' a=expr b=expr)  {$value = a+b;}
    |   ^('-' a=expr b=expr)  {$value = a-b;}   
    |   ^('*' a=expr b=expr)  {$value = a*b;}
    |   ID 
        {
			int v;
			if (memory.TryGetValue(($ID.text), out v)) 
			{
				$value = v;
			}
			else 
			{
				Console.WriteLine("undefined variable "+$ID.text);
			}
        }
    |   INT                   {$value = int.Parse($INT.text);}
    ;