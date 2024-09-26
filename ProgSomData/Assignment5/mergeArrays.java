package ProgSomData.Assignment5;

import java.util.Arrays;

public class mergeArrays {

    public static void main(String[] args) {
        int[] xs = { 3, 5, 12 };
        int[] ys = { 2, 3, 4, 7 };

        System.out.println(Arrays.toString(merge(xs,ys)));
    }
    
    static int[] merge(int[] xs, int[] ys){
        int [] mergedList = new int[xs.length+ys.length]; 
        int xPointer = 0; 
        int yPointer = 0; 
        int resultPointer = 0; 

        //If no array are empty: 
        while (xPointer < xs.length && yPointer < ys.length) {
            if (xs[xPointer] < ys[yPointer]) {
                mergedList[resultPointer] = xs[xPointer++]; 
            } else {
                mergedList[resultPointer] = ys[yPointer++]; 
            } 
            resultPointer++; 
        }

        //if ys are empty 
        while (xPointer < xs.length) {
            mergedList[resultPointer] = xs[xPointer++];
            resultPointer++; 
        }

        //if xs are empty 
        while (yPointer < ys.length) {
            mergedList[resultPointer] = ys[yPointer++];
            resultPointer++; 
        }
        return mergedList;
    }

}
