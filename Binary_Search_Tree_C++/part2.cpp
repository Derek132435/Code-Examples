/** Derek Edwards
 * Binary search tree fun part 2
 * Test out features of self implemented tree
 * 5/16/16
 */

#include <iostream>
#include <random>
#include <ctime>
#include <fstream>
#include "MySet.h"


using namespace std;

int main()
{
/*----------------------------Part 2A--------------------------------*/

//    MySet<int> printTest;
//    for(int i = 2; i < 1001; i += 2){
//            printTest.add(i);
//    }
//    printTest.printFirst(10);
////    printTest.printFirst(250);
////    printTest.printFirst(10000);


/*----------------------------Part 2B--------------------------------*/

    ifstream infile("WordsRandomized.txt");
    MySet<string> fileWords;
    string line;

    for(int i = 0; i < 10; i++){
    int j = 0;
    while ( getline (infile,line) && j < 10000){
        fileWords.add(line);
        ++j;
    }
    fileWords.printFirst(10);
    cout << endl;
    }

    return 0;

}
