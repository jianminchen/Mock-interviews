
class HelloWorld
{
    static void Main()
    {
        System.Console.WriteLine("Practice makes Perfect!");
    }

    public static void DrawHTree(double x, double y, int depth, double length)
    {
        if (depth <= 0)
            return;

        // draw one H-Tree - draw 3 lines
        var half = length / 2;

        var leftX = x - half;
        var rightX = x + half;
        // Horizontal Line
        DrawLine(leftX, y, rightX, y);

        var topY = y + half;
        var bottomY = y - half;

        // Left Line
        // x1, Y1, X2, Y2
        DrawLine(leftX, topY, leftX, bottomY);

        // Right Line
        DrawLine(rightX, topY, rightX, bottomY);

        // Four recursive calls for four corners
        var nextLength = length / Math.Sqrt(2);
        var nextDepth = depth - 1;

        // go over four corners, LT, clockwise
        // LT
        DrawHTree(leftX, topY, nextDepth, nextLength);

        // RT
        DrawHTree(rightX, topY, nextDepth, nextLength);

        // RB
        DrawHTree(rightX, bottomY, nextDepth, nextLength);

        // LB
        DrawHTree(leftX, bottomY, nextDepth, nextLength);
    }

    private void DrawLine(double x, double y, double x2, double y2)
    {
        Console.Write();
    }
}

/*
given: center x, y, length, depth
Asking: H-tree

time complexity 
1 + 4 + 4 * 4 + ... = 4 ^(depth + 1)/ (4 -1)
*/