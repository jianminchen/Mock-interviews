using System;

class Solution
{
    public class Node
    {
        public int key;
        public Node left;
        public Node right;
        public Node parent;
    }

    public static int findLargestSmallerKey(Node rootNode, int num) // num = 17
    {
        if (rootNode == null)
            return -1;

        var iterate = rootNode;
        var largestOne = -1;
        while (iterate != null)
        {
            var current = iterate.key;  //20
            if (current < num) //
            {
                largestOne = current; // 9, 12
                iterate = iterate.right; // 12, 14
            }
            else
            {
                iterate = iterate.left; // node 9
            }
        }

        return largestOne;
    }

    static void Main(string[] args)
    {

    }
}

// 5 9 11 12 14  20 25
//                  |
//     |     |  |             
// given 17, rootNode, try to find largest smallest one 
//
// Time complexity: O(logn), 
// space complexity: O(1)