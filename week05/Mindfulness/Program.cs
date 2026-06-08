using System;

class Program
{
    static void Main(string[] args)
    {
        ActivityTracker tracker = new ActivityTracker();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nMindfulness Activities:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflexion Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select an activity (1-4): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    tracker.Addtime("Breathing", breathingActivity.GetDuration());
                    break;

                case "2":
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.Run();
                    tracker.Addtime("Reflexion", reflectingActivity.GetDuration());
                    break;

                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    tracker.Addtime("Listing", listingActivity.GetDuration());
                    break;

                case "4":
                    tracker.ShowTotalTime();
                    running = false;
                    Console.WriteLine("Thank you for using the Mindfulness Activities. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }
    }
}