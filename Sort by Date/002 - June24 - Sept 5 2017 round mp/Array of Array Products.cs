using System;

class Solution
{
    // 8, 10, 2
    static int[] arrayOfArrayProducts(int[] arr)
    {
        // your code goes here
        if (arr == null || arr.Length == 0)
        {
            return new int[0];
        }

        int length = arr.Length; // 3
        var products = new int[length]; // 3

        // scan left to right, store left side products
        int product = 1;
        products[0] = 1;
        for (int i = 1; i < length; i++)// i = 2
        {
            var visit = arr[i - 1]; // 8, 10
            product *= visit; // 8, 80
            products[i] = product; // products[1] = 8 , products[2] = 80
        }

        // scan right to left, store right side products 
        product = 1;
        for (int i = length - 2; i >= 0; i--) // 1, 0
        {
            var visit = arr[i + 1]; // 2, 10
            product *= visit; // 2, 20
            products[i] *= product; // products[1] *= 2 = 16 , products[0] *= 20 = 20
        }

        return products; // 20, 16, 80
    }

    static void Main(string[] args)
    {
        var result = arrayOfArrayProducts(new int[] { 8, 10, 2 });
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
}
// dynamic 
// left -> right
// 1, 1 * 8, 1* 8 * 10, n size of array 
// right -> left
// product = 1 
// 1* 8 * 10 * 1
// 1 * 8 * 2
// product = 2 * 1
// 1 * 10 * product , n multiplication 
// O(2n) multiplication 
// space is O(n)
