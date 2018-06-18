using System;

class Solution
{
    public class Node
    {
        public int Cost { get; set; }
        public Node[] Children { get; set; }
        // public Node parent;     

        public Node(int number)
        {
            Cost = number;
        }
    }

    public static int getCheapestCost(Node rootNode) // node with 0
    {
        if (rootNode == null) // false 
        {
            return 0;
        }

        var rootValue = rootNode.Cost;

        // base case 
        if (rootNode.Children == null) // on the leaves of tree, true 
        {
            return rootValue;
        }

        var cheapestValue = Int32.MaxValue;

        foreach (var item in rootNode.Children) // node with 5, with 3, with 6
        {
            var childPath = getCheapestCost(item); // 9, 13, 7
            cheapestValue = childPath < cheapestValue ? childPath : cheapestValue; // 9, 7
        }

        return rootValue + cheapestValue; // 0 + 7 = 7
    }

    static void Main(string[] args)
    {
        var node0 = new Node(0);

        // from left to right 
        var node5 = new Node(5);
        var node3 = new Node(3);
        var node6 = new Node(6);

        var node4 = new Node(4);
        var node02 = new Node(0);
        var node10 = new Node(10);

        var nodeSecond1 = new Node(1);
        var nodeSecond5 = new Node(5);

        // second level 
        node0.Children = new Node[] { node5, node3, node6 };

        // third level 
        node5.Children = new Node[] { node4 };
        node3.Children = new Node[] { node02 };

        node6.Children = new Node[] { nodeSecond1, nodeSecond5 };

        // fourth level 
        node02.Children = new Node[] { node10 };

        Console.WriteLine(getCheapestCost(node0));  //0+5+4, 0+3+0+10, 0+6+1, 0+6+5   
    }
}
/*
time complexity O(n) - n is total nodes in the tree
space complexity is O(n)-O(1)

*/
