using System;

class Solution
{//[[1,10]], [[2,3],[5,7]]
    public static int[] MeetingPlanner(int[,] slotsA, int[,] slotsB, int dur)
    {
        int rowsA = slotsA.GetLength(0);
        int rowsB = slotsB.GetLength(0);

        int indexA = 0;
        int indexB = 0;

        while (indexA < rowsA && indexB < rowsB)
        {
            int startA = slotsA[indexA, 0];
            int endA = slotsA[indexA, 1];

            int startB = slotsB[indexB, 0];
            int endB = slotsB[indexB, 1];

            int overlapStart = Math.Max(startA, startB);
            int overlapEnd = Math.Min(endA, endB);

            int current = overlapEnd - overlapStart;

            bool hasOverlap = overlapEnd > overlapStart;

            Console.WriteLine("startA " + startA + " endA " + endA + " endB " + endB + " rowsB " + rowsB);

            if (hasOverlap && current >= dur)
            {
                return new int[] { overlapStart, overlapStart + dur };
            }
            else if (endA > endB)
            {
                indexB++;
            }
            else
            {
                indexA++;
            }
        }

        return new int[0];
    }

    static void Main(string[] args)
    {

    }
}
/*
Keywords:

intervals no overlap, start time is sorted ascending order

10        50  60     120   140      210
  _________   _________    __________  A
  
0   15       60   70
_____         _____ B  


  dur: 8 hours
  
  Time complexity: O(m + n), m  - 
  space complexity: O(1)

*/