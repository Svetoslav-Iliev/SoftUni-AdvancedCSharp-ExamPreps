using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int totalNumberOfCouples = numbers.Length - 1;

        var coupleFreq = new Dictionary<string, int>();
        for (int i = 1; i < numbers.Length; i++)
        {
            string currentCouple=String.Format("{0} {1}", numbers[i-1],numbers[i]);

            if (!coupleFreq.ContainsKey(currentCouple))
            {
                coupleFreq.Add(currentCouple,0);
            }

            coupleFreq[currentCouple]++;
        }

        foreach (var couple in coupleFreq)
        {
            double frequency = couple.Value*100.0/totalNumberOfCouples;

            Console.WriteLine("{0} -> {1:F2}%", couple.Key,frequency);
        }
    }
}

