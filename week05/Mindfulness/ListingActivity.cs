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
    public ListingActivity() : base
}