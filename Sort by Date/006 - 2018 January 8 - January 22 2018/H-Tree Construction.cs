using System;

class HelloWorld
{
    static void Main()
    {
        System.Console.WriteLine("Practice makes Perfect!");
        DrawHTree(2, 0, 4, 3);
    }

    public static void DrawHTree(double centerX, double centerY, double length, int depth) // 
    {
        // base case 
        if (depth == 0) // 3
        {
            return;
        }


        // draw one H - draw 3 lines, horizontal, left vertical, right vertical
        // horizontal
        var half = length / 2;

        var leftX = centerX - half;
        var rightX = centerX + half;

        var topY = centerY + half;
        var bottomY = centerY - half;

        drawLine(leftX, centerY, rightX, centerY); //horizontal
        drawLine(leftX, topY, leftX, bottomY); // left vertical
        drawLine(rightX, topY, rightX, bottomY); // left vertical



        // recursive call 4 times for 4 sub H trees
        var nextLength = length / Math.Sqrt(2);
        var nextDepth = depth - 1;

        DrawHTree(leftX, topY, nextLength, nextDepth); // left top
        DrawHTree(rightX, topY, nextLength, nextDepth); //right top
        DrawHTree(rightX, bottomY, nextLength, nextDepth); //right bottom
        DrawHTree(leftX, bottomY, nextLength, nextDepth); // left bottom

    }

    private static void drawLine(double x1, double y1, double x2, double y2)
    {
        Console.WriteLine("start:" + to2Decimal(x1) + "-" + to2Decimal(y1) + "to " + to2Decimal(x2) + "-" + to2Decimal(y2));
    }

    private static double to2Decimal(double x)
    {
        return (int)(x * 10) / 10.0;
    }
}




/*
constaints: 
length -> / sqrt(2) -> smaller of H tree size 
depth -> depth = 1 draw big tree H
         depth = 2 
           H tree -> 4 small H trees based on four corners of first H tree 
         depth = 3
           first two steps, one more 4 * 4 = 16 small H tree, 
     given information:      
  1. center is given (double x, double y)
  2. start length 
    3. depth is given int >= 0
  
  assume that drawLine(double x1, double y1, double x2, double y2) -  Console.WriteLine("start line ")
  
  H - horizontal line is parellel to the X-axis    
  
  Time complexity: 
     depth = 1, draw H tree, 3 lines, constant 
     depth = n,  1 + 4 + 4 ^2 + .. + 4^(n - 1) = 4^n / ( 4 - 1) = 
  space complexity: recursive n - 1 

   TL        TR
 
   -----------  x axis   0 4, center is (2, 0),  (0,0) ----------- (4, 0) 
   
   
   BL        BR
   
   TL (0, 2)  - centerX - length/2, centerY
   TR (4, 2)    centerX + length/2
   BR (4, -2)
   BL (0, -2)
   
*/