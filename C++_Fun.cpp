/*Derek Edwards
 * Factorial, Collatz, and Fibonacci in C++
 */

#include <iostream>

using namespace std;

//calculate nth fibonacci value
unsigned long long fibonacci(unsigned long long n) {
    if(n == 0) return 0;
    if(n > 0 && n < 3) return 1;

    int nDigit = 0;
    int lastResult2 = 1;
    int lastResult1 = 1;

    for (unsigned int i = 2; i < n; i++) {
        nDigit = lastResult2 + lastResult1;
        lastResult2 = lastResult1;
        lastResult1 = nDigit;}

return nDigit;
}

//return factorial of n
unsigned long long factorial(unsigned long long n) {
    if(n == 0)
       return 1;
    return n * factorial(n - 1);
}

//return the number of times collatz is called for n
int collatz(unsigned long long n){

    static int counter = 1;

    if ( n == 1 ){
    }
    else if ( n % 2 == 0 ){
        counter++;
        collatz(n / 2);
    }
    else{
        counter++;
        collatz(3 * n + 1);
    }
    return counter;
}

int main()
{
    /*
    unsigned long long n = 21;

    cout << "Fibonacci of " << n << " = " << fibonacci(n) << endl;
    cout << "Factorial of " << n << " = " << factorial(n) << endl;
    cout << "Collatz of " << n << " results in " << collatz(n)
         << " cycles" << endl;
         */

    for(int i = 0; i < 50; ++i){
        cout << "Factorial of " << i << " = " << factorial(i) << endl;
    }

    return 0;
}
