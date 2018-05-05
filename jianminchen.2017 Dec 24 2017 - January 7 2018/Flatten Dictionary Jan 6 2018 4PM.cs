using System;
using System.Collections.Generic;

class Solution
{
    public static Dictionary<string, string> FlattenDictionary(Dictionary<string, object> dict) // 
    {
        if (dict == null || dict.Count == 0) // false 
        {
            return new Dictionary<string, string>();
        }

        var flatten = new Dictionary<string, string>();

        foreach (var pair in dict) // Key1 : 1
        {
            var key = pair.Key; // "Key1"
            var value = pair.Value; // "1"

            // https://stackoverflow.com/questions/16956903/determine-if-type-is-dictionary
            var isDictionary = value is Dictionary<string, object>;

            if (!isDictionary)
            {
                flatten.Add(key, (string)value);
            }
            else
            {
                var childFlatten = FlattenDictionary((Dictionary<string, object>)value);

                var prefix = key;  // Key2
                foreach (var keyValue in childFlatten)
                {
                    var subKey = keyValue.Key;
                    var subValue = keyValue.Value;

                    var newKey = prefix + "." + subKey;  // conditional .

                    if (String.IsNullOrEmpty(prefix))
                        newKey = subKey;
                    if (String.IsNullOrEmpty(subKey))
                        newKey = prefix;


                    flatten.Add(newKey, subValue);
                }
            }
        }

        return flatten;
    }

    static void Main(string[] args)
    {

    }
}

/*
"":
  Key1 : 1   
 
 Key2: 
     a: 2
     b: 3
     c: {}
   
line 19: same thing back
line 20: prefix = Key2; 
   Let us call FlattenDictionary(value)
   go over each key value pair
   then add prefix to each key
   
   new key/ value to output dictionary

*/