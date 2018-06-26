using System;

class Solution
{
    public class Node
    {
        public int value;
        public Node left { get; set; }
        public Node right { get; set; }
        public Node parent { get; set; }

        public Node(int val)
        {
            value = val;
        }
    }

    public static Node findInOrderSuccessor(Node inputNode) // give 9, find 11; give 14, find 20
    {
        if (inputNode == null) // false , false 
        {
            return null;
        }

        var hasRightChild = inputNode.right != null; // true, false 
        if (hasRightChild)
        {
            // find minimum of right subtree
            var minimumNode = inputNode.right; // node 12
            while (minimumNode != null && minimumNode.left != null) // node 11
            {
                minimumNode = minimumNode.left; // node 11
            }

            return minimumNode; // return node 11
        }
        else
        {
            // check parent node
            var value = inputNode.value; // 14
            var current = inputNode; // node 14
            while (current != null || current.parent != null) // node 12 != null ; node20!= null 
            {
                if (current.parent.value > value) // 12 > 14, false , 9 > 14 false ; 20 > 14
                {
                    return current.parent;  // node 20
                }

                current = current.parent; // current = node 12, current = 9 
            }

            return null;
        }
    }

    static void Main(string[] args)
    {
        // test findInOrderSuccessor here
        var node20 = new Node(20);
        node20.left = new Node(9);
        node20.right = new Node(25);

        node20.left.parent = node20;
        node20.right.parent = node20;

        var node9 = node20.left;
        node9.right = new Node(12);


        var node12 = node9.right;
        node12.parent = node9;

        node12.left = new Node(11);
        node12.right = new Node(14);

        var node11 = node12.left;
        var node14 = node12.right;

        node11.parent = node12;
        node14.parent = node12;


        var node11Success = findInOrderSuccessor(node11);
        Console.WriteLine(node11Success.value);


        var node14Success = findInOrderSuccessor(node14);
        Console.WriteLine(node14Success.value);
    }
}

/*
      3
      
  root = Node(20)
  root.left = Node(9)
  root.rig
Give value 9 - find right substree minimum node
   12
   
 11    14 
 
 smallest number 11 BST successor 
 
 Give value 11, no right child 
 parent node -> 12 > 11, 12 may be the successor, go 
 
 
 Give value 14, no right child -> parent -> 12 < 14 -> it is not possible 
 -> 9 < 14 (no) -> 20 -> 20 > 14 -> 20 is the successor
 
 Give 25, -> 20 < 25 -> return null 
 
 
*/