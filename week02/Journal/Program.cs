using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        //create object for Journal class
        Journal journal = new Journal();
        //create object for PromptGenerator class
        PromptGenerator prompt = new PromptGenerator();
   
        bool valid = true;

        while (valid)
        {
            Console.Write("""
        
        Welcome to the Journal Program! 
        Please select one of the following choices
        1. Write
        2. Display
        3. Load
        4. Save
        5. Quit
        What would you like to do?
        """);
            int userInput = Console.Read();
            if (userInput == 1)
            {
                //create object for Entry class
                Entry entry = new Entry();

                //get random prompt
                string entryPrompt = prompt.GetRandomPrompt();
                //display random prompt
                Console.WriteLine(entryPrompt);

                //get user entry
                string entryFromUser = Console.ReadLine();
                //get date
                string dateEntry = DateTime.Now.ToString("MMMM dd, yyyy");

                //save entryPrompt string to Entry class _promptEntry variable
                entry._promptEntry = entryPrompt;
                //save userFromEntry string to Entry class _entryText variable
                entry._entryText = entryFromUser;
                //save dateEntry string to Entry class _date variable
                entry._date = dateEntry;

                //save the prompt of the user to _entryText
                journal.AddEntry(entry);
            }
            else if (userInput == 2)
            {
                journal.DisplayAll();
            }
            else if (userInput == 3)
            {

            }
            else if (userInput == 4)
            {
                Console.Write("What is the file name: ");
                string filename = Console.ReadLine();
                
            }
        }
    }
}