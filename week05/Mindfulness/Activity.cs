using System;
using System.Threading;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        // FIX: Correctly set _description to the description parameter.
        _description = description; 
    }

    public void ShowSpinner(int seconds)
    {
        char[] spinner = { '|', '/', '-', '\\' };
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < seconds)
        {
            foreach (char symbol in spinner)
            {
                if ((DateTime.Now - startTime).TotalSeconds >= seconds)
                    break;
                Console.Write($"Reflecting... {symbol}\r");
                Thread.Sleep(250);
            }
        }
        // FIX: Used the correct escape sequence "\r" to clear the line.
        Console.Write(new string(' ', 40) + "\r");
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"Pausing... Starting in: {i} \r");
            Thread.Sleep(1000);
        }
        // FIX: Used the correct escape sequence "\r" to clear the line.
        Console.Write(new string(' ', 40) + "\r");
    }

    private void SetDuration()
    {
        while (true)
        {
            Console.Write($"How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();
            
            // FIX: Uses tempDuration to avoid scope/naming conflicts and validate input.
            if (int.TryParse(input, out int tempDuration) && tempDuration > 0)
            {
                _duration = tempDuration;
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive whole number.");
            }
        }
    }

    public void DisplayStartingMessage()
    {
        // FIX: Cleaned up the formatting for the activity title.
        Console.WriteLine($"\n--- {_name} Activity ---");
        Console.WriteLine(_description);
        SetDuration();
        Console.WriteLine("\nGet ready to begin...");
        ShowCountdown(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done! You have completed the following activity:");
        Console.WriteLine($"Activity: {_name}");
        Console.WriteLine($"Duration: {_duration} seconds");
        ShowCountdown(3);
    }

    public abstract void Run();
}