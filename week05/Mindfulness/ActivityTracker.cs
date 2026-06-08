using System;

public class ActivityTracker
{
    private int totalBreathingTime;
    private int totalReflexionTime;
    private int totalListingtime;

    public void Addtime(string activityType, int time)
    {
        switch (activityType)
        {
            case "Breathing":
                totalBreathingTime += time;
                break;
            case "Reflexion":
                totalReflexionTime += time;
                break;
            case "Listing":
                totalListingtime += time;
                break;
        }
    }

    public void ShowTotalTime()
    {
        Console.WriteLine($"\nTotal time spent on activities:");
        Console.WriteLine($"Breathing Activity: {totalBreathingTime} seconds");
        Console.WriteLine($"Reflexion Activity: {totalReflexionTime} seconds");
        Console.WriteLine($"Listing Activity: {totalListingtime} seconds\n");
    }
}