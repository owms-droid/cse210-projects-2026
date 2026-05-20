using System;

public class Entry
{
    public string _date; //Saved date information in the journal entry.
    public string _promptText;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine($"\nDate: {_date}\nPrompt: {_promptText}\nResponse: {_entryText}\n");
    }
}