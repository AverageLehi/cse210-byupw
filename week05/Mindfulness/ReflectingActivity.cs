using System;
using System.Collections.Generic;
using System.Linq;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _random = new Random();

    public ReflectingActivity() : base(
        "Reflection",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
    ) { }

    public string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }

    public string GetRandomQuestion()
    {
        return _questions[_random.Next(_questions.Count)];
    }

    public void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"\n{prompt}");
        Console.WriteLine("Take a few moments to think about this experience.");
        ShowSpinner(5); // Initial reflection time
    }

    public void DisplayQuestions()
    {
        DateTime startTime = DateTime.Now;
        const int DefaultReflectionTime = 10;

        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            string question = GetRandomQuestion();
            Console.WriteLine($"\n> {question}");

            double remainingSeconds = _duration - (DateTime.Now - startTime).TotalSeconds;
            
            // Determine the pause duration: it's either the default time or whatever time is left.
            // We use Math.Ceiling to ensure any remaining time triggers at least a 1-second pause 
            // if the time is less than DefaultReflectionTime but greater than zero.
            int reflectionTime = (int)Math.Ceiling(Math.Min(DefaultReflectionTime, remainingSeconds));

            // Only run the spinner if there is measurable time left.
            if (reflectionTime > 0)
            {
                ShowSpinner(reflectionTime); 
            }
            else
            {
                // Break immediately if no time is left after the check.
                break;
            }
        }
    }

    public override void Run()
    {
        DisplayStartingMessage();

        DisplayPrompt();
        DisplayQuestions();

        Console.WriteLine("\nReflection activity complete.");
        DisplayEndingMessage();
    }
}