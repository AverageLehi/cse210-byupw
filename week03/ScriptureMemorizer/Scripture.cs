using System.Collections.Generic;
class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private static Random random = new Random();
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
}