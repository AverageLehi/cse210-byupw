using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Learn C# in 10 Minutes", "Code Academy", 600);
        Video video2 = new Video("Top 10 Programming Languages", "Tech Guru", 720);
        Video video3 = new Video("How to Stay Motivated", "Life Coach", 480);

        video1.AddComment(new Comment("Alice", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Bob", "Can you make one about Java?"));
        video1.AddComment(new Comment("Charlie", "This was exactly what I needed."));

        video2.AddComment(new Comment("David", "I love Python!"));
        video2.AddComment(new Comment("Eve", "C# is awesome too."));
        video2.AddComment(new Comment("Frank", "Thanks for the breakdown."));

        video3.AddComment(new Comment("Grace", "Great advice, thank you!"));
        video3.AddComment(new Comment("Hank", "Needed this today."));
        video3.AddComment(new Comment("Ivy", "Please make more motivational content."));

        List<Video> videos = new List<Video> { video1, video2, video3 };
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}