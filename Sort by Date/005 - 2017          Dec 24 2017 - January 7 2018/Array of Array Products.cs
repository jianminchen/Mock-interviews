using System;

class Solution
{
    public static int[] ArrayOfArrayProducts(int[] arr)  // [1, 2, 3, 4, 5]
    {
        if (arr == null || arr.Length <= 1) // false 
        {
            return new int[0];
        }

        var length = arr.Length; // 5
        var product = new int[length];

        int leftToRight = 1; // 1, 1, 2, 2* 3, 2* 3 * 4
        for (int i = 0; i < length; i++) // 0 , 1, 2, 3, 4
        {
            product[i] = leftToRight; // 1, 1, 1,
            leftToRight *= arr[i]; // 1, 1 
        }

        int rightToLeft = 1;
        for (int i = length - 1; i >= 0; i--)
        {
            product[i] *= rightToLeft;
            rightToLeft *= arr[i];
        }

        return product;
    }

    static void Main(string[] args)
    {
        var product = ArrayOfArrayProducts(new int[] { 8, 10, 2 });
        foreach (var number in product)
        {
            Console.WriteLine(number);
        }
    }
}

/*

[8, 10, 2]

10 * 2, 8 * 2, 8 * 10 

array with 100 elements 

[1, 2, 3, 4, 5, 6, 7, 8 ,9, 10]

product[8] = 1 * 2 * 3 * 4 * 5 * 6 * 7 * 8 -> 
product[7] = 1 * 2 * 3 * 4 * 5 * 6 * 7 

build dynamic programming 
LeftToRight[0] = 1
LeftToRight[i] = LeftToRight[i - 1] * arr[i - 1];  i > 0 -> save the space -> 
count of multiplication is O(n), otherwise O(n^2)


RightToLeft[len - i]

time complexity : O(n)  multiplication 

O(n)
*/