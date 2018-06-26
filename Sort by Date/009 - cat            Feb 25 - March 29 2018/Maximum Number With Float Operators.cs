/* Given an array of strings, group anagrams together.

For example, given: ["eat", "tea", "tan", "ate", "nat", "bat"], 
Return:

[
  ["ate", "eat","tea"],
  ["nat","tan"],
  ["bat"]
]
*/

/* 
  
 if the words is short, then sort words first, all anagram will be same if it is sorted; add then to group based on sorted value
  
 word by char, maximum length M, sort n word, time complexity:  n * mlogm 
  
 if the words is long, then we can map each word to key ate   a1b0c0...t1e1 -> a1e1t1 -> key, sorted by alphabetic, group by same 
 interviewing.io -> it took me over, two cases, 


 Given a list of float numbers, and four operators +, -, *, / with flat preference, find the maximum value by inserting operator between each consecutive pair of numbers.

For example, given the array [1, 12, -3], the maximum number 33 can be found using 1 - 12 * (-3), since all operators have flat preference, so 1 - 12 * (-3) will be handled from left to right, first operation is 1 - 12 with value -11, and then second operation is -11 * (-3) = 33.
  
   1 + 2 * 3 = 1 + 6 = 7
   flat prefefence
    
   1 + 2 * 3 = 3 * 3 = 9 
  
   Brute force solution by the peer
   /*
    [1, 12, -3]
    1+12+(-3)
    1-12+(-3)
    1*12+(-3)
    .
    .
    .
    1/12/(-3)
    string max_expression;
    int max_number;
    vector<char> symbols {+, -, *, / }
    vector<string> {num1, , num2, , num3}
    for(int i = 0; i < 4; i++)
     for(int j = 0; j < 4; j++)
     {
       string exp = num1+symbol[i]+num2+symbol[j]+num3;
       if(eval(exp) > max_num)
         max_expression = exp;
     }
      
     O(n^4)
 
 
Julia's analysis 
     1 + 12 = 13
     1 - 12 = -11  ->  [1, 12, -3 ] -> first two number we kept minimum number 
     1 * 12 = 12
     1/ 12  = 1/12   -> 4 numbers for first two numbers, only keep max/ min - 2 numbers 
      
      
     and then 
      
     -3, 
     [13, -3]
     [-11, -3]
     [[12, -3]]
     [1/12, -3]
      
     16 numbers in total -> only two pairs -> 8 numbers -> only keep max/ min - 2 numbers
      
      
     4 + 8 + 8 + ... + 8 = O(8 * n) - linear - 
          
   */