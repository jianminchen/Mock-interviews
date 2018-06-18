using System;

// https://slimdx.org/
// https://github.com/WCell/WCell
// https://codereview.stackexchange.com/users/123986/jianmin-chen
// coding style - Nov. 2016 - reputation - 
// https://www.hackerrank.com/jianminchen_fl
class Solution
{
    public static int[] MeetingPlanner(int[,] slotsA, int[,] slotsB, int dur)
    {
        if (slotsA == null || slotsA.GetLength(0) < 1 || slotsA.GetLength(1) < 2 ||
           slotsB == null || slotsB.GetLength(0) < 1 || slotsB.GetLength(1) < 2 ||
           dur < 1)
        {
            return new int[0];
        }

        var lengthA = slotsA.GetLength(0); // 3
        var lengthB = slotsB.GetLength(0); // 2

        int indexA = 0;
        int indexB = 0;

        while (indexA < lengthA && indexB < lengthB)
        {
            // int[], startValue, endValue, 
            var overlapInterval = getIntervalOverlap(slotsA, slotsB, indexA, indexB);

            var start = overlapInterval[0];
            var end = overlapInterval[1];

            if (end - start >= dur)
            {
                return new int[] { start, start + dur };
            }
            else if (slotsA[indexA, 1] >= slotsB[indexB, 1])
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

    private static int[] getIntervalOverlap(int[,] slotsA, int[,] slotsB, int indexA, int indexB)
    {
        var maxStart = Math.Max(slotsA[indexA, 0], slotsB[indexB, 0]);
        var minEnd = Math.Min(slotsA[indexA, 1], slotsB[indexB, 1]);

        return new int[] { maxStart, minEnd };
    }

    static void Main(string[] args)
    {

    }
}

/*
series A - interval - not overlap, sorted by start time 

given two seriese, find first overlap matching given duration 8,  for example, [60, 68]

     10         50    60         120   140             210
     ____________     _____________    __________________

0      15             60    70
_______               _______




    10         50    
     ____________    

0      15             
_______              

max(start1, start2)
min(end1, end2)

advance the pointer with less end value 

try to avoid two many if statement. 4 cases

case 1: 
 ________________
     _________
     
case 2: 
    ________________
 __________________________
 
Time complexity: O(m + n), m, n is length of series
space: O(1)

*/