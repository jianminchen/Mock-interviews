#Flatten a Dictionary

Given a dictionary, write a function to flatten it. Consider the following input/output scenario for better understanding:

Input:

{
  'Key1': '1',
  'Key2': {
    'a' : '2',
    'b' : '3',
    'c' : {
      'd' : '3',
      'e' : '1'
      }
    }
}
Output:

{
  'Key1': '1',
  'Key2.a': '2',
  'Key2.b' : '3',
  'Key2.c.d' : '3',
  'Key2.c.e' : '1'
}

July 18, 2023
My C# practice
https://gist.github.com/jianminchen/98e6b3175a6d01d35c18b2f6f05011be
