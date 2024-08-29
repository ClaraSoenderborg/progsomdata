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





(* 1.1 i*)
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
    
    
(*1.1 ii*)
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