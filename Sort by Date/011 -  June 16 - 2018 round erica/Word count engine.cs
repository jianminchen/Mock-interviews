using System;

class Solution
{
    public static string[,] WordCountEngine(string document)
    {
        if (document == null || document.Length == 0)
            return new string[0, 0];

        document.ToLower(document);
        var stripped = stripPunctation(document); //"''"  you'll -> youll string.replace()
        var split = stripped.Split(" .!");

        var dict = putToDictionary(split);
        var sorted = applyBucketSortKeepOriginalOrder(dict); // 

        return convertToDimension(sorted);
    }


    private static IList<string>[] applyBucketSortKeepOriginalOrder(Dictionary<string, int> dict,
                                        string[] split)
    {
        var maxValue = dict.Values.Max(); 
        var buckets = new List<string>[maxValue + 1];
      
        for(int i = 0; i < maxValue + 1)
          buckets[i] = new List<string>();
        var seen = new HashSet<string>(); 
      
        foreach(var word in split)
        {
          if(seen.Contains(word))
            continue;
          
          var countVal = dict[word];
          
          buckets[countVal].Add(word);
          
          
          seen.Add(word);
        }
      
        return buckets;
    }

    private static string stripPunctation(string document)
    {
        var sb = new stringBuilder();

        foreach (var item in document)
        {
            int current = item - 'a';
            if (current >= 0 && current < 26)
            {
                sb.Append(item);
            }
        }

        return sb.ToString();
    }


    static void Main(string[] args)
    {

    }
}

// lower case 
// strip out punctutation 
// split words " .!"
//count number
//descending order
//constraint: if same count, sorted accoding to their order in original sentence

//instead of removing .!,[]-+=

// KEEP A-Z 

/*
The peer shared his idea to solve the problem:
 * 
2 data structures
counts = map (word; number of occurrences)
sorted = ordered, distinct list of words [practice, makes, perfect, youll ...]
result = list(wordobjects{word, count})
for (word in sorted) {
  push to result
}

sort result based on number of occurrences descending


*/
