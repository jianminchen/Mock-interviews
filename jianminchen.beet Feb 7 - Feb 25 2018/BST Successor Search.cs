using System;

class Solution
{
    public class Node
    {
        public int value;
        public Node left;
        public Node right;
        public Node parent;

        public Node(int number)
        {
            value = number;
        }
    }

    public static Node findInOrderSuccessor(Node inputNode)
    {
        if (inputNode == null)
        {
            return null;
        }

        if (inputNode.right != null)
        {
            // find leftmost child node 
            var leftmost = inputNode.right;
            while (leftmost.left != null)
            {
                leftmost = leftmost.left;
            }

            return leftmost; // smallest one in right subtree
        }
        else
        {
            var upward = inputNode.parent;
            while (upward != null && upward.value < inputNode.value)
            {
                upward = upward.parent;
            }

            return upward; // return null or node with value bigger than given value
        }
    }

    static void Main(string[] args)
    {
        var node20 = new Node(20);
        var node9 = new Node(9);
        var node25 = new Node(25);

        node20.left = node9;
        node20.right = node25;

        node9.parent = node20; // ok 
        node25.parent = node20;

        var node12 = new Node(12);
        node9.right = node12;

        node12.parent = node9; // ok 


        var node11 = new Node(11);
        node11.parent = node12;
        node12.left = node11;

        var node14 = new Node(14);
        node14.parent = node12;  // ok 
        node12.right = node14;

        var successor = findInOrderSuccessor(node14);
        Console.WriteLine("14's succcessor is " + successor.value);

        var successor2 = findInOrderSuccessor(node9);
        Console.WriteLine("9's succcessor is " + successor2.value);
    }
}


/*
5 9 11 12 14 20 25
  
  given input node 9, the successor is 11. 
  14, find 20 
  
  first check right subtree
  second check parent node, parent node
  */