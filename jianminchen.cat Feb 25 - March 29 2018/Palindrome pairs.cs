/*
    Hard level 
     Given a list of unique words, find all pairs of distinct indices (i, j) in the given list, so that the concatenation of the two words, i.e. words[i] + words[j] is a palindrome.

Example 1:
Given words = ["bat", "tab", "cat"]
Return [[0, 1], [1, 0]]
The palindromes are ["battab", "tabbat"]

Example 2:
Given words = ["abcd", "dcba", "lls", "s", "sssll"]
Return [[0, 1], [1, 0], [3, 2], [2, 4]]
The palindromes are ["dcbaabcd", "abcddcba", "slls", "llssssll"]
https://leetcode.com/problems/palindrome-pairs/description/
Freddie Mac - Second Round - Full Time
    */
/*
    
    battab -> [0, 1]
    taabbat -> [1, 0]
    
    keywords:  unique words, 
  ask: indices (i, j), words[i] + words[j] is palindrome
  
  Brute force: n - length of words array  n * (n - 1) - > O(N^2) - pair to check, but each word we need to spend time to check if palindrome
  O(n) -> even/ odd -> center -> move to two end and check if it is palindrome
  
  -> sort the array
  
  [bat, cat, tab] -O(nlogn)  save
  -> original index -> 
    
    if two words are palindrome -> length is same, then we know that it should be reverse of the word 
    
    example 2: [0, 1] -> reverse two words
    
    [3, 2]  -> 3, 1 -> lls -> s  palindrome  lls -> s 
    lls   3, 4 sssll -> we can tell -> short one -> reverse sll -> it is substring of the another one -> remove substring, left over is palindrome ss -> 
      
      sll -> sssll 
      
      Trie -> reduce time complexity - check prefix/ suffix 
      
      Count triangles; 


      Given an array of positive integers, return the number of triangles that can be formed 
with three different array elements as three sides of triangles. 
For example, if the input array is {4, 6, 3, 7}, the output should be 3. 
There are three triangles possible {3, 4, 6}, {4, 6, 7} and {3, 6, 7}. 
Note that {3, 4, 7} is not a possible triangle.

  sideA < sideB + sideC
    combinations: 4C3
   if all permutation of selection meets requirement: counter++;
  I cannot hear you. 
    
    medium level - triangle 
---------------------------------
 * 
 */