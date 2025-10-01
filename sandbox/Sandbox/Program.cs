using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type '0' when finised: ");
        List<int> numList = new List<int>();
        string num;
        int intNum;
        int sum = 0;
        int largestNum = 0;
        int smallestPositiveNum = int.MaxValue;
        do
        {
            num = Console.ReadLine();
            intNum = int.Parse(num);
            if (intNum != 0)
            {
                numList.Add(intNum);
                sum += intNum;
                if (intNum > largestNum)
                {
                    largestNum = intNum;
                }
                if (intNum < smallestPositiveNum)
                {
                    smallestPositiveNum = intNum;
                }

            }
        } while (intNum != 0);

        double average = (double)sum / numList.Count;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average:F2}");
        Console.WriteLine($"The largest number is: {largestNum}");
        Console.WriteLine($"The smallest positive number is: {smallestPositiveNum}");
        Console.WriteLine("The sorted list is:");
        numList.Sort();
        foreach (int number in numList) { Console.WriteLine(number); }



    }
}