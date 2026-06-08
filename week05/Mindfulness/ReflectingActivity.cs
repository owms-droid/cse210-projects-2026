using System;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    private int _promptIndex = 0;
    private int _questionIndex = 0;

    public ReflectingActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?"
        };
    }

    public void Run()
    {
        GetDurationFromUser();
        DisplayStartingMessage();
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);

        ShuffleList(_prompts);
        ShuffleList(_questions);
        _promptIndex = 0;
        _questionIndex = 0;

        DisplayPrompt();

        int elapsedSeconds = 0;
        while (elapsedSeconds < _duration)
        {
            DisplayQuestions();
            ShowSpinner(5);
            elapsedSeconds += 5;
        }

        DisplayEndingMessage();
        ShowSpinner(3);
    }

    public string GetRandomPrompt()
    {
        if (_promptIndex >= _prompts.Count)
        {
            ShuffleList(_prompts);
            _promptIndex = 0;
        }
        return _prompts[_promptIndex++];
    }

    public string GetRandomQuestion()
    {
        if (_questionIndex >= _questions.Count)
        {
            ShuffleList(_questions);
            _questionIndex = 0;
        }
        return _questions[_questionIndex++];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine(GetRandomPrompt());
    }

    public void DisplayQuestions()
    {
        Console.WriteLine(GetRandomQuestion());
    }

    private void ShuffleList(List<string> list)
    {
        Random random = new Random();
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = random.Next(i + 1);
            string temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}