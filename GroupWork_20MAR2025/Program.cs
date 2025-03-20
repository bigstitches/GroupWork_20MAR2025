using System;
using System.Collections.Generic;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, People!");
LongestConsecutiveSequence.Main();


// wow! "commit all and sync" and I saw Lepolean's on my Visual Studio app

public class LongestConsecutiveSequence
{
    public static void Main()
    {
        int[] nums = { 100, 3, 2, 0, 55, 1, 22 };
        Console.WriteLine(LongestConsecutive(nums));
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

    public int LongestConsecutive2(int[] nums)
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
}


