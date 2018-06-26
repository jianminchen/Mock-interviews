using System;

class HelloWorld
{
    static void Main()
    {
        DrawHTree(1, 1, 2, 1);
    }
  
    public static void DrawHTree(double centerX, double centerY, double length, int depth)
    {
      // base case 
      if(depth == 0)
        return; 
      
      // draw one H-Tree - horizontal, left vertical, right vertical 
      var half = length/ 2; 
      var leftX  = centerX - half; 
      var rightX = centerX + half; 
      var topY    = centerY + half; 
      var bottomY = centerY - half; 
      
      drawLine(leftX, centerY, rightX, centerY); 
      drawLine(leftX, topY, leftX, bottomY); 
      drawLine(rightX, topY, rightX, bottomY);      
      
      // recursive call to draw 4 subtree on 4 corners, depth - 1, length / 1.414
      var nextLength = length/ 1.414; 
      var nextDepth  = depth - 1; 
      
      // start from left top corner, clockwise
      DrawHTree( leftX,  topY,    nextLength,  nextDepth);
      DrawHTree( rightX, topY,    nextLength,  nextDepth);
      DrawHTree( rightX, bottomY, nextLength,  nextDepth);
      DrawHTree( leftX,  bottomY, nextLength,  nextDepth);
    }
  
    private static void drawLine(double x1, double y1, double x2, double y2)
    {
      Console.WriteLine(x1 + "  " + y1 + "  "+ x2 + "  " + y2); 
    }
}


/*
keywords:

H-tree
length reduced by 1.414 = square root of 2 
depth = 1 - draw one tree 
depth = 2 - draw 4 small tree, on four corners
drawLine - two points 
given centerX, centerY, length, depth, start line is parallel to X-axis

Time complexity: 1 + 4 + 4 * 4 + ... = 1 + 4^(depth + 1)/ (4 - 1), O(4^depth) count of H tree 
Space complexity: use recursive - stack depth - depth of tree 
*/

        
            
  
