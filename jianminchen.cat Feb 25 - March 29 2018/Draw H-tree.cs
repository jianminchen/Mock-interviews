// https://www.linkedin.com/in/jianminchen
// https://codereview.stackexchange.com/users/123986/jianmin-chen
// http://juliachencoding.blogspot.ca/
// journalling - practice - one game a time, one problem a time, one improvement a time 
// 30 algorithm, 170 - 
/*
http://juliachencoding.blogspot.ca/2018/01/are-you-ready-for-algorithm-and-data.html




interviewing.io - interviewer sign up - recording / replay / 
  interviewee/ interviewer - 3 - 160 mock interview - 

refdash.com

pramp.com - senior - 
  
  leetcode weekly contest
  hackerrank contest  - 20 contest
  online presence - write coding blog - show off - explanation - 10 -20 
  quora.com - write quora.com 
  stackoverflow.com
  code review - I ask 44 - , answer 8 - answer 10 questions - 
*/
class HelloWorld
{
    static int lines = 0; 
    static void Main()
    {
        DrawHTree(4, 0, 4, 2);
    }
  
    public static void DrawHTree(double centerX, double centerY, double length, int depth)
    {
      if(depth == 0)  
        return; 
      
      // Draw H tree - draw 3 line - horizontal, vertical left, right
      var half = length/ 2; 
      var leftX   = centerX - half;   // horizontal  leftX -------------rightX
      var rightX  = centerX + half; 
      var topY    = centerY + half;
      var bottomY = centerY - half; 
      
      DrawLine(leftX, centerY, rightX, centerY); // horizontal
      DrawLine(leftX, topY,    leftX,  bottomY); 
      DrawLine(rightX,topY,    rightX, bottomY); 
      
      // inductive step 
      var nextDepth = depth - 1; 
      var nextLength = length/ 1.4; 
      
      DrawHTree(leftX,  topY,    nextLength, nextDepth); 
      DrawHTree(rightX, topY,    nextLength, nextDepth); 
      DrawHTree(rightX, bottomY, nextLength, nextDepth); 
      DrawHTree(leftX,  bottomY, nextLength, nextDepth); 
    }
  
    private static void DrawLine(double x1, double y1, double x2, double y2)
    {
      lines++; 
      System.Console.WriteLine("Lines:"+lines + "  "+ x1 + ", " + y1 +" " + x2 + " " + y2);
    }
}

/*
Time complexity: 
1 + 4 + ... + 4^(n - 1) = O(4^n)
space complexity: stack depth O(depths)


H - tree
keywords:

double centerX, centerY, int depth, double length 

Draw H-tree

Base case:
if (depth == 0 )
  return
  
Draw H tree

// inductive step

DrawHTree() // left top corner, depth - 1, length/ sqrt(2)
DrawHTree()
DrawHTree()
DrawHTree()
  
  */
  