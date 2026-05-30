using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private static Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] splitText = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (var word in splitText)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        for (int i = 0; i < numberToHide; i++)
        {
            var available = new List<int>();
            for (int j = 0; j < _words.Count; j++)
            {
                if (!_words[j].IsHidden()) available.Add(j);
            }
            if (available.Count == 0) break;
            int pick = available[_random.Next(available.Count)];
            _words[pick].Hide();
        }
    }

    public void RevealRandomWords(int numberToReveal)
    {
        for (int i = 0; i < numberToReveal; i++)
        {
            var hidden = new List<int>();
            for (int j = 0; j < _words.Count; j++)
            {
                if (_words[j].IsHidden()) hidden.Add(j);
            }
            if (hidden.Count == 0) break;
            int pick = hidden[_random.Next(hidden.Count)];
            _words[pick].Show();
        }
    }

    public void Reset()
    {
        foreach (var w in _words) w.Show();
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + " ";
        foreach (var word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText.Trim();
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