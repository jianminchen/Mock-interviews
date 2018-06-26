

/*
 * https://codereview.stackexchange.com/questions/186306/recursive-function-challenge
 * 
Question - not Sudoku :)

Q1: (Easy)
You are a professional robber planning to rob houses along a street. Each house has a certain amount of money
stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security 
system connected and it will automatically contact the police if two adjacent houses were broken into on 
the same night.

Given a list of non-negative integers representing the amount of money of each house, determine the maximum 
amount of money you can rob tonight without alerting the police.

For e.g.
[10] Ans 10
[10, 20
] Ans 20
[10, 20, 30]
T(0) = T
Brute Force: 
Looking of all the options
Time Complexity (2^(n/2))

Dynamic Programming:
S[i] = Max(H[i] + S[i+2], S[i + 1]);

S[i] = Max(H[i] + S[i-2], S[i-1]);

Time Complexity? O(n)
Space Complexity? O(n) // Constant space - Great Awesome


Q2: (Medium)
Extension:

After robbing those houses on that street, the thief has found himself a new place for his thievery 
so that he will not get too much attention. This time, all houses at this place are arranged in a circle. 
That means the first house is the neighbor of the last one. Meanwhile, the security system for these houses 
remain the same as for those in the previous street.

Given a list of non-negative integers representing the amount of money of each house, determine 
the maximum amount of money you can rob tonight without alerting the police.

Write your approach here:

[1, 2, 3, 4, 5]
               One loop of O(n), OneLoop of O(n)
return Max(1 +  MaxRob([3,4]),     MaxRob([2,3,4,5]));

return Max(H[0] + MaxRob(2, n-1), MaxRober(1, n))

Time complexity will be  O(n)
Space will be O(1)


Max(H[i] + S[i-2],                             S[i-1]);
      first one is selected                     normal
      
      last item in the array is not selected
*/


/*
Question: (hard)

Given a set of words (without duplicates), find all word squares you can build from them.

A sequence of words forms a valid word square if the kth row and column read the exact same string, where 0 ≤ k < max(numRows, numColumns).

For example, the word sequence ["ball","area","lead","lady"] forms a word square because each word reads the same both horizontally and vertically.
*/
/*

b a l l
a r e a
l e a d
l a d y


Example 2:

Input:
["area","lead","wall","lady","ball"]

Output:
[
  [ "wall", a, l, l 
    "area", ? arbitray char , e, a, 
    "lead", search by pref: "le"
    "lady"            "la", y can be arbitrary 
  ],
  [ "ball",
    "area",
    "lead",
    "lady"
  ]
]
 */
/*
DFS(int ans[], int r, Trie){

Find the prefix for the row r, based on the previous rows values
// Look for prefix in trie
  // foreach word of that prefix in Trie
  ans[row] = word
  // DFS(ans, r+1, Trie);

}
*/
/*
class Solution
{
    public int Rob(int[] nums) {
      // your code goes here
    }

    static void Main(string[] args)
    {

    }
}
*/
