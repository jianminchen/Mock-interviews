using System;

class Solution
{
    public class Node
    {
        public int key;
        public Node left;
        public Node right;
        public Node parent;

        public Node(int value)
        {
            key = value;
        }
    }

    public static int findLargestSmallerKey(Node rootNode, int num) // given 17, find 14 
    {
        if (rootNode == null)
        {
            return -1;
        }

        var largestSmallestValue = int.MinValue; // -1

        // line 24 -  31
        var currentNode = rootNode;

        while (currentNode != null)
        {
            if (currentNode.key < num)  // 20 > 14, false , true 
            {
                largestSmallestValue = currentNode.key;// 9 

                while (currentNode.right.key < num) // 12 < 14, 14 < 17  
                {
                    largestSmallestValue = currentNode.right.key; // 12, 14
                    currentNode = currentNode.right;          // node 12

                    if (currentNode == null || currentNode.right == null)  // bug: null pointer, the bug was found after mock interview, use visual studio debug
                        break;
                }

                return largestSmallestValue; // 
            }
            else
            {
                currentNode = currentNode.left; // node 9
            }
        }

        return largestSmallestValue;
    }

    static void Main(string[] args)
    {
        var node20 = new Node(20);
        var node9 = new Node(9);
        var node25 = new Node(25);

        node20.right = node25;
        node20.left = node9;

        var node12 = new Node(12);
        var node11 = new Node(11);
        var node14 = new Node(14);

        node9.right = node12;
        node12.right = node14;
        node12.left = node11;

        var node5 = new Node(5);
        node9.left = node5;

        Console.WriteLine(findLargestSmallerKey(node20, 17));
    }
}

