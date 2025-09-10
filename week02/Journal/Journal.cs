public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public string SaveToFile(string fileName)
    {
        return "";
    }

    public string LoadFromFile(string fileName)
    {
        return "";
    }
}