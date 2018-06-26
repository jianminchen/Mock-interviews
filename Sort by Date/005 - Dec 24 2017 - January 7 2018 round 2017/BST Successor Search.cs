using System;

class Solution
{
    public class Node
    {
        public int value;
        public Node left;
        public Node right;
        public Node parent;   // definition
    }

    public static Node findInOrderSuccessor(Node inputNode) // given 9 find 11 , given 14, find 20 
    {
        if (inputNode == null) // false, false 
        {
            return null;
        }

        var hasRightChild = inputNode.right != null; // true
        if (hasRightChild)
        {
            return findMinimumTree(inputNode.right); //
        }
        else
        {
            return findFirstParentBiggerThanGiveNodeValue(inputNode); // 
        }
    }

    private static Node findMinimumTree(Node root) // node 12
    {
        if (root.left == null) // false , true 
        {
            return root; // node 11
        }

        return findMinimumTree(root.left); // node11
    }

    private static Node findFirstParentBiggerThanGiveNodeValue(Node givenNode) // node14
    {
        int value = givenNode.value; // 14 

        Node search = givenNode; // node14

        while (search.parent != null && search.parent.value < value) // 12 < 14, 9 < 14 , 9's 20 > 14 
        {
            search = search.parent; // 14's 12
        }


        return search.parent != null && search.parent.value > value ? search.parent : null;
    }

    static void Main(string[] args)
    {
        // test findInOrderSuccessor here
    }
}


/*
give value 9 - 
right child, find smallest number in right subtree

if there is no right child, then go to parent -> continuously until the parrent node > given value, 12 < 14 => 9 < 14 => 20 > 14 

given value 5, successor is 9 


*/