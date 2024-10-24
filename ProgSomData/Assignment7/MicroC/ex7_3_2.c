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
        

        for (i = 0; i < n; i = i + 1)
        {
            arr[i] = i*i; 

        }
    }
}

//from 7.3.(i)
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