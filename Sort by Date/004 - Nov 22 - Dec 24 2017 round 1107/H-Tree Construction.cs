using System;

class HelloWorld
{
    static void Main()
    {
        DrawHTreeGivenDepthLength(2, 0, 3, 4);
    }

    public static void DrawHTreeGivenDepthLength(double x, double y, int depth, double length) // 2, 0, 3, 4
    {
        // base case
        if (depth == 0 || depth < 0) // false
        {
            return;
        }

        // draw h- tree 
        double half = length / 2; // 2
        double leftH = x - half;  // 0 
        double rigthH = x + half; // 4

        drawLine(x - half, y, x + half, y);  // horizontal line (0, 0, 4, 0)
        drawLine(leftH, y + half, leftH, y - half);  // left one vertical (0, 2, 0, -2)
        drawLine(rigthH, y + half, rigthH, y - half); // (2, 2, 2, -2 )

        // call 4 recursive calls for each corners 
        var nextLength = length / Math.Sqrt(2); // 2/ sqrt(2)
        var nextDepth = depth - 1;  // 2

        DrawHTreeGivenDepthLength(leftH, y + half, nextDepth, nextLength); // (0, 2)  LT
        DrawHTreeGivenDepthLength(leftH, y - half, nextDepth, nextLength); // (0, -2) LB
        DrawHTreeGivenDepthLength(rigthH, y - half, nextDepth, nextLength); // (2, -2) RB
        DrawHTreeGivenDepthLength(rigthH, y + half, nextDepth, nextLength); // (2, 2)  RT
    }

    private static void drawLine(double x1, double y1, double x2, double y2)
    {
        // (x1, y1) to (x2, y2)
        Console.WriteLine(x1 + " " + y1 + " " + x2 + " " + y2);
    }
}

// depth = 3
// H -> depth = 2, 4 trees -> 4* 4= 16 , tree 1 + 4 + 4 ^2 + .. + 4^(depth - 1) = (4^depth -1)/ 3
// 3 lines -> time complexity time O(4^depth)
// space -> stack -> depth space O(depth)

/*
from center -> (x, y ), depth, length 
(2, 0),  length 4

x1 (0, 2) x4(4, 2)

_________
0   2    4 -> x axis, y = 0 

x2        x3
(0, -2)  (4, -2), nextlength = length/ sqrt(2)

base case: three lines    0 - 4 y = 0 horizontal
   x1 -> x2, 
   x4 -> x3 
*/