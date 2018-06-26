using System;

class HelloWorld
{
    static void Main()
    {
        DrawHTree(100, 100, 50, 2);
    }

    public static void DrawHTree(double x, double y, double length, int depth) // deppth = 1
    {
        // base case 
        if (depth == 0)
        {
            return;
        }

        // draw One H
        var halfLength = length / 2;

        var leftX = x - halfLength;
        var rightX = x + halfLength;

        var topY = y + halfLength;
        var bottomY = y - halfLength;

        drawLine(leftX, y, rightX, y);       // horizontal line
        drawLine(leftX, topY, leftX, bottomY);  // left vertical line
        drawLine(rightX, topY, rightX, bottomY); // rigth vertical line         


        // draw 4 H tree in four corners 
        // four corners start from left/ top, clockwise 
        var nextLength = length / Math.Sqrt(2);
        var nextDepth = depth - 1;

        DrawHTree(leftX, topY, nextLength, nextDepth);
        DrawHTree(rightX, topY, nextLength, nextDepth);
        DrawHTree(rightX, bottomY, nextLength, nextDepth);
        DrawHTree(leftX, bottomY, nextLength, nextDepth);
    }

    private static void drawLine(double x1, double y1, double x2, double y2)
    {
        Console.WriteLine(to3Decimal(x1) + "," + to3Decimal(y1) + " -" + to3Decimal(x2) + "," + to3Decimal(y2));
    }

    private static double to3Decimal(double x)
    {
        return (int)(x * 1000) / 1000.0;
    }
}
// 1.4  3 draw line - O(1)  
// 1 + 4 + 4^2 + ... + 4^n = 4^(n + 1) - 1/ 4 - 1 = O(4^n)
// space complexity  O(n)
/*

center value (x, y), length , depth 

First H, 






(x - length/2, y + length/2)              (x +length/2, y + length/2)    
|                                            |
|
|
|


                  (x, y)
-------------------|-------------------------- (x + length/2, y )
(x - length/2, y )





|
(x- length/2, y - length/2)
*/


