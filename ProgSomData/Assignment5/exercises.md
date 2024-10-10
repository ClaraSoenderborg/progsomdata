# Question 5.1.a 
See 51a.fs :)

# Question 5.1.b 
See mergeArrays.java :)

# Question 5.7
See TypedFun.fs :) 

# Question 6.1
The third program returns ´Int 7´ which is as expected, as the x variable in line 3 should not have any effect on the result. The function addTwo should set x=2 inside the scope of the add function and save this inside the closure, so it can use it later when called in line 3.
The result of the fourth program is a closure, because the add function is only given one argument, and therefore the y argument is not bound yet. 

# Question 6.2 
See HigherFun.fs and Absyn.fs

# Question 6.3
See FunLex.fsl and FunPar.fsy 

# Question 6.4.1
See ex_6_4_i.jpg 
f is polymorphic in the body of let because it does not use the argument x in what it returns. In this example, f can take itself as an argument. 

# Question 6.4.2
See ex_6_4_ii.jpg 
f is not polymorphic in the body of let, because x is used to compare with an integer in the function body. 

# Question 6.5.1
`inferType (fromString "let f x = 1 in f f end");;` is type int

`inferType (fromString "let f g = g g in f end");;` failure due to the type of g is circular, which the type of f depends on.

`inferType (fromString "let f x =
                                 let g y = y
                                 in g false end
                           in f 42 end");; ` is type bool

`inferType (fromString "let f x =
                                 let g y = if true then y else x
                                 in g false end
                           in f 42 end");;` failure because the function f returns both bool and int. Ill-typed. 


`inferType (fromString "let f x =
                                 let g y = if true then y else x
                                 in g false end
                           in f true end");;` is type bool. 

# Question 6.5.2
bool -> bool
```fsharp
> inferType (fromString "let f x = 
-                                 if x = true then true else false
-                            in f end");;
val it: string = "(bool -> bool)"
``` 

int -> int
```fsharp
> inferType (fromString "let f x = 
-                                 if x = 1 then 2 else 3
-                            in f end");;
val it: string = "(int -> int)"
``` 

int -> int -> int
```fsharp
> inferType (fromString "let f x =
-                                  let g y = if x = 1 then y else x
-                                  in g end
-                            in f end");;
val it: string = "(int -> (int -> int))"
``` 

'a -> 'b -> 'a
```fsharp
> inferType (fromString "let f x =
-                                  let g y = x
-                                  in g end
-                            in f end");;
val it: string = "('h -> ('g -> 'h))"
```

'a -> 'b -> 'b

```fsharp
> inferType (fromString "let f x =
-                                  let g y = y
-                                  in g end
-                            in f end");;
val it: string = "('g -> ('h -> 'h))"
```


(’a -> ’b) -> (’b -> ’c) -> (’a -> ’c)
```fsharp
> inferType (fromString "let f x =
-                                  let g y =
-                                     let h z = y (x z) 
-                                     in h end
-                                  in g end
-                            in f end");;
val it: string = "(('l -> 'k) -> (('k -> 'm) -> ('l -> 'm)))"
```

’a -> ’b
```fsharp
> inferType (fromString "let f x = 
-                                  let g = f x                                  
-                                  in g end
-                            in f end");;
val it: string = "('e -> 'f)"
```

’a
```fsharp
> inferType (fromString "let f x = f 8
-                            in f 1 end");;
val it: string = "'e"
```