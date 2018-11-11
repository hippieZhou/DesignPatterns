using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DesignPatterns.Adapter
{
    public class AudioPlayer:IMediaPlayer
    {
        private IMediaPlayer mediaAdapter;
        public void Play(AudioType audioType, string fileName)
        {
            switch (audioType)
            {
                case AudioType.MP3:
                    Console.WriteLine($"Playing mp3 file. Name:{fileName}");
                    break;
                case AudioType.VLC:
                case AudioType.MP4:
                    mediaAdapter = new MediaAdapter(audioType);
                    mediaAdapter.Play(audioType, fileName);
                    break;
                default:
                    Console.WriteLine($"Invalid media.{audioType} format not supported");
                    break;
            }
        }
    }
}
