using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new RunningActivity("03 Nov 2022", 30, 4.8));
        activities.Add(new CyclingActivity("04 Nov 2022", 45, 20));
        activities.Add(new SwimmingActivity("05 Nov 2022", 40, 40));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }

}