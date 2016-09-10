/** Derek Edwards
 *  C++ HashMap Implementation
 *  HashMap.cpp
 *  6/03/16
 */

#include "HashMap.h"
#include <cassert>
#include <algorithm>
#include <stdexcept>

///-----------------------------------------------------------------------------------///
///----constructor, copy constructor, destructor, assignment operator overload--------///
///-----------------------------------------------------------------------------------///

//constructor: takes size of table to use
HashMap::HashMap(int tableSize){
    m_tableSize = tableSize;
    setSize = 0;
    buckets = new list<PairType>[tableSize];
}

HashMap::~HashMap()
{
    for(int i = 0; i < m_tableSize; i++){
        for(std::list<PairType>::iterator it=buckets[i].begin(); it != buckets[i].end();){
            if(buckets[i].empty()) { return; }
            else {
                buckets[i].erase(it++);
                --setSize;
            }
        }
    }
    delete [] buckets;
}

//if(buckets[index].empty()) { return; }

//for(std::list<PairType>::iterator it=buckets[index].begin(); it != buckets[index].end(); ++it){
//    if(it->key == key){
//        buckets[index].erase(it++);
//        --setSize;
//        return;

HashMap::HashMap(const HashMap& other)
{
    //no copy constructor
    assert(0);
}

HashMap& HashMap::operator=(const HashMap& rhs)
{
    //no assignment operator
    assert(0);
}


///-----------------------------------------------------------------------------------///
///--------------------------------member functions-----------------------------------///
///-----------------------------------------------------------------------------------///

unsigned int HashMap::hashFunc(string key){
    hash<string> hasher;
    unsigned int index = hasher(key);
    return index %= m_tableSize;
}

//true if contains given key
bool HashMap::contains(std::string key){
    unsigned int index = hashFunc(key);

    if(buckets[index].empty()) { return false; }
    else {
        for(std::list<PairType>::iterator it=buckets[index].begin(); it != buckets[index].end(); ++it){
            if(it->key == key){
                return true;
            }
        }
    }
    return false;
}

//add given key/value pair - determine the bucket by hashing
//the key - overwrite any existing value for the key
void HashMap::insert(std::string key, int value){
    PairType curItem = PairType(key, value);
    unsigned int index = hashFunc(key);

    for(std::list<PairType>::iterator it=buckets[index].begin(); it != buckets[index].end(); ++it){
        if(it->key == key){
            it->value = value;
            return;
        }
    }
    buckets[index].push_back(curItem);
    ++setSize;

    if(setSize > 0.5 * m_tableSize)
        resize(m_tableSize * 2 + 1);
}

//Retrieves value associated with given key, else throw exception
int HashMap::get(std::string key){
    unsigned int index = hashFunc(key);
    if(buckets[index].empty()) { throw invalid_argument("Invalid key"); }

    for(std::list<PairType>::iterator it=buckets[index].begin(); it != buckets[index].end(); ++it){
        if(it->key == key)
            return it->value;
    }
    throw invalid_argument("Invalid key");
}


//remove pair associated with given key - do nothing if existing key
//is not there
void HashMap::remove(std::string key){
    unsigned int index = hashFunc(key);

    if(buckets[index].empty()) { return; }

    for(std::list<PairType>::iterator it=buckets[index].begin(); it != buckets[index].end(); ++it){
        if(it->key == key){
            buckets[index].erase(it++);
            --setSize;
            return;
        }
    }
}

//number of key/value pairs stored
int HashMap::size(){
    return setSize;
}

void HashMap::resize(int newSize) {
    //temp copies of old array and size
    std::list<PairType>* oldData = buckets;
    int oldSize = m_tableSize;

    //setup new storage
    m_tableSize = newSize;
    buckets = new list<PairType>[newSize];
    setSize = 0;

    //take value from old storage and rehash into new array
    for(int i = 0; i < oldSize; i++){
        for(std::list<PairType>::iterator it=oldData[i].begin(); it != oldData[i].end(); ++it){
            if(oldData[i].empty()) { continue; }
            else { this->insert(it->key, it->value); }
        }
    }

    //delete old storage
    delete [] oldData;
}

ostream& operator<<(ostream& os, const HashMap& theSet) {
    for(int i = 0; i < theSet.m_tableSize; i++) {
        os << i << ": ";
        if(theSet.buckets[i].empty())
            cout << endl;
        for(std::list<PairType>::iterator it=theSet.buckets[i].begin(); it != theSet.buckets[i].end(); ++it){
                cout << it->key << "/" << it->value << " ";
                if(it->key == theSet.buckets[i].back().key) { cout << endl; }
        }
    }
    cout << endl;
    return os;
}

void HashMap::printStorage(){
    cout << endl << "Printing Storage: " << endl;
    cout << *this;
}
