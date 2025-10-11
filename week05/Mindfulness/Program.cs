using System;
using System.Collections.Generic;
using System.Threading;

public class Program
{
    public static void Main(string[] args)
    {
        // Dictionary to hold activity instances (using the corrected class names)
        var activities = new Dictionary<string, Activity>
        {
            { "1", new BreathingActivity() },
            { "2", new ReflectingActivity() },
            { "3", new ListingActivity() }
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n\n--- Mindfulness Program Menu ---");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            
            Console.Write("\nEnter your choice (1-4): ");
            string choice = Console.ReadLine();
            
            if (activities.ContainsKey(choice))
            {
                // Polymorphism: Calls the correct Run() method for the chosen activity
                activities[choice].Run();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Thank you for taking time for yourself. Goodbye! 👋");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                Thread.Sleep(2000); 
            }
        }
    }
}