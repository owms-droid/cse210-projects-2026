using System;

public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void GetDurationFromUser()
    {
        Console.Write("Enter the duration of the activity in seconds: ");
        int duration;
        while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.Write("Please enter a valid positive integer for the duration: ");
        }
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        //need to improve or check again
        Console.WriteLine($"Starting {_name} for {_duration} seconds.");
        Console.WriteLine(_description);
    }

    public void DisplayEndingMessage()
    {
        //need to improve or check again
        Console.WriteLine($"Finished {_name}.");
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            //just verify if it works or not
            Console.Write("|");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b/");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b-");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b\\");
            System.Threading.Thread.Sleep(250);
            Console.Write("\b");
        }
    }

    public void ShowcountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            System.Threading.Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}