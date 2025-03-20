using System;
using System.Collections.Generic;
using System.Diagnostics;

public class LongestConsecutiveSequence
{


    public static void Main()
    {
        int[] nums = { 100, 3, 2, 0, 55, 1, 22 };
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        LongestConsecutive(nums);
        stopwatch.Stop();

        Console.WriteLine("LongestConsecutive runtime:" + stopwatch.ElapsedTicks);

        stopwatch.Reset();
        
        stopwatch.Start();
        LongestConsecutiveWithMap(nums);
        stopwatch.Stop();

        Console.WriteLine("LongestConsecutiveWithMap runtime:" + stopwatch.ElapsedTicks);

        stopwatch.Reset();

        stopwatch.Start();
        LongestConsecutive2(nums);
        stopwatch.Stop();

        Console.WriteLine("LongestConsecutive2 runtime:" + stopwatch.ElapsedTicks);



    }

    public static int LongestConsecutiveWithMap(int[] nums)
    {
        if (nums.Length < 2) { return nums.Length; }

        // unique elements, not stored in any order, but takes O(1) time to retrieve/add/remove/contains

        Dictionary<int, int> dictionary = new Dictionary<int, int>();

        foreach (int n in nums)

        {
            dictionary.Add(n, 0); // skip duplicates
        }

        int maxConsecutive = 0;

        foreach (KeyValuePair<int, int> kvp in dictionary)
        {
            int counter = 1;
            int firstElement = kvp.Key;
            while (dictionary.ContainsKey(firstElement + 1))
            {
                firstElement += 1;
                counter += 1;
            }

            if (counter > maxConsecutive)
            {
                maxConsecutive = counter;
            }
        }

        return maxConsecutive;
    }
    public static int LongestConsecutive(int[] nums)
    {
        if (nums.Length < 2) { return nums.Length; }

        // unique elements, not stored in any order, but takes O(1) time to retrieve/add/remove/contains

        HashSet<int> hashSet = new HashSet<int>();

        foreach (int n in nums)

        {
            hashSet.Add(n);
        }

        int maxConsecutive = 0;

        foreach (int n in hashSet)

        {
            int counter = 1;
            int firstElement = n;
            while (hashSet.Contains(firstElement + 1))
            {
                firstElement += 1;
                counter += 1;
            }

            if (counter > maxConsecutive)
            {
                maxConsecutive = counter;
            }
        }
        return maxConsecutive;
    }

    public static int LongestConsecutive2(int[] nums)
    {
        if (nums.Length < 2)
        {
            return nums.Length;
        }

        HashSet<int> hashSet = new HashSet<int>(nums);
        int longestStreak = 0;

        foreach (int num in nums)
        {
            if (!nums.Contains(num - 1))
            {
                int currentNum = num;
                int currentStreak = 1;


                while (nums.Contains(currentNum + 1))
                {
                    currentNum++;
                    currentStreak++;
                }

                longestStreak = Math.Max(longestStreak, currentStreak);
            }
        }
        return longestStreak;
    }

    public class Solution
    {
        public int LongestConsecutive(int[] nums)
        {   // have the number of nums available         
            // can i use that one highest instance algorthithm        
            // in a hashmap?
            int maxCount = 0;         
            Dictionary<int, int> dictionary = new();         
            foreach(int num in nums) {             
                if (dictionary.TryAdd(num, 1)) {                 
                    if (dictionary.ContainsKey(num - 1) && dictionary.ContainsKey(num + 1)) 
                    {                     
                        int ahead = dictionary[num + 1];                     
                        int behind = dictionary[num - 1];                     
                        dictionary[num] = dictionary[num + ahead] + dictionary[num - behind] + 1;                     
                        dictionary[num + ahead] = dictionary[num];                     
                        dictionary[num - behind] = dictionary[num];                 
                    } 
                    else if (dictionary.ContainsKey(num-1)) 
                    {                     
                        int sequence = dictionary[num - 1];                     
                        dictionary[num - sequence]++;                     
                        dictionary[num] = dictionary[num - sequence];                 
                    } 
                    else if (dictionary.ContainsKey(num+1)) 
                    {                     
                        int sequence = dictionary[num + 1];                     
                        dictionary[num + sequence]++;                    
                        dictionary[num] = dictionary[num + sequence];                 
                    }             
                }             
                if (dictionary[num] > maxCount) {maxCount = dictionary[num];}
            }         
            return maxCount;     
        }
    }
}


