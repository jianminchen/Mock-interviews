using System;

class Solution
{
    public class Node
    {
        public int cost;
        public Node[] children;
    }

    public static int getCheapestCost(Node rootNode) // 0
    {
        // your code goes here
        if (rootNode == null) //
        {
            return 0;
        }


        bool noChildren = rootNode.children == null || rootNode.children.Length == 0;
        var current = rootNode.cost; // 0

        // Console.WriteLine(current);
        if (noChildren)
        {
            return current;
        }
        var minSalesPath = Int32.MaxValue;

        foreach (var child in rootNode.children) // [5,3,6]
        {
            minSalesPath = Math.Min(minSalesPath, current + getCheapestCost(child)); //9. 7., 7, 
        }

        return minSalesPath; // 7
    }

    static void Main(string[] args)
    {
        var root = new Node();
        root.cost = 0;

        // left subtree
        var root5 = new Node();
        root5.cost = 5;

        var root4 = new Node();
        root4.cost = 4;
        root5.children = new Node[] { root4 };

        // right subtree
        var root6 = new Node();
        root6.cost = 6;

        var root5B = new Node();
        root5B.cost = 5;

        var root1 = new Node();
        root1.cost = 1;

        root6.children = new Node[] { root1, root5B };

        // 
        root.children = new Node[] { root5, root6 };
        //root.children = new Node[]{root5}; 

        Console.WriteLine(getCheapestCost(root));


    }
}
// 
// if(rootNode == null)  return 0; 
// base case: 
// bool noChildren = rootNode.children == null
// if noChildren
//    return rootNode.cost
// assuming that there are multiple children
// minSalePath = Int.MaxValue
// var current = rootNode.cost
// foreach(var child in rootNode.children)
//{
//      minSalePath = Math.min(minSalePath, current + getCheapestCost(child)
//}
// return minSalePath

