import java.io.*;
import java.util.*;

class Solution {

  static int deletionDistance(String str1, String str2) {
    str1 = "$" + str1;
    str2 = "$" + str2;
    int m = str1.length();
    int n = str2.length();
    int[][] f = new int[m][n];
    for(int i = 0; i < m ; i++) {
      Arrays.fill(f[i], m + n + 1);
    }
    for(int i = 0; i < m; i++) {
      f[i][0] = i;
    }
    for(int i = 0; i < n; i++) {
      f[0][i] = i;
    }        
    
    for(int i = 1; i < m; i++) {
      for(int j = 1; j < n; j++) {
        if (str1.charAt(i) == str2.charAt(j)) {
          f[i][j] = f[i-1][j-1];
        } else {
          f[i][j] = Math.min(f[i-1][j],f[i][j-1]) + 1;
        }
      }
    }
    return f[m-1][n-1];
  }

  //$dog and $frop, 
  //$hit, i =   3 $heat, j = 4
  //f[$hit][$heat] = f[$hi][$hea]
  //(f[$hit][$hea] + 1)
  //(f[$hi][$heat] + 1)
  //(f[$hi][$hea]  <- minimum 
  //    min(f[$h][$hea], $f[$hi][$he]) + 1
  //)
  //f[3][4] = f[2][3]       
  
  //f[4][5]
  //f[0][0] = 0
  //f[i][j] 
    // i == j f[i][j] = f[i-1][j-1]
    // i !== f[i][j] = min(f[i-1][j],f[i][j-1]) + 1
  
  //f[0][0] = 0
  //f[0][1] = 1
  //f[0][2] = 2
  //...
  //f[1][1] = min(f[1][0], f[0][1]) + 1 = 2
  //...
  
  
  public static void main(String[] args) {
    System.out.println(deletionDistance("dog","frog"));
    System.out.println(deletionDistance("some","some"));
    System.out.println(deletionDistance("some","thing"));
  }
}