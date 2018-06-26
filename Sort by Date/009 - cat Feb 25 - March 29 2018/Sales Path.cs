using System;

class Solution
{
  public class Node
  {
    public int cost;
    public Node[] children;
    //public Node parent;
    
    public Node(int value)
    {
      cost = value; 
    }
  }
    
  public static int getCheapestCost(Node rootNode)
  {
    if(rootNode == null)
      return 0; 
    
    var hasNoChildren = rootNode.children == null || rootNode.children.Length == 0; 
    
    if(hasNoChildren)
      return rootNode.cost; 
    
    var children = rootNode.children; 
    
    int minimum = int.MaxValue; 
    
    foreach(var item in children)
    {
       var childPath =   getCheapestCost(item);
      minimum = childPath < minimum? childPath : minimum; 
    }
    
    return rootNode.cost + minimum; 
  }

  static void Main(string[] args)
  {
      var node0 = new Node(0);  
      var node5 = new Node(5); 
      var node4 = new Node(4); 
      var node6 = new Node(6); 
    
      node0.children = new Node[]{node5, node6};
      node5.children = new Node[]{node4}; 
    
      node6.children = new Node[]{new Node(5)}; 
    
     
      Console.WriteLine(getCheapestCost(node0));
    
  }
}



  /*
  
  base case:
  if node == null 
    return 0
   
  if node.has no children 
    return node.value
    
  if node has children
    
    minPathSum = from all children
    
    return node.Value + minPathSum
    
    0 - 
    node 5,  left -> 9
  node 3 -> 7
    node 6 -> 7
    
    return 0 + Math.Min(9, 7, 7) = 7 
    Time complexity: O(n) - all nodes in the tree
    space complexity: height of tree -> 5 depth of tree -> 0 - 3 - 3 - 1 - 1, stack space 
  */
  
  
