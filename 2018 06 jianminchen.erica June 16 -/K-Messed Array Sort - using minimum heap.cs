using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_23_Merge_K_Sorted_Lists
{
    /// <summary>
    /// Leetcode 23 Merge K Sorted Lists
    /// https://leetcode.com/problems/merge-k-sorted-lists/discuss/10630/C-Using-MinHeap-(PriorityQueue)-Implemented-Using-SortedDictionary
    /// </summary>
    class Program
    {       
        public class MinHeap
        {
            /// <summary>
            /// We need to keep track of the heads of all lists at all times and be able 
            /// to do the following operations efficiently:
            /// 1- Get/Remove Min
            /// 2- Add (once you remove the head of one list, you need to add the next from that list)

            /// A min heap (or a priority queue) is obviously the data structure we need here, 
            /// where the key of the dictionary is the value of the ListNode, and the value of the 
            /// dictionary is a queue of ListNodes having that value. (we need to queue the ones with 
            /// the same value since Dictionary cannot have dupes)
            /// 
            /// Using a SortedDictionary of queues.
            /// SortedDictionary is internally implemented using a binary tree, and provides O(logn) 
            /// for Add() and O(1) for PopMin(), so it's as efficient as it gets.
            /// </summary>
            public SortedDictionary<int, Queue<int>> map = new SortedDictionary<int, Queue<int>>();

            public void Add(int val, int node)
            {
                if (!map.ContainsKey(val))
                {
                    map.Add(val, new Queue<int>());
                }

                map[val].Enqueue(node);
            }

            public int PopMin()
            {
                int minKey = map.First().Key;
                var node = map[minKey].Dequeue();

                if (map[minKey].Count == 0)
                {
                    map.Remove(minKey);
                }

                return node;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] SortKMessedArray(int[] numbers, int k)
        {
            if (numbers == null || numbers.Length == 0 || k < 0 || k > numbers.Length)
                return new int[0];

            // selection sort
            var length = numbers.Length;
            var minHeap = new MinHeap(); 

            for (int i = 0; i < Math.Min(k + 1, length); i++)
            {
                minHeap.Add(numbers[i], numbers[i]); 
            }

            int index = k + 1; 

            var sorted = new int[length];
            var sortedIndex = 0; 
            while (minHeap.map.Count > 0)
            {
                var current = minHeap.PopMin();
                sorted[sortedIndex++] = current;                

                if (index < length)
                {
                    var visit = numbers[index];

                    minHeap.Add(visit, visit);
                }

                index++;
            }

            return sorted;
        }

        static void Main(string[] args)
        {
            var result = SortKMessedArray(new int[]{3, 2, 1, 6, 5, 4}, 2); 
        }        
    }
}
