using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        

        StringBuilder sb=new StringBuilder();

        for (int i = 0; i < 4; i++)
        {
            sb.AppendFormat(" {0}",Console.ReadLine());
        }

        string arrowPattern = @"(>>>----->>)|(>>----->)|(>----->)";
        Regex arrowMatcher=new Regex(arrowPattern);

        var arrowsQuantity = arrowMatcher.Matches(sb.ToString());

        int largeArrowCount = 0;
        int mediumArrowCount = 0;
        int smallArrowCount = 0;

        foreach (Match arrow in arrowsQuantity)
        {
            if (!string.IsNullOrEmpty(arrow.Groups[1].Value))
            {
                largeArrowCount++;
            }
            else if (!string.IsNullOrEmpty(arrow.Groups[2].Value))
            {
                mediumArrowCount++;
            }
            else
            {
                smallArrowCount++;
            }
        }

        string numberAsString = string.Format("{0}{1}{2}", smallArrowCount, mediumArrowCount, largeArrowCount);

        long usableNumber = long.Parse(numberAsString);

        string binaryNum = Convert.ToString(usableNumber, 2);

        string reversedNum = new string(binaryNum.Reverse().ToArray());

        string resultAsString = binaryNum + reversedNum;

        long result = Convert.ToInt64(resultAsString,2);
   
        Console.WriteLine(result);

    }
}

