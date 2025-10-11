using System;
public class BreathingActivity : Activity
{
    public BreathingActivity() : base (
        "Breathing",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
         ) {}
    public override void Run()
    {
        DisplayStartingMessage();
        DateTime startTime = DateTime.Now;
        double elapsedSeconds = 0;
        while (elapsedSeconds < _duration)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(4);
            
            elapsedSeconds = (DateTime.Now - startTime).TotalSeconds;
            if (elapsedSeconds >= _duration) break; 
  
            Console.WriteLine("Breathe out...");
            ShowCountdown(4);
            
            elapsedSeconds = (DateTime.Now - startTime).TotalSeconds;
        }
        Console.WriteLine("\nBreathing activity complete.");
        DisplayEndingMessage();
    }
}