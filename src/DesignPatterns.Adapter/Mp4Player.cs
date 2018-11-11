using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Adapter
{
    public class Mp4Player:IAdvancedMediaPlayer
    {
        public void PlayVlc(string fileNmae)
        {
        }

        public void PlayMp4(string fileNmae)
        {
            Console.WriteLine($"Playing mp4 file.Name:{fileNmae}");
        }
    }
}
