# Exercise 4.1
Done

# Exercise 4.2

## 4.2.1
`run (fromString "let sum n = if n = 1 then 1 else sum (n - 1) + n in sum 1000 end");;`

## 4.2.2
`run (fromString "let pow a = if a = 0 then 1 else 3 * pow (a - 1) in pow 8 end");;`

## 4.2.3
`run (fromString "let pow a = if a = 0 then 1 else 3 * pow (a - 1) in let foo x = if x = 0 then 1 else foo (x - 1) + pow x in foo 11 end end");;`