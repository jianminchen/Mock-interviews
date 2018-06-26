using System;

class Solution
{
    public static int FindBusiestPeriod(int[,] data)
    {
        if (data == null || data.GetLength(0) == 0 || data.GetLength(1) < 3)
        {
            return 0;
        }

        var rows = data.GetLength(0);


        int maxPeople = 0;
        int maxIndex = 0;

        int totalPeople = 0;
        for (int i = 0; i < rows; i++)
        {
            var timeStamp = data[i, 0];
            var number = data[i, 1];
            var direction = data[i, 2];

            totalPeople = direction == 1 ? (totalPeople + number) : (totalPeople - number);

            bool isLastEntry = i == (rows - 1) || timeStamp != data[i + 1, 0];

            if (isLastEntry)
            {
                if (totalPeople > maxPeople)
                {
                    maxPeople = totalPeople;
                    maxIndex = i;
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

Can plant flower - leetcode contest - 
48 minutes - 5 minutes 

http://juliachencoding.blogspot.ca/2018/01/are-you-ready-for-algorithm-and-data.html

*/