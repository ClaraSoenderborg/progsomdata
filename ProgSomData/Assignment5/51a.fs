
// 5.1.a
let rec merge (lists: int list * int list) : int list = 
    match lists with
    | [], [] -> [] 
    | [], x -> x
    | x, [] -> x
    | x :: xs, y :: ys -> 
        if x<y then x :: merge(xs, y :: ys) 
        else y :: merge(x :: xs, ys)

