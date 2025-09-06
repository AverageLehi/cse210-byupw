using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        bool continueAdd = true;
        while (continueAdd)
        {
            Console.Write("Enter number: ");
            int addNumber = int.Parse(Console.ReadLine());
            if (addNumber != 0)
            {
                numbers.Add(addNumber);
            }
            else
            {
                continueAdd = false;
            }
        }
        double sum = 0;
        int listIndex = 0;
        int highestPossibleNum = 0;
        int lowestPossibleNum = int.MaxValue;
        foreach (int num in numbers)
        {
            sum += num;
            listIndex += 1;
            if (num > highestPossibleNum)
            {
                highestPossibleNum = num;
            }
            if (num > 0)
            {
                if (num < lowestPossibleNum)
                {
                    lowestPossibleNum = num;
                }
            }
        }
        double averageInList = sum / listIndex;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {averageInList}");
        Console.WriteLine($"The largest number is: {highestPossibleNum}");
        Console.WriteLine($"The smallest positive number is: {lowestPossibleNum}");
        numbers.Sort();
        Console.WriteLine($"The sorted list is: ");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}