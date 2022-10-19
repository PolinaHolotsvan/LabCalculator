grammar LabCalculator;

/*
 * Parser Rules
 */

compileUnit : expression EOF;
expression :
LPAREN expression RPAREN #ParenthesizedExpr
|expression EXPONENT expression #ExponentialExpr

| expression operatorToken=(MULTIPLY | DIVIDE) expression #MultiplicativeExpr
| expression operatorToken=(ADD | SUBTRACT) expression #AdditiveExpr
| operatorToken=(MOD | DIV) LPAREN expression ',' expression RPAREN #ModDivExpr
| MMIN LPAREN paramlist=arglist RPAREN #MminExpr
| MMAX LPAREN paramlist=arglist RPAREN #MmaxExpr


| NUMBER #NumberExpr
| IDENTIFIER #IdentifierExpr
;

arglist: expression(',' expression)+;
paramlist: expression(',' expression)+;
/*
* Lexer Rules
*/
MOD: 'mod';
DIV: 'div';
MMAX: 'mmax';
MMIN: 'mmin';
NUMBER : INT ('.' INT)?;
IDENTIFIER : [a-zA-Z]+[1-9][0-9]*;
INT : ('0'..'9')+;
EXPONENT : '^';
MULTIPLY : '*';
DIVIDE : '/';
SUBTRACT : '-';
ADD : '+';
LPAREN : '(';
RPAREN : ')';
WS : [ \t\r\n] -> channel(HIDDEN);