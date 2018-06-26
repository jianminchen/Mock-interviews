using System;

class Solution
{
    public static int[] SpiralCopy(int[,] inputMatrix)
    {
       if(inputMatrix == null)
       {
         return new int[0];
       }
      
       var rows = inputMatrix.GetLength(0); 
       var columns = inputMatrix.GetLength(1); 
      
      var total  = rows * columns;
      var spiral = new int[total];
      
      var ranges = new int[]{columns, rows - 1}; ///5, 3 
      
      var direction = 0; // horizontal, ranges[direction%2] - decrement along 
      //                                         L-> R            T -> B             R ->L            B -> T
      var directionDetail = new int[][]{new int[]{0, 1}, new int[]{1, 0}, new int[]{0, -1}, new int[]{-1, 0}};
      
      int row = 0; 
      int col = -1; // 
      
      int index = 0; 
      
      while(ranges[direction%2] > 0)  // 5 > 0
      {
        for(int i = 0; i < ranges[direction%2]; i++) // five columns
        {
          row = row + directionDetail[direction][0]; 
          col = col + directionDetail[direction][1]; 
          
          spiral[index++] = inputMatrix[row, col]; 
        }
        
        ranges[direction % 2]--; // direction range 
        direction = (direction + 1) % 4;   // go to next direction       
      }
      
      return spiral; 
    }

    static void Main(string[] args)
    {

    }
}

/* The peer shared his code:
 * 
def spiral_copy(inputMatrix):
  size = len(inputMatrix) * len(inputMatrix[0])
  results = []
  layer = 0 
  while len(results) < size:
    traverse_right(inputMatrix, layer, results)
    if len(results) >= size:
      return results
    traverse_down(inputMatrix, layer, results)
    if len(results) >= size:
      return results

    traverse_left(inputMatrix, layer, results)
    if len(results) >= size:
      return results

    traverse_up(inputMatrix, layer, results)
    if len(results) >= size:
      return results

    layer += 1
  
  return results

def traverse_right(matrix, layer, results):
  for c in range(layer, len(matrix[layer]) - layer):
    results.append(matrix[layer][c])

def traverse_down(matrix, layer, results):
  size = len(matrix)
  c = len(matrix[0]) - 1 - layer
  for r in range(layer + 1, size - layer):
    results.append(matrix[r][c])
    
def traverse_left(matrix, layer, results):
  size = len(matrix) - 1
  r = size - layer
  for c in reversed(range(layer, len(matrix[0]) - (layer + 1))):
    results.append(matrix[r][c])
    
def traverse_up(matrix, layer, results):
  size = len(matrix)
  c = layer
  for r in reversed(range(layer + 1, size - (layer + 1))):
    results.append(matrix[r][c])
 * 
 */
// interviewer - 5 - 6 -> 
// https://codereview.stackexchange.com/questions/185935/leetcode-54-spiral-matrix
// 
// optimal solution 

// direction - directionRow [0, 1, 0, -1]
                        //    [1, 0, -1, 0]
 /*
rows = 4
columns = 5
  
range 
 1   2  3  4 5 - first row columns = 5
 10 15 20 - last column   rows - 1 = 3
 19, 18, 17, 16 - second row columsn = 5 - 1
  
  
  columns ranges -> 5 -> 4 -> 3 -> 2 -> 1 ->0
  rows ranges -> 3 -> 2 -> 1 -> 0
  
  alternate the direction automatically
  
  0, 1, 2, 3
  0, 2 - > left /right horizti
  1, 3 _. vetically 
  
  direction specified 
  */