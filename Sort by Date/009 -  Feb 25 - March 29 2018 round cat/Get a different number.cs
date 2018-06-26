using System;

class Solution
{
    public static int GetDifferentNumber(int[] arr)
    {
        if (arr == null)
            return 0;

        var length = arr.Length;


        int index = 0;
        while (index < length)
        {
            var current = arr[index]; // 10 
            var isInRange = current < length; // false
            if (isInRange)
            {
                if (current == index)
                {
                    index++;
                }
                else
                {
                    // swap  index with current two position
                    var tmp = arr[index];
                    arr[index] = arr[current];
                    arr[current] = tmp;
                }
            }
            else
            {
                index++;
            }
        }

        // Try to find first element with value 0
        for (int i = 0; i < length; i++)
        {
            if (arr[i] != i) // found[0] = 0 
            {
                return i;
            }
        }

        return length;
    }

    static void Main(string[] args)
    {

    }
}

/*
[0, 2, 3, 4]  -> array size is 4
[2, 3, 0, 4] -> 
Try to find zero
[0, 3, 2, 4]
 -     - 
  
 [4, 3, 0, 2] -> 4 >= 4
 [0, 4, 2, 3] -> 
     - 
   */