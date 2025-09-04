using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade? ");
        string grade = Console.ReadLine();
        int gradeInt = int.Parse(grade);

        string letter;
        string message;
        string classPassedMessage = "Congratulations! You passed the class.";
        string classFailedMessage = "You failed the class. I know you can do it better next time!";


        if (gradeInt >= 90)
        {
            letter = "A";
            message = classPassedMessage;
        }
        else if (gradeInt >= 80)
        {
            letter = "B";
            message = classPassedMessage;
        }
        else if (gradeInt >= 70)
        {
            letter = "C";
            message = classPassedMessage;
        }
        else if (gradeInt >= 60)
        {
            letter = "D";
            message = classFailedMessage;
        }
        else
        {
            letter = "F";
            message = classFailedMessage;
        }

        int gradeSign = gradeInt % 10;

        if (gradeSign >= 7 && letter != "A" && letter != "F")
        {
            letter += "+";
        }
        if (gradeSign < 3 && letter != "F")
        {
            letter += "-";
        }
        Console.WriteLine($"\nYou earned a {letter} grade. {message}");
    }
}
