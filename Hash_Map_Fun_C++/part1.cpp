/** Derek Edwards
  * Playing with HashMap
  * part 1
  * 6/03/16
  */

#include <iostream>
#include <fstream>
#include <string>
#include <algorithm>
#include "HashMap.h"

using namespace std;

int main()
{
    cout << std::boolalpha;

    HashMap tester(5);

    cout << "Inserting Items..." << endl;
    tester.insert("Apple", 1);
    tester.insert("Banana", 2);
    tester.insert("Carrot", 3);
    tester.insert("Donkey", 4);
    tester.insert("Eagle", 5);
    tester.insert("Flag", 6);
    tester.insert("Apple", 7);

    cout << endl << "Value of Apple: " << tester.get("Apple") << endl
         << "Value of Banana: " << tester.get("Banana") << endl
         << "Value of Carrot: " << tester.get("Carrot") << endl
         << "Value of Donkey: " << tester.get("Donkey") << endl
         << "Value of Eagle: " << tester.get("Eagle") << endl
         << "Value of Flag: " << tester.get("Flag") << endl;

    tester.insert("Flag", 8);

    cout << endl << "Value of Flag/8 is: " << tester.get("Flag") << endl;

    cout << endl << "Size of HashMap: " << tester.size() << endl;

    cout << "HashMap contains Donkey: " << tester.contains("Donkey") << endl;

    cout << endl << "Removing Donkey... " << endl;
    tester.remove("Donkey");
    cout << endl << "HashMap contains Donkey: " << tester.contains("Donkey") << endl;

    cout << "Size of HashMap: " << tester.size() << endl << endl;

    tester.printStorage();

    cout << endl << "Inserting items..." << endl;
    tester.insert("Apricot", 1);
    tester.insert("Peach", 4);
    tester.insert("Strawberry", 8);
    tester.insert("Nectarine", 9);
    tester.insert("Grapes", 0);
    tester.insert("Beans", 10);
    tester.insert("Garlic", 11);

    tester.printStorage();

    return 0;
}
