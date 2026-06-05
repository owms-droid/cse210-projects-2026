using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Homework Project.");

        // Create an instance of the Assignment class
        Assignment assignment = new Assignment("Alice Wornder", "C# Programming");
        Console.WriteLine(assignment.GetSummary());

        // Create an instance of the MathAssignment class
        MathAssignment mathAssignment = new MathAssignment("Bob Smith", "Algebra", "Section 2.3", "Problems 1-10");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        // Create an instance of the WrittingAssignment class
        WrittingAssignment writtingAssignment = new WrittingAssignment("Charlie Brown", "Literature", "The Great Gatsby");
        Console.WriteLine(writtingAssignment.GetSummary());
        Console.WriteLine(writtingAssignment.GetWrittingInformation());
    }
}