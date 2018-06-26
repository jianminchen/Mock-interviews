using System;

class Solution
{
    public static int[] ArrayOfArrayProducts(int[] arr)  // [8, 10, 2]
    {
        if (arr == null || arr.Length <= 1) // false 
        {
            return new int[0];
        }

        var length = arr.Length; // 3

        int leftToRightProduct = 1;

        var product = new int[length];

        for (int index = 0; index < length; index++) // 0, 1, 2  (n - 1)
        {
            product[index] = leftToRightProduct; // 1
            leftToRightProduct *= arr[index]; // one multiplication, *8
        }

        var rightToLeftProduct = 1;

        for (int index = length - 1; index >= 0; index--) // 2 * n
        {
            product[index] *= rightToLeftProduct; // extra multiplication 
            rightToLeftProduct *= arr[index];     // one more multiplcation 
        }

        return product;
    }

    static void Main(string[] args)
    {
        var productOfArray = ArrayOfArrayProducts(new int[] { 8, 10, 2 });

        foreach (var item in productOfArray)
        {
            Console.WriteLine(item);
        }
    }
}


/*
division -> multiple n - 1
[8, 10, 2, 5]

[10 * 2 * 5, 8 * 2 * 5, 8 * 10 * 5, 8 * 10 * 2]  - one multiplication 
(n-1) * n = O(n^2) - brute force solution - time complexity 
O(n)
leftToRightProduct

[1, 8, 8 * 10, 8* 10 * 2], 
[1, 8 * leftToRightProduct[i -1], 10 * leftToRightProduct[i-1]] -> O(n) -> variable -> O(1)

rightToLeftProduct
[,,,  2 * rigthToLeftProduct[i +1], 1]
product[]

productArray

*/

