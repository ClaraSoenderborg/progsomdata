# Question 8.1


## (ii) ex3

```fsharp
BEFORE: symbolic bytecode
>    compile "ex3";; 
val it: Machine.instr list =
  [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; ADD;
   CSTI 0; STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 1; ADD; LDI;
   PRINTI; INCSP -1; GETBP; CSTI 1; ADD; GETBP; CSTI 1; ADD; LDI; CSTI 1; ADD;
   STI; INCSP -1; INCSP 0; Label "L3"; GETBP; CSTI 1; ADD; LDI; GETBP; CSTI 0;
   ADD; LDI; LT; IFNZRO "L2"; INCSP -1; RET 0]
```
```
AFTER: 
24 LDARGS                 | void main (int n)   
19 CALL 1 5               
25 STOP                   
15 INCSP 1                |
13 GETBP                  |
0 CSTI 1                  | int i = 0
1 ADD                     |
0 CSTI 0                  |
12 STI                    | 
15 INCSP -1               
16 GOTO 43                | while (i<n)
13 GETBP                     |
0 CSTI 1                     | 
1 ADD                        | print i 
11 LDI                       | 
22 PRINTI                    |
15 INCSP -1               
13 GETBP                  |
0 CSTI 1                  |
1 ADD                     |
13 GETBP                  |
0 CSTI 1                  |
1 ADD                     | i = i + 1
11 LDI                    |
0 CSTI 1                  |
1 ADD                     |
12 STI                    |
15 INCSP -1
15 INCSP 0                |
13 GETBP                  |
0 CSTI 1                  | 
1 ADD                     |
11 LDI                    |
13 GETBP                  | i < n 
0 CSTI 0                  |
1 ADD                     |
11 LDI                    |
7 LT                      |
18 IFNZRO 18              |
15 INCSP -1              
21 RET 0 
```

### (ii) ex5

```fsharp
BEFORE: symbolic bytecode
>    compile "ex5";; 
val it: Machine.instr list =
  [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; ADD;
   GETBP; CSTI 0; ADD; LDI; STI; INCSP -1; INCSP 1; GETBP; CSTI 0; ADD; LDI;
   GETBP; CSTI 2; ADD; CALL (2, "L2"); INCSP -1; GETBP; CSTI 2; ADD; LDI;
   PRINTI; INCSP -1; INCSP -1; GETBP; CSTI 1; ADD; LDI; PRINTI; INCSP -1;
   INCSP -1; RET 0; Label "L2"; GETBP; CSTI 1; ADD; LDI; GETBP; CSTI 0; ADD;
   LDI; GETBP; CSTI 0; ADD; LDI; MUL; STI; INCSP -1; INCSP 0; RET 1]
```

```
AFTER: 
24 LDARGS          | void main(int n) 
19 CALL 1 4         
25 STOP             
15 INCSP 1          
13 GETBP           | 
0 CSTI 1           | int r
1 ADD              |
13 GETBP              |
0 CSTI 0              | 
1 ADD                 | r = n
11 LDI                |
12 STI                |
15 INCSP -1 
15 INCSP +1       
13 GETBP            |
0 CSTI 0            |  access to n
1 ADD               |
11 LDI              |    
13 GETBP                |  
0 CSTI 2                | access to r
1 ADD                   |
19 CALL 2 39        | square(n, &r)
15 INCSP -1 
13 GETBP            |
0 CSTI 2            |  
1 ADD               | print r in block
11 LDI              |
22 PRINTI           |
15 INCSP -1 
15 INCSP -1 
13 GETBP            | 
0 CSTI 1            |
1 ADD               | print r
11 LDI              |
22 PRINTI           |
15 INCSP -1 
15 INCSP -1 
21 RET 0            | return from main
13 GETBP                | start of square function
0 CSTI 1                | access *rp
1 ADD                   |
11 LDI                  |
13 GETBP            |
0 CSTI 0            |
1 ADD               | access i
11 LDI              |
13 GETBP                |
0 CSTI 0                |
1 ADD                   | access i
11 LDI                  |
3 MUL               | i * i
12 STI              | *rp = i * i
15 INCSP -1 
15 INCSP 0
21 RET 1          | end of square function
```
The generated byte code shows that we have a nested scope by how it accesses the r variable inside the inner block and outside the inner block. When accessing and printing r inside the block, we add 2 to the base pointer, and outside of the block we add 1 to the base pointer to access r. It is therefore stored in different places in the stack. 

## Machinetrace of ex3
See ex3trace.txt

# Question 8.2
We did not realise this was not part of the assignment until after we made it. So here you go :) 

## ex7_2_1
Old:
```fsharp
- run (fromFile "ex7_2_1.c") [];;
37 val it: Interp.store =
  map
    [(-1, 37); (0, -1); (1, 7); (2, 13); (3, 9); (4, 8); (5, 1); (6, 4);
     (7, 4); ...]
```

New:
```
clarasonderborg@Claras-MacBook-Pro MicroC % java Machine ex7_2_1.out   
37 
Ran 0.018 seconds
```

## ex7_2_2

Old:
```fsharp
> run (fromFile "ex7_2_2.c") [2];;
1 val it: Interp.store =
  map
    [(-1, 1); (0, 2); (1, 0); (2, 1); (3, -999); (4, -999); (5, -999);
     (6, -999); (7, -999); ...]
```

New:
```
clarasonderborg@Claras-MacBook-Pro MicroC % java Machine ex7_2_2.out 2 
1 
Ran 0.019 seconds
```

## ex7_2_3
Old:
```fsharp
> run (fromFile "ex7_2_3.c") [];; 
1 4 2 0 val it: Interp.store =
  map
    [(0, 1); (1, 2); (2, 1); (3, 1); (4, 1); (5, 2); (6, 0); (7, 0); (8, 4);
     ...]
```
New:
```
clarasonderborg@Claras-MacBook-Pro MicroC % java Machine ex7_2_3.out   
1 4 2 0 
Ran 0.018 seconds
```

# Question 8.3 
See Comp.fs 
```
sarahschalls@Sarahs-MacBook-Pro MicroC %    java Machine ex7_5.out 
1 1 
Ran 0.012 seconds
```

# Question 8.4 - Compile ex8.c and study the symbolic byte code to see why it is so much slower than the handwritten 20 million iterations loop in prog1.:

```
20000000; GOTO 7; 1; SUB; DUP; IFNZRO 4; STOP
```

```fsharp
>    compile "ex8";; 
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 0; ADD;
   CSTI 20000000; STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 0; ADD;
   GETBP; CSTI 0; ADD; LDI; CSTI 1; SUB; STI; INCSP -1; INCSP 0; Label "L3";
   GETBP; CSTI 0; ADD; LDI; IFNZRO "L2"; INCSP -1; RET -1]
```

ex8 is slow because the code need to look up value of i each iteration. When using GETBP, CSTI, LDI, STI it accesses memory which is slow. 

# Question 8.4 - Compile ex13.c and study the symbolic bytecode to see how loops and conditionals interact; describe what you see:

```fsharp
> compile "ex13";;
val it: Machine.instr list =
  [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; ADD;
   CSTI 1889; STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 1; ADD; GETBP;
   CSTI 1; ADD; LDI; CSTI 1; ADD; STI; INCSP -1; GETBP; CSTI 1; ADD; LDI;
   CSTI 4; MOD; CSTI 0; EQ; IFZERO "L7"; GETBP; CSTI 1; ADD; LDI; CSTI 100;
   MOD; CSTI 0; EQ; NOT; IFNZRO "L9"; GETBP; CSTI 1; ADD; LDI; CSTI 400; MOD;
   CSTI 0; EQ; GOTO "L8"; Label "L9"; CSTI 1; Label "L8"; GOTO "L6";
   Label "L7"; CSTI 0; Label "L6"; IFZERO "L4"; GETBP; CSTI 1; ADD; LDI;
   PRINTI; INCSP -1; GOTO "L5"; Label "L4"; INCSP 0; Label "L5"; INCSP 0;
   Label "L3"; GETBP; CSTI 1; ADD; LDI; GETBP; CSTI 0; ADD; LDI; LT;
   IFNZRO "L2"; INCSP -1; RET 0]
```

The bytecode uses labels and instructions like IFZERO, IFNZERO and GOTO to handle the while loop and the conditions with modulo. This makes the bytecode very complex to understand.

# Question 8.5 
See file Absyn.fs, CLex.fsl, CPar.fsy, ex8_5.c 

Our example from ex8_5.c:
```fsharp 
> compileToFile (fromFile "ex8_5.c") "ex8_5.out";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; Label "L1"; CSTI 1; CSTI 1; IFZERO "L3";
   CSTI 1; PRINTI; GOTO "L2"; Label "L3"; CSTI 2; PRINTI; Label "L2"; EQ;
   INCSP -1; INCSP 0; RET -1]
```

```
sarahschalls@Sarahs-MacBook-Pro MicroC %    javac Machine.java
sarahschalls@Sarahs-MacBook-Pro MicroC %    java Machine ex8_5.out  
1 
Ran 0.012 seconds
sarahschalls@Sarahs-MacBook-Pro MicroC % 
```

# Question 8.6
See file Absyn.fs, CLex.fsl, CPar.fsy, ex8_6.c 

Our example from ex8_6.c:
```fsharp
> compileToFile (fromFile "ex8_6.c") "ex8_6.out";;
val it: Machine.instr list =
  [LDARGS; CALL (2, "L1"); STOP; Label "L1"; GETBP; CSTI 0; ADD; LDI; CSTI 3;
   EQ; IFNZRO "L5"; GETBP; CSTI 0; ADD; LDI; CSTI 2; EQ; IFNZRO "L4"; GETBP;
   CSTI 0; ADD; LDI; CSTI 1; EQ; IFNZRO "L3"; Label "L5"; CSTI 31; PRINTI;
   INCSP -1; INCSP 0; GOTO "L2"; Label "L4"; GETBP; CSTI 1; ADD; LDI; CSTI 4;
   MOD; CSTI 0; EQ; IFZERO "L6"; CSTI 29; PRINTI; INCSP -1; INCSP 0; GOTO "L7";
   Label "L6"; CSTI 28; PRINTI; INCSP -1; INCSP 0; Label "L7"; INCSP 0;
   GOTO "L2"; Label "L3"; CSTI 31; PRINTI; INCSP -1; INCSP 0; GOTO "L2";
   Label "L2"; INCSP 0; RET 1]
```

```
clarasonderborg@Claras-MacBook-Pro MicroC % java Machine ex8_6.out 2 2000
29 
Ran 0.02 seconds
```