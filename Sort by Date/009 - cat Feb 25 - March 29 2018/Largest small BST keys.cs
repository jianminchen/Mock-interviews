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

    public static int findLargestSmallerKey(Node rootNode, int num)
    {
        if (rootNode == null)
            return -1; // assuming node >= 0 

        var visit = rootNode;
        int smaller = -1;

        while (visit != null)
        {
            var current = visit.key;

            if (current < num)
            {
                smaller = current;
                visit = visit.right;
            }
            else
            {
                visit = visit.left;
            }
        }

        return smaller;
    }

    static void Main(string[] args)
    {
        var root20 = new Node(20);
        var root9 = new Node(9);
        var root25 = new Node(25);
        root20.left = root9;
        root20.right = root25;

        var root12 = new Node(12);
        var root11 = new Node(11);
        var root14 = new Node(14);

        root9.right = root12;
        root12.left = root11;
        root12.right = root14;

        // 4, 17, 13, 30 
        var result = findLargestSmallerKey(root20, 4);

        Console.WriteLine(result);

    }

}

/*
Brute force solution, inorder traversal - BST 
5 9 11 13 14 20 25, given num, find the position , largest smallest, given 17, 14 largest smaller 

in order traversal time complexity: O(n)
  
  optimal time complexity: O(logn)
    
  17, root 20, 17 < 20 
5 9 11 12 14 20 25
  <----------->
       <-------  
           <-- 14 
    
 given 12, find 11
    
       left edge value is smaller value, but in ascending order
       
       
    given number is 12
    
    while(visit != null)
    {
      var value = visit.val;
      if(value < num)
      {
        largestSmaller = value; // increasing 
        visit = visit.right; 
      }
      else 
      {
        visit = visit.left; 
      }
    }
*/
// so the answer may not be the leaf node, but the termination of loop has to be the leaf node