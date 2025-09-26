using System.Collections.Generic;
using System.IO;
class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private static Random random = new Random();
    public int CountVisibleWords()
    {
        int count = 0;
        foreach (var word in _words)
        {
            if (!word.IsHidden())
            {
                count++;
            }
        }
        return count;
    }
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] parts = text.Split(" ");
        for (int i = 0; i < parts.Length; i++)
        {
            string wordText = parts[i];
            Word word = new Word(wordText);
            _words.Add(word);
        }
    }
    public void HideRandomWords(int count)
    {
        List<Word> visibleWords = new List<Word>();
        foreach (var word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }
        int toHide = Math.Min(count, visibleWords.Count);
        for (int i = 0; i < toHide; i++)
        {
            int pick = random.Next(visibleWords.Count);
            Word chosenWord = visibleWords[pick];
            chosenWord.Hide();
            visibleWords.RemoveAt(pick);
        }
    }
    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + " ";
        foreach (var word in _words)
        {
            result += word.GetDisplayText() + " ";
        }
        return result.Trim();
    }
    public bool IsCompletelyHidden()

    {
        foreach (var word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
    public void Reset()
    {
        foreach (var word in _words)
        {
            word.Show();
        }
    }
    public static Scripture LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
            throw new FileNotFoundException($"File {filename} not found.");
        string[] lines = File.ReadAllLines(filename);
        string book = lines[0].Replace("Book:", "").Trim();
        int chapter = int.Parse(lines[1].Replace("Chapter:", "").Trim());
        int verseStart = int.Parse(lines[2].Replace("VerseStart:", "").Trim());
        int verseEnd = int.Parse(lines[3].Replace("VerseEnd:", "").Trim());
        string text = lines[4].Replace("Text:", "").Trim();

        Reference reference = new Reference(book, chapter, verseStart, verseEnd);
        return new Scripture(reference, text);
    }
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"Book:{_reference.GetBook()}");
            writer.WriteLine($"Chapter:{_reference.GetChapter()}");
            writer.WriteLine($"VerseStart:{_reference.GetVerseStart()}");
            writer.WriteLine($"VerseEnd:{_reference.GetVerseEnd()}");

            List<string> originalWords = new List<string>();
            foreach (var word in _words)
            {
                originalWords.Add(word.GetOriginalText());
            }
            writer.WriteLine($"Text:{string.Join(" ", originalWords)}");
        }
    }
}