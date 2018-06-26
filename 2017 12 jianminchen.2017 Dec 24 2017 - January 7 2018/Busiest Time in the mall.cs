using System;

class Solution
{
    public static int FindBusiestPeriod(int[,] data) // 9 rows 
    {
        if (data == null || data.GetLength(0) == 0 || data.GetLength(1) == 0) // false 
        {
            return 0;
        }

        var rows = data.GetLength(0); // 9 
        int maxNumber = 0; // 0
        int maxIndex = 0; // 0

        int totalPeople = 0;
        for (int i = 0; i < rows; i++)
        {
            var direction = data[i, 2]; // 1, 0, 0,
            var number = data[i, 1]; // 14, 4, 2
            var timeStamp = data[i, 0]; // 425, 425, 425

            var entrance = direction == 1; // true, false, false  
            totalPeople = entrance ? (totalPeople + number) : (totalPeople - number); // 14, 14 - 4 = 10, 10 -2 = 8 

            var isLastRow = i == (rows - 1) || timeStamp != data[i + 1, 0]; // false , false , true
            if (isLastRow && totalPeople > maxNumber)
            {
                maxIndex = i; // 2
                maxNumber = totalPeople; // 8 
            }
        }

        return data[maxIndex, 0];
    }

    static void Main(string[] args)
    {

    }
}

// 0 - exit 1 - entrance 
//1487799425 425 - 3 rows - 
// +14 
// -4
// -2  - summarize - line 20  (index == lastRow || data[index + 1] != data[index]) - current 14 - 4 - 2 = 8 vs maxValue, 8 - index = 2
// once - maxValue - index
// return data[index, 0]
// time complexity O(n), space complexity O(1)