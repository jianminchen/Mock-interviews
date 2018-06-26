using System;

class Solution
{
    public static int FindBusiestPeriod(int[,] data) // 
    {
        // your code goes here
        if (data == null || data.GetLength(0) == 0 ||
          data.GetLength(1) == 0)
        {
            return -1;
        }

        int rows = data.GetLength(0); // 9
        int columns = data.GetLength(1); // 3

        int maxNumber = 0;
        int maxNumberIndex = 0;
        int totalNumber = 0;
        for (int row = 0; row < rows; row++)
        {
            var currentTime = data[row, 0];
            var direction = data[row, 2];
            var currentNumber = data[row, 1]; // 4

            bool isEnter = direction == 1; // true
            bool isExit = direction == 0; // true

            bool checkMax = row == rows - 1 || currentTime != data[row + 1, 0];
            if (isEnter)
            {
                totalNumber += currentNumber; // 14
            }
            else if (isExit)
            {
                totalNumber -= currentNumber; // 10, 8
            }

            if (checkMax)  // true
            {
                if (totalNumber > maxNumber)
                {
                    maxNumber = totalNumber; // 8
                    maxNumberIndex = row; // 2
                }
            }
        }

        return data[maxNumberIndex, 0];
    }

    static void Main(string[] args)
    {

    }
}
// are you still there?
// connection get lost?
// 425, 14, 1,   1 entrance/ 0 exit 
// 425
// 425  -> 14 - 4 - 2= 8 // busiest time -> max value -> write down time stamp
// 378  + 10 max value = time stamp
// 
// 478 0 
// 013 1
// 1211 0 
// O(n)  space maxValue / maxValueIndex   O(1)
// iterate the array -> each iteration, index is last item in the time stamp -> i == length -1 || (i+1)  vs i difference
// bool checkMax
