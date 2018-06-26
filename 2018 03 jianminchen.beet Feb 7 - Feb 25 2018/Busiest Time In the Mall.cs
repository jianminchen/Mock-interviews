using System;

class Solution
{
    public static int FindBusiestPeriod(int[,] data)
    {
        if (data == null || data.GetLength(0) == 0) // false
            return 0;

        var rows = data.GetLength(0);

        var maxNumber = 0;
        var maxIndex = 0;

        var totalCount = 0;
        for (int index = 0; index < rows; index++)
        {
            var timeStamp = data[index, 0];
            var current = data[index, 1];
            var direction = data[index, 2];
            var exit = direction == 0;

            if (exit)
            {
                totalCount -= current;
            }
            else
            {
                totalCount += current;
            }

            var isLastRowCurrentTimeStamp = index == (rows - 1) || data[index + 1, 0] != timeStamp;
            if (isLastRowCurrentTimeStamp)
            {
                if (totalCount > maxNumber)
                {
                    maxNumber = totalCount;
                    maxIndex = index;
                }
            }
        }

        return data[maxIndex, 0];
    }

    static void Main(string[] args)
    {

    }
}

/*
ask busiest time 

0 - exit 1 entrance
time stamp -> ascending order

14 - get
 4 - exit
 2 - exit -  14 - 4 - 2 = 8 people 
 4 time stamps
 current time stamp - statistics - current time - people inside - maximum value previous - time stamp 
 Ask: time stamp 
 
 look ahead -> determine if the current row is the last row in the current time stamp 
 */