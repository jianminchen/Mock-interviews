using System;

class Solution
{
    public static int FindBusiestPeriod(int[,] data) // only check first 7 rows 
    {
        if (data == null || data.GetLength(0) == 0 || data.GetLength(1) < 3) // false 
        {
            return -1;
        }

        var rows = data.GetLength(0); // 9 rows

        var maxNumber = 0;
        int timeStamp = 0;
        int totalNumber = 0;
        for (int row = 0; row < rows; row++) // row = 3
        {
            var time = data[row, 0]; // 1487799425, 1487800378 
            var number = data[row, 1]; // 4 , 4, 2
            var direction = data[row, 2]; // 1,  0, 0

            var isEntrance = direction == 1; // true, false , false 
            totalNumber = isEntrance ? (totalNumber + number) : (totalNumber - number); // 14, 14 - 4 = 10, 10 - 2= 8

            var isLastRowCurrentTimeStamp = row == rows - 1 || time < data[row + 1, 0]; // false , false , true
            if (isLastRowCurrentTimeStamp)
            {
                var currentIsBigger = totalNumber > maxNumber; // true
                if (currentIsBigger)
                {
                    maxNumber = totalNumber; // 8 
                    timeStamp = time; // 1487799425
                }
            }
        }

        return timeStamp;
    }

    static void Main(string[] args)
    {

    }
}
// I can scan the array, and record the maximum number of people in the mall
// for example, time stamp
// maximumPeople = 0 
// startNO = 0
// 1487799425  14, 1 - direction = 1 means enter the mall, 0 for exit + 14
// 1487799425   4, 0 - -4 => 14 - 4 = 10
// 1487799425, 2,  0 -  2 => 10 - 2 = 8 -> maxPeople = 8, time index = 1487799425
// check if it is time to compare to maximumPeople if row == rows - 1 || data[row + 1, 0] != data[row, 0]
// it is last row or next row with different time stamp , it is time to compare maxPeople, update time index 
// Are you following me? Can I write code? 
//  Yeah, sure 
