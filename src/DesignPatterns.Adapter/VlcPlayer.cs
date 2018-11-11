using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Adapter
{
    public class VlcPlayer:IAdvancedMediaPlayer
    {
        public void PlayVlc(string fileNmae)
        {
            Console.WriteLine($"Playing vlc file.Name:{fileNmae}");
        }

        public void PlayMp4(string fileNmae)
        {
        }
    }
}
