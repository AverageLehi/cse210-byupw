public class Entry
{
    private string _date;
    private string _promptEntry;
    private string _entryText;

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptEntry = promptText;
        _entryText = entryText;
    }
    public void Display()
    {
        Console.WriteLine($"\nDate: {_date} - Prompt: {_promptEntry}\n{_entryText}\n");
    }
    public string ToFileFormat()
    {
        return $"{_date} | {_promptEntry} | {_entryText}";
    }

    public static Entry FromFileFormat(string line)
    {
        if (string.IsNullOrWhiteSpace(line)) return null;
        string[] parts = line.Split('|');
        if (parts.Length < 3) return null;
        return new Entry(parts[0], parts[1], parts[2]);
    }
}