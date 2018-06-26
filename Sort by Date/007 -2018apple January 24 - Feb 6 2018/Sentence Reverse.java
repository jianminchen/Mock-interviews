import java.io.*;
import java.util.*;

class Solution {

  static char[] reverseWords(char[] arr) {
    
    if(arr == null || arr.length <= 1){
        return arr ; 
    }
    
    int len = arr.length ;         
     
    reverse(arr, 0, len-1);
    
    int left = 0, right = 0; 
    
    while(left < len && right < len){
      char current = arr[right];
      
      if(current == ' ' || right == len-1) //handle single word
      { //found a word
        int end = current == ' '? right - 1 : right; 
        reverse(arr, left, end);  //reverse chars in the word
        left = right+1; //move to next word
      }
      
      right++ ;           
    }
    
    return arr ; 
  }
  
  static void reverse(char[] arr, int start, int end){
    int i=start, j=end; 
    
    while(i<j){
      char temp = arr[i]; 
      arr[i] = arr[j]; 
      arr[j] = temp ;
      
      i++;
      j--;
    }
  }

  public static void main(String[] args) {
  
  }

}