import java.io.*;
import java.util.*;

class Solution {

  static int binarySearchShiftedArray(int[] shiftArr, int left, int right, int num){
    
    int mid = (left+right)/2;
    
    if(shiftArr[mid] == num){
       return mid;
    }
    
    if(left >= right)
      return -1;
    
    int result = -1;
    
    boolean rightHalfNotSorted = shiftArr[mid] > shiftArr[right]; 
    
      
    if(rightHalfNotSorted){
      result = binarySearch(shiftArr, left, mid-1, num);
      
      if(result != -1){
        return result;
      }
      
      return binarySearchShiftedArray(shiftArr, mid+1, right, num);
    }else
    {
      result = binarySearch(shiftArr, mid + 1, right, num);  // normal 
      
      if(result != -1){
        return result;
      }
      
      return binarySearchShiftedArray(shiftArr, left, mid-1, num);
    }
  }
  
  static int binarySearch(int[] arry, int left, int right, int num){
  
    int low = left;
    int high = right;
    
    while(low <= high){
      
     int mid = left + (right - left) / 2;
      
     int value = arry[mid]; 
      
     if(value == num){
       return mid;
     }else if(value < num){
       
       low = mid - 1;
     }else
     {
       high = mid + 1;
     }
    }
    
    return -1; 
  }  

  public static void main(String[] args) {
    
   int[] shiftArr = {9, 12, 17, 2, 4, 5};
 //                  0   1   2  3   4 5
  // System.out.println(shiftedArrSearch(shiftArr, 2));
  
  }
}