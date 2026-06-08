using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private string _count;
    private List<string> _prompts;

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by prompting you to list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        GetDurationFromUser();
        DisplayStartingMessage();
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);

        GetRandomPrompt();
        Console.WriteLine("Begin listing...");
        ShowcountDown(3);

        List<string> userList = GetListFromUser(_duration);
        Console.WriteLine($"You listed {userList.Count} items!");
        DisplayEndingMessage();
        ShowSpinner(3);
    }

    public void GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        Console.WriteLine(_prompts[index]);
    }

    public List<string> GetListFromUser(int durationSeconds)
    {
        List<string> userList = new List<string>();
        Console.WriteLine("Enter your items (type 'done' to finish):");

        DateTime startTime = DateTime.Now;
        while (true)
        {
            TimeSpan elapsed = DateTime.Now - startTime;

            if (elapsed.TotalSeconds >= durationSeconds)
            {
                break;
            }

            string input = Console.ReadLine();
            if (input.ToLower() == "done")
            {
                break;
            }
            userList.Add(input);
        }
        return userList;
    }
}