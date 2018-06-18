
class HelloWorld
{
    static void Main()
    {
        System.Console.WriteLine("Practice makes Perfect!");
    }
  
    public static void DrawHTree(double centerX, double centerY, double width, int depth)
    {
      if(depth == 0)
      {
        return; 
      }
      
      // Draw one H tree, horizontal, left vertical, right vertical
      var half = width/ 2; 
      var leftX  = centerX - half;
      var rightX = centerX + half;
      
      var topY = centerY + half;
      var bottomY = centerY - half; 
      
      drawLine(leftX, centerY, rightX, centerY); 
      drawLine(leftX, topY,    leftX,  bottomY); 
      drawLine(rightX,topY,    rightX, bottomY); 
      
      // inductive step 
      var nextDepth = depth - 1; 
      var nextWidth = width/ Math.Sqrt(2); 
      
      // clockwise from top left, 
      
      DrawHTree(leftX,  topY,    nextWidth, nextDepth); 
      DrawHTree(rightX, topY,    nextWidth, nextDepth); 
      DrawHTree(rightX, bottomY, nextWidth, nextDepth); 
      DrawHTree(leftX,  bottomY, nextWidth, nextDepth); 
    }
  
    private void drawLine()
    {
    }
}


/*
Time complexity:
depth = n
1 + 4 + ... + 4 ^(n-1) = ( 1 + 4 ^(n))/ (4 - 1) = O(4^n)
  
Space complexity: O(n), n is depth 

Base case:

depth = 0
  return 
  
 Draw one H tree
 
 // inductive steps 
 nextDepth = depth = 1
 nextLenghtOfLine = lengthOfLine/ Math.sqrt(2)
  
  center four corners, draw recursively 4 small H-trees
  */
  