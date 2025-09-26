using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = null;
        Reference reference = null;
        bool running = true;
        while (running)
        {
            Console.WriteLine("Welcome to Scripture Memorize program.");
            Console.WriteLine("1: Insert Scripture");
            Console.WriteLine("2: Memorize Scripture");
            Console.WriteLine("3. Reset scripture");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Save");
            Console.WriteLine("Choose an option: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            string startVerse = "";
            string endVerse = "";
            string book = "";
            string chapter = "";
            string verses = "";
            string text = "";
            switch (choice)
            {
                case "1":
                    bool correct = true;
                    while (correct)
                    {
                        Console.Write("Book: ");
                        book = Console.ReadLine();
                        Console.Write("Chapter: ");
                        chapter = Console.ReadLine();
                        Console.Write("Verse/s: ");
                        bool validVerse = false;
                        while (!validVerse)
                        {
                            verses = Console.ReadLine();

                            if (verses.Contains("-"))
                            {
                                string[] verse = verses.Split("-");
                                if (verse.Length == 2 && !string.IsNullOrWhiteSpace(verse[0]) && !string.IsNullOrWhiteSpace(verse[1]))
                                {
                                    startVerse = verse[0].Trim();
                                    endVerse = verse[1].Trim();
                                }
                                else
                                {
                                    Console.WriteLine("Invalid verse range. Please enter in the format start-end (e.g., 5-7).");
                                    continue;
                                }
                            }
                            else
                            {
                                startVerse = verses.Trim();
                                endVerse = verses.Trim();
                            }
                            validVerse = true;
                        }
                        Console.Write($"Is this corect?\n{book} {chapter}:{verses}\n(Y/N): ");
                        string correctInput = Console.ReadLine();

                        if (correctInput.ToLower() == "y")
                        {
                            break;
                        }
                        else if (correctInput.ToLower() == "n")
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter 'Y' for yes or 'N' for no.");
                            continue;
                        }
                    }
                    reference = new Reference(book, int.Parse(chapter), int.Parse(startVerse), int.Parse(endVerse));
                    bool validText = false;
                    while (!validText)
                    {
                        Console.WriteLine("Enter the scripture text: ");
                        text = Console.ReadLine();
                        Console.WriteLine($"You entered: {reference.GetDisplayText()} - {text}");
                        Console.Write("Is this correct? (Y/N): ");
                        string confirmation = Console.ReadLine();
                        if (confirmation.ToLower() == "y")
                        {
                            scripture = new Scripture(reference, text);
                            validText = true;
                        }
                        else if (confirmation.ToLower() == "n")
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter 'Y' for yes or 'N' for no.");
                            continue;
                        }                        
                    }

                    break;
                case "2":
                    if (scripture == null)
                    {
                        Console.WriteLine("No scripture available. Please insert a scripture first.\n");
                        break;
                    }
                    while (!scripture.IsCompletelyHidden())
                    {
                        Console.Clear();
                        Console.WriteLine(scripture.GetDisplayText());
                        Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
                        string userInput = Console.ReadLine();
                        if (userInput.ToLower() == "quit")
                        {
                            break;
                        }

                        int visibleWordCount = scripture.CountVisibleWords();

                        if (visibleWordCount < 3)
                        {
                            scripture.HideRandomWords(visibleWordCount);
                            Console.Clear();
                            Console.WriteLine(scripture.GetDisplayText());
                            Console.WriteLine("\nAll words are now hidden.\n");
                            break;
                        }
                        else
                        {
                            scripture.HideRandomWords(3);
                        }
                    }
                    break;
                case "3":
                    if (scripture == null)
                    {
                        Console.WriteLine("No scripture available. Please insert a scripture first.\n");
                        break;
                    }
                    scripture.Reset();
                    Console.WriteLine("Scripture has been reset.\n");
                    break;
                case "4":
                    Console.Write("Enter filename to load (e.g., scripture.txt): ");
                    string loadFile = Console.ReadLine();
                    try
                    {
                        scripture = Scripture.LoadFromFile(loadFile);
                        Console.WriteLine("Scripture loaded successfully!\n");
                    }
                    catch (Exception ex)
                    { 
                        Console.WriteLine($"Error loading scripture: {ex.Message}\n");
                    }
                    break;
                case "5":
                    if(scripture == null)
                    {
                        Console.WriteLine("No scripture available. Please insert a scripture first.\n");
                        break;
                    }
                    Console.Write("Enter filename to save (e.g., scripture.txt): ");
                    string saveFile = Console.ReadLine();
                    try
                    {
                        scripture.SaveToFile(saveFile);
                        Console.WriteLine("Scripture saved successfully!\n");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error saving scripture: {ex.Message}\n");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again. \n");
                    break;
            }
        }
    }
}