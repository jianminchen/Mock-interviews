using System;

class Solution
{
    public static int[] ArrayOfArrayProducts(int[] arr)
    {
        if (arr == null || arr.Length < 2)
            return new int[0];

        var length = arr.Length;
        var product = new int[length];

        for (int i = 0; i < length; i++)
        {
            product[i] = 1;
        }

        var leftToRight = 1;
        // left to right, one multiplication 
        for (int i = 0; i < length; i++)
        {
            product[i] = leftToRight;

            leftToRight *= arr[i];
        }

        // right to left, two multiplication
        var rightToLeft = 1;
        for (int i = length - 1; i >= 0; i--)
        {
            product[i] *= rightToLeft;
            rightToLeft *= arr[i];
        }

        return product;
    }

    static void Main(string[] args)
    {

    }
}

/*
dynamic programming 

iteration -> left to right 
product[] 
for iteration
  one multiplication

product[0] = 1
8, 10, 2
   *8  *10
  
second iteration from right to left

for each iteration 
 two mulitiplcations
 product[i] *= arr[i + 1] - two mulitiplcations
*/