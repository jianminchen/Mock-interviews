using System;

class Solution
{
    public class Node
    {
        public int cost;
        public Node[] children;
        //public Node parent;

        public Node(int val)
        {
            cost = val;
        }
    }

    public static int getCheapestCost(Node rootNode)
    {
        if (rootNode == null) // false 
        {
            return 0;
        }

        var rootValue = rootNode.cost;  // 0
        var children = rootNode.children; // 3

        // base case
        if (rootNode.children == null) // reach leaf node 4, 1, 10, 1, 5
        {
            return rootValue;
        }

        // recurrence 
        int minPathOfChildren = Int32.MaxValue;

        foreach (var child in children)
        {
            var currentPath = getCheapestCost(child);  // 9, 7, 7 

            minPathOfChildren = currentPath < minPathOfChildren ? currentPath : minPathOfChildren; // 7
        }

        return rootValue + minPathOfChildren; // 0 + 7

    }

    static void Main(string[] args)
    {
        Node root = new Node(0);

        Node node1 = new Node(5);
        Node node2 = new Node(3);
        Node node3 = new Node(6);

        Node node11 = new Node(5);
        Node node12 = new Node(4);

        Node node21 = new Node(7);
        Node node22 = new Node(5);

        Node node31 = new Node(6);
        Node node32 = new Node(7);


        root.children = new Node[3];
        root.children[0] = node1;
        root.children[1] = node2;
        root.children[2] = node3;

        root.children[0].children = new Node[2];
        root.children[1].children = new Node[2];
        root.children[2].children = new Node[2];

        root.children[0].children[0] = node11;
        root.children[0].children[1] = node12;

        root.children[1].children[0] = node21;
        root.children[1].children[1] = node22;

        root.children[2].children[0] = node31;
        root.children[2].children[1] = node32;

        Console.WriteLine(getCheapestCost(root));
    }
}

/*
Go over all the paths
0->5->4   9
0->3->2->1->1  7
0->3->0->10   13
0->6->1  7
0->6->5  11

Find minimum value 
total 5 paths, not path itself, need minimum sales path -> Math.min(9, 7, 13, 7, 11) -> minimum 7 

DFS search: 
depth first search -> recursive

Template: 
if the node is null
return 0

base case
if there is no child
return node.value

// have multiple child
minPath = Int.Max
foreach child
   fidnMinPath
   update minPath
   
return node.value + minPath   

recurrence formula

Write code 
*/
