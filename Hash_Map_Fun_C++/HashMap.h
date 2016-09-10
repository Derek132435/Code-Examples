/** Derek Edwards
 *  C++ HashMap Declaration
 *  HashMap.h
 *  6/03/16
 */

#ifndef HASHMAP_H
#define HASHMAP_H

#include <string>
#include <list>
#include <iostream>

using namespace std;

struct PairType
{
    string key;
    int value;

    PairType(string p_key, int p_value) {
        key = p_key;
        value = p_value;
    }

    PairType() {
        key = "";
        value = 0;
    }
};

class HashMap
{
private:
    int m_tableSize;
    int setSize;
    std::list<PairType>* buckets;

    /**
     * @brief resize: reallocate new storage array when load factor
     * reaches 2 or more
     * @param newSize: Size of resized HashMap
     */
    void resize(int newSize);

    /**
     * @brief hashFunc: Hashes and returns given key
     * @param key: key to hash
     * @return : hashed key
     */
    unsigned int hashFunc(string key);

public:

    /**
     * @brief HashMap: constructor takes size of table to use
     * @param tableSize: size of table to use
     */
    HashMap(int tableSize);

    /**
     * @brief contains: true if contains given key
     * @param key: given key
     * @return true if contains key
     */
    bool contains(std::string key);

    /**
     * @brief insert: add given key/value pair - determine the bucket by hashing
     * the key - overwrite any existing value for the key
     * @param key : key to add
     * @param value : value to add
     */
    void insert(std::string key, int value);

    /**
     * @brief get: Retrieves value associated with given key, else throw exception
     * @param key: key to get the value of
     * @return value of key
     */
    int get(std::string key);

    /**
     * @brief remove: remove pair associated with given key - do nothing if existing key
     * is not there
     * @param key: key for pair to remove
     */
    void remove(std::string key);

    /**
     * @brief size: returns the number of key/value pairs stored
     * @return: number of key/value pairs stored
     */
    int size();

    /**
     * @brief printStorage: Prints all pairs in all lists sequentially
     */
    void printStorage();

    //Memory management
    ~HashMap();
    HashMap(const HashMap& other);
    HashMap& operator=(const HashMap& other);

    //Printing
    friend std::ostream& operator<<(std::ostream& os, const HashMap& theSet);

};

#endif // HASHMAP_H

