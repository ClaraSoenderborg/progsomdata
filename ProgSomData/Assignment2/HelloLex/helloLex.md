# Question 1
Read the specification hello.fsl.
What are the regular expressions involved, and which semantic values are they associated with?

## Answer 
The regular expression is a range between 0-9, which matches with any digit from 0 to 9. 

# Question 2.1
Generate the lexer out of the specification using a command prompt. Which additional file is generated during the process?

## Answer 
hello.fs and hello.fsi

# Question 2.2
How many states are there by the automaton of the lexer? 

## Answer 
3 states.

# Question 6
Consider the 3 examples of input provided at the prompt and
the result.
Explain why the results are expected behaviour from the lexer.

## Answer
Because hello3 lexer only accepts integers 0-9 and floating numbers that are written with integers 0-9, a period '.' and more integers 0-9. It does not accept commas ',', so the regex only reads everything before the comma. 