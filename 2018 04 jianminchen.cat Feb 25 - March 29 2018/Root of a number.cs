
import java.io.*;
import java.util.*;

class Solution {
/*
input:  x = 7, n = 3
output: 1.913
1,2,3
(1,2)
0.001
if x = 7, what is n? logn -> 
0, 0.0001, 
0 - 1, 1000, 
0 - 7 , 7000 -> x = 7, log1000x = 10logx = 10 log7 = 30 
what is n? 
0 -> upper bound, x > 1, x, 
                  x < 1, 1
 [0, max(x, 1)]  - range 
input:  x = 9, n = 2
output: 3
1,2,3...
1,4,9
*/
  static double root(double x, int n) {
      // your code goes here
    int start = 0;
    int range = 10000; 
    int end = Math.max( 1 * range, (int) x * range);
    int middle = 0;
    double sample = 0.0;
    double result = 0.0;
    
    while (start <= end) {
      middle = start + (end - start)/2;
      sample = test((double)middle/range, n);
      
      double diff = Math.abs(sample - x);  // 0.001 -> 0.0008 -> 0.001, 0.0012 -> 0.001  diff <= 0.0005
      
      if (diff * 1000 < 1) {
        return (double)middle/range;        
      } 
      else if (sample < x) 
      {
        start = middle + 1;
      } 
      else {
        end = middle - 1;
      }
    }
    
    return 1.0 * start/range;  
  }

  static double test(double x, int n){
    double t = x;
    while (n > 1) {
      t *= x;
      n--;
    }
    return t;
  }
  
  public static void main(String[] args) {
  }
}
 
 
            
 
 

