/** Derek Edwards
  * Playing with HashMap
  * part 2: Using my hash map class to count the number of times the
  * word "begat" appears in the bible as well as the ten most common words
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

    ifstream infile("bible.txt");
    HashMap bible(10000);
    string mostCommon[10];

    string word;
    while(infile >> word){
        transform(word.begin(), word.end(), word.begin(), ::tolower);
        if(!bible.contains(word)) { bible.insert(word, 1); }
        else {
            int newValue = 1 + bible.get(word);
            bible.insert(word, newValue);

            ///keep track of 10 most common words
            string tempWord = word;
            bool exists = false;
            for(int j = 0; j < 10; j++){
                if(mostCommon[j] == tempWord) { exists = true; }
            }
            if(exists){ continue; }
            for(int i = 0; i < 10; i++){
                if(mostCommon[i] == ""){
                    mostCommon[i] = tempWord;
                    break;
                }
                else if( bible.get(tempWord) <= bible.get(mostCommon[i])){ continue; }
                else {
                    string temp = mostCommon[i];
                    mostCommon[i] = tempWord;
                    tempWord = temp;
                }
            }
        }
    }

    cout << "begat appears " << bible.get("begat") << " times in the bible." << endl;

    cout << endl << "The number of distinct words in the bible is: " << bible.size()
         << endl << endl;

    cout << "The most 10 common words in the bible are: " << endl;
    for(int i = 0; i < 10; i++){
        cout << mostCommon[i] << endl;
    }
    cout << endl;

    return 0;
}
