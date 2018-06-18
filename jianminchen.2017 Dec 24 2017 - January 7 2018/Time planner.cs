using System;

class Solution
{
    public static int[] MeetingPlanner(int[,] slotsA, int[,] slotsB, int dur)  // 4, 3
    {
        if (slotsA == null || slotsA.GetLength(0) == 0 || slotsA.GetLength(1) < 2 || // false 
           slotsB == null || slotsB.GetLength(0) == 0 || slotsB.GetLength(1) < 2 || // false
           dur <= 0)
        {
            return new int[0];
        }

        int lengthA = slotsA.GetLength(0); // 4
        int lengthB = slotsB.GetLength(0); // 3

        int startA = 0;
        int startB = 0;

        while (startA < lengthA && startB < lengthB)
        {
            var intervalStart_A = slotsA[startA, 0]; // 10 
            var intervalEnd_A = slotsA[startA, 1]; // 50        

            var intervalStart_B = slotsB[startB, 0];  // 0 
            var intervalEnd_B = slotsB[startB, 1];  // 15

            var maxStart = Math.Max(intervalStart_A, intervalStart_B); // 10
            var minEnd = Math.Min(intervalEnd_A, intervalEnd_B); // 15

            var overlap = minEnd > maxStart; // true

            if (overlap && (minEnd - maxStart >= dur)) // 5 < 8 
            {
                return new int[] { maxStart, maxStart + dur };
            }

            // advance one of pointers
            if (intervalEnd_A > intervalEnd_B)
            {
                startB++; // 1
            }
            else
            {
                startA++;
            }
        }

        return new int[0];
    }

    static void Main(string[] args)
    {

    }
}

/*

slotsA

0    10    50    60      120    140   210 
      ______     _____________      ______

slotsB
        15           70
________         _____

overlap
overlapStart = max(slotsA[startB].start, slotsB[startB].start)
overlapEnd   = min(slotsB[startA].end,   slotsB[startB].end)

overlapEnd > overlapStart -> overlap 

   ________
 
 __________________
 
 duration > 8, [overlapStart, overlapStart + 8]
 interval with small end value -> startA or startB determined by end value, min value
 
 time complexity O(maximum(m,  n)) 

space complexity is O(1), a few variables
*/