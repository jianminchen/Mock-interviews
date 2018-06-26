using System;

class HelloWorld
{
    static void Main()
    {
        DrawHtree(8, 0, 16, 3);
    }

    public static void DrawHtree(double centerX, double centerY, double length, double depth)
    {
        // base case
        if (depth == 0)
        {
            return;
        }

        // Draw one H-tree
        var half = length / 2;
        var leftEnd = centerX - half;
        var rightEnd = centerX + half;

        var topY = centerY + half;
        var bottomY = centerY - half;

        drawLine(leftEnd, centerY, rightEnd, centerY);
        drawLine(leftEnd, topY, leftEnd, bottomY);
        drawLine(rightEnd, topY, rightEnd, bottomY);

        // inductive step 
        var nextLength = length / Math.Sqrt(2);
        var nextDepth = depth - 1;

        DrawHtree(leftEnd, topY, nextLength, nextDepth);  // left top
        DrawHtree(rightEnd, topY, nextLength, nextDepth);  // right top
        DrawHtree(rightEnd, bottomY, nextLength, nextDepth);  // right bottom
        DrawHtree(leftEnd, bottomY, nextLength, nextDepth);  // left bottom
    }

    private static void drawLine(double x1, double y1, double x2, double y2)
    {
        Console.WriteLine(x1 + "," + y1 + " to " + x2 + "," + y2);
    }

    private static double toOneDecimal(double x)
    {
        return (int)(x * 10) / 10.0;
    }
}

/*

  H- tree
  
  given depth, center point of H-tree, length of line 
  Draw H-tree
  
  Recursive 
  
  Base case:

depth = 0 
  return 
 
// draw one H-tree
  center point -> calculate six end points for 3 lines 
  draw 3 lines
  
  centerX, centerY  - leftEnd, rightEnd centerX - half, centerX + half -> half = length/ 2         
  
  inductive step:
  DrawHTree()  // center to H-tree four corners, left-top, nextLength = length/ Math.sqrt(2)
  DrawHTree()
  DrawHTree()
  DrawHTree()
  
  */