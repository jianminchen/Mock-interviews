using System;

class Solution
{
    public class Node
    {
        public int cost;
        public Node[] children;
        public Node parent;
    }

    public static int getCheapestCost(Node rootNode, int prefixSum, ref int minimumSum)
    {
        if (rootNode == null)
        {
            return 0;
        }

        var cost = rootNode.cost;
        var children = rootNode.children;

        if (children == null || children.Length == 0)
        {
            return cost;
        }

        int minPathSum = int.MaxValue;

        foreach (var child in children)
        {
            // minPathSum = Math.Min(minPathSum, getCheapestCost(child));
            var minPathChild = getCheapestCost(child);
            minPathSum = minPathChild < minPathSum ? minPathChild : minPathSum;
        }

        return cost + minPathSum;
    }

    static void Main(string[] args)
    {

    }
}

// educative.io
/*
recursive depth first search

if node is null 
  return 0

if node has no children
  return node.value

  minpath
foreach(child)
{
  keep min path
}

return node.value + minPathOfallChildren 
*/