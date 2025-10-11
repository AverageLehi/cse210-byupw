using System;
using System.Collections.Generic;
using System.Linq;

public class ListingActivity : Activity
{
    private int _count = 0;
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of you personal heroes?"
    };
    private Random _random = new Random();
    public ListingActivity() : base(
        "Listing",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
    ) { }

    // --- Specific Listing Methods ---

    public string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }

    public List<string> GetListFromUser()
    {
        List<string> listedItems = new List<string>();
        DateTime startTime = DateTime.Now;

        Console.WriteLine("\nStart listing items now (press Enter after each one).");
        Console.WriteLine($"You have {_duration} seconds. Go!");

        // Loop runs until duration is met, relying on console input blocking for timing
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("Item: ");
            string item = Console.ReadLine(); 
            
            if (!string.IsNullOrWhiteSpace(item))
            {
                listedItems.Add(item);
            }
        }
        
        Console.WriteLine("\nTime's up! Stop listing items.");
        _count = listedItems.Count; // Set the internal count
        return listedItems;
    }

    public override void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine($"\n{prompt}");

        // Give a moment to think about the prompt
        Console.WriteLine("You have a few seconds to begin thinking of items.");
        ShowCountdown(5); // Countdown used for this pause

        GetListFromUser();
        
        // Activity display back the number of items that were entered.
        Console.WriteLine($"You listed {_count} items!");

        DisplayEndingMessage();
    }
}