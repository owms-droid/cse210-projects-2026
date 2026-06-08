using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breath.")
    {
    }

    public void Run()
    {
        GetDurationFromUser();
        DisplayStartingMessage();
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);

        int elapsedSeconds = 0;
        while (elapsedSeconds < _duration)
        {
            Console.WriteLine("Breathe in...");
            ShowcountDown(4);
            elapsedSeconds += 4;

            if (elapsedSeconds < _duration)
            {
                Console.WriteLine("Breathe out...");
                ShowcountDown(4);
                elapsedSeconds += 4;
            }
        }

        DisplayEndingMessage();
        ShowSpinner(3);
    }
}