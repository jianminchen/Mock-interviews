using System;

class Solution
{
    public class Node
    {
        public int cost;
        public Node[] children;


        public Node(int value)
        {
            cost = value;
        }
    }

    public static int getCheapestCost(Node rootNode) // node 0 , 
    {
        // base case 
        if (rootNode == null) // false 
        {
            return 0;
        }

        var costRoot = rootNode.cost; // 0 
        int minimalPathCost = Int32.MaxValue;

        var hasNoChildren = rootNode.children == null || rootNode.children.Length == 0;

        if (hasNoChildren)
        {
            return costRoot;
        }

        foreach (var item in rootNode.children) // node 5, 3, 6, node 3
        {
            var current = getCheapestCost(item); // 9, 13, 7  
            var cost = costRoot + current; // 0 + 9 = 9, 13, 7
            minimalPathCost = cost < minimalPathCost ? cost : minimalPathCost; // 9, 9, 7 < 9
        }

        return minimalPathCost; // 7 
    }

    static void Main(string[] args)
    {
        Console.WriteLine("testing is  here");
        var root0 = new Node(0);
        var root5 = new Node(5);
        var root3 = new Node(3);
        var root6 = new Node(6);

        root0.children = new Node[] { root5, root3, root6 };

        var root4 = new Node(4);
        root5.children = new Node[] { root4 }; // path cost 9

        var root1 = new Node(1);
        root6.children = new Node[] { root1 }; // path cost 7

        var root10 = new Node(10);
        root3.children = new Node[] { root10 }; // path cost 13
        Console.WriteLine("testing is  here");
        Console.WriteLine("path cost is " + getCheapestCost(root0));
    }
}

// are you there?
// root 0 -> Math.Min(node 5's find mininum, node 3's find minimum, node 6's minimum)
// 7 - path cost 
// https://appear.in/nov14Julia?skipCamPrimer

