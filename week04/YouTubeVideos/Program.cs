using System;
using System.Collections.Generic;

class Channel
{
    public string Name { get; }
    private int subscribers;
    private List<Video> uploadedVideos;

    public Channel(string name)
    {
        Name = name;
        subscribers = 0;
        uploadedVideos = new List<Video>();
    }

    public void Subscribe()
    {
        subscribers++;
        Console.WriteLine($"Subscribed to {Name}! Total subscribers: {subscribers}");
    }

    public void UploadVideo(Video video)
    {
        uploadedVideos.Add(video);
        Console.WriteLine($"New video uploaded: {video.Title} on {Name}");
    }

    public List<Video> GetVideos()
    {
        return uploadedVideos;
    }
}

class Video
{
    public string Title { get; }
    public Channel Channel { get; }
    public int Duration { get; } // in seconds
    private int views;
    private int likes;
    private List<string> comments;

    public Video(string title, Channel channel, int duration)
    {
        Title = title;
        Channel = channel;
        Duration = duration;
        views = 0;
        likes = 0;
        comments = new List<string>();

        // Automatically upload video to channel
        channel.UploadVideo(this);
    }

    public void Play()
    {
        views++;
        Console.WriteLine($"Playing: {Title} by {Channel.Name} ({Duration} sec) - Views: {views}");
    }

    public void Like()
    {
        likes++;
        Console.WriteLine($"Liked {Title}! Total likes: {likes}");
    }

    public void AddComment(string comment)
    {
        comments.Add(comment);
        Console.WriteLine("Comment added.");
    }

    public void ShowDetails()
    {
        Console.WriteLine($"\nTitle: {Title}");
        Console.WriteLine($"Channel: {Channel.Name}");
        Console.WriteLine($"Duration: {Duration} sec");
        Console.WriteLine($"Views: {views}, Likes: {likes}");
        Console.WriteLine("Comments:");
        foreach (string comment in comments)
        {
            Console.WriteLine($"- {comment}");
        }
    }
}

class Playlist
{
    public string Name { get; }
    private List<Video> videos;

    public Playlist(string name)
    {
        Name = name;
        videos = new List<Video>();
    }

    public void AddVideo(Video video)
    {
        videos.Add(video);
        Console.WriteLine($"Added {video.Title} to playlist {Name}");
    }

    public void ShowPlaylist()
    {
        Console.WriteLine($"\nPlaylist: {Name}");
        foreach (var video in videos)
        {
            Console.WriteLine($"- {video.Title} ({video.Channel.Name})");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Enhanced YouTubeVideos Project.\n");

        // Create channels
        Channel techChannel = new Channel("Tech Academy");
        Channel foodChannel = new Channel("Food Lovers");

        // Subscribe to channels
        techChannel.Subscribe();
        foodChannel.Subscribe();

        // Create and play videos
        Video video1 = new Video("C# Tutorial for Beginners", techChannel, 600);
        Video video2 = new Video("How to Cook Pasta", foodChannel, 300);

        video1.Play();
        video1.Like();
        video1.AddComment("Great tutorial!");
        video1.ShowDetails();

        video2.Play();
        video2.Like();
        video2.Like();
        video2.AddComment("Looks delicious!");
        video2.ShowDetails();

        // Create a playlist
        Playlist myPlaylist = new Playlist("My Favorite Videos");
        myPlaylist.AddVideo(video1);
        myPlaylist.AddVideo(video2);
        myPlaylist.ShowPlaylist();
    }
}
