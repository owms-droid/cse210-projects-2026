using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video(
            "Learn C# in 30 Minutes",
            "CodeMaster",
            1800);

        video1.AddComment(
            new Comment("Alice", "Great explanation!"));

        video1.AddComment(
            new Comment("Bob", "Very helpful tutorial."));

        video1.AddComment(
            new Comment("Charlie", "Thanks for sharing."));

        videos.Add(video1);

        // Video 2
        Video video2 = new Video(
            "Top 10 Programming Tips",
            "DevWorld",
            900);

        video2.AddComment(
            new Comment("Diana", "Awesome tips!"));

        video2.AddComment(
            new Comment("Edward", "I learned a lot."));

        video2.AddComment(
            new Comment("Frank", "Please make more videos."));

        videos.Add(video2);

        // Video 3
        Video video3 = new Video(
            "How to Build a Website",
            "WebGuru",
            2400);

        video3.AddComment(
            new Comment("Grace", "Excellent content."));

        video3.AddComment(
            new Comment("Henry", "Very clear instructions."));

        video3.AddComment(
            new Comment("Isabel", "Exactly what I needed."));

        videos.Add(video3);

        // Video 4
        Video video4 = new Video(
            "Understanding Databases",
            "TechAcademy",
            1500);

        video4.AddComment(
            new Comment("Jack", "Best database video!"));

        video4.AddComment(
            new Comment("Karen", "Well organized lesson."));

        video4.AddComment(
            new Comment("Leo", "Helped me with my homework."));

        videos.Add(video4);

        // Display videos and comments
        foreach (Video video in videos)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");

            Console.WriteLine("\nComment List:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine(
                    $"{comment.GetCommenterName()}: {comment.GetCommentText()}");
            }

            Console.WriteLine();
        }
    }
}