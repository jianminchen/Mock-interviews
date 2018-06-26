using System;

class Solution
{
    public class Node
    {
        public int key;
        public Node left;
        public Node right;
        // public Node parent;

        public Node(int value)
        {
            key = value;
        }
    }

    public static int findLargestSmallerKey(Node rootNode, int num) // given num = 17
    {
        if (rootNode == null)
        {
            return -1;
        }

        int smallerValue = -1;

        var iterate = rootNode;
        while (iterate != null)
        {
            int key = iterate.key; // 20
            if (key < num) // false, 9 < 17
            {
                smallerValue = key; // 9, 12
                iterate = iterate.right; // node 12 , node 14
            }
            else
            {
                iterate = iterate.left; // node 9
            }
        }

        return smallerValue;
    }

    static void Main(string[] args)
    {
        var node20 = new Node(20);
        node20.left = new Node(9);
        node20.right = new Node(25);

        node20.left.left = new Node(5);
        node20.left.right = new Node(12);

        node20.left.right.left = new Node(11);
        node20.left.right.right = new Node(14);

        Console.WriteLine(findLargestSmallerKey(node20, 26));
    }
}
/*

5 9 11  12  14  20   25 
  
  <- 17, largest smaller BST key 
  14 < 17, but 20 > 17
  
                 |
  20 > 17, so 20 can not be the answer
  9 
  |
        12
        |
           |
           14
  Line 30  go left
  Line 32, go right
  Line 34, go right
  
  Go over the example: given the value 12 
   root node 20 > 12 -> left
             9 < 12 => right, 12 >= 12
             11 < 12, but 11 do not have right child 
             
   Time complexity: O(logn) -> O(n)
     
  given value 14, find larger smaller one is 12 
     
     */