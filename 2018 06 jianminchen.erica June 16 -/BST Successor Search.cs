using System;

class Solution
{
    public class Node
    {
        public int value;
        public Node left;
        public Node right;
        public Node parent;
    }

    public static Node findInOrderSuccessor(Node inputNode)
    {
        if (inputNode == null)
            return null;

        if (inputNode.right != null)
        {
            // find leftmost  node in right subtree
            return findLeftMostNode(inputNode.right);
        }
        else
        {
            var iterate = inputNode;
            while (iterate.parent != null && iterate.parent < inputNode.value)
            {
                iterate = iterate.parent;
            }

            return iterate.parent;
        }
    }

    private static Node findLeftMostNode(Node root)
    {
        var iterate = root;
        while (iterate.left != null)
            iterate = iterate.left;

        return iterate;
    }

    static void Main(string[] args)
    {
        // test findInOrderSuccessor here
    }
}

// keywords: BST, inorder successor, 
// given a node inputNode in a BST, asking: inorder successor
// in other words, bigger, smallest one in all bigger elements

// brute force, inorder traversal -> 5, 9, 11, 12, 14, 20, 25, given node 9, 
// search the array to find 9, next element - O(n)
// try to do O(logn), try to start from given node, back to root node or down 
// to leaf node, try to find successor
