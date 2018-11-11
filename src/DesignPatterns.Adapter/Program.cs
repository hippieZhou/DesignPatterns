using System;

namespace DesignPatterns.Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            IMediaPlayer audioPlayer = new AudioPlayer();
            audioPlayer.Play(AudioType.MP3, "beyond the horizon.mp3");
            audioPlayer.Play(AudioType.MP4, "alone.mp4");
            audioPlayer.Play(AudioType.VLC, "far far away.vlc");
            audioPlayer.Play(AudioType.Unknown, "mind me.avi");

            Console.ReadKey();
        }
    }
}
