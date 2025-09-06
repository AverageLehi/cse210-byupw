using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        int userNumber = PromptUserNumber();
        int squaredNumber = SquaredNumber(userNumber);
        DisplayResult(userName, squaredNumber);

        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();
            return userName;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            string userInput = Console.ReadLine();
            return int.Parse(userInput);
        }

        static int SquaredNumber(int number)
        {
            int square = number * number;
            return square;
        }
        static void DisplayResult(string userName, int squaredNumber)
        {
            Console.Write($"{userName}, the square of your number is {squaredNumber}");
        }

    }

}