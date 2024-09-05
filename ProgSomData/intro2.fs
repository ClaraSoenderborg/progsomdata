(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

module Intro2

(* Association lists map object language variables to their values *)

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)];;

let emptyenv = []; (* the empty environment *)

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

let cvalue = lookup env "c";;


(* Object language expressions with variables *)

type expr = 
  | CstI of int
  | Var of string
  | Prim of string * expr * expr;;

let e1 = CstI 17;;

let e2 = Prim("+", CstI 3, Var "a");;

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a");;



(* Evaluation within an environment *)
let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim _            -> failwith "unknown primitive";;

let e1v  = eval e1 env;;
let e2v1 = eval e2 env;;
let e2v2 = eval e2 [("a", 314)];;
let e3v  = eval e3 env;;

// 1.1 i 
let rec eval1 e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim("max", e1, e2) ->
        System.Math.Max(eval e1 env, eval e2 env)
    | Prim("min", e1, e2) ->
    System.Math.Min(eval e1 env, eval e2 env)
    | Prim("==", e1, e2) ->
        match eval e1 env = eval e2 env with
        | true -> 1
        | _ -> 0
    | Prim _            -> failwith "unknown primitive";;
    
    
// 1.1 ii
let exampleMax = eval1 (Prim("max", e1, e2)) env
let exampleMin = eval1 (Prim("min", e1, e2)) env
let exampleEqualTrue = eval1 (Prim("==", CstI 17, e1)) env
let exampleEqualFalse = eval1 (Prim("==", e1, e2)) env


// 1.1 iii
let eval2 e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x
    | Prim(op, e1,e2) ->
        let res1 = eval e1 env
        let res2 = eval e2 env
        match op with
        | "+" -> res1 + res2
        | "-" -> res1 - res2
        | "*" -> res1 * res2
        | "max" -> System.Math.Max(res1, res2)
        | "min" -> System.Math.Min(res1, res2)
        | "==" -> if res1 = res2 then 1 else 0
        | _ -> failwith "unknown primitive"

// 1.1 iv
type expr1 = 
  | CstI of int
  | Var of string
  | Prim of string * expr1 * expr1
  | If of expr1 * expr1 * expr1
  
// 1.1 v
let rec eval3 (e:expr1) (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | Prim("+", e1, e2) -> eval3 e1 env + eval3 e2 env
    | Prim("*", e1, e2) -> eval3 e1 env * eval3 e2 env
    | Prim("-", e1, e2) -> eval3 e1 env - eval3 e2 env
    | Prim("max", e1, e2) ->
        System.Math.Max(eval3 e1 env, eval3 e2 env)
    | Prim("min", e1, e2) ->
    System.Math.Min(eval3 e1 env, eval3 e2 env)
    | Prim("==", e1, e2) ->
        if eval3 e1 env = eval3 e2 env then 1 else 0
    | Prim _            -> failwith "unknown primitive"
    | If(e1, e2, e3) ->
        match eval3 e1 env with
        | x when x > 0 -> eval3 e2 env
        | _ -> eval3 e3 env
    

let exampleIfTrue = eval3 (If(Var "a", CstI 11, CstI 22)) env


// 1.2 i
type aexpr =
    | CstI of int
    | Var of string
    | Add of aexpr * aexpr
    | Mul of aexpr * aexpr
    | Sub of aexpr * aexpr
    
// 1.2 ii
let expr1 = Sub(Var "v", Add(Var "w", Var "z"))
let expr2 = Mul(CstI 2, Sub(Var "v", Add(Var "w", Var "z")))
let expr3 = Add(Add(Var "x", Var "y"), Add(Var "z", Var "v"))

// 1.2 iii

let rec fmt e : string=
    match e with
    | CstI x -> string x
    | Var s -> s
    | Add (e1, e2) -> "(" + fmt e1 + " + " + fmt e2 + ")"
    | Mul (e1, e2) -> "(" + fmt e1 + " * " + fmt e2 + ")"
    | Sub (e1, e2) -> "(" + fmt e1 + " - " + fmt e2 + ")"
    
    
// 1.2 iv

let rec simplify e : aexpr =
    match e with
    | CstI 0 -> e
    | Var s -> e
    | Add(e1, e2) ->
        match e1, e2 with
        | CstI 0, _ -> simplify e2
        | _ , CstI 0 -> simplify e1
        | _, _  -> Add(simplify e1, simplify e2)
    | Sub(e1, e2) ->
        match e1, e2 with
        | _,_ when e1 = e2 -> CstI 0
        | _ , CstI 0 -> simplify e1
        | _, _  -> Sub(simplify e1, simplify e2)
    | Mul(e1, e2) ->
        match e1, e2 with
        | CstI 0, _ -> CstI 0
        | _ , CstI 0 -> CstI 0
        | _, _  -> Mul(simplify e1, simplify e2) 
    | _ -> e
    
let simpEx1 = Add(Var "x", CstI 0)

let simpEx2 = Mul(Var "x", CstI 0)

let simpEx3 = Sub(Var "x", Var "x")

// 1.2 v
// Se evt. "Regneregler for symbolsk differentiering" 
let rec diff (e: aexpr) (var: string) : aexpr =
    match e with
    | CstI _ -> CstI 0                                           // d(a)/dx = 0, for konstante a 
    | Var x -> if x = var then CstI 1 else CstI 0       // d(x)/dx = 1 eller d(y)/dx = 0 hvis y ikke er lig x
    | Add (e1, e2) ->                             // d(e1 + e2)/dx = d(e1)/dx + d(e2)/dx
        Add (diff e1 var, diff e2 var)
    | Sub (e1, e2) ->                            // d(e1 - e2)/dx = d(e1)/dx - d(e2)/dx
        Sub (diff e1 var, diff e2 var)
    | Mul (e1, e2) ->                            // d(e1 * e2)/dx = (d(e1)/dx) * e2 + e1 * (d(e2)/dx)
        Add (Mul (diff e1 var, e2), Mul (e1, diff e2 var))

