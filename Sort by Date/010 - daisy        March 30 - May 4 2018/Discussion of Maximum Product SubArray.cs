
Julia asked the peer to work on an extra algorithm. 
 
Given an integer array nums, find the contiguous subarray within an array (containing at least one number)
  which has the largest product.

Example 1:

Input: [2,3,-2,4]
Output: 6
Explanation: [2,3] has the largest product = 6.
Example 2:

Input: [-2,0,-1]
Output: 0
Explanation: The result cannot be 2, because [-2,-1] is not a subarray.
  
0 ... i -> even amount of negative numbers  
0 ... i -> odd amount of negative numbers
l -> first negative number, l+1...i

log(x * y) = log(x) + log(y)
  
l....r
arr[l] * arr[l + 1]....*arr[r]
(log(arr[l]) + log(arr[l + 1]) +.. log(arr[r]))
  
  
  
  [-2, 10, 2, 10, -2]
  [-2, 10, 2, 10, -2]
  try a few examples, 
  investigate: 
  
       subarrary can end from i = 0 to length - 1, 
       |
      what is maximum product of subarray ending at index = 1? 
         using dynamic programming dp[i] is related to dp[i - 1]
         
       at index = 1, what is maximum subarray product? 10 
          minimum subarray product? -2 * 10 = -20 
         
       work on next problem, index = 2, 
       there are two choices, one is standalone, 2
                    another choice, at least 2 elements
                    max/ min, 2
                   current max = max( arr[2], dp_max[i - 1] * arr[2], dp_min[i - 1] * arr[2])
                           min = min( arr[2], dp_max[i - 1] * arr[2], dp_min[i - 1] * arr[2])
         
         
        logPref[i] = logPref[i - 1] + log(arr[i])
        if (cntNegative is even) {
if there is zero, break into small -> 
  
  0

n = arr.size

int maxAns = arr[0];
for (int l = 0; l < n; l++) {
   int prod = 1;
   for (int r = l; r < n; r++) {
     prod *= arr[r];
     
     maxAns = max(maxAns, prod);     
  }
}

prefProd[i] - product on prefix from 0 ... i arr[0] * arr[1] * .. arr[i]

if (prefProd[i - 1] != 0) {
  prefProd[i] = prefProd[i - 1] * arr[i];
} else {
  prefProd[i] = arr[i];
}
  
if (prefProd[i] > 0) {
  ans = max(ans, prefProd[i] / positiveMin);
  positiveMin = min(prefProd[j], where prefProd[j] > 0 and j < i)
  positiveMin = min(positiveMin, prefProd[i])
} else if (prefProd[i] < 0) {
  ans = max(ans, prefProd[i] / negativeMax);
  negativeMax = max(prefProd[j], where prefProd[j] < 0 and j < i)
  negativeMax = max(negativeMax, prefProd[i]);
} else {
  ans = max(ans, 0);
  positiveMin = 1;
  negativeMax = 1;
}
          
prefProd[i] = 0....i    // [-2, 10, -2, 10], i = 0, -2; i = 1, ; -20
  
  ans = 0
  positiveMinId = -1, positiveMin = 1
  negativeMaxId = -1, negativeMax = 1
  
  i = 0
    ans = prefProd[i] / negativeMax = -2
    negativeMax = -2, negativeMaxId = 0
  i = 1
    ans  = prefProd[i] / negativeMax = -20 / -2 = 10
    negativeMax = -2, negativeMaxId = 0
  i = 2
    ans = prefProd[i] / positiveMin = 40 / 1 = 40
  i = 3
    ans = prefProd[i] / positiveMin = 400 / 1 = 400

i:
  if (arr[i] = 0) 
    prefProd[i] = 1
    updateMins()
  else if (prefProd[i] > 0) 
    getPositiveMin -> prefProd[i] / prefProd[postiveMinId]
  else if (prefProd[i] < 0)
    getNegativeMin -> prefProd[i] / prefProd[negativeMaxId]
    

          
          graph - 
            
            
            Leetcode 4 sum 
            For example, given an input array with the elements of [1, 6, 3, 8, 4, 0, 2], 
          given 4 sum value 14, the ordered quadruplet with 14 in an ascending order can be [0, 2, 4, 8].
            
thirdId = 0
allSums is empty
thirdId = 1
allSums is empty
thirdId = 2
allSums contain sum arr[0] + arr[1]
thirdId = 3
allSums contain arr[0] + arr[1], arr[0] + arr[2], arr[1] + arr[2]
thirdId = 4            
       
            given array, find quadruplet to have a sum matching given value 
            
unordered_max <int, pair <int, int> > allSums;
          
i:
          allSums will contain arr[j] + arr[k] for all (j < i && j < k < i )
            
    HashMap.count(x) -> 0 if x is absent
            non-zero otherwise
            
for (int thirdId = 0; thirdId < n; thirdId++) {
  for (int fourthId = thirdId + 1; fourthId < n; fourthId++) {
    int currSum = arr[thirdId] + arr[fouthId];
    if (allSums.count(sum - currSum)) {
      vector <int> ansIds(4);
      ansIds[0] = allSums[sum - currSum].first;  // ? key value - related to index third 
      ansIds[1] = allSums[sum - currSum].second;
      ansIds[2] = thirdId;
      ansIds[3] = fourthId;
      return ansIds;
    }
  }
  for (int firstId = 0; firstId < thirdId; firstId++) {
    allSums[firstId + thirdId] = make_pair(firstId, thirdId);
  }
}           

          return NULL;
  