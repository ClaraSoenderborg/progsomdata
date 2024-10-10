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


