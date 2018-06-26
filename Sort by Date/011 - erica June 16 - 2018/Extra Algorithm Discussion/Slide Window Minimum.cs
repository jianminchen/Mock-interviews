using System;

public class Class1
{
	public Class1()
	{
	}

    /*
     [1, 2, 3, 4, 5, 6], given an integer, k is range 
new array with range sum.
 k = 3, 
1 + 2 + 3
  [6, 9, 12, 15]
  
 */
 /*
 The peer wrote a solution:

#include <iostream>
#include <string>

using namespace std;

std::vector<int> k_ranges(const std::vector<int> range, int k)
{  
  if (k > range.size()) {
    std::cout << "error" << std::endl;
    return {};    
  }

  std::vector<int> result;
  int initial = std::accumulate(range.begin(), range.begin() + k, 0);
  result.push_back(initial);
  
  for (int i = k; i < range.size(); ++i) {
    initial -= range[i - k];
    initial += range[k];
    result.push_back(initial);
  }
  
  return result;

Julia gave some feedback after the peer gave his thoughts. His first thought is to use minimum heap, 
and then we had some discussion about binary tree, find element in the binary tree time complexity. 
And then the peer said that let me think about if linear time complexity is possible or not. 

After a few minutes, he told me that it seems to him that the linear time complexity can be done based on
...

Julia then gave out her anlysis from the brute force solution first in the following:

  klogk * n sort k elements
  minimum of k element -> k n -> k comparison
  minimum heap  logk * n <- delete element from heap -> find element -> 
    -> delete 
    red-black tree - self balance tree data structure
    
    linear solution -> data structure, 

Please look up leetcode algorithm by google search:
maximum sliding window

     */
}
