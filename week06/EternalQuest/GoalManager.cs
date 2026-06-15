using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private const string FILENAME = "goals.txt";

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        LoadGoals();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n========== ETERNAL QUEST ==========");
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Display Goals");
            Console.WriteLine("2. Create New Goal");
            Console.WriteLine("3. Record Goal Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Quit");
            Console.Write("\nSelect a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListGoalDetails();
                    break;
                case "2":
                    CreateGoal();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    SaveGoals();
                    Console.WriteLine("Goals saved successfully!");
                    break;
                case "5":
                    Console.WriteLine("Thank you for using Eternal Quest!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYour Score: {_score}");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals yet. Create one to get started!");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            string status = goal.IsComplete() ? "[X]" : "[ ]";

            if (goal is ChecklistGoal checklistGoal)
            {
                Console.WriteLine($"{i + 1}. {status} {goal.GetShortName()} (Completed {checklistGoal.GetAmountCompleted()}/{checklistGoal.GetTarget()} times)");
            }
            else
            {
                Console.WriteLine($"{i + 1}. {status} {goal.GetShortName()}");
            }
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals yet. Create one to get started!");
            return;
        }

        Console.WriteLine("\n========== GOAL DETAILS ==========");
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            string status = goal.IsComplete() ? "[X]" : "[ ]";

            Console.WriteLine($"\n{i + 1}. {status} {goal.GetShortName()}");
            Console.WriteLine($"   Description: {goal.GetDescription()}");
            Console.WriteLine($"   Points: {goal.GetPoints()}");

            if (goal is ChecklistGoal checklistGoal)
            {
                Console.WriteLine($"   Progress: {checklistGoal.GetAmountCompleted()}/{checklistGoal.GetTarget()} completed");
            }
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\n========== CREATE NEW GOAL ==========");
        Console.WriteLine("What type of goal would you like to create?");
        Console.WriteLine("1. Simple Goal (one-time completion)");
        Console.WriteLine("2. Eternal Goal (repeats forever)");
        Console.WriteLine("3. Checklist Goal (multiple completions required)");
        Console.Write("Select goal type (1-3): ");

        string type = Console.ReadLine();

        Console.Write("Enter short name: ");
        string name = Console.ReadLine();

        Console.Write("Enter description: ");
        string description = Console.ReadLine();

        Console.Write("Enter points for this goal: ");
        string points = Console.ReadLine();

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
            Console.WriteLine("Simple goal created!");
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
            Console.WriteLine("Eternal goal created!");
        }
        else if (type == "3")
        {
            Console.Write("Enter target number of completions: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Enter bonus points for completing target: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
            Console.WriteLine("Checklist goal created!");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals to record. Create a goal first!");
            return;
        }

        ListGoalNames();
        Console.Write("\nWhich goal did you accomplish? Enter number: ");

        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _goals.Count)
        {
            Goal goal = _goals[index - 1];
            int points = int.Parse(goal.GetPoints());

            goal.RecordEvent();
            _score += points;

            Console.WriteLine($"Congratulations! You've earned {points} points!");

            // Check for bonus points on checklist goals
            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                int bonus = checklistGoal.GetBonus();
                _score += bonus;
                Console.WriteLine($"Wow! You've completed the goal! You earn a bonus of {bonus} points!");
            }

            Console.WriteLine($"Total Score: {_score}");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void SaveGoals()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(FILENAME))
            {
                writer.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving goals: {e.Message}");
        }
    }

    public void LoadGoals()
    {
        try
        {
            if (!File.Exists(FILENAME))
            {
                return;
            }

            using (StreamReader reader = new StreamReader(FILENAME))
            {
                string line = reader.ReadLine();
                if (line != null)
                {
                    _score = int.Parse(line);
                }

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length > 0)
                    {
                        string goalType = parts[0];

                        if (goalType == "SimpleGoal")
                        {
                            // SimpleGoal|name|description|points|isComplete
                            bool isComplete = bool.Parse(parts[4]);
                            SimpleGoal goal = new SimpleGoal(parts[1], parts[2], parts[3]);
                            if (isComplete)
                            {
                                goal.RecordEvent();
                            }
                            _goals.Add(goal);
                        }
                        else if (goalType == "EternalGoal")
                        {
                            // EternalGoal|name|description|points
                            EternalGoal goal = new EternalGoal(parts[1], parts[2], parts[3]);
                            _goals.Add(goal);
                        }
                        else if (goalType == "ChecklistGoal")
                        {
                            // ChecklistGoal|name|description|points|amountCompleted|target|bonus
                            int amountCompleted = int.Parse(parts[4]);
                            int target = int.Parse(parts[5]);
                            int bonus = int.Parse(parts[6]);
                            ChecklistGoal goal = new ChecklistGoal(parts[1], parts[2], parts[3], target, bonus);

                            for (int i = 0; i < amountCompleted; i++)
                            {
                                goal.RecordEvent();
                            }

                            _goals.Add(goal);
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading goals: {e.Message}");
        }
    }
}