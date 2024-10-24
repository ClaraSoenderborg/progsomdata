# Question  

BEFORE: symbolic bytecode
>    compile "ex3";; 
val it: Machine.instr list =
  [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; ADD;
   CSTI 0; STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 1; ADD; LDI;
   PRINTI; INCSP -1; GETBP; CSTI 1; ADD; GETBP; CSTI 1; ADD; LDI; CSTI 1; ADD;
   STI; INCSP -1; INCSP 0; Label "L3"; GETBP; CSTI 1; ADD; LDI; GETBP; CSTI 0;
   ADD; LDI; LT; IFNZRO "L2"; INCSP -1; RET 0]

AFTER: 
24 LDARGS                 | void main (int n)   
19 CALL 1 4               
25 STOP                   
15 INCSP 1                |
13 GETBP                  |
0 CSTI 1                  | int i = 0
1 ADD                     |
0 CSTI 0                  |
12 STI                    | 
15 INCSP -1               
16 GOTO 30                | while (i<n)
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
18 IFNZRO 12              |
15 INCSP -1              
21 RET 0 


BEFORE: symbolic bytecode

>    compile "ex5";; 
val it: Machine.instr list =
  [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; GETBP; CSTI 1; ADD;
   GETBP; CSTI 0; ADD; LDI; STI; INCSP -1; INCSP 1; GETBP; CSTI 0; ADD; LDI;
   GETBP; CSTI 2; ADD; CALL (2, "L2"); INCSP -1; GETBP; CSTI 2; ADD; LDI;
   PRINTI; INCSP -1; INCSP -1; GETBP; CSTI 1; ADD; LDI; PRINTI; INCSP -1;
   INCSP -1; RET 0; Label "L2"; GETBP; CSTI 1; ADD; LDI; GETBP; CSTI 0; ADD;
   LDI; GETBP; CSTI 0; ADD; LDI; MUL; STI; INCSP -1; INCSP 0; RET 1]

AFTER: 
24 LDARGS          | void main(int n) 
19 CALL 1 4        | 
25 STOP            | 
15 INCSP 1         | 
13 GETBP           | 
0 CSTI 1         
1 ADD 
13 GETBP 
0 CSTI 0           | int i = 0 
1 ADD
11 LDI
12 STI
15 INCSP -1 
15 INCSP +1 
13 GETBP
0 CSTI 0
1 ADD 
11 LDI 
13 GETBP 
0 CSTI 2           | 
1 ADD
19 CALL 2 L2 
15 INCSP -1 
13 GETBP
0 CSTI 2           | 
1 ADD
11 LDI 
22 PRINTI
15 INCSP -1 
15 INCSP -1 
13 GETBP
0 CSTI 1 
1 ADD 
11 LDI 
22 PRINTI
15 INCSP -1 
15 INCSP -1 
21 RET 0 
13 GETBP
0 CSTI 1 
1 ADD 
11 LDI
13 GETBP
0 CSTI 0 
1 ADD 
11 LDI 
13 GETBP
0 CSTI 0 
1 ADD 
11 LDI 
3 MUL
12 STI
15 INCSP -1 
15 INCSP 0
21 RET 1 









