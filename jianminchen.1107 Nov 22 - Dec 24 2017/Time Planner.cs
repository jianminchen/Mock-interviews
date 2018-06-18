using System;

class Solution
{
    public static int[] MeetingPlanner(int[,] slotsA, int[,] slotsB, int dur) // dur =8
    {
        if (dur <= 0 || slotsA.GetLength(0) == 0 || slotsA.GetLength(1) != 2 ||
          slotsB.GetLength(0) == 0 || slotsB.GetLength(1) != 2) // false
        {
            return new int[] { };
        }

        var lengthA = slotsA.GetLength(0); // 3
        var lengthB = slotsB.GetLength(0); // 2

        int indexA = 0;
        int indexB = 0;

        while (indexA < lengthA && indexB < lengthB) // 
        {
            var visitStartA = slotsA[indexA, 0]; //10
            var visitStartB = slotsB[indexB, 0]; // 0 

            var visitEndA = slotsA[indexA, 1]; // 50
            var visitEndB = slotsB[indexB, 1]; // 15

            var maxStart = Math.Max(visitStartA, visitStartB); // 50
            var minEnd = Math.Min(visitEndA, visitEndB); // 15

            var hasOverlap = maxStart < minEnd; // 10 < 15 - true
            if (hasOverlap)
            {
                var intervalLength = minEnd - maxStart; // 5
                if (intervalLength >= dur) // false 
                {
                    return new int[] { maxStart, maxStart + dur };
                }
                else
                {
                    // move one slot further 
                    if (visitEndA < visitEndB) // 
                    {
                        indexA++;
                    }
                    else
                    {
                        indexB++; // 1
                    }
                }
            }
        }

        return new int[0];
    }

    static void Main(string[] args)
    {

    }
}

/*
0   10     50    60       120   140       210
-----------------------------------------------------------------------------------
    <------>     <--------->    <---------->
<------>         <--->
___________________________________________________________________________________
       15            70
       [60, 68]
       
 overlap -> [max(start1, start2), min(end1, end2)], interval 
 ----
       ______  no overlap 
       first check if there is overlap
       there is interval 
       _______          _____
       ________________________
       
       move the interval with smaller end time 
       
       time complexity - O(m + n)  
       space complexity  - O(1)
       
*/