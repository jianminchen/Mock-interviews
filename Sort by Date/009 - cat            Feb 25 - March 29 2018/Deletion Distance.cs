using System;

class Solution
{
    public static int DeletionDistance(string str1, string str2)
    {
        if (str1 == null || str2 == null)
            return 0;

        var length1 = str1.Length; // "dog"
        var length2 = str2.Length; // "frog"

        var rows = length1 + 1;
        var columns = length2 + 1;

        var dist = new int[rows, columns];

        // base case
        for (int col = 0; col < columns; col++)
        {
            dist[0, col] = col;
        }

        for (int row = 0; row < rows; row++)
        {
            dist[row, 0] = row;
        }

        // set value row by row from top to bottom
        for (int row = 1; row < rows; row++)
        {
            for (int col = 1; col < columns; col++)
            {
                var rowChar = str1[row - 1];
                var colChar = str2[col - 1];

                var isEqual = rowChar == colChar;
                if (isEqual)
                {
                    dist[row, col] = dist[row - 1, col - 1];
                }
                else
                {
                    dist[row, col] = 1 + Math.Min(dist[row - 1, col], dist[row, col - 1]);
                }
            }
        }

        return dist[rows - 1, columns - 1];
    }

    static void Main(string[] args)
    {

    }
}

/*
dog,  frog 

1 + min(dist("og", "frog"), dist("dog","rog"))
  
  matrix to set up the space - int[length1 + 1, length2 + 1]
  
        "" "f"  "fr"  "fro"  "frog"
       -------------------------------
  ""|   0   1    2     3       4
  "d"   1   2    3     4       5 
  "do"  2   3    4     3       4
  "dog" 3   4    5     4       3
  
  
  dist("f","d") = 1 + Min(dis("","d"), dist("f","")
  
  */