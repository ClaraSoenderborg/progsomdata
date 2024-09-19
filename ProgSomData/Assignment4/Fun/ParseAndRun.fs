(* File Fun/ParseAndRun.fs *)

module ParseAndRun

let fromString = Parse.fromString;;

let eval = Fun.eval;;

let run e = eval e [];;

let rec pow a = if a = 0 then 1 else 3 * pow (a-1)

let rec foo x = if x = 0 then 1 else foo (x-1) + pow x

let rec powpow a = 
    let rec inner b = if b = 0 then 1 else a * inner (b-1)
    if a = 0 then 0 else inner 8 + powpow a-1


