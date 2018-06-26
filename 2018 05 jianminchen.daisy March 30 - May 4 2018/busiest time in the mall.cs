using System;

class Solution
{
    public static int FindBusiestPeriod(int[,] data)
    {
        if (data == null || data.GetLength(0) == 0 || data.GetLength(1) < 3)
            return -1;

        var rows = data.GetLength(0);
        // var columns = data.GetLength(1); 

        var maxIndex = 0;
        var maxNumber = 0;
        var peopleInMall = 0;
        for (int row = 0; row < rows; row++)
        {
            var number = data[row, 1];
            var direction = data[row, 2];

            var enter = direction == 1;
            var isLastRowTimeStamp = row == (rows - 1) || data[row, 0] != data[row + 1, 0];

            peopleInMall = enter ? (peopleInMall + number) : (peopleInMall - number);

            if (isLastRowTimeStamp && peopleInMall > maxNumber)
            {
                maxIndex = row;
                maxNumber = peopleInMall;
            }
        }

        return data[maxIndex, 0];
    }

    static void Main(string[] args)
    {

    }
}

// iterate the array, check time stamp
// if time stamp is the last row of current time stamp, -> final number people in mall for the current time
// compare final time stamp row's number with max 
// return max 
// For example:
// row: 2, 14 - 4 - 2= 8 people -> 425
// row: 3, 8 + 10 = 18 -> 378   -> max 18
// row: 5, 18  = 18
// row 8: 
// 
