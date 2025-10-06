using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Lehi", "Mathematics");
        string summary = assignment.GetSummary();
        Console.WriteLine(summary);

        Math math = new Math("Lehi", "Mathematics", "7.5", "12-20");
        string mathAssignment = math.GetHomeworkList();
        Console.WriteLine(mathAssignment);

        Writing writing = new Writing("Lehi", "Mary waters - European History", "The Causes of World War II by Mary Waters");
        string writingAssignment = writing.GetWritingInformation();
        Console.WriteLine(writingAssignment);
    }
}