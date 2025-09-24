using System;
using System.IO;
using System.Collections.Generic;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries are found.\n");
            return;
        }
        foreach (Entry entry in _entries)
            {
                entry.Display();
            }
    }
    public void ClearAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Journal is already empty.'\n");
            return;
        }
        _entries.Clear();
        Console.WriteLine("All entries have been deleted.\n");
    }

    public void LoadFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.\n");
            return;
        }
        _entries.Clear();
        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            Entry entry = Entry.FromFileFormat(line);
            if (entry != null)
            {
                _entries.Add(entry);
            }
        }
        Console.WriteLine("Journal loaded successfully.\n");
    }
    public void SaveToFile(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry e in _entries)
            {
                outputFile.WriteLine(e.ToFileFormat());
            }
        }

    }

    
}