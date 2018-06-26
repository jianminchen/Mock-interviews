using System;

class Solution
{
    public static int[] ArrayOfArrayProducts(int[] arr)
    {
        if (arr == null || arr.Length <= 1)
        {
            return new int[] { };
        }

        var productLeftToRight = 1;

        var length = arr.Length;

        var product = new int[length];

        // left to right
        for (int i = 0; i < length; i++)
        {
            product[i] = productLeftToRight;
            productLeftToRight *= arr[i];
        }

        // right to left
        var productRightToLeft = 1;
        for (int i = length - 1; i >= 0; i--)
        {
            product[i] *= productRightToLeft;
            productRightToLeft *= arr[i];
        }

        return product;
    }

    static void Main(string[] args)
    {
        var result = ArrayOfArrayProducts(new int[] { 8, 10, 2 });

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
}

// 20
// 1

// 5 10
// 10 5
/*
8 10 2
left to right
1
1 1*8, previous * 10
product
  
right to left 
  
two mulitiplication
  
product *=previous 
*/
//two mutiplication in each step 