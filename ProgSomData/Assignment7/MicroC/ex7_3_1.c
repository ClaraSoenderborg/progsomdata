//7.2.(i) 

int *sump;

void main() {
    int mainArray[4];
    mainArray[0] = 7; 
    mainArray[1] = 13;
    mainArray[2] = 9;
    mainArray[3] = 8;

    int n;
    n = 4;

    arrsum(n, mainArray, sump);
    
    print *sump; 
}

void arrsum(int n, int arr[], int *sump) {
    int i; 

    int sum; 
    sum = 0; 

    for (i = 0; i < n; i = i + 1)
    {
        sum = sum + arr[i];
    }

    //return 
    *sump = sum;
  
}