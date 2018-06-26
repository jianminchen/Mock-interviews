using System;

class Solution
{
    public static int FindBusiestPeriod(int[,] data)
    {
        if (data == null || data.GetLength(0) == 0)
            return 0;

        var rows = data.GetLength(0);

        int maxIndex = 0;
        int maxNumber = 0;

        int currentNumber = 0;
        for (int row = 0; row < rows; row++)
        {
            int timeStamp = data[row, 0];
            int number = data[row, 1];
            int direction = data[row, 2];  // note: 1 - entrance

            currentNumber = direction == 1 ? (currentNumber + number) : (currentNumber - number);

            var finalState = row == (rows - 1) || timeStamp != data[row + 1, 0];
            if (finalState)
            {
                if (currentNumber > maxNumber)
                {
                    maxNumber = currentNumber;
                    maxIndex = row;
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
time stamp - multiple entries - 0, 1, 2, first three rows, one time stamp, 
1 -> entrance
0 -> exit
collect all 3 rows -> final state of time stamp -> 14 - 4 - 2 = 8 people left 
Each time stamp final state -> compare maximum number
Linear scan -> determine last row in the current time stamp -> next row, time stamp 
*/
