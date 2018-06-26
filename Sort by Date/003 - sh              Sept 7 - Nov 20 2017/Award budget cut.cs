using System;
using System.Linq;

class Solution
{
    public static double FindGrantsCap(double[] grantsArray, double newBudget) // 2, 100, 50, 120, 1000
    {
        // your code goes here
        if (grantsArray == null || grantsArray.Length == 0 || grantsArray.Sum() < newBudget)
        {
            return -1;
        }

        Array.Sort(grantsArray);  // ascending order, 2, 50, 100, 120, 1000

        int length = grantsArray.Length; // 3

        // [2, 4, 6], budget = 3

        double cap = 0;
        double available = newBudget; // 3

        for (int i = 0; i < length; i++) // i = 0
        {
            double visit = grantsArray[i]; // 2

            bool needCut = visit * (length - i) > available; // 2 * 3 > 3 => true
            if (!needCut) // true, false
            {
                available -= visit;  // 188
            }
            else
            {
                Console.WriteLine("available " + available);
                Console.WriteLine("length - i " + (length - i));

                cap = (available * 1.0) / (double)(length - i); // 3 / (3 - 0) = 1
                break;
            }
        }

        return cap; // 47 
    }

    static void Main(string[] args)
    {
        Console.WriteLine(FindGrantsCap(new double[] { 2, 4, 6 }, 3));
    }
}

// asian 
// [2, 100, 50, 120, 1000]
// let us connect to this web page: let me find it in 20 seconds, 
// my internet is slow, but it is working 
//can you connect here? https://appear.in/jianminchen
// okay, you'll write me explain, without micro or video
// okay
// I can't hear you.. you have some problem with microphone and some delay with videochat
// [2, 100, 50, 120, 1000], newBudget 190

// [2, 47, 47, 47, 47]
// cap -> ascending order 2, 47, 2 + 47 * 4 = 190, 
// sort the array -> O(nlogn)
// start left, right
// left -> 2 * 5 = 10 < 190 , 
// 2, 50, 100, 120, 1000 -> 50 190 - 2 = 188 -> 50 * 4 > 188 
// 188/ 4 = 47 -> cap 
//time  O(nlogn) + O(n) => O(nlogn)
// space: O(1), newBudget -> 2, available , index 
// can I write code now? 
// [2, 3, 5, 7] and budget = 100
// sort the array [2, 3, 5, 7]
// smallest, arr.length = 4, 2 * 4 < 100 -> 2 is ok, no cut
// 98 -> /3 => 32 > 3, , 7 no need to cut -> [2, 3, 5, 7], 0 // 100, -> 17
// [2, 3, 5, 90], total sum of array = 17 < 100, no cut 
// only if  sum > budget, need to cut. 
// can you hear me now? sum > budget -> otherwise, no cut is need. 

