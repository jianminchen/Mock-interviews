using System;

class Solution
{
    public static int FindBusiestPeriod(int[,] data)
    {
        if (data == null || data.GetLength(0) == 0 || data.GetLength(1) < 3)
            return -1;

        var rows = data.GetLength(0);

        int maximumNo = 0;
        int indexForMax = -1;

        int total = 0;
        for (int row = 0; row < rows; row++)
        {
            var currentNo = data[row, 1];
            var direction = data[row, 2];

            var isEnter = direction == 1;

            total = isEnter ? (total + currentNo) : (total - currentNo);

            // end of current time 
            if (row == rows - 1 || data[row + 1, 0] != data[row, 0])
            {
                var isBigger = total > maximumNo;
                maximumNo = isBigger ? total : maximumNo;
                if (isBigger)
                    indexForMax = row;
            }
        }

        return data[indexForMax, 0];
    }

    static void Main(string[] args)
    {

    }
}

/*
notes:  data, 
time stamp, count of visitors, entered 1 0 exit
array is sorted, ascending order by timestamp 
asking: busiest time in the mall, return earliest time

Best time complexity: O(n)
maximumNo - 
timeStamp - 
  425 - 14, 1 , +14, -4, -2 => 8 people -> maximumNo -> update maximumNo -> three rows -> one summary calculation
  428 - 
  
  */