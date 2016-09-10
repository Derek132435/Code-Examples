/** Derek Edwards
 * Binary search tree fun part 1
 * Test out features of self implemented tree
 * 5/16/16
 */

#include <iostream>
#include <random>
#include <ctime>
#include <fstream>
#include "MySet.h"


using namespace std;

/**
 * @brief randomValue: generate and return a random value between 0 and 100,000
 * @return: random value between 0 and 100,000
 */
int randomValue();

int main()
{
/*----------------------------Part 1A--------------------------------*/


////    build tree/test add
//    MySet<char> testSet;
//    testSet.add('J');
//    testSet.add('F');
//    testSet.add('G');
//    testSet.add('Y');
//    testSet.add('A');
//    testSet.add('B');
//    testSet.add('C');
//    testSet.add('C');

////    test copy ctor and overloaded assignment
//    MySet<char> testCopy1(testSet);
//    MySet<char> testCopy2;
//    testCopy2 = testSet;

////    test remove
//    testSet.remove('F');
//    testSet.remove('Y');
//    testSet.remove('B');

//    cout << "testSet: ";
//    testSet.print();
//    cout << endl << "testCopy1: ";
//    testCopy1.print();
//    cout << endl << "testCopy2: ";
//    testCopy2.print();

////    test contains, extractLargest, depth, and size
//    cout << endl << "Contains C?: " << testSet.contains('C') << endl;
//    cout << endl << "Contains Z?: " << testSet.contains('Z') << endl;
//    cout << endl << "Largest is: " << testSet.extractLargest() << endl;
//    cout << endl << "depth is: " << testSet.depth() << endl;
//    cout << endl << "Size is: " << testSet.size() << endl;


/*----------------------------Part 1B--------------------------------*/


    srand(time(0));

    MySet<int> random;

    clock_t startClock = clock();
    for(int i = 0; i < 1000000; i++){
        int randVal = randomValue();
        if(random.contains(randVal))
            random.remove(randVal);
        else
            random.add(randVal);
    }
    clock_t clockDuration = clock() - startClock;
    cout << "Big Loop Took: " << (1.0 * clockDuration / CLOCKS_PER_SEC) << " seconds" << endl;

    cout << endl << "The number of items in the set is: " << random.size() << endl;
    cout << endl << "The depth of the storage tree is: " << random.depth() << endl;

    cout << endl;
    for(int i = 0; i < 5; i++){
    cout<< "Largest is: " << random.extractLargest() << endl;
    }


/*----------------------------Part 1C--------------------------------*/


    MySet<int> testCopy1;
    for(int i = 2; i < 1001; i += 2){
        testCopy1.add(i);
    }

    MySet<int> testCopy2;
    for(int i = 5; i < 1001; i += 5){
        testCopy2.add(i);
    }

    MySet<int> joined = testCopy1.unionWith(testCopy2);

    cout << endl << "The size of the set is: " << joined.size() << endl;


    return 0;

}

int randomValue() {
    int thousands = rand() % 100;
    int ones = rand() % 1000;
    return thousands * 1000 + ones;
}
