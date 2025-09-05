using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hi! Welcome to Guess the Number game.");
        bool continueGame = true;
        string continueGameQ;
        while(continueGame)
        {
            Console.WriteLine("I'm thinking of a magic number between 1-100.");
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1,100);
            bool continuePlay = true;
            int guessCount = 0;
            while (continuePlay)
            {
                Console.WriteLine("What is the your guess?");
                int guessNumber = int.Parse(Console.ReadLine());   

                if (guessNumber == magicNumber)
                {
                    Console.WriteLine("You guessed it!");
                    guessCount += 1;
                    Console.WriteLine($"You have tried {guessCount} time(s)!");
                    continuePlay = false;
                } 
                else if (guessNumber > magicNumber)
                {
                    Console.WriteLine("Lower");
                    guessCount += 1;
                }
                else
                {
                    Console.WriteLine("Higher");
                    guessCount += 1;
                }

            }
            Console.WriteLine("Would you like to play again (yes/no)?");
            continueGameQ = Console.ReadLine();
            if (continueGameQ.ToLower() == "yes")
            {
                continuePlay = true;
            }
            else
            {
                continuePlay = false;
            }
        }

    }
}