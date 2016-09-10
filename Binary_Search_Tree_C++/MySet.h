/** Derek Edwards
 * Binary Search Tree Implementation
 * 5/16/16
 */

#ifndef MYSET_H
#define MYSET_H

#include <iostream>

using namespace std;

///-----------------------------BST NODE---------------------------------
template <class T>
struct BSTNode {
    T value;
    BSTNode<T>* left;
    BSTNode<T>* right;

    /**
     * @brief BSTNode: 2-arg constructor
     * @param val: value to store in node
     * @param theHeight: depth of node
     */
    BSTNode(T val) {
        value = val;
        left = nullptr;
        right = nullptr;
    }

    int depth();

};

template <class T>
int BSTNode<T>::depth() {
    if(this == nullptr){ return -1; }
    else { return 1 + max(left->depth(), right->depth()); }
}

///-----------------------------MySet BST---------------------------------
///----------------------------Declaration--------------------------------
template <class T>
class MySet {
private:
    BSTNode<T>* root;
    int numNodes;

public:

    //default ctor, destructor,copy ctor, overload assignment
    MySet();
    ~MySet();
    MySet(const MySet<T>& other);
    MySet& operator=(const MySet& other);

    /**
     * @brief add: insert a new node
     * @param item: value of new node
     */
    void add(T item);

    /**
     * @brief remove: remove a node
     * @param item: value of node to remove
     */
    void remove(T item);

    /**
     * @brief contains: recursive search function
     * @param item: value to search for
     * @return: true or false
     */
    bool contains(T item);

    /**
     * @brief extractLargest: find, remove, and return the largest value from
     * the tree
     * @return largest value in tree
     */
    T extractLargest();

    /**
     * @brief size: get-function for size
     * @return: size of tree
     */
    int size();

    /**
     * @brief depth: get-function for depth of the tree
     * @return : depth of the tree
     */
    int depth();

    //part 2
    MySet<T> unionWith(const MySet<T> &other) const;
    void unionWithHelper(BSTNode<T> *curNodeThis, BSTNode<T> *curNodeOther);

    void printFirst(int n);

    //debugging: print tree
    void print();
};

///----------------------------Implementation--------------------------------

/*-----------------constructor, destructor, assignment op-------------------*/
//default constructor
template <class T>
MySet<T>::MySet() {
    root = nullptr;
    numNodes = 0;
}

//Helper used by destructor and assignment operator
template <class T>
void deleteSubTree(BSTNode<T>* startNode) {
    if(startNode == nullptr)
        return;
    deleteSubTree(startNode->left);
    deleteSubTree(startNode->right);
    delete startNode;
}

//Helper used by copy ctor and assignment operator
template <class T>
BSTNode<T>* copySubTree(BSTNode<T>* currentNode) {
    //Copy current node into a new node of type BSTNode<char>
    //Recurively copy children and hook copies to new node
    //Return the new node
    if(currentNode == nullptr)
        return nullptr;
    BSTNode<T>* newNode = new BSTNode<T>(currentNode->value);
    newNode->left = copySubTree(currentNode->left);
    newNode->right = copySubTree(currentNode->right);
    return newNode;
}

//destructor
template <class T>
MySet<T>::~MySet() {
    deleteSubTree(root);
}

//copy constructor
template <class T>
MySet<T>::MySet(const MySet& other) {
    numNodes = other.numNodes;
    root = copySubTree(other.root);
}

//overloaded assignment operator
template <class T>
MySet<T>& MySet<T>::operator=(const MySet<T>& other) {
    if(this != &other) {
        //remove any existing nodes before
        //copying nodes of other tree
        deleteSubTree(root);
        numNodes = other.numNodes;
        root = copySubTree(other.root);
    }
    return *this;
}

/*---------------------------------Add--------------------------------------*/

template <class T>
BSTNode<T>* addHelper(BSTNode<T>* curNode, T insertVal) {
    if(curNode == nullptr){ return new BSTNode<T>(insertVal); }
    if(insertVal < curNode->value){
        curNode->left = addHelper(curNode->left, insertVal);
    } else {
        curNode->right = addHelper(curNode->right, insertVal);
    }
    return curNode;
}


template <class T>
void MySet<T>::add(T item) {
    if(root == nullptr){ root = new BSTNode<T>(item); }
    else if(contains(item)){ return; }
    else { root = addHelper(root, item); }
    ++numNodes;
}

/*-------------------------------Remove-----------------------------------*/

//Recursive helper function to remove smallest value starting from indicated node
template <class T>
BSTNode<T>* removeSmallestNode(BSTNode<T>* curNode){
    if(curNode->left == nullptr){
        BSTNode<T>* temp = curNode->right;
        delete curNode;
        return temp;
    }
    curNode->left = removeSmallestNode(curNode->left);
    return curNode;
}

//Recursive helper function to return smallest value starting from given node
template <class T>
T smallestValueFrom(BSTNode<T>* curNode)
{
    if(curNode->left == nullptr)
        return curNode->value;
    return smallestValueFrom(curNode->left);
}

///Helper function for remove - chains down, until it finds node to
/// remove. Removes that node and repairs pointers on way back up
template <class T>
BSTNode<T>* removeHelper(BSTNode<T>* curNode, T valToRemove) {
    if(curNode->value == valToRemove) {
        //Found node to remove
        if(curNode->right == nullptr) {
            //no right child, replace with left child
            BSTNode<T>* leftChild = curNode->left;
            delete curNode;
            return leftChild;   //this replaces the current node
        }
        else if(curNode->left == nullptr) {
            //no left child, replace with right child
            BSTNode<T>* rightChild = curNode->right;
            delete curNode;
            return rightChild;  //this replaces the current node
        }
        else {
            //Have two children, replace with smallest value from right hand side
            // then delete smallest node on right side
            curNode->value = smallestValueFrom(curNode->right);
            curNode->right = removeSmallestNode(curNode->right);

            //Return this node up the tree to hook to parent
            return curNode;
        }

    } else {
        //Keep looking, set child to result of removing from appropriate side
        if(curNode->value > valToRemove)
            curNode->left = removeHelper(curNode->left, valToRemove);
        else
            curNode->right = removeHelper(curNode->right, valToRemove);

        //Return this node up the tree to hook to parent
        return curNode;
    }
}

template <class T>
void MySet<T>::remove(T value) {
    //Check if actualy have it first to simplify removal logic
    if(!contains(value))
        return;

    //new root is root that results from doing removeHelper
    --numNodes;
    root = removeHelper(root, value);
}

/*------------------------MySet Member Functions----------------------------*/

//helper for recursive contains function
template <class T>
bool containsHelper(BSTNode<T>* curNode, T valToFind) {
    if(curNode == nullptr)
        return false;
    else if(curNode->value == valToFind)
        return true;
    else if(curNode->value > valToFind)
        return containsHelper(curNode->left, valToFind);
    else
        return containsHelper(curNode->right, valToFind);
}

//recursively find out if tree contains valToFind
template <class T>
bool MySet<T>::contains(T valToFind) {
    return containsHelper(root, valToFind);
}

//Recursive helper function to return largest value starting from given node
template <class T>
BSTNode<T>* largestValueFrom(BSTNode<T>* curNode)
{
    if(curNode->right == nullptr){
        return curNode;
    }
    curNode = curNode->right;
    return largestValueFrom(curNode);
}

//Recursive function to return largest value starting from given node
template <class T>
T MySet<T>::extractLargest() {
    if(root == nullptr){
        cout << "Error: Empty List";
        return 0;
    }
    BSTNode<T>* temp = largestValueFrom(root);
    T val = temp->value;
    remove(val);
    return val;
}

template <class T>
int MySet<T>::size() {
    return numNodes;
}

template <class T>
int depthHelper(BSTNode<T> *curNode) {
    if (!curNode) return 0;
    else { return 1 + max(depthHelper(curNode->left), depthHelper(curNode->right)); }
}

template <class T>
int MySet<T>::depth() {
    return depthHelper(this->root);
}

template <class T>
T unionHelperNode(BSTNode<T> *curNode){
    if(curNode == nullptr)
        return 0;
    else
        return curNode->value;
}

template <class T>
void MySet<T>::unionWithHelper(BSTNode<T> *curNodeThis, BSTNode<T> *curNodeOther){
    if(curNodeThis == nullptr || curNodeOther == nullptr){
        return;
    }
    unionWithHelper(curNodeThis->left, curNodeOther->left);
    add(unionHelperNode(curNodeThis));
    add(unionHelperNode(curNodeOther));
    unionWithHelper(curNodeThis->right, curNodeOther->right);
}

template <class T>
MySet<T> MySet<T>::unionWith(const MySet<T>& other) const{
    MySet<T> joined;
    joined.unionWithHelper(root, other.root);
    return joined;
}

template <class T>
void printFirstHelper(int n, int &counter, BSTNode<T> *curNode){
    if(curNode == nullptr){
        ++counter;
        return;
    }
    if(counter == 0 && curNode != nullptr){
    printFirstHelper(n, counter, curNode->left);
    }
    if(counter < n + 1){
        ++counter;
        cout << curNode->value << " ";
        if(curNode->right != nullptr)
            printFirstHelper(n, counter, curNode->right);
    }
}


template <class T>
void MySet<T>::printFirst(int n){
    int counter = 0;
    printFirstHelper(n, counter, root);
}

/*----------------------------Debugging--------------------------------*/

template <class T>
void printHelper(BSTNode<T>* curNode) {
    if(curNode == nullptr)
        return;

    printHelper(curNode->left);
    cout << curNode->value << " ";
    printHelper(curNode->right);
}

template <class T>
void MySet<T>::print() {
    printHelper(root);
    cout << endl;
}

#endif // MYSET_H
