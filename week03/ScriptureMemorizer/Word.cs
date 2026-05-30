using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (!_isHidden) return _text;

        if (string.IsNullOrEmpty(_text)) return _text;

        int end = _text.Length - 1;
        while (end >= 0 && !Char.IsLetterOrDigit(_text[end])) end--;
        int coreLength = end + 1;
        if (coreLength <= 0) return _text;

        string core = _text.Substring(0, coreLength);
        string punctuation = _text.Substring(coreLength);
        string mask = new string('_', core.Length);
        return mask + punctuation;
    }
}