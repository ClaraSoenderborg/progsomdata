// File Intro/SimpleExpr.java
// Java representation of expressions as in lecture 1
// sestoft@itu.dk * 2010-08-29

import java.util.Map;
import java.util.HashMap;

// 1.4 (i) 
abstract class Expr { 
  abstract public int eval(Map<String,Integer> env); //1.4 (iii)
  abstract public String toString();                 //1.4.(i)
  abstract public Expr simplify();                   //1.4 (iv)
  
  
}

class CstI extends Expr { 
  protected final int i;

  public CstI(int i) { 
    this.i = i; 
  }

  //1.4 (iii)
  public int eval(Map<String,Integer> env) {
    return i;
  } 

  //1.4 (i)
  public String toString() {
    return ""+i;
  }


  //1.4 (iv)
  public Expr simplify() { 
    return this; 
  }


}

class Var extends Expr { 
  protected final String name;

  public Var(String name) { 
    this.name = name; 
  }

  //1.4 (iii)
  public int eval(Map<String,Integer> env) {
    return env.get(name);
  } 

  //1.4 (i)
  public String toString() {
    return name;
  } 

  //1.4 (iv)
  public Expr simplify() { 
    return this; 
  }


}


abstract class Binop extends Expr {

  protected final Expr E1, E2; 

  public Binop(Expr E1, Expr E2) { 
    this.E1 = E1;
    this.E2 = E2; 
  }

  public boolean isE1Zero (){
    if(E1 instanceof CstI){
      return (((CstI)E1).i == 0);
    } else {
      return false;
    }
  }

  public boolean isE2Zero (){
    if(E2 instanceof CstI) {
      return (((CstI)E2).i == 0);
    } else {
      return false; 
    }
  }

  public boolean isE1One (){
    if(E1 instanceof CstI) {
      return (((CstI)E1).i == 1);
    } else {
      return false;
    }
  }

  public boolean isE2One (){
    if(E2 instanceof CstI) {
      return (((CstI)E2).i == 1);
    } else {
      return false; 
    }
    
    
  }

}

class Add extends Binop {

  public Add(Expr E1, Expr E2) { 
     super (E1, E2);
  }

  //1.4 (i)
  public String toString() {

    return "(" + E1 + " + " + E2 + ")";

  }

  //1.4 (iii)
  public int eval(Map<String,Integer> env) {
    return E1.eval(env) + E2.eval(env);
  }

  //1.4 (iv)
  public Expr simplify() { 
    if (isE1Zero()) {
      return E2.simplify();
    } else if (isE2Zero()){
      return E1.simplify();
    } else {
      return this;
    }
  }

  

}

class Sub extends Binop {

  public Sub(Expr E1, Expr E2) { 
     super (E1, E2);
  }

  //1.4 (i)
  public String toString() {

    return "(" + E1 + " - " + E2 + ")";

  }

  //1.4 (iii)
  public int eval(Map<String,Integer> env) {
    return E1.eval(env) - E2.eval(env);
  }

  //1.4 (iv)
  public Expr simplify() { 
     if (isE2Zero()){
      return E1.simplify();
    } else if (E1.toString().equals(E2.toString())) {
      return new CstI(0);
    } else {
      return this;
    }
  }
  

}


class Mul extends Binop {

  public Mul(Expr E1, Expr E2) { 
     super (E1, E2);
  }

  //1.4 (i)
  public String toString() {

    return "(" + E1 + " * " + E2 + ")";

  }

  //1.4 (iii)
  public int eval(Map<String,Integer> env) {
    return E1.eval(env) * E2.eval(env);
  }

  //1.4 (iv)
  public Expr simplify() { 
    if (isE1One()){
     return E2.simplify();
   } else if (isE2One()) {
     return E1.simplify();
   } else if (isE1Zero() || isE2Zero())  {
      return new CstI(0);
   } else {
     return this;
   }
  }

}

public class SimpleExpr {
  public static void main(String[] args) {
    
    //1.4 (i)
    Expr e = new Add(new CstI(17), new Var("z"));
    System.out.println(e.toString());

    //1.4 (ii) 
    Expr e1 = new Sub(new Var("v"), new Add(new Var("w"), new Var ("z")));
    System.out.println(e1.toString());

    Expr e2 = new Mul(new CstI(2), new Sub(new Var("v"), new Add(new Var("w"), new Var ("z"))));
    System.out.println(e2.toString());

    Expr e3 = new Add(new Add(new Var ("x"), new Var ("y")), new Add(new Var("z"), new Var("v")));
    System.out.println(e3.toString());

    //1.4 (iv)
    System.out.println((new Add(new Var ("x"), new CstI(0))).simplify().toString());
    System.out.println((new Mul(new Var ("x"), new CstI(0))).simplify());
    System.out.println((new Sub(new Var("x"), new Var("x"))).simplify());

  }
}


