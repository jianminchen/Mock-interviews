using System;

class Solution
{
    public static int FindBusiestPeriod(int[,] data)
    {
        // your code goes here
        if (data.GetLength(0) == 0 || data.GetLength(1) == 0)
        {
            return -1;
        }

        var rows = data.GetLength(0);
        // var columns = data.GetLength(1); 

        var max = int.MinValue;
        var maxTimeStamp = -1;

        var sum = 0;

        for (int row = 0; row < rows; row++)  // 25, 2
        {
            var currentTime = data[row, 0]; // 25, 25, 78
            var number = data[row, 1];   // 14, 4, 2, 10 
            var direction = data[row, 2]; // 1, 0, 0 , 1

            var isEntrance = direction == 1; // true, false, false , true
            var isLastRow = row == rows - 1; // false, false , false , false
            //var startNewTime = currenttime != previousTimeStamp; // true

            sum = isEntrance ? (sum + number) : (sum - number); // true? 14  //update new time, 14 - 4= 10, 10 - 2 = 8 , 8 + 10 = 18

            var readyToCompare = isLastRow || data[row + 1, 0] != currentTime;  // false , false , true, true 

            if (readyToCompare) // false 
            {
                var currentIsBigger = sum > max; // 8
                if (currentIsBigger)
                {
                    max = sum; // 8 ....
                    maxTimeStamp = currentTime; // 25                    
                }
            }
        }

        return maxTimeStamp;
    }

    static void Main(string[] args)
    {

    }
}

// 25   14 1 -> 14 entrance, n   n + 14
// 25   4  0 -> 4 exit, n + 14 - 4
// 25   2  0 -> 2 exit, n + 14 - 4 - 2

// at 25 : + 8
// 78   78 != 25,  n + 14 - 4 -2 = n + 8 compared to max value int.MinValue, 

//+18 at 378