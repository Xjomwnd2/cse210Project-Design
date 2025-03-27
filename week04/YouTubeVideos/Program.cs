using System;
using System.Collections.Generic;

class Video
{
    public string Title { get; }
    public string Channel { get; }
    public int Duration { get; } // in seconds
    private int views;
    private int likes;
    private List<string> comments;

    public Video(string title, string channel, int duration)
    {
        Title = title;
        Channel = channel;
        Duration = duration;
        views = 0;
        likes = 0;
        comments = new List<string>();
    }

    public void Play()
    {
        views++;
        Console.WriteLine($"Playing: {Title} by {Channel}");
    }

    public void Like()
    {
        likes++;
        Console.WriteLine($"Liked {Title}!");
    }

    public void AddComment(string comment)
    {
        comments.Add(comment);
        Console.WriteLine("Comment added.");
    }

    public void ShowDetails()
    {
        Console.WriteLine($"\nTitle: {Title}");
        Console.WriteLine($"Channel: {Channel}");
        Console.WriteLine($"Duration: {Duration} seconds");
        Console.WriteLine($"Views: {views}, Likes: {likes}");
        Console.WriteLine("Comments:");
        foreach (string comment in comments)
        {
            Console.WriteLine($"- {comment}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.\n");

        Video video1 = new Video("C# Tutorial for Beginners", "Tech Academy", 600);
        Video video2 = new Video("How to Cook Pasta", "Food Lovers", 300);

        video1.Play();
        video1.Like();
        video1.AddComment("Great tutorial!");
        video1.ShowDetails();

        video2.Play();
        video2.Like();
        video2.Like();
        video2.AddComment("Looks delicious!");
        video2.ShowDetails();
    }
}
