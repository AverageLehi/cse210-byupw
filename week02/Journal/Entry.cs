public class Entry
{
    public string _date;
    public string _promptEntry;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"\nDate: {_date} - Prompt: {_promptEntry}\n{_entryText}\n");
    }
}