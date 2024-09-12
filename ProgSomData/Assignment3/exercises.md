# Exercise 3.3

let z = (17) in z + 2 * 3 end EOF

Main =(A)=> **Expr** EOF =(F)=> LET NAME EQ Expr IN **Expr** END EOF =(G)=> 
    LET NAME EQ Expr IN Expr TIMES **Expr** END EOF =(C)=> 
    LET NAME EQ Expr IN **Expr** TIMES CSTINT END EOF =(H)=>
    LET NAME EQ Expr IN Expr PLUS **Expr** TIMES CSTINT END EOF =(C)=>
    LET NAME EQ Expr IN **Expr** PLUS CSTINT TIMES CSTINT END EOF =(B)=>
    LET NAME EQ **Expr** IN NAME PLUS CSTINT TIMES CSTINT END EOF =(E)=>
    LET NAME EQ LPAR **Expr** RPAR IN NAME PLUS CSTINT TIMES CSTINT END EOF =(C)=>
    LET NAME EQ LPAR CSTINT RPAR IN NAME PLUS CSTINT TIMES CSTINT END EOF =>
    LET z = (17) in z + 2 * 3 end EOF

# Exercise 3.4
See ex3_4.JPG 

# Exercise 3.5 
Done

# Exercise 3.6
See Expr.fs 

# Exercise 3.7 
See Absyn.fs & ExprLex.fsl & ExprPar.fsy :)