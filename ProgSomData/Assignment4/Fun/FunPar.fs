// Implementation file for parser generated by fsyacc
module FunPar
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Text.Lexing
open FSharp.Text.Parsing.ParseHelpers
# 1 "FunPar.fsy"

 (* File Fun/FunPar.fsy 
    Parser for micro-ML, a small functional language; one-argument functions.
    sestoft@itu.dk * 2009-10-19
  *)

 open Absyn;

# 15 "FunPar.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | LPAR
  | RPAR
  | EQ
  | NE
  | GT
  | LT
  | GE
  | LE
  | AND
  | OR
  | PLUS
  | MINUS
  | TIMES
  | DIV
  | MOD
  | ELSE
  | END
  | FALSE
  | IF
  | IN
  | LET
  | NOT
  | THEN
  | TRUE
  | CSTBOOL of (bool)
  | NAME of (string)
  | CSTINT of (int)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_LPAR
    | TOKEN_RPAR
    | TOKEN_EQ
    | TOKEN_NE
    | TOKEN_GT
    | TOKEN_LT
    | TOKEN_GE
    | TOKEN_LE
    | TOKEN_AND
    | TOKEN_OR
    | TOKEN_PLUS
    | TOKEN_MINUS
    | TOKEN_TIMES
    | TOKEN_DIV
    | TOKEN_MOD
    | TOKEN_ELSE
    | TOKEN_END
    | TOKEN_FALSE
    | TOKEN_IF
    | TOKEN_IN
    | TOKEN_LET
    | TOKEN_NOT
    | TOKEN_THEN
    | TOKEN_TRUE
    | TOKEN_CSTBOOL
    | TOKEN_NAME
    | TOKEN_CSTINT
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startMain
    | NONTERM_Main
    | NONTERM_Expr
    | NONTERM_AtExpr
    | NONTERM_ParamList
    | NONTERM_AppExpr
    | NONTERM_Const

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | LPAR  -> 1 
  | RPAR  -> 2 
  | EQ  -> 3 
  | NE  -> 4 
  | GT  -> 5 
  | LT  -> 6 
  | GE  -> 7 
  | LE  -> 8 
  | AND  -> 9 
  | OR  -> 10 
  | PLUS  -> 11 
  | MINUS  -> 12 
  | TIMES  -> 13 
  | DIV  -> 14 
  | MOD  -> 15 
  | ELSE  -> 16 
  | END  -> 17 
  | FALSE  -> 18 
  | IF  -> 19 
  | IN  -> 20 
  | LET  -> 21 
  | NOT  -> 22 
  | THEN  -> 23 
  | TRUE  -> 24 
  | CSTBOOL _ -> 25 
  | NAME _ -> 26 
  | CSTINT _ -> 27 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_LPAR 
  | 2 -> TOKEN_RPAR 
  | 3 -> TOKEN_EQ 
  | 4 -> TOKEN_NE 
  | 5 -> TOKEN_GT 
  | 6 -> TOKEN_LT 
  | 7 -> TOKEN_GE 
  | 8 -> TOKEN_LE 
  | 9 -> TOKEN_AND 
  | 10 -> TOKEN_OR 
  | 11 -> TOKEN_PLUS 
  | 12 -> TOKEN_MINUS 
  | 13 -> TOKEN_TIMES 
  | 14 -> TOKEN_DIV 
  | 15 -> TOKEN_MOD 
  | 16 -> TOKEN_ELSE 
  | 17 -> TOKEN_END 
  | 18 -> TOKEN_FALSE 
  | 19 -> TOKEN_IF 
  | 20 -> TOKEN_IN 
  | 21 -> TOKEN_LET 
  | 22 -> TOKEN_NOT 
  | 23 -> TOKEN_THEN 
  | 24 -> TOKEN_TRUE 
  | 25 -> TOKEN_CSTBOOL 
  | 26 -> TOKEN_NAME 
  | 27 -> TOKEN_CSTINT 
  | 30 -> TOKEN_end_of_input
  | 28 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startMain 
    | 1 -> NONTERM_Main 
    | 2 -> NONTERM_Expr 
    | 3 -> NONTERM_Expr 
    | 4 -> NONTERM_Expr 
    | 5 -> NONTERM_Expr 
    | 6 -> NONTERM_Expr 
    | 7 -> NONTERM_Expr 
    | 8 -> NONTERM_Expr 
    | 9 -> NONTERM_Expr 
    | 10 -> NONTERM_Expr 
    | 11 -> NONTERM_Expr 
    | 12 -> NONTERM_Expr 
    | 13 -> NONTERM_Expr 
    | 14 -> NONTERM_Expr 
    | 15 -> NONTERM_Expr 
    | 16 -> NONTERM_Expr 
    | 17 -> NONTERM_Expr 
    | 18 -> NONTERM_Expr 
    | 19 -> NONTERM_AtExpr 
    | 20 -> NONTERM_AtExpr 
    | 21 -> NONTERM_AtExpr 
    | 22 -> NONTERM_AtExpr 
    | 23 -> NONTERM_AtExpr 
    | 24 -> NONTERM_ParamList 
    | 25 -> NONTERM_ParamList 
    | 26 -> NONTERM_AppExpr 
    | 27 -> NONTERM_AppExpr 
    | 28 -> NONTERM_Const 
    | 29 -> NONTERM_Const 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 30 
let _fsyacc_tagOfErrorTerminal = 28

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | LPAR  -> "LPAR" 
  | RPAR  -> "RPAR" 
  | EQ  -> "EQ" 
  | NE  -> "NE" 
  | GT  -> "GT" 
  | LT  -> "LT" 
  | GE  -> "GE" 
  | LE  -> "LE" 
  | AND  -> "AND" 
  | OR  -> "OR" 
  | PLUS  -> "PLUS" 
  | MINUS  -> "MINUS" 
  | TIMES  -> "TIMES" 
  | DIV  -> "DIV" 
  | MOD  -> "MOD" 
  | ELSE  -> "ELSE" 
  | END  -> "END" 
  | FALSE  -> "FALSE" 
  | IF  -> "IF" 
  | IN  -> "IN" 
  | LET  -> "LET" 
  | NOT  -> "NOT" 
  | THEN  -> "THEN" 
  | TRUE  -> "TRUE" 
  | CSTBOOL _ -> "CSTBOOL" 
  | NAME _ -> "NAME" 
  | CSTINT _ -> "CSTINT" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | LPAR  -> (null : System.Object) 
  | RPAR  -> (null : System.Object) 
  | EQ  -> (null : System.Object) 
  | NE  -> (null : System.Object) 
  | GT  -> (null : System.Object) 
  | LT  -> (null : System.Object) 
  | GE  -> (null : System.Object) 
  | LE  -> (null : System.Object) 
  | AND  -> (null : System.Object) 
  | OR  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | MINUS  -> (null : System.Object) 
  | TIMES  -> (null : System.Object) 
  | DIV  -> (null : System.Object) 
  | MOD  -> (null : System.Object) 
  | ELSE  -> (null : System.Object) 
  | END  -> (null : System.Object) 
  | FALSE  -> (null : System.Object) 
  | IF  -> (null : System.Object) 
  | IN  -> (null : System.Object) 
  | LET  -> (null : System.Object) 
  | NOT  -> (null : System.Object) 
  | THEN  -> (null : System.Object) 
  | TRUE  -> (null : System.Object) 
  | CSTBOOL _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | CSTINT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us;65535us;1us;65535us;0us;1us;23us;65535us;0us;2us;6us;7us;8us;9us;10us;11us;12us;13us;32us;14us;33us;15us;34us;16us;35us;17us;36us;18us;37us;19us;38us;20us;39us;21us;40us;22us;41us;23us;42us;24us;43us;25us;44us;26us;49us;27us;50us;28us;53us;29us;54us;30us;56us;31us;25us;65535us;0us;4us;4us;60us;5us;61us;6us;4us;8us;4us;10us;4us;12us;4us;32us;4us;33us;4us;34us;4us;35us;4us;36us;4us;37us;4us;38us;4us;39us;4us;40us;4us;41us;4us;42us;4us;43us;4us;44us;4us;49us;4us;50us;4us;53us;4us;54us;4us;56us;4us;1us;65535us;48us;52us;23us;65535us;0us;5us;6us;5us;8us;5us;10us;5us;12us;5us;32us;5us;33us;5us;34us;5us;35us;5us;36us;5us;37us;5us;38us;5us;39us;5us;40us;5us;41us;5us;42us;5us;43us;5us;44us;5us;49us;5us;50us;5us;53us;5us;54us;5us;56us;5us;25us;65535us;0us;45us;4us;45us;5us;45us;6us;45us;8us;45us;10us;45us;12us;45us;32us;45us;33us;45us;34us;45us;35us;45us;36us;45us;37us;45us;38us;45us;39us;45us;40us;45us;41us;45us;42us;45us;43us;45us;44us;45us;49us;45us;50us;45us;53us;45us;54us;45us;56us;45us;|]
let _fsyacc_sparseGotoTableRowOffsets = [|0us;1us;3us;27us;53us;55us;79us;|]
let _fsyacc_stateToProdIdxsTableElements = [| 1us;0us;1us;0us;14us;1us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;1us;1us;2us;2us;26us;2us;3us;27us;1us;4us;14us;4us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;1us;4us;14us;4us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;1us;4us;14us;4us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;1us;5us;14us;5us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;14us;6us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;14us;6us;7us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;14us;6us;7us;8us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;14us;6us;7us;8us;9us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;14us;6us;7us;8us;9us;10us;10us;11us;12us;13us;14us;15us;16us;17us;18us;14us;6us;7us;8us;9us;10us;11us;11us;12us;13us;14us;15us;16us;17us;18us;14us;6us;7us;8us;9us;10us;11us;12us;12us;13us;14us;15us;16us;17us;18us;14us;6us;7us;8us;9us;10us;11us;12us;13us;13us;14us;15us;16us;17us;18us;14us;6us;7us;8us;9us;10us;11us;12us;13us;14us;14us;15us;16us;17us;18us;14us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;15us;16us;17us;18us;14us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;16us;17us;18us;14us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;17us;18us;14us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;18us;14us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;21us;14us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;21us;14us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;22us;14us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;22us;14us;6us;7us;8us;9us;10us;11us;12us;13us;14us;15us;16us;17us;18us;23us;1us;6us;1us;7us;1us;8us;1us;9us;1us;10us;1us;11us;1us;12us;1us;13us;1us;14us;1us;15us;1us;16us;1us;17us;1us;18us;1us;19us;1us;20us;2us;21us;22us;2us;21us;22us;1us;21us;1us;21us;1us;21us;2us;22us;25us;1us;22us;1us;22us;1us;22us;1us;23us;1us;23us;1us;24us;1us;25us;1us;26us;1us;27us;1us;28us;1us;29us;|]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us;2us;4us;19us;21us;24us;27us;29us;44us;46us;61us;63us;78us;80us;95us;110us;125us;140us;155us;170us;185us;200us;215us;230us;245us;260us;275us;290us;305us;320us;335us;350us;365us;367us;369us;371us;373us;375us;377us;379us;381us;383us;385us;387us;389us;391us;393us;395us;398us;401us;403us;405us;407us;410us;412us;414us;416us;418us;420us;422us;424us;426us;428us;430us;|]
let _fsyacc_action_rows = 64
let _fsyacc_actionTableElements = [|7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;0us;49152us;14us;32768us;0us;3us;3us;37us;4us;38us;5us;39us;6us;40us;7us;41us;8us;42us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;0us;16385us;5us;16386us;1us;56us;21us;47us;25us;63us;26us;46us;27us;62us;5us;16387us;1us;56us;21us;47us;25us;63us;26us;46us;27us;62us;7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;14us;32768us;3us;37us;4us;38us;5us;39us;6us;40us;7us;41us;8us;42us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;23us;8us;7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;14us;32768us;3us;37us;4us;38us;5us;39us;6us;40us;7us;41us;8us;42us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;16us;10us;7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;13us;16388us;3us;37us;4us;38us;5us;39us;6us;40us;7us;41us;8us;42us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;5us;16389us;9us;43us;10us;44us;13us;34us;14us;35us;15us;36us;5us;16390us;9us;43us;10us;44us;13us;34us;14us;35us;15us;36us;5us;16391us;9us;43us;10us;44us;13us;34us;14us;35us;15us;36us;2us;16392us;9us;43us;10us;44us;2us;16393us;9us;43us;10us;44us;2us;16394us;9us;43us;10us;44us;11us;16395us;5us;39us;6us;40us;7us;41us;8us;42us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;11us;16396us;5us;39us;6us;40us;7us;41us;8us;42us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;7us;16397us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;7us;16398us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;7us;16399us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;7us;16400us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;13us;16401us;3us;37us;4us;38us;5us;39us;6us;40us;7us;41us;8us;42us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;13us;16402us;3us;37us;4us;38us;5us;39us;6us;40us;7us;41us;8us;42us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;14us;32768us;3us;37us;4us;38us;5us;39us;6us;40us;7us;41us;8us;42us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;20us;50us;14us;32768us;3us;37us;4us;38us;5us;39us;6us;40us;7us;41us;8us;42us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;17us;51us;14us;32768us;3us;37us;4us;38us;5us;39us;6us;40us;7us;41us;8us;42us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;20us;54us;14us;32768us;3us;37us;4us;38us;5us;39us;6us;40us;7us;41us;8us;42us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;17us;55us;14us;32768us;2us;57us;3us;37us;4us;38us;5us;39us;6us;40us;7us;41us;8us;42us;9us;43us;10us;44us;11us;32us;12us;33us;13us;34us;14us;35us;15us;36us;7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;0us;16403us;0us;16404us;1us;32768us;26us;48us;2us;32768us;3us;49us;26us;58us;7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;0us;16405us;2us;32768us;3us;53us;26us;59us;7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;0us;16406us;7us;32768us;1us;56us;12us;12us;19us;6us;21us;47us;25us;63us;26us;46us;27us;62us;0us;16407us;0us;16408us;0us;16409us;0us;16410us;0us;16411us;0us;16412us;0us;16413us;|]
let _fsyacc_actionTableRowOffsets = [|0us;8us;9us;24us;25us;31us;37us;45us;60us;68us;83us;91us;105us;113us;119us;125us;131us;134us;137us;140us;152us;164us;172us;180us;188us;196us;210us;224us;239us;254us;269us;284us;299us;307us;315us;323us;331us;339us;347us;355us;363us;371us;379us;387us;395us;403us;404us;405us;407us;410us;418us;426us;427us;430us;438us;446us;447us;455us;456us;457us;458us;459us;460us;461us;|]
let _fsyacc_reductionSymbolCounts = [|1us;2us;1us;1us;6us;2us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;3us;1us;1us;7us;8us;3us;1us;2us;2us;2us;1us;1us;|]
let _fsyacc_productionToNonTerminalTable = [|0us;1us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;2us;3us;3us;3us;3us;3us;4us;4us;5us;5us;6us;6us;|]
let _fsyacc_immediateActions = [|65535us;49152us;65535us;16385us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;65535us;16403us;16404us;65535us;65535us;65535us;65535us;16405us;65535us;65535us;65535us;16406us;65535us;16407us;16408us;16409us;16410us;16411us;16412us;16413us;|]
let _fsyacc_reductions = lazy [|
# 267 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : 'gentype__startMain));
# 276 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 34 "FunPar.fsy"
                                                               _1 
                   )
# 34 "FunPar.fsy"
                 : Absyn.expr));
# 287 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 38 "FunPar.fsy"
                                                               _1                     
                   )
# 38 "FunPar.fsy"
                 : Absyn.expr));
# 298 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 39 "FunPar.fsy"
                                                               _1                     
                   )
# 39 "FunPar.fsy"
                 : Absyn.expr));
# 309 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            let _4 = parseState.GetInput(4) :?> Absyn.expr in
            let _6 = parseState.GetInput(6) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 40 "FunPar.fsy"
                                                               If(_2, _4, _6)         
                   )
# 40 "FunPar.fsy"
                 : Absyn.expr));
# 322 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 41 "FunPar.fsy"
                                                               Prim("-", CstI 0, _2)  
                   )
# 41 "FunPar.fsy"
                 : Absyn.expr));
# 333 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 42 "FunPar.fsy"
                                                               Prim("+",  _1, _3)     
                   )
# 42 "FunPar.fsy"
                 : Absyn.expr));
# 345 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 43 "FunPar.fsy"
                                                               Prim("-",  _1, _3)     
                   )
# 43 "FunPar.fsy"
                 : Absyn.expr));
# 357 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 44 "FunPar.fsy"
                                                               Prim("*",  _1, _3)     
                   )
# 44 "FunPar.fsy"
                 : Absyn.expr));
# 369 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 45 "FunPar.fsy"
                                                               Prim("/",  _1, _3)     
                   )
# 45 "FunPar.fsy"
                 : Absyn.expr));
# 381 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 46 "FunPar.fsy"
                                                               Prim("%",  _1, _3)     
                   )
# 46 "FunPar.fsy"
                 : Absyn.expr));
# 393 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 47 "FunPar.fsy"
                                                               Prim("=",  _1, _3)     
                   )
# 47 "FunPar.fsy"
                 : Absyn.expr));
# 405 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 48 "FunPar.fsy"
                                                               Prim("<>", _1, _3)     
                   )
# 48 "FunPar.fsy"
                 : Absyn.expr));
# 417 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 49 "FunPar.fsy"
                                                               Prim(">",  _1, _3)     
                   )
# 49 "FunPar.fsy"
                 : Absyn.expr));
# 429 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "FunPar.fsy"
                                                               Prim("<",  _1, _3)     
                   )
# 50 "FunPar.fsy"
                 : Absyn.expr));
# 441 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 51 "FunPar.fsy"
                                                               Prim(">=", _1, _3)     
                   )
# 51 "FunPar.fsy"
                 : Absyn.expr));
# 453 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 52 "FunPar.fsy"
                                                               Prim("<=", _1, _3)     
                   )
# 52 "FunPar.fsy"
                 : Absyn.expr));
# 465 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "FunPar.fsy"
                                                               If(_1, _3, CstB(false))
                   )
# 53 "FunPar.fsy"
                 : Absyn.expr));
# 477 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _3 = parseState.GetInput(3) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 54 "FunPar.fsy"
                                                               If(_1, CstB(true), _3) 
                   )
# 54 "FunPar.fsy"
                 : Absyn.expr));
# 489 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 58 "FunPar.fsy"
                                                               _1                     
                   )
# 58 "FunPar.fsy"
                 : Absyn.expr));
# 500 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 59 "FunPar.fsy"
                                                               Var _1                 
                   )
# 59 "FunPar.fsy"
                 : Absyn.expr));
# 511 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            let _4 = parseState.GetInput(4) :?> Absyn.expr in
            let _6 = parseState.GetInput(6) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 60 "FunPar.fsy"
                                                               Let(_2, _4, _6)        
                   )
# 60 "FunPar.fsy"
                 : Absyn.expr));
# 524 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> string in
            let _3 = parseState.GetInput(3) :?> 'gentype_ParamList in
            let _5 = parseState.GetInput(5) :?> Absyn.expr in
            let _7 = parseState.GetInput(7) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 61 "FunPar.fsy"
                                                                    Letfun(_2, _3, _5, _7) 
                   )
# 61 "FunPar.fsy"
                 : Absyn.expr));
# 538 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 62 "FunPar.fsy"
                                                               _2                     
                   )
# 62 "FunPar.fsy"
                 : Absyn.expr));
# 549 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 66 "FunPar.fsy"
                                                               [_1] 
                   )
# 66 "FunPar.fsy"
                 : 'gentype_ParamList));
# 560 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> 'gentype_ParamList in
            let _2 = parseState.GetInput(2) :?> string in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 67 "FunPar.fsy"
                                                               _1 @ [_2] 
                   )
# 67 "FunPar.fsy"
                 : 'gentype_ParamList));
# 572 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 71 "FunPar.fsy"
                                                               Call(_1, [_2])           
                   )
# 71 "FunPar.fsy"
                 : Absyn.expr));
# 584 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> Absyn.expr in
            let _2 = parseState.GetInput(2) :?> Absyn.expr in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 72 "FunPar.fsy"
                                                               match _1 with           
                                                               | Call(f, args) -> Call(f, args @ [_2])
                                                               | _ -> Call(_1, [_2])           
                   )
# 72 "FunPar.fsy"
                 : Absyn.expr));
# 598 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> int in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 78 "FunPar.fsy"
                                                               CstI(_1)               
                   )
# 78 "FunPar.fsy"
                 : Absyn.expr));
# 609 "FunPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = parseState.GetInput(1) :?> bool in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 79 "FunPar.fsy"
                                                               CstB(_1)               
                   )
# 79 "FunPar.fsy"
                 : Absyn.expr));
|]
# 621 "FunPar.fs"
let tables : FSharp.Text.Parsing.Tables<_> = 
  { reductions = _fsyacc_reductions.Value;
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 31;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = tables.Interpret(lexer, lexbuf, startState)
let Main lexer lexbuf : Absyn.expr =
    engine lexer lexbuf 0 :?> _