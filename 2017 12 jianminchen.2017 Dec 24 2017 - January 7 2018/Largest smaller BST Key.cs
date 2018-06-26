using System;

class Solution
{
    public class Node
    {
        public int key;
        public Node left;
        public Node right;
        //   public Node parent;

        public Node(int number)
        {
            key = number;
        }
    }

    public static int findLargestSmallerKey(Node rootNode, int num)  // 17, 14
    {
        if (rootNode == null) // false 
        {
            return -1;
        }

        int largestSmaller = num; //  - 1, 17 

        var iterate = rootNode;
        while (iterate != null)
        {
            if (iterate.key >= num) // 20 > 17
            {
                iterate = iterate.left; // 9 
            }
            else
            {
                largestSmaller = iterate.key;  // 9 12, 14
                iterate = iterate.right; // 12, 14, null 
            }
        }

        return largestSmaller == num ? -1 : largestSmaller;
    }

    static void Main(string[] args)
    {
        // level 0 
        var node20 = new Node(20);

        // level 1
        var node9 = new Node(9);
        var node25 = new Node(25);

        // level 0 -> level 1
        node20.left = node9;
        node20.right = node25;

        // level 2
        var node5 = new Node(5);
        var node12 = new Node(12);

        // level 1 to leve 2
        node9.left = node5;
        node9.right = node12;

        var node11 = new Node(11);
        var node14 = new Node(14);

        node12.left = node11;
        node12.right = node14;

        Console.WriteLine(findLargestSmallerKey(node20, 3));

    }
}

/*

5 9 11 12 14  20 25 -> 

17 -> 14

21 -> 20
20 -> 14

    20
    
 9      
      14
      
   10  
   
       12
       
    11
    
given the number 12, find smallest number -> 11

20 vs 12
left -> 9 < 12 ( 9)
            14  (12)
        10 < 12 (9, 10 replaces 9)
        12 >= 12
        11 < 12 ( 11 is largest)
        terminate 
        
        9, 10, 11 -> left 3 time -> < 12 

*/
