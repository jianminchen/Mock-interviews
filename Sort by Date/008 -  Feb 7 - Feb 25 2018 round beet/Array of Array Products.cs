using System;

class Solution
{
    public static int[] ArrayOfArrayProducts(int[] arr)
    {
        if (arr == null || arr.Length <= 1)
        {
            return new int[0];
        }

        int length = arr.Length;

        int leftProduct = 1;
        var product = new int[length];

        for (int i = 0; i < length; i++)
        {
            product[i] = leftProduct;
            leftProduct *= arr[i];
        }

        int rightProduct = 1;
        for (int i = length - 1; i >= 0; i--)
        {
            product[i] *= rightProduct;
            rightProduct *= arr[i];
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
Keyword: integer array, 
ask: product of all integers except itself on the index 

dynamic programming 
[8, 10, 2]
----------->
one multiplication 
value = 1, value = 8
product =  new int[] {1, value*8, value * 10} -> 2 multiplication 


<---------------------
each time I will two mutliplication

product[i] = product[i] * arr[i + 1]  - wrong
product[i] = product[i] * rightProduct - correct 

[1, 8, 80]

   rightProduct = 1, 
   rightProduct *= arr[i + 1]
[1 * 20 , 8 * 2, 80 * 1]

time complexity: O(n)
space complexity: O(n)

*/
