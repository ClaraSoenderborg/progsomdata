//7.2.(ii)

int *sump;

void main(int n) {
    int mainArray[20];

    squares(n, mainArray);

    arrsum(n, mainArray, sump);

    print * sump;

}

void squares(int n, int arr[]) {
    if (n <=20) {
        int i; 
        i = 0;

        while (i < n)
        {
            arr[i] = i*i; 
            i = i + 1;
        }
    }
}

//from 7.2.(i)
void arrsum(int n, int arr[], int *sump) {
    int i; 
    i = 0; 

    int sum; 
    sum = 0; 

    while (i < n)
    {
        sum = sum + arr[i];
        i = i + 1;
    }

    //return 
    *sump = sum;
  
}