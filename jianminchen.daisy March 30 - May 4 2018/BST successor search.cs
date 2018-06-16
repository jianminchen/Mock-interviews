
using System;

class Solution
{
  public class Node
  {
    public int value;
    public Node left;
    public Node right;
    public Node parent;
    
    public Node(int number)
    {
      value = number; 
    }
  }

  public static Node findInOrderSuccessor(Node inputNode)
  {
    if(inputNode == null)
      return null;
    
    if(inputNode.right != null)
    {
      return findMinimumValueInTree(inputNode.right);
    }
    else 
    {
      return findParentNodeWithBiggerValue(inputNode);
    }
  }
  
  private static Node findMinimumValueInTree(Node node)
  {
    var currentNode = node;
    while(currentNode.left != null)
    {
      currentNode = currentNode.left;
    }
    
    return currentNode; 
  }

  private static Node findParentNodeWithBiggerValue(Node node)  // node 14
  {
    var current = node; // node 14
    while(current.parent != null && current.parent.value < node.value) // node12, true
    {
      current = current.parent; // node12, node9
    }
    
    return current.parent; // node9's parent -> node 20
  }
  
  static void Main(string[] args)
  {
    var node20 = new Node(20); 
    var node9 = new Node(9); 
    var node5 = new Node(5); 
    var node12 = new Node(12); 
    var node11 = new Node(11); 
    var node14 = new Node(14); 
    var node25 = new Node(25); 
    
    node20.left = node9;
    node20.right = node25;
    
    node9.parent = node20;
    node25.parent = node20;
    
    node9.left = node5;
    node9.right = node12; 
    node5.parent = node9;
    node12.parent = node9; 
    
    node12.left = node11; 
    node12.right = node14; 
    node11.parent = node12; 
    node14.parent = node12; 
    
    var successor11 = findInOrderSuccessor(node9); 
    Console.WriteLine(successor11.value);
    
    var successor20 = findInOrderSuccessor(node14); 
    Console.WriteLine(successor20.value);
    
  }
}

/*
brute force: in order traversal, BST in ascending order, Light, Root, right
5, 9, 11, 12, 14, 20, 25 -> given node 9, 11, lookup 
time complexity: O(n)
  
O(logn) -> root to leaf node, binary search, try to get rid of half of tree all the time
give input node 9, if right node is existing, find minimum value in right subtree. 
  otherwise, search parent node until the parent node's value is bigger than give node's value, maybe return null. 
  
  */
