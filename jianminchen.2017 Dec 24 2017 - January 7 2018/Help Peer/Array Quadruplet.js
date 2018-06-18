// Help the peer to solve array quadruplet 
function findArrayQuadruplet(arr, s) {
  // your code goes here
  arr = arr.sort(function(a, b) {
    return a - b;
  });
  
  let tempS = 0;
  let tempArr = [];
  
 // while(tempS !== s) { // remove this line!
    tempArr = [];
    loop1: for(let i = 0; i < arr.length; i++) {
      for(let j = i + 1; j < arr.length; j++) {
        for(let k = j + 1; k < arr.length; k++) {
          for(let l = k + 1; l < arr.length; l++) {
            tempS = arr[i] + arr[j] + arr[k] + arr[l];
            
            if(tempS == s)
              {
                // push here only! 
                tempArr.push(arr[i]);
                tempArr.push(arr[j]);
                tempArr.push(arr[k]);
                tempArr.push(arr[l]);
                
                break loop1;   // break 4 loops please, let us run the code
                //breaking loop1 should break everything
                
                
                
             }
          } 
        } 
      } 
    }
  //}
  
  
  
  return tempArr;
}

//time complexity is o(n), though i don't think this co
// i can't figure out the right solution for now, this is to get me started
//sure, i understand the brute force method, time complexity will be abysmal at o(n4)
//so u need me to code out the brute force method?
  
 // let me correct your for loop , you have some issues -> 

// can you solve the problem using brute force solution
// i < j < k < l 
// using four loops
// for(i = 0; i < length - 1; i ++)
//  for(j = i + 1 ; j < length - 1; j++)
//   for(k = j + 1; k < length - 1; k++)   // it is ok as long as you solve the problem first, and then we dicuss optimal solution
//    for(l = k + 1; )
  // yes, try to code the brute force solution first
  // use 4 for loops 
  // do not use while loop 

// can you run the test cases and see if your code has pr


//here's how i'm planning to solve the problem
//1) sort the array
//2) get the last 2 numbers
//3) get remainder from smaller numbers

//anything you wanna ask me?
  
//  using your example
//1) [0,1,2,3,4,5] 

//2) 12 - (4 + 5) = 3

//3) 3 = array[1] + array[2]

//let me work on it before explaining


//give example [0, 2, 3, 4, 1, 5], given sum = 12, how to find the 4 numbers



// [0, 2, 3, 4, 1, 5, 10, 11]



