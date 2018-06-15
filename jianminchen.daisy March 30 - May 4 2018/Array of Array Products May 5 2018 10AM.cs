// https://www.linkedin.com/in/jianminchen
// https://codereview.stackexchange.com/users/123986/jianmin-chen
// https://www.hackerrank.com/jianminchen_fl
// https://codereview.stackexchange.com/questions/181046/four-sum-algorithm-mock-interview-practice
// https://codereview.stackexchange.com/a/193293/123986
// The art of readable code - 200 pages
// pluralsight.com clean code: write code for humans 
// clean code/ readable code -> contest
// work on tricks how to write simple code -> code is too complicated, variable name is confusing me/ 
// mental baggage -> simplify the code -> 50 minutes -> 
// julia code blog: 
// http://juliachencoding.blogspot.ca/ 
// Leetcode https://leetcode.com/problems/reverse-words-in-a-string/
// elements of programming interview -> 
// quora.com
// interviewing.io 

using System;

class Solution
{
    public
      static int[] ArrayOfArrayProducts(int[] arr)
    {
        if (arr == null || arr.Length <= 1)
        {
            return new int[0];
        }

        var length = arr.Length;

        var product = new int[length];

        // left to right iteration 
        var prefixProduct = 1;

        for (int index = 0; index < length; index++)
        {
            product[index] = prefixProduct;

            prefixProduct *= arr[index];
        }

        var suffixProduct = 1;
        for (int index = length - 1; index >= 0; index--)
        {
            product[index] = product[index] * suffixProduct;
            suffixProduct *= arr[index];
        }

        return product;
    }

    static void Main(string[] args)
    {
        var product = ArrayOfArrayProducts(new int[] { 8, 10, 2 });
        foreach (var item in product)
        {
            Console.WriteLine(item);
        }
    }
}
/*
keywords:

integer array, 
define a product except itself for each index i - for example:
[8, 10, 2]
defined product: [10 * 2, 8 * 2, 8 * 10]

ask: return array of products
Constraints: without using division 

analysis: 
two portion of product, prefixProduct, suffixProduct 
dynamic programming
two iterations:
first one is from left to right
each iteration one multiplication 

second iteration from right to left 

Time complexity: O(n)
space complexity: O(n) 
  
  */
//

