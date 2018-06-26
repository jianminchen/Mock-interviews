using System;

class Solution
{
    public static int[] ArrayOfArrayProducts(int[] arr) // [8, 10, 2]
    {
        if (arr == null || arr.Length <= 1) // false
        {
            return new int[0];
        }

        int length = arr.Length; // 3
        var product = new int[length]; // 3

        var previousProduct = 1;      // 1 
        // first iteration from left to right 
        for (int i = 0; i < length; i++)  // [8,10,2] -> [1,8, 80]
        {
            product[i] = previousProduct;
            previousProduct *= arr[i]; // 8, 8 * 10
        }

        // second iteration from right to left
        previousProduct = 1;
        for (int i = length - 1; i >= 0; i--) // [8, 10, 2]
        {
            product[i] *= previousProduct;
            previousProduct *= arr[i]; // 2, 10 * 2
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

//[8, 10, 2] 
// right side 10 * 2, space complexity O()
//brute force n - 1, n -> O(n * n - 1) -> lower O(n)
// product[n]
// left -> right 1, 8, 8 * 10, 
// second, right -> left 
// [10 * product[i+1],2,1] -> O(n)
// [1, 8, 20] -> left to right 
// variable -> leftNeighborProduct 1, 2, 20
// [20, 2, 1] -> right to left 
// n -> 1 * 20, 8 * 2, 20 * 1,  space O(n), time complexity O(n)