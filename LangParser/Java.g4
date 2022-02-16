grammar Java;

/*
 * Parser Rules
 */

if_     : 'if' separator block;

condition   : comparison 
            | comparison LOGIC condition
            | comparison LOGIC comparison
            ;

comparison  : number COMP number 
            | number
            ;

separator   : '(' condition ')';
block       : '{' statement '}';

statement   : number ';' #Nmb
            | word ';' #Wrd
            ;

word        : LETTER+;
number      : DIGIT+;
/*
 * Lexer Rules
 */

LETTER      : 'A'..'Z'
            | 'a'..'z'
            | '_'
            ;
DIGIT       : ('0'..'9');

COMP        : '=='  
            | '!='  
            | '<='  
            | '<'   
            | '>='  
            | '>'   
            ;

LOGIC       : '||'
            | '|'
            | '&&'
            | '&'
            ;

WHITESPACE  : (' '|'\t'|'\r'|'\n') -> skip;