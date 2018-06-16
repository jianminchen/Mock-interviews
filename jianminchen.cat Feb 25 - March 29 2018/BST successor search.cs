
/*   sway.com  */

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
    if(inputNode == null)
      return null; 
    
    if(inputNode.right != null)
    {
      return getRightSubtreeSmallest(inputNode);
    }
    else 
    {
      findPossibleFirstParentBiggerThanGivenValue(inputNode);
    }
  }
  
  public static Node getRightSubtreeSmallest(Node inputNode)
  {
      var node = inputNode.right; 
      while(node.left != null)
      {
        node = node.left; 
      }
      
      return node; 
  }
  
  public static Node findPossibleFirstParentBiggerThanGivenValue(Node inputNode)
  {
    var start = inputNode.parent; 
      
      while(start.parent != null && start.parent < inputNode.value)
      {
        start = start.parent; // start's value definitely will be smaller than given value
      }
      
      return start.parent; 
  }

   
  static void Main(string[] args)
  {
    
  }
}

/*
BST - 5 9 11 12 14 20 25 <- linear access O(1) -> inorder traversal time complexity: O(n)
next to give node value
  given node is 9, find 11;
  given node is 14, find 20;

- lgn - height of tree 

*/