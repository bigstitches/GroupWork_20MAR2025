using System;
using System.Collections.Generic;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, People!");


// wow! "commit all and sync" and I saw Lepolean's on my Visual Studio app

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
