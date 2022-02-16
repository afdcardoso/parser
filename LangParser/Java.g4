grammar Java;

/*
 * Parser Rules
 */

if_     : 'if(' comparison ')';

condition   : comparison LOGIC comparison | comparison;
comparison  : NUMBER COMP condition | NUMBER;

block   : '{' statement '}';

statement   : NUMBER #Value
            // | WORD  #Word
            ;

/*
 * Lexer Rules
 */


// WORD        : '[Aa-Zz]*';
NUMBER       : '[0-9]+';
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
WHITESPACE  : (' '|'t') -> skip;