using System;

class Solution
{
    public class Node
    {
        public int cost;
        public Node[] children;
        //public Node parent;

        public Node(int value)
        {
            cost = value;
        }
    }

    public static int getCheapestCost(Node rootNode)
    {
        if (rootNode == null)
        {
            return 0;
        }

        var children = rootNode.children;
        var cost = rootNode.cost;

        // base case
        if (children == null || children.Length == 0)
        {
            return cost;
        }

        // inductive step 
        int minimumSalePath = int.MaxValue;

        foreach (var item in children)
        {
            var minimumCost = getCheapestCost(item);

            if (minimumCost < minimumSalePath)
                minimumSalePath = minimumCost;
        }

        return cost + minimumSalePath;

    }

    static void Main(string[] args)
    {
        var root0 = new Node(0);

        // level 2
        var root5B = new Node(5);
        var root3B = new Node(3);
        var root6B = new Node(6);
        root0.children = new Node[] { root5B, root3B, root6B };

        // level 3
        var root4C = new Node(4);
        var root2C = new Node(2);
        var root0C = new Node(0);
        var root1C = new Node(1);
        var root5C = new Node(5);

        root5B.children = new Node[] { root4C };
        root3B.children = new Node[] { root2C, root0C };
        root6B.children = new Node[] { root1C, root5C };

        //level 4
        var root1D = new Node(1);
        var root10D = new Node(10);

        root2C.children = new Node[] { root1D };
        root0C.children = new Node[] { root10D };
        // level 5
        var root1E = new Node(1);
        root1D.children = new Node[] { root1E };

        Console.WriteLine(getCheapestCost(root0));
    }
}

/*
DFS - recursive 

base case:
root == null, 0

root has no children, return root.Value

inductive step:

minimumValue
foreach child, get its minimum path cost, 
  compare minimumValue with child's minimum path sale
    
return root.Value + minimumValue

Time complexity: each node in the tree visit once, O(n), n is nodes of tree
Stack space - maximum depth of the tree O(n) - O(logn)
*/