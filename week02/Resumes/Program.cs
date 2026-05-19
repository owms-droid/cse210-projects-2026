using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Resumes Project.");

        Job job1 = new Job();
        job1._company = "BYU-Idaho";
        job1._jobTitle = "Student";
        job1._startYear = 2022;
        job1._endYear = 2026;

        Job job2 = new Job();
        job2._company = "Amazon";
        job2._jobTitle = "Software Engineer";
        job2._startYear = 2026;
        job2._endYear = 2030;

        Resume myResume = new Resume();
        myResume._name = "Allison Rose";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();

    }
}