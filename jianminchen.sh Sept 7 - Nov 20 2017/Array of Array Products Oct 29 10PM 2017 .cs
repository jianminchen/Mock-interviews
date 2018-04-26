using System;

class Solution
{
    public static int[] ArrayOfArrayProducts(int[] arr)  // 8, 10, 2 
    {
        // your code goes here
        if (arr == null || arr.Length == 0 || arr.Length == 1)
        {
            return new int[0];
        }

        // assume that array is not empty
        var length = arr.Length;  // 3
        var products = new int[length];  // 3 

        var production = 1; // production 

        // iterate from left to right 
        for (int i = 0; i < length; i++)  // 8, 10, 2, visit index = 1, 10, 2
        {
            var previous = i - 1;
            var visit = i > 0 ? arr[previous] : 1; // 1, 8, 10

            production *= visit;
            products[i] = production; // products[0] = 1, 1 * 8, 8 * 10 -> new int[]{1, 8, 80}
        }

        // right side -> right -> left 
        production = 1;
        for (int i = length - 1; i >= 0; i--)  // 2, 10, 8    new int[]{1, 8, 80}  ->   new int[]{1 * 10 *2, 8 * 2, 80 * 1}
        {
            var previous = i + 1;
            var visit = i < length - 1 ? arr[previous] : 1; // 1, 2, 10 

            production *= visit;

            products[i] *= production;
        }

        return products;
    }

    static void Main(string[] args)
    {
        var test1 = ArrayOfArrayProducts(new int[] { 8, 10, 2 });
        foreach (var item in test1)
        {
            Console.WriteLine(item);
        }
    }
}

// juliachencoding.blogspot.ca
// https://www.linkedin.com/in/jianminchen/

// input:  arr = [8, 10, 2]
// output: [20, 16, 80] # by calculating: [10*2, 8*2, 8*10]

// input:  arr = [2, 7, 3, 4]
// output: [84, 24, 56, 42] # by calculating: [7*3*4, 2*3*4, 2*7*4, 2*7*3]

// [time limit] 5000ms

// 0 ≤ arr.length ≤ 20
// [8, 10, 2]
// 10 * 2  -> i, arr[0] * arr[1] * .. arr[i - 1]  (called part A) arr[i+1]*arr[i+2]....*arr[n-1]  (part B)
// dynamic programmer -> two iteration left -> right (part A)
// iteration right -> left (part B
// multiplcation in total -> redundant -> arr[0] * arr[1] -> multiplication -> *arr[2] -> O(n) + O(n)
// left -> right 
// product = 1 
// i = 0 -> i = 1 product *= arr[i -1] -> i=2 , product *= arr[i-1] ...
// right -> left 